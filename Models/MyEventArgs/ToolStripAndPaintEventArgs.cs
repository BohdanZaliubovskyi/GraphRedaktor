using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GraphRedaktor.Models.MyEventArgs
{
    public class ToolStripAndPaintEventArgs : EventArgs
    {
        ToolStripItemClickedEventArgs _argumentToolStripItemClicked;
        PaintEventArgs _argumentPaint;

        public ToolStripAndPaintEventArgs(ToolStripItemClickedEventArgs tsea, PaintEventArgs pea)
        {
            _argumentPaint = pea;
            _argumentToolStripItemClicked = tsea;
        }

        public ToolStripItemClickedEventArgs ArgumentToolStripItemClicked { get => _argumentToolStripItemClicked; private set => _argumentToolStripItemClicked = value; }
        public PaintEventArgs ArgumentPaint { get => _argumentPaint; private set => _argumentPaint = value; }
    }
}
