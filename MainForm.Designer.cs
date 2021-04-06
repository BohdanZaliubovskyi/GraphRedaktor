
namespace GraphRedaktor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadImage = new System.Windows.Forms.ToolStripMenuItem();
            this.Image = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageUpdatingMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ImageInversion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripPencilButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLineButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripRectangleButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripFillRectangleButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripCircleButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripFillCircleButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFigureColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFigureFillColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDrawPanelBackgroundColor = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.coordX = new System.Windows.Forms.ToolStripStatusLabel();
            this.coordY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFigure = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelOperation = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarOperation = new System.Windows.Forms.ToolStripProgressBar();
            this.panelForDrawing = new GraphRedaktor.DoubleBufferedPanel();
            this.mainMenu.SuspendLayout();
            this.SaveFileMenu.SuspendLayout();
            this.ImageUpdatingMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Image});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1031, 28);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // File
            // 
            this.File.DropDown = this.SaveFileMenu;
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(59, 24);
            this.File.Text = "Файл";
            // 
            // SaveFileMenu
            // 
            this.SaveFileMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.SaveFileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveImage,
            this.LoadImage});
            this.SaveFileMenu.Name = "SaveImageMenu";
            this.SaveFileMenu.OwnerItem = this.File;
            this.SaveFileMenu.Size = new System.Drawing.Size(214, 52);
            this.SaveFileMenu.Text = "Сохранить рисунок";
            this.SaveFileMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.SaveImageMenu_ItemClicked);
            // 
            // SaveImage
            // 
            this.SaveImage.Name = "SaveImage";
            this.SaveImage.Size = new System.Drawing.Size(213, 24);
            this.SaveImage.Text = "Сохранить рисунок";
            // 
            // LoadImage
            // 
            this.LoadImage.Name = "LoadImage";
            this.LoadImage.Size = new System.Drawing.Size(213, 24);
            this.LoadImage.Text = "Загрузить рисунок";
            // 
            // Image
            // 
            this.Image.DropDown = this.ImageUpdatingMenu;
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(79, 24);
            this.Image.Text = "Рисунок";
            // 
            // ImageUpdatingMenu
            // 
            this.ImageUpdatingMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ImageUpdatingMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImageInversion});
            this.ImageUpdatingMenu.Name = "ImageUpdatingMenu";
            this.ImageUpdatingMenu.OwnerItem = this.Image;
            this.ImageUpdatingMenu.Size = new System.Drawing.Size(248, 28);
            this.ImageUpdatingMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ImageUpdatingMenu_ItemClicked);
            // 
            // ImageInversion
            // 
            this.ImageInversion.Name = "ImageInversion";
            this.ImageInversion.Size = new System.Drawing.Size(247, 24);
            this.ImageInversion.Text = "Инверсия изображения";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripPencilButton,
            this.toolStripLineButton,
            this.toolStripRectangleButton,
            this.toolStripFillRectangleButton,
            this.toolStripCircleButton,
            this.toolStripFillCircleButton,
            this.toolStripSeparator1,
            this.toolStripButtonFigureColor,
            this.toolStripButtonFigureFillColor,
            this.toolStripButtonDrawPanelBackgroundColor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(30, 570);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripPencilButton
            // 
            this.toolStripPencilButton.Checked = true;
            this.toolStripPencilButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripPencilButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPencilButton.Image = global::GraphRedaktor.Properties.Resources.Pencil;
            this.toolStripPencilButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPencilButton.Name = "toolStripPencilButton";
            this.toolStripPencilButton.Size = new System.Drawing.Size(27, 28);
            this.toolStripPencilButton.Text = "toolStripButton1";
            this.toolStripPencilButton.ToolTipText = "Карандаш";
            // 
            // toolStripLineButton
            // 
            this.toolStripLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLineButton.Image = global::GraphRedaktor.Properties.Resources.Line;
            this.toolStripLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLineButton.Name = "toolStripLineButton";
            this.toolStripLineButton.Size = new System.Drawing.Size(27, 28);
            this.toolStripLineButton.Text = "toolStripButton1";
            this.toolStripLineButton.ToolTipText = "Линия";
            // 
            // toolStripRectangleButton
            // 
            this.toolStripRectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRectangleButton.Image = global::GraphRedaktor.Properties.Resources.Rectangle;
            this.toolStripRectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRectangleButton.Name = "toolStripRectangleButton";
            this.toolStripRectangleButton.Size = new System.Drawing.Size(27, 28);
            this.toolStripRectangleButton.Text = "toolStripButton1";
            this.toolStripRectangleButton.ToolTipText = "Нарисовать прямоугольник";
            // 
            // toolStripFillRectangleButton
            // 
            this.toolStripFillRectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFillRectangleButton.Image = global::GraphRedaktor.Properties.Resources.FillRectangle;
            this.toolStripFillRectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFillRectangleButton.Name = "toolStripFillRectangleButton";
            this.toolStripFillRectangleButton.Size = new System.Drawing.Size(27, 28);
            this.toolStripFillRectangleButton.Text = "toolStripButton1";
            this.toolStripFillRectangleButton.ToolTipText = "Прямоугольник с фоном";
            // 
            // toolStripCircleButton
            // 
            this.toolStripCircleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCircleButton.Image = global::GraphRedaktor.Properties.Resources.Circle;
            this.toolStripCircleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCircleButton.Name = "toolStripCircleButton";
            this.toolStripCircleButton.Size = new System.Drawing.Size(27, 28);
            this.toolStripCircleButton.Text = "toolStripButton1";
            this.toolStripCircleButton.ToolTipText = "Круг";
            // 
            // toolStripFillCircleButton
            // 
            this.toolStripFillCircleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFillCircleButton.Image = global::GraphRedaktor.Properties.Resources.FillCircle;
            this.toolStripFillCircleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFillCircleButton.Name = "toolStripFillCircleButton";
            this.toolStripFillCircleButton.Size = new System.Drawing.Size(27, 28);
            this.toolStripFillCircleButton.Text = "toolStripButton1";
            this.toolStripFillCircleButton.ToolTipText = "Круг с фоном";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(27, 6);
            // 
            // toolStripButtonFigureColor
            // 
            this.toolStripButtonFigureColor.BackColor = System.Drawing.Color.Black;
            this.toolStripButtonFigureColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonFigureColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFigureColor.Name = "toolStripButtonFigureColor";
            this.toolStripButtonFigureColor.Size = new System.Drawing.Size(27, 24);
            this.toolStripButtonFigureColor.Text = " ";
            this.toolStripButtonFigureColor.ToolTipText = "Цвет фигуры";
            // 
            // toolStripButtonFigureFillColor
            // 
            this.toolStripButtonFigureFillColor.BackColor = System.Drawing.Color.White;
            this.toolStripButtonFigureFillColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonFigureFillColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFigureFillColor.Name = "toolStripButtonFigureFillColor";
            this.toolStripButtonFigureFillColor.Size = new System.Drawing.Size(27, 24);
            this.toolStripButtonFigureFillColor.Text = " ";
            this.toolStripButtonFigureFillColor.ToolTipText = "Цвет заливки фигуры";
            // 
            // toolStripButtonDrawPanelBackgroundColor
            // 
            this.toolStripButtonDrawPanelBackgroundColor.BackColor = System.Drawing.Color.White;
            this.toolStripButtonDrawPanelBackgroundColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDrawPanelBackgroundColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDrawPanelBackgroundColor.Name = "toolStripButtonDrawPanelBackgroundColor";
            this.toolStripButtonDrawPanelBackgroundColor.Size = new System.Drawing.Size(27, 24);
            this.toolStripButtonDrawPanelBackgroundColor.Text = " ";
            this.toolStripButtonDrawPanelBackgroundColor.ToolTipText = "Цвет фона листа";
            this.toolStripButtonDrawPanelBackgroundColor.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.coordX,
            this.coordY,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelFigure,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelOperation,
            this.toolStripProgressBarOperation});
            this.statusStrip1.Location = new System.Drawing.Point(30, 572);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1001, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // coordX
            // 
            this.coordX.Name = "coordX";
            this.coordX.Size = new System.Drawing.Size(57, 20);
            this.coordX.Text = "coordX";
            // 
            // coordY
            // 
            this.coordY.Name = "coordY";
            this.coordY.Size = new System.Drawing.Size(56, 20);
            this.coordY.Text = "coordY";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // toolStripStatusLabelFigure
            // 
            this.toolStripStatusLabelFigure.Name = "toolStripStatusLabelFigure";
            this.toolStripStatusLabelFigure.Size = new System.Drawing.Size(207, 20);
            this.toolStripStatusLabelFigure.Text = "Текущая фигура: неизвестно";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabelOperation
            // 
            this.toolStripStatusLabelOperation.Name = "toolStripStatusLabelOperation";
            this.toolStripStatusLabelOperation.Size = new System.Drawing.Size(138, 20);
            this.toolStripStatusLabelOperation.Text = "текущая операция";
            // 
            // toolStripProgressBarOperation
            // 
            this.toolStripProgressBarOperation.Name = "toolStripProgressBarOperation";
            this.toolStripProgressBarOperation.Size = new System.Drawing.Size(200, 18);
            // 
            // panelForDrawing
            // 
            this.panelForDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForDrawing.BackColor = System.Drawing.Color.White;
            this.panelForDrawing.Location = new System.Drawing.Point(33, 27);
            this.panelForDrawing.Name = "panelForDrawing";
            this.panelForDrawing.Size = new System.Drawing.Size(998, 542);
            this.panelForDrawing.TabIndex = 5;
            this.panelForDrawing.SizeChanged += new System.EventHandler(this.panelForDrawing_SizeChanged);
            this.panelForDrawing.Paint += new System.Windows.Forms.PaintEventHandler(this.panelForDrawing_Paint);
            this.panelForDrawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelForDrawing_MouseDown);
            this.panelForDrawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelForDrawing_MouseMove);
            this.panelForDrawing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelForDrawing_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 598);
            this.Controls.Add(this.panelForDrawing);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Графический редактор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.SaveFileMenu.ResumeLayout(false);
            this.ImageUpdatingMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripRectangleButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonFigureColor;
        private System.Windows.Forms.ToolStripButton toolStripButtonFigureFillColor;
        private System.Windows.Forms.ToolStripButton toolStripButtonDrawPanelBackgroundColor;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel coordX;
        private System.Windows.Forms.ToolStripStatusLabel coordY;
        private DoubleBufferedPanel panelForDrawing;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelOperation;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarOperation;
        private System.Windows.Forms.ContextMenuStrip SaveFileMenu;
        private System.Windows.Forms.ToolStripMenuItem SaveImage;
        private System.Windows.Forms.ToolStripMenuItem LoadImage;
        private System.Windows.Forms.ToolStripButton toolStripPencilButton;
        private System.Windows.Forms.ToolStripButton toolStripLineButton;
        private System.Windows.Forms.ToolStripButton toolStripFillRectangleButton;
        private System.Windows.Forms.ToolStripButton toolStripCircleButton;
        private System.Windows.Forms.ToolStripButton toolStripFillCircleButton;
        private System.Windows.Forms.ToolStripMenuItem Image;
        private System.Windows.Forms.ContextMenuStrip ImageUpdatingMenu;
        private System.Windows.Forms.ToolStripMenuItem ImageInversion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFigure;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

