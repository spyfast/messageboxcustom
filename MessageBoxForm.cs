using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace JungFranco.MessageBox
{
    public partial class MessageBoxForm : Form
    {
        // Mouse Down
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        private Color PrimaryCol { get; set; } = Color.CornflowerBlue;

        private int BorderSize { get; set; }  = 2;

        public MessageBoxForm(string text)
        {
            InitializeComponent();

            InitializeItems();
            PrimaryColor = PrimaryCol;

            labelMessage.Text = text;
            labelCaption.Text = "";

            SetFormSize();
            SetButtons(MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
        }
        public MessageBoxForm(string text, string caption)
        {
            InitializeComponent();

            InitializeItems();
            PrimaryColor = PrimaryCol;

            labelMessage.Text = text;
            labelCaption.Text = caption;

            SetFormSize();
            SetButtons(MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
        }
        public MessageBoxForm(string text, string caption, MessageBoxButtons buttons)
        {
            InitializeComponent();

            InitializeItems();
            PrimaryColor = PrimaryCol;

            labelMessage.Text = text;
            labelCaption.Text = caption;

            SetFormSize();
            SetButtons(buttons, MessageBoxDefaultButton.Button1);
        }
        public MessageBoxForm(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            InitializeComponent();

            InitializeItems();
            PrimaryColor = PrimaryCol;

            labelMessage.Text = text;
            labelCaption.Text = caption;

            SetFormSize();
            SetButtons(buttons, MessageBoxDefaultButton.Button1);
            SetIcon(icon);
        }
        private void InitializeItems()
        {
            FormBorderStyle = FormBorderStyle.None;
            Padding = new Padding(BorderSize);

            labelMessage.MaximumSize = new Size(550, 0);

            btnClose.DialogResult = DialogResult.Cancel;
            button_Ok.DialogResult = DialogResult.OK;

            button_Ok.Visible = false;
            button_cancel.Visible = false;
            button_cancel2.Visible = false;
        }
        public MessageBoxForm(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            InitializeComponent();

            InitializeItems();
            PrimaryColor = PrimaryCol;

            labelMessage.Text = text;
            labelCaption.Text = caption;

            SetFormSize();
            SetButtons(buttons, defaultButton);
            SetIcon(icon);
        }
        public Color PrimaryColor
        {
            get 
            { 
                return PrimaryCol; 
            }
            set
            {
                PrimaryCol = value;
                BackColor = PrimaryCol;
                panelTitleBar.BackColor = PrimaryColor;
            }
        }

        private void SetFormSize()
        {
            int widht = labelMessage.Width + pictureBoxIcon.Width + panelBody.Padding.Left;
            int height = panelTitleBar.Height + labelMessage.Height + panelButtons.Height + panelBody.Padding.Top;
            Size = new Size(widht, height);
        }
        private void SetButtons(MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
        {
            int xCenter = (panelButtons.Width - button_Ok.Width) / 2;
            int yCenter = (panelButtons.Height - button_Ok.Height) / 2;

            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    // Кнопка ОК
                    button_Ok.Visible = true;
                    button_Ok.Location = new Point(xCenter, yCenter);
                    button_Ok.Text = "Oк";
                    button_Ok.DialogResult = DialogResult.OK;
                    SetDefaultButton(defaultButton);
                    break;
                case MessageBoxButtons.OKCancel:
                    // Кнопка ОК
                    button_Ok.Visible = true;
                    button_Ok.Location = new Point(xCenter - (button_Ok.Width / 2) - 5, yCenter);
                    button_Ok.Text = "Oк";
                    button_Ok.DialogResult = DialogResult.OK;

                    // Кнопка отмены
                    button_cancel.Visible = true;
                    button_cancel.Location = new Point(xCenter + (button_cancel.Width / 2) + 5, yCenter);
                    button_cancel.Text = "Отмена";
                    button_cancel.DialogResult = DialogResult.Cancel;
                    button_cancel.BackColor = Color.DimGray;

                    if (defaultButton != MessageBoxDefaultButton.Button3)
                        SetDefaultButton(defaultButton);
                    else 
                        SetDefaultButton(MessageBoxDefaultButton.Button1);
                    break;

                case MessageBoxButtons.RetryCancel:
                    // Кнопка повторить
                    button_Ok.Visible = true;
                    button_Ok.Location = new Point(xCenter - (button_Ok.Width / 2) - 5, yCenter);
                    button_Ok.Text = "Повторить";
                    button_Ok.DialogResult = DialogResult.Retry;

                    // Кнопка отмена
                    button_cancel.Visible = true;
                    button_cancel.Location = new Point(xCenter + (button_cancel.Width / 2) + 5, yCenter);
                    button_cancel.Text = "Отмена";
                    button_cancel.DialogResult = DialogResult.Cancel;
                    button_cancel.BackColor = Color.DimGray;

                    if (defaultButton != MessageBoxDefaultButton.Button3)
                        SetDefaultButton(defaultButton);
                    else 
                        SetDefaultButton(MessageBoxDefaultButton.Button1);
                    break;

                case MessageBoxButtons.YesNo:
                    // Кнопка Да
                    button_Ok.Visible = true;
                    button_Ok.Location = new Point(xCenter - (button_Ok.Width / 2) - 5, yCenter);
                    button_Ok.Text = "Да";
                    button_Ok.DialogResult = DialogResult.Yes;

                    // Кнопка Нет
                    button_cancel.Visible = true;
                    button_cancel.Location = new Point(xCenter + (button_cancel.Width / 2) + 5, yCenter);
                    button_cancel.Text = "Нет";
                    button_cancel.DialogResult = DialogResult.No;
                    button_cancel.BackColor = Color.IndianRed;

                    if (defaultButton != MessageBoxDefaultButton.Button3)
                        SetDefaultButton(defaultButton);
                    else 
                        SetDefaultButton(MessageBoxDefaultButton.Button1);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    // Кнопка Да
                    button_Ok.Visible = true;
                    button_Ok.Location = new Point(xCenter - button_Ok.Width - 5, yCenter);
                    button_Ok.Text = "Да";
                    button_Ok.DialogResult = DialogResult.Yes;

                    // Кнопка Нет
                    button_cancel.Visible = true;
                    button_cancel.Location = new Point(xCenter, yCenter);
                    button_cancel.Text = "Нет";
                    button_cancel.DialogResult = DialogResult.No;
                    button_cancel.BackColor = Color.IndianRed;

                    // Кнопка отмена
                    button_cancel2.Visible = true;
                    button_cancel2.Location = new Point(xCenter + button_cancel.Width + 5, yCenter);
                    button_cancel2.Text = "Отмена";
                    button_cancel2.DialogResult = DialogResult.Cancel;
                    button_cancel2.BackColor = Color.DimGray;

                    SetDefaultButton(defaultButton);
                    break;

                case MessageBoxButtons.AbortRetryIgnore:
                    // Кнопка преврвать
                    button_Ok.Visible = true;
                    button_Ok.Location = new Point(xCenter - button_Ok.Width - 5, yCenter);
                    button_Ok.Text = "Прервать";
                    button_Ok.DialogResult = DialogResult.Abort;
                    button_Ok.BackColor = Color.Goldenrod;

                    // Кнопка повторить
                    button_cancel.Visible = true;
                    button_cancel.Location = new Point(xCenter, yCenter);
                    button_cancel.Text = "Повторить";
                    button_cancel.DialogResult = DialogResult.Retry;                  

                    // Кнопка Пропустить
                    button_cancel2.Visible = true;
                    button_cancel2.Location = new Point(xCenter + button_cancel.Width + 5, yCenter);
                    button_cancel2.Text = "Пропустить";
                    button_cancel2.DialogResult = DialogResult.Ignore;
                    button_cancel2.BackColor = Color.IndianRed;

                    SetDefaultButton(defaultButton);
                    break;
            }
        }
        private void SetDefaultButton(MessageBoxDefaultButton defaultButton)
        {
            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1:
                    button_Ok.Select();
                    button_Ok.ForeColor = Color.White;
                    button_Ok.Font = new Font(button_Ok.Font, FontStyle.Underline);
                    break;
                case MessageBoxDefaultButton.Button2:
                    button_cancel.Select();
                    button_cancel.ForeColor = Color.White;
                    button_cancel.Font = new Font(button_cancel.Font, FontStyle.Underline);
                    break;
                case MessageBoxDefaultButton.Button3:
                    button_cancel2.Select();
                    button_cancel2.ForeColor = Color.White;
                    button_cancel2.Font = new Font(button_cancel2.Font, FontStyle.Underline);
                    break;
            }
        }
        private void SetIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error: // Ошибка
                    pictureBoxIcon.Image = Properties.Resources.Error;
                    PrimaryColor = Color.FromArgb(224, 79, 95);
                    btnClose.FlatAppearance.MouseOverBackColor = Color.Crimson;
                    break;
                case MessageBoxIcon.Information: // Информация
                    pictureBoxIcon.Image = Properties.Resources.Information;
                    PrimaryColor = Color.FromArgb(38, 191, 166);
                    break;
                case MessageBoxIcon.Question:// Вопрос
                    pictureBoxIcon.Image = Properties.Resources.Question;
                    PrimaryColor = Color.FromArgb(10, 119, 232);
                    break;
                case MessageBoxIcon.Exclamation:// Восклицание
                    pictureBoxIcon.Image = Properties.Resources.Exclamation;
                    PrimaryColor = Color.FromArgb(255, 140, 0);
                    break;
                case MessageBoxIcon.None: // Пустота
                    pictureBoxIcon.Image = Properties.Resources.Chat;
                    PrimaryColor = Color.CornflowerBlue;
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
