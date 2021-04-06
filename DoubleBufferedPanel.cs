using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GraphRedaktor
{
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel():base()
        {
            DoubleBuffered = true;
        }
    }
}
