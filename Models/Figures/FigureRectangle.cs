using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphRedaktor.Models
{
    public class FigureRectangle : SimpleFigure
    {
        public override void DrawFigure(Graphics graphics, Pen myPen, int coordX, int coordY, int width, int height)
        {
            if (graphics == null)
                return;
            if (myPen == null)
                return;

            graphics.DrawRectangle(myPen, coordX, coordY, width, height);
        }
        public override string ToString()
        {
            return "прямоугольник";
        }
    }
}
