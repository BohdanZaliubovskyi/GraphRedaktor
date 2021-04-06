using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphRedaktor.Models
{
    public interface IDraw
    {
        /// <summary>
        /// действие рисования фигуры
        /// </summary>
        /// <param name="graphics">объект графики</param>
        /// <param name="myPen">чем рисовать</param>
        /// <param name="coordX">координата Х</param>
        /// <param name="coordY">координата У</param>
        /// <param name="width">ширина фигуры</param>
        /// <param name="height">высота фигуры</param>
        void DrawFigure(Graphics graphics, Pen myPen, int coordX, int coordY, int width, int height);
    }
}
