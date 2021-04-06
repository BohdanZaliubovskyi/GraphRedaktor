using System;
using System.Collections.Generic;
using System.Text;

namespace GraphRedaktor.Models.Interfaces
{
    public interface IInfoMessageInterface
    {
        /// <summary>
        /// отправка сообщения
        /// </summary>
        event EventHandler OnErrorMessageSend;
        /// <summary>
        /// отправка данных для отображения долгой операции на представлении пользователя
        /// </summary>
        event EventHandler OnDataForLongOperationSend;
    }
}
