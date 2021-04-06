using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphRedaktor.Models.Figures
{
    public class FigureCircle : SimpleFigure
    {        
        public override void DrawFigure(Graphics graphics, Pen myPen, int coordX, int coordY, int width, int height)
        {
            if (graphics == null)
                return;
            if (myPen == null)
                return;
            
            graphics.DrawEllipse(myPen, coordX, coordY, width, width);
        }
        public override string ToString()
        {
            return "круг";
        }
    }
}
