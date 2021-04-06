using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GraphRedaktor.Models
{
    public static class MessageSender
    {
        public static void SendMessage(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void SendErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool SendQuestionMessage(string message)
        {
            if (MessageBox.Show(message, "Вопрос", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                return true;

            return false;
        }
    }
}
