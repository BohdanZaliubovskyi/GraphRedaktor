using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphRedaktor.Models
{
    public abstract class SimpleFigure : IDraw
    {
        private Color _figureColor;
        private Point _beginPoint;
        private Point _endPoint;

        /// <summary>
        /// цвет фона фигуры
        /// </summary>
        public Color BackgroundColor { get => _figureColor; set => _figureColor = value; }
        /// <summary>
        /// начальная точка для рисования фигуры
        /// </summary>
        public Point BeginPoint { get => _beginPoint; set => _beginPoint = value; }
        /// <summary>
        /// конечная точка для рисования фигуры
        /// </summary>
        public Point EndPoint { get => _endPoint; set => _endPoint = value; }

        /// <summary>
        /// пересчет координат отрисовки в зависимости от направления движения рисования пользователя
        /// </summary>
        /// <param name="coordX">координата Х</param>
        /// <param name="coordY">координата У</param>
        /// <param name="width">ширина фигуры</param>
        /// <param name="height">высота фигуры</param>
        private void CalculateCoords(ref int coordX, ref int coordY, ref int width, ref int height )
        {
            if (width > 0 && height > 0)
            {
                coordX = BeginPoint.X;
                coordY = BeginPoint.Y;
            }
            if (width < 0 && height < 0)
            {
                coordX = EndPoint.X;
                coordY = EndPoint.Y;
                width *= -1;
                height *= -1;
            }
            if (width < 0 && height > 0)
            {
                coordX = EndPoint.X;
                coordY = BeginPoint.Y;
                width *= -1;
            }
            if (width > 0 && height < 0)
            {
                coordX = BeginPoint.X;
                coordY = EndPoint.Y;
                height *= -1;
            }
        }

        /// <summary>
        /// рисование фигуры
        /// </summary>
        /// <param name="figureColor">цвет для рисования</param>
        /// <param name="tempDraw">исходный рисунок, на котором будет дорисовываться фигура</param>
        /// <param name="pea">объект графики, на котором будет рисоваться конечный общий рисунок</param>
        public virtual void Draw(Color figureColor, Bitmap tempDraw, PaintEventArgs pea)
        {
            if (tempDraw == null)
                return;
            if (pea == null)
                return;

            Graphics g = Graphics.FromImage(tempDraw);
            Pen myPen = new Pen(figureColor, Constants.PenSize);

            int width = EndPoint.X - BeginPoint.X;
            int height = EndPoint.Y - BeginPoint.Y;
            int coordX = 0;
            int coordY = 0;

            CalculateCoords(ref coordX, ref coordY, ref width, ref height);

            DrawFigure(g, myPen, coordX, coordY, width, height);
            myPen.Dispose();
            pea.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
            g.Dispose();
        }

        /// <summary>
        /// отрисовка конкретной фигуры
        /// </summary>
        /// <param name="graphics">объект графики</param>
        /// <param name="myPen">чем рисуем</param>
        /// <param name="coordX">координата Х с которой нужно начинать рисование</param>
        /// <param name="coordY">координата Y с которой нужно начинать рисование</param>
        /// <param name="width">ширина фигуры</param>
        /// <param name="height">высота фигуры</param>
        public abstract void DrawFigure(Graphics graphics, Pen myPen, int coordX, int coordY, int width, int height);

        public override string ToString()
        {
            return "неизвестно";
        }
    }
}
