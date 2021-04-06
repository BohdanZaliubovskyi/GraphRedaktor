using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphRedaktor.Models.MyEventArgs
{
    public class BitmapEventArgs : EventArgs
    {
        private Bitmap _argument;
        public BitmapEventArgs(Bitmap argument)
        {
            _argument = argument;
        }

        public Bitmap Argument { get => _argument; private set => _argument = value; }
    }
}
