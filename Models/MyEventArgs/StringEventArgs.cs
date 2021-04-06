using System;
using System.Collections.Generic;
using System.Text;

namespace GraphRedaktor.Models.MyEventArgs
{
    public class StringEventArgs : EventArgs
    {
        private string _argumentString;
        public StringEventArgs(string argument)
        {
            _argumentString = argument;
        }

        public string ArgumentString { get => _argumentString; private set => _argumentString = value; }
    }
}
