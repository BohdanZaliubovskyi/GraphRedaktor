using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphRedaktor.Models.Figures
{
    public class FigureFillRectangle : SimpleFigure
    {
        public override void DrawFigure(Graphics graphics, Pen myPen, int coordX, int coordY, int width, int height)
        {
            if (graphics == null)
                return;
            if (myPen == null)
                return;

            graphics.DrawRectangle(myPen, coordX, coordY, width, height);
            graphics.FillRectangle(new SolidBrush(BackgroundColor), coordX+myPen.Width/2, coordY+myPen.Width/2, width- myPen.Width, height- myPen.Width);
        }
        public override string ToString()
        {
            return "прямоугольник с заливкой";
        }
    }
}
