using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphRedaktor.Models.MyEventArgs
{
    public class SIzeEventArgs : EventArgs
    {
        private Size _argumentSize;
        public SIzeEventArgs(Size size)
        {
            ArgumentSize = size;
        }

        public Size ArgumentSize { get => _argumentSize; private set => _argumentSize = value; }
    }
}
