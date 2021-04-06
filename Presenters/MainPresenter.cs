using GraphRedaktor.Models;
using GraphRedaktor.Models.Figures;
using GraphRedaktor.Models.Handlers;
using GraphRedaktor.Models.Interfaces;
using GraphRedaktor.Models.MyEventArgs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphRedaktor.Presenters
{
	public class MainPresenter
	{
		/// <summary>
		/// основное представление
		/// </summary>
		private IMainView _mainView;
		/// <summary>
		/// обработчик файлов
		/// </summary>
		private IFileHandler _fileHandler;
		/// <summary>
		/// обработчик картинок
		/// </summary>
		private IImageHandler _imageHandler;
		/// <summary>
		/// массив инструментов
		/// </summary>
		private Dictionary<string, SimpleFigure> _figures;
		/// <summary>
		/// массив текущих цветов
		/// </summary>
		private Dictionary<string, Color> _colors;
		/// <summary>
		/// делегат для пустых по параметрам функций
		/// </summary>
		private  delegate void EmptyDelegateHandler();
		/// <summary>
		/// массив выполняемых действий по нажатию на пункт меню связанных с файлом
		/// </summary>
		private Dictionary<string, EmptyDelegateHandler> _actionsFileModifications;
		/// <summary>
		/// массив выполняемых действий по нажатию на пункт меню связанных с изображением
		/// </summary>
		private Dictionary<string, EventHandler> _actionsImageModifications;

		/// <summary>
		/// рисуем ли мы в текущий момент
		/// </summary>
		private bool _isDrawing;

		/// <summary>
		/// текущая картинка с панели рисования
		/// </summary>
		Bitmap snapshot;
		/// <summary>
		/// временная картинка с панели рисования
		/// </summary>
		Bitmap tempDraw;

		/// <summary>
		/// текущая фигура для рисования
		/// </summary>
		private SimpleFigure _currentFigure;
		/// <summary>
		/// сохранен ли рисунок
		/// </summary>
		private bool _isImageSaved;
		/// <summary>
		/// происходит ли на данный момент долгая фоновая операция
		/// </summary>
		private bool _isLongOperationGoing;

		/// <summary>
		/// добавление объектов фигур в общий массив
		/// </summary>
		/// <param name="key">ключ - имя кнопки</param>
		/// <param name="customObject">объект добавления</param>
		private void TryAddObjectToDict<T>(string key, T customObject, ref Dictionary<string, T> curDict)
        {
			if (curDict == null)
				return;

			if (!curDict.TryAdd(key, customObject))
				curDict.Add(key, customObject);

		}
		/// <summary>
		/// получение и сохранение размера холста
		/// </summary>
		private void GetSnapshotSize()
		{
			Size? tmpSize = _mainView.GetPanelSize();
			if (tmpSize != null)
				snapshot = new Bitmap(tmpSize.Value.Width, tmpSize.Value.Height);
			else
				MessageSender.SendErrorMessage("Объект панели для рисования не был получен. Программа будет работать некорректно.");
		}
		/// <summary>
		/// инициализация обработчика объекта
		/// </summary>
		/// <param name="outerHandler">обработчик, который к нам приходит</param>
		/// <param name="message">диагностическое сообщение</param>
		/// <returns></returns>
		private IInfoMessageInterface InitializeHandler(IInfoMessageInterface outerHandler, string message)
		{
			if (outerHandler != null)
			{
				outerHandler.OnErrorMessageSend += _handler_OnMessageSend;
				outerHandler.OnDataForLongOperationSend += _handler_OnDataForLongOperationSend;
				return outerHandler;
			}
			else
			{
				MessageSender.SendErrorMessage(string.Format("Объект обработчика {0} не был получен. Программа будет работать некорректно.", message));
				return null;
			}
		}
		public MainPresenter(IMainView view, IFileHandler fileHandler, IImageHandler imageHandler)
        {
            if (view != null)
            {
                _mainView = view;
                _isDrawing = false;
                _isImageSaved = true;
				_isLongOperationGoing = false;

                _figures = new Dictionary<string, SimpleFigure>();
                TryAddObjectToDict("toolStripRectangleButton", new FigureRectangle(), ref _figures);
                TryAddObjectToDict("toolStripFillRectangleButton", new FigureFillRectangle(), ref _figures);
                TryAddObjectToDict("toolStripPencilButton", new FigurePencil(), ref _figures);
                TryAddObjectToDict("toolStripLineButton", new FigureLine(), ref _figures);
                TryAddObjectToDict("toolStripCircleButton", new FigureCircle(), ref _figures);
                TryAddObjectToDict("toolStripFillCircleButton", new FigureFillCircle(), ref _figures);

                _colors = new Dictionary<string, Color>();
                TryAddObjectToDict("toolStripButtonFigureColor", Color.Black, ref _colors);
                _mainView.SetStripButtonColor("toolStripButtonFigureColor", _colors["toolStripButtonFigureColor"]);
                TryAddObjectToDict("toolStripButtonFigureFillColor", Color.Red, ref _colors);
                _mainView.SetStripButtonColor("toolStripButtonFigureFillColor", _colors["toolStripButtonFigureFillColor"]);
                TryAddObjectToDict("toolStripButtonDrawPanelBackgroundColor", Color.White, ref _colors);
                _mainView.SetStripButtonColor("toolStripButtonDrawPanelBackgroundColor", _colors["toolStripButtonDrawPanelBackgroundColor"]);

                _actionsFileModifications = new Dictionary<string, EmptyDelegateHandler>();
                TryAddObjectToDict("SaveImage", new EmptyDelegateHandler(SaveFileImage), ref _actionsFileModifications);
                TryAddObjectToDict("LoadImage", new EmptyDelegateHandler(LoadFileImage), ref _actionsFileModifications);

				_actionsImageModifications = new Dictionary<string, EventHandler>();
				TryAddObjectToDict("ImageInversion", new EventHandler(ImageInversion), ref _actionsImageModifications);

                _currentFigure = null;

                _mainView.ToolStrip_ItemClicked += _mainView_ToolStrip_ItemClicked;
                _mainView.DrawPanelOnMouseDown += _mainView_DrawPanelOnMouseDown;
                _mainView.DrawPanelOnMouseMove += _mainView_DrawPanelOnMouseMove;
                _mainView.DrawPanelOnMouseUp += _mainView_DrawPanelOnMouseUp;
                _mainView.DrawPanelOnPaint += _mainView_DrawPanelOnPaint;
                _mainView.OnMainMenuItemClicked += _mainView_OnMainMenuItemClicked;
                _mainView.PanelForDrawingSizeChanged += _mainView_PanelForDrawingSizeChanged;
                _mainView.ImageUpdatingMenuItemClicked += _mainView_ImageUpdatingMenuItemClicked;
                _mainView.MainFormFormClosing += _mainView_MainFormFormClosing;

                GetSnapshotSize();
            }
            else
                MessageSender.SendErrorMessage("Объект главного представления не был получен. Программа будет работать некорректно.");

			_fileHandler = InitializeHandler(fileHandler, "файла") as IFileHandler;
			_imageHandler = InitializeHandler(imageHandler, "изображения") as IImageHandler;
        }

        private void _mainView_MainFormFormClosing(object sender, EventArgs e)
        {
			_mainView.ToolStrip_ItemClicked -= _mainView_ToolStrip_ItemClicked;
			_mainView.DrawPanelOnMouseDown -= _mainView_DrawPanelOnMouseDown;
			_mainView.DrawPanelOnMouseMove -= _mainView_DrawPanelOnMouseMove;
			_mainView.DrawPanelOnMouseUp -= _mainView_DrawPanelOnMouseUp;
			_mainView.DrawPanelOnPaint -= _mainView_DrawPanelOnPaint;
			_mainView.OnMainMenuItemClicked -= _mainView_OnMainMenuItemClicked;
			_mainView.PanelForDrawingSizeChanged -= _mainView_PanelForDrawingSizeChanged;
			_mainView.ImageUpdatingMenuItemClicked -= _mainView_ImageUpdatingMenuItemClicked;
			_mainView.MainFormFormClosing -= _mainView_MainFormFormClosing;
			if(_fileHandler != null)
            {
				_fileHandler.OnErrorMessageSend -= _handler_OnMessageSend;
				_fileHandler.OnDataForLongOperationSend -= _handler_OnDataForLongOperationSend;
			}
			if(_imageHandler != null)
            {
				_imageHandler.OnErrorMessageSend -= _handler_OnMessageSend;
				_imageHandler.OnDataForLongOperationSend -= _handler_OnDataForLongOperationSend;
			}				
		}

        private void _mainView_ImageUpdatingMenuItemClicked(object sender, EventArgs e)
        {
			ToolStripAndPaintEventArgs tsapea = e as ToolStripAndPaintEventArgs;
			if (tsapea == null)
				return;

			EventHandler tmpHandler;
			if (_actionsImageModifications.TryGetValue(tsapea.ArgumentToolStripItemClicked.ClickedItem.Name, out tmpHandler))
				tmpHandler.Invoke(sender, tsapea.ArgumentPaint);
		}

        /// <summary>
        /// изменение размеров холста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _mainView_PanelForDrawingSizeChanged(object sender, EventArgs e)
        {
			PaintEventArgs pea = e as PaintEventArgs;
			if (pea == null)
				return;

			tempDraw = (Bitmap)snapshot.Clone();
			GetSnapshotSize();
			
			pea.Graphics.DrawImageUnscaled(tempDraw, 0, 0);

			using (Graphics g = Graphics.FromImage(snapshot))
			{
				g.DrawImage(tempDraw, new Point(0, 0));
			}
		}

        private void _handler_OnDataForLongOperationSend(object sender, EventArgs e)
        {
			LongOperationEventArgs loea = e as LongOperationEventArgs;
			if (loea == null)
				return;

			_mainView.TryToSetInformationToLongOperationFields(loea, (sender as BaseHandler).HaveAccessToProgressBar);
		}

		private async void ImageInversion(object sender, EventArgs e)
        {
			if (_imageHandler == null)
				return;

			PaintEventArgs pea = e as PaintEventArgs;
			if (pea == null)
				return;
			_isLongOperationGoing = true;

			Bitmap tmpBitmap = _mainView.GetBitmapForSaving();					

			if (!_mainView.IsProgressBarUsing)
			{
				_mainView.SetVisibilityOfOperationStatus(true);
				SetAccessToProgressBar(true, _imageHandler as BaseHandler);
			}
            await Task.Run(() => _imageHandler.InvertBitmap(tmpBitmap));
			if (_mainView.IsProgressBarUsing && (_imageHandler as BaseHandler).HaveAccessToProgressBar == true)
			{
				SetAccessToProgressBar(false, _imageHandler as BaseHandler);
				_mainView.SetVisibilityOfOperationStatus(false);
			}

			pea.Graphics.DrawImageUnscaled(tmpBitmap, 0, 0);

			using (Graphics g = Graphics.FromImage(snapshot))
			{
				g.DrawImage(tmpBitmap, new Point(0, 0));
			}
			_isLongOperationGoing = false;
		}

        private void SetAccessToProgressBar(bool access, BaseHandler handler)
        {
            _mainView.IsProgressBarUsing = access;
			handler.HaveAccessToProgressBar = access;
        }

        private async void SaveFileImage()
        {
			if (_fileHandler == null || _mainView == null)
				return;

			Bitmap tmpBitmap = _mainView.GetBitmapForSaving();
			if (tmpBitmap == null)
				return;

			_isLongOperationGoing = true;

			string filePath = _fileHandler.GetFiePathForSaving();

			if (!_mainView.IsProgressBarUsing)
			{
				_mainView.SetVisibilityOfOperationStatus(true);
				SetAccessToProgressBar(true, _fileHandler as BaseHandler);
			}
			await Task.Run(() => _fileHandler.SaveFile(tmpBitmap, filePath));
			if (_mainView.IsProgressBarUsing && (_fileHandler as BaseHandler).HaveAccessToProgressBar == true)
			{
				SetAccessToProgressBar(false, _fileHandler as BaseHandler);
				_mainView.SetVisibilityOfOperationStatus(false);
			}

			_isImageSaved = true;
			_isLongOperationGoing = false;
		}
		private void LoadFileImage()
        {
			if (_fileHandler == null || _mainView == null)
				return;

			if (!_isImageSaved)
				if (MessageSender.SendQuestionMessage("Текущий рисунок не был сохранен. Хотите сохранить ?"))
				{
					SaveFileImage();
				}

			string filePath = _fileHandler.GetFiePathForLoading();
			if (filePath == "")
				return;							

			Bitmap tmpBitmap = _fileHandler.GetBitmapFromFile(filePath);
			if (tmpBitmap == null)
				return;
			
			_mainView.ClearPanelForDrawing();
			GetSnapshotSize();
			tempDraw = null;

			_mainView.SetImageToPanelForDrawing(tmpBitmap);
			_isImageSaved = true;
		}


		private void _mainView_OnMainMenuItemClicked(object sender, EventArgs e)
        {
			ToolStripItemClickedEventArgs tsicea = e as ToolStripItemClickedEventArgs;
			if (tsicea == null)
				return;			

			EmptyDelegateHandler tmpFigtmpHandler;
			if (_actionsFileModifications.TryGetValue(tsicea.ClickedItem.Name, out tmpFigtmpHandler))
				tmpFigtmpHandler.Invoke();
		}

        private void _handler_OnMessageSend(object sender, EventArgs e)
        {
			StringEventArgs sea = e as StringEventArgs;
			if (sea == null)
				return;

			MessageSender.SendErrorMessage(sea.ArgumentString);
        }

        private void _mainView_DrawPanelOnPaint	(object sender, EventArgs e)
        {
			PaintEventArgs pea = e as PaintEventArgs;
			if (pea == null)
				return;

			if (tempDraw == null)
				return;
			if (_currentFigure == null)
				return;

			tempDraw = (Bitmap)snapshot.Clone();

			_currentFigure.Draw(_colors["toolStripButtonFigureColor"], tempDraw, pea);
		}

        private void _mainView_DrawPanelOnMouseUp(object sender, EventArgs e)
        {
			_isDrawing = false;

			MouseEventArgs mea = e as MouseEventArgs;
			if (mea == null)
				return;

			if (snapshot == null || tempDraw == null)
				return;

			if (_isLongOperationGoing)
				return;

			snapshot = (Bitmap)tempDraw.Clone();
		}

        private void _mainView_DrawPanelOnMouseMove(object sender, EventArgs e)
        {
			MouseEventArgs mea = e as MouseEventArgs;
			if (mea == null)
				return;

			if (!_isDrawing)
				return;

			if (_isLongOperationGoing)
				return;

			_mainView.UpdateMouseCoords(mea);

			// чтобы не рисовать за пределами холста
			if (mea.Location.X > 0 && mea.Location.X<= snapshot.Width && mea.Location.Y > 0 && mea.Location.Y <= snapshot.Height)
				_currentFigure.EndPoint = mea.Location;

			_mainView.InvalidateDrawPanel();

			if (_currentFigure is FigurePencil)
			{
				_currentFigure.BeginPoint = mea.Location;
				snapshot = (Bitmap)tempDraw.Clone();
			}

			_isImageSaved = false;
		}

        private void _mainView_DrawPanelOnMouseDown(object sender, EventArgs e)
        {
            if(_currentFigure == null)
            {
				MessageSender.SendMessage("Сначала выберите фигуру для рисования");
				return;
            }

			MouseEventArgs mea = e as MouseEventArgs;
			if (mea == null)
				return;

			if (_isLongOperationGoing)
				return;

			_isDrawing = true;
			_currentFigure.BeginPoint = mea.Location;

			tempDraw = (Bitmap)snapshot.Clone();
		}

        private void _mainView_ToolStrip_ItemClicked(object sender, EventArgs e)
        {
			ToolStripItemClickedEventArgs tsicea = e as ToolStripItemClickedEventArgs;
			if (tsicea == null)
				return;

			SimpleFigure tmpFigure;
			if (_figures.TryGetValue(tsicea.ClickedItem.Name, out tmpFigure))
			{
				_currentFigure = tmpFigure;
				_currentFigure.BackgroundColor = _colors["toolStripButtonFigureFillColor"];
				_mainView.SetCurrentFigureText(_currentFigure.ToString());
			}
			else
			{
				Color tmpColor;
				if (_colors.TryGetValue(tsicea.ClickedItem.Name, out tmpColor))
				{
					ColorDialog colorDialog = new ColorDialog();
					if (colorDialog.ShowDialog() == DialogResult.OK)
					{
						_colors[tsicea.ClickedItem.Name] = colorDialog.Color;
						if (tsicea.ClickedItem.Name == "toolStripButtonFigureFillColor")
							_currentFigure.BackgroundColor = colorDialog.Color;
						_mainView.SetStripButtonColor(tsicea.ClickedItem.Name, colorDialog.Color);
					}
				}
			}
		}
    }
}
