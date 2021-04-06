using System;
using System.Collections.Generic;
using System.Text;

namespace GraphRedaktor.Models.MyEventArgs
{
    public class LongOperationEventArgs : StringEventArgs
    {
        private int _argumentInt;
        public LongOperationEventArgs(string argumentString, int argumentInt) : base(argumentString)
        {
            _argumentInt = argumentInt;
        }

        public int ArgumentInt { get => _argumentInt; private set => _argumentInt = value; }
    }
}
