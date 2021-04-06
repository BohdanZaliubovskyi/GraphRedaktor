using System;
using System.Collections.Generic;
using System.Text;

namespace GraphRedaktor.Models.Handlers
{
    public class BaseHandler
    {
        private bool _haveAccessToProgressBar;
        /// <summary>
        ///  есть ли у текущего класса доступ к компоненту отображения прогресса на пользовательском представлении
        /// </summary>
        public bool HaveAccessToProgressBar { get => _haveAccessToProgressBar; set => _haveAccessToProgressBar = value; }
        public BaseHandler()
        {
            _haveAccessToProgressBar = false;
        }
    }
}
