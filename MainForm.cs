using GraphRedaktor.Models;
using GraphRedaktor.Models.MyEventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphRedaktor
{
    public interface IMainView
    {
        /// <summary>
        /// событие клика на каком то из пунктов/кнопок инструментов
        /// </summary>
        event EventHandler ToolStrip_ItemClicked;
        /// <summary>
        /// изменение цвета на панели инструментов в зависимости от выбранного
        /// </summary>
        /// <param name="color">цвет фона элемента</param>
        /// <param name="name">ключ имя элемента</param>
        void SetStripButtonColor(string name, Color color);
        /// <summary>
        /// нажатие мышки на панели рисования
        /// </summary>
        event EventHandler DrawPanelOnMouseDown;
        /// <summary>
        /// движение мышки на панели рисования
        /// </summary>
        event EventHandler DrawPanelOnMouseMove;
        /// <summary>
        /// отщелкивание мышки на панели рисования
        /// </summary>
        event EventHandler DrawPanelOnMouseUp;
        /// <summary>
        /// событие перерисовки панели для рисования
        /// </summary>
        event EventHandler DrawPanelOnPaint;
        /// <summary>
        /// нажатие на пункт меню
        /// </summary>
        event EventHandler OnMainMenuItemClicked;
        /// <summary>
        /// изменение размера панели для рисования
        /// </summary>
        event EventHandler PanelForDrawingSizeChanged;
        /// <summary>
        /// клик по пунктам меню группы модификации изображения
        /// </summary>
        event EventHandler ImageUpdatingMenuItemClicked;
        /// <summary>
        /// событие закрытия формы
        /// </summary>
        event EventHandler MainFormFormClosing;

        /// <summary>
        /// принудительная перерисовка панели рисования
        /// </summary>
        void InvalidateDrawPanel();
        /// <summary>
        /// установить видимость для элементов меню, которые будут отображать протекание какой либо долгосрочной операции
        /// </summary>
        /// <param name="isVisible">видимые?</param>
        void SetVisibilityOfOperationStatus(bool isVisible);
        /// <summary>
        /// потокобезопастное обновление данных долгой операции
        /// </summary>
        /// <param name="loea">данные для контролов</param>
        /// <param name="haveAccess">есть ли доступ к обновлению контрола у контрола, который пытается это сделать</param>
        public void TryToSetInformationToLongOperationFields(LongOperationEventArgs loea, bool objectHaveAccess);
        /// <summary>
        /// получить картинку области рисования 
        /// </summary>
        /// <returns>текущая картинка с области рисования</returns>
        public Bitmap GetBitmapForSaving();
        /// <summary>
        /// получить размер области для рисования
        /// </summary>
        /// <returns>размер области для рисования</returns>
        public Size? GetPanelSize();
        /// <summary>
        /// установить рисунок на панель для рисования
        /// </summary>
        /// <param name="image">рисунок</param>
        public void SetImageToPanelForDrawing(Bitmap image);
        /// <summary>
        /// очистка панели для рисования
        /// </summary>
        public void ClearPanelForDrawing();
        /// <summary>
        /// показать название текущей фигуры в строке состояния
        /// </summary>
        /// <param name="currentFigureName"></param>
        void SetCurrentFigureText(string currentFigureName);
        /// <summary>
        /// отобразить координаты мыши в строке состояния
        /// </summary>
        /// <param name="e"></param>
        public void UpdateMouseCoords(MouseEventArgs e);
        /// <summary>
        /// используется ли прогресс бар каким либо объектом для отображения обновления данных
        /// </summary>
        bool IsProgressBarUsing { get; set; }

    }
    public partial class MainForm : Form, IMainView
    {
        private bool _isProgressBarUsing;
        public bool IsProgressBarUsing { get => _isProgressBarUsing; set => _isProgressBarUsing=value; }

        public MainForm()
        {
            InitializeComponent();
            SetVisibilityOfOperationStatus(false);
            _isProgressBarUsing = false;
        }        
        public void SetVisibilityOfOperationStatus(bool isVisible)
        {
            toolStripStatusLabelOperation.Visible = isVisible;
            toolStripProgressBarOperation.Visible = isVisible;
        }

        private delegate void SafeCallDelegate(LongOperationEventArgs loea, bool objectHaveAccess);
        public void TryToSetInformationToLongOperationFields(LongOperationEventArgs loea, bool objectHaveAccess)
        {
            if (!objectHaveAccess)
                return;

            if (toolStripProgressBarOperation.Control.InvokeRequired)
            {
                var d = new SafeCallDelegate(TryToSetInformationToLongOperationFields);
                toolStripProgressBarOperation.Control.Invoke(d, new object[] { loea, objectHaveAccess });
            }
            else
            {
                toolStripProgressBarOperation.Value = loea.ArgumentInt;
            }

            toolStripStatusLabelOperation.Text = loea.ArgumentString;
        }

        public event EventHandler ToolStrip_ItemClicked;
        public event EventHandler DrawPanelOnMouseDown;
        public event EventHandler DrawPanelOnMouseMove;
        public event EventHandler DrawPanelOnMouseUp;
        public event EventHandler DrawPanelOnPaint;
        public event EventHandler OnMainMenuItemClicked;
        public event EventHandler PanelForDrawingSizeChanged;
        public event EventHandler ImageUpdatingMenuItemClicked;
        public event EventHandler MainFormFormClosing;

        public void SetStripButtonColor(string name, Color color)
        {
            if (toolStrip1.Items == null)
                return;
            if (toolStrip1.Items.Count == 0)
                return;
            if (toolStrip1.Items[name] == null)
                return;

            toolStrip1.Items[name].BackColor = color;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (ToolStrip_ItemClicked != null)
                ToolStrip_ItemClicked.Invoke(sender, e);
        }

        private void panelForDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            if (DrawPanelOnMouseDown != null)
                DrawPanelOnMouseDown.Invoke(this, e);
        }

        private void panelForDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            if (DrawPanelOnMouseUp != null)
                DrawPanelOnMouseUp.Invoke(sender, e);
        }

        public void UpdateMouseCoords(MouseEventArgs e)
        {
            if (e == null)
                return;

            coordX.Text = string.Format("координата Х {0}", e.X);
            coordY.Text = string.Format("координата Y {0}", e.Y);
        }

        private void panelForDrawing_MouseMove(object sender, MouseEventArgs e)
        {        
            if (DrawPanelOnMouseMove != null)
                DrawPanelOnMouseMove.Invoke(sender, e);
        }
        /// <summary>
        /// принудительное обновление панели для рисования
        /// </summary>
        public void InvalidateDrawPanel()
        {
            panelForDrawing.Invalidate();
            panelForDrawing.Update();
        }

        private void panelForDrawing_Paint(object sender, PaintEventArgs e)
        {
            if (DrawPanelOnPaint != null)
                DrawPanelOnPaint.Invoke(this, e);
        }

        private void SaveImageMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SaveFileMenu.Close();
            if (OnMainMenuItemClicked != null)
                OnMainMenuItemClicked.Invoke(this, e);
        }

        public Bitmap GetBitmapForSaving()
        {
            if (panelForDrawing == null)
                return null;

            int width = panelForDrawing.Size.Width;
            int height = panelForDrawing.Size.Height;

            Bitmap tmpBitmap = new Bitmap(width, height);
            panelForDrawing.DrawToBitmap(tmpBitmap, new Rectangle(0, 0, width, height));

            return tmpBitmap;
        }
        public Size? GetPanelSize()
        {
            if (panelForDrawing == null)
                return null;
            if (panelForDrawing.ClientRectangle == null)
                return null;

            Size tmpSize = new Size(panelForDrawing.ClientRectangle.Width, panelForDrawing.ClientRectangle.Height);

            return tmpSize;
        }

        public void SetImageToPanelForDrawing(Bitmap image)
        {
            if (image == null)
                return;

            panelForDrawing.BackgroundImage = image; 
        }

        public void ClearPanelForDrawing()
        {
            using (Graphics tmpGraphics = panelForDrawing.CreateGraphics())
            {
                tmpGraphics.Clear(panelForDrawing.BackColor);
            }
            panelForDrawing.BackColor = toolStripButtonDrawPanelBackgroundColor.BackColor;
        }

        private void panelForDrawing_SizeChanged(object sender, EventArgs e)
        {
            if (PanelForDrawingSizeChanged != null)
                PanelForDrawingSizeChanged.Invoke(sender, new PaintEventArgs(panelForDrawing.CreateGraphics(), panelForDrawing.ClientRectangle));
        }

        private void ImageUpdatingMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(ImageUpdatingMenuItemClicked != null)
                ImageUpdatingMenuItemClicked.Invoke(sender,new ToolStripAndPaintEventArgs(e, new PaintEventArgs(panelForDrawing.CreateGraphics(), panelForDrawing.ClientRectangle)));
        }

        public void SetCurrentFigureText(string currentFigureName)
        {
            toolStripStatusLabelFigure.Text = string.Format("Текущая фигура: {0}", currentFigureName);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainFormFormClosing != null)
                MainFormFormClosing.Invoke(this, null);
        }
    }
}
