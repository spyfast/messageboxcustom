using System.Windows.Forms;

namespace JungFranco.MessageBox
{
    public static class MessageBoxCustom
    {
        /// <summary>
        /// Модальное окно с одним текстом
        /// </summary>
        /// <param name="text">Текст</param>
        /// <returns></returns>
        public static DialogResult Show(string text)
        {
            DialogResult result;
            using (var msgForm = new MessageBoxForm(text))
                result = msgForm.ShowDialog();
            return result;
        }
        /// <summary>
        /// Модальное окно с текстом и заголовком
        /// </summary>
        /// <param name="text">Текст модельного окна</param>
        /// <param name="caption">Текст заголовка</param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption)
        {
            DialogResult result;
            using (var msgForm = new MessageBoxForm(text, caption))
                result = msgForm.ShowDialog();
            return result;
        }
        /// <summary>
        /// Модальное окно с текстом, заголовком и кнопками
        /// </summary>
        /// <param name="text">Текст модального окна</param>
        /// <param name="caption">Текст заголовка</param>
        /// <param name="buttons">Кнопки</param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            DialogResult result;
            using (var msgForm = new MessageBoxForm(text, caption, buttons))
                result = msgForm.ShowDialog();
            return result;
        }
        /// <summary>
        /// Модальное окно с текстом, заголовком, кнопками и иконкой
        /// </summary>
        /// <param name="text">Текст модального окна</param>
        /// <param name="caption">Текст заголовка</param>
        /// <param name="buttons">Кнопки</param>
        /// <param name="icon">Иконки</param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult result;
            using (var msgForm = new MessageBoxForm(text, caption, buttons, icon))
                result = msgForm.ShowDialog();
            return result;
        }
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            DialogResult result;
            using (var msgForm = new MessageBoxForm(text, caption, buttons, icon, defaultButton))
                result = msgForm.ShowDialog();
            return result;
        }

        public static DialogResult Show(IWin32Window owner, string text)
        {
            DialogResult result;
            using (var msgForm = new MessageBoxForm(text))
                result = msgForm.ShowDialog(owner);
            return result;
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            DialogResult result;
            using (var msgForm = new MessageBoxForm(text, caption))
                result = msgForm.ShowDialog(owner);
            return result;
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            DialogResult result;
            using (var msgForm = new MessageBoxForm(text, caption, buttons))
                result = msgForm.ShowDialog(owner);
            return result;
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult result;
            using (var msgForm = new MessageBoxForm(text, caption, buttons, icon))
                result = msgForm.ShowDialog(owner);
            return result;
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            DialogResult result;
            using (var msgForm = new MessageBoxForm(text, caption, buttons, icon, defaultButton))
                result = msgForm.ShowDialog(owner);
            return result;
        }
    }
}
