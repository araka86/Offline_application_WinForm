using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CartrigeAltstar.Dialogs
{
    public partial class DialogForm : Form
    {
        /// <summary>
        /// Пользовательские дополнительные кнопки
        /// </summary>
        private readonly List<Button> lstAdvancedButtons = null;

        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        public int UserID { get; set; }

        /// <summary>
        /// Признак необратимости использования диалоговой формы - блокировка кнопки "Отмена" и кнопки "Закрытия формы"
        /// </summary>
        [Browsable(false)]
        public bool DiscardCanceling
        {
            get { return !btnCancel.Enabled; }
            set { /*this.ControlBox =*/ btnCancel.Enabled = !value; }  
        }

        public Panel OptionsPanel
        {
            get { return pnlButtons; }
        }

        protected bool ButtonOKEnabled
        {
            get { return btnOK.Enabled; }
            set { btnOK.Enabled = value; }
        }

        protected bool ButtonCancelEnabled
        {
            get { return btnCancel.Enabled; }
            set { btnCancel.Enabled = value; }
        }

        #endregion

        #region СОБЫТИЯ И ДЕЛЕГАТЫ

        public event EventHandler BeginShown;

        #endregion

        public DialogForm()
        {
            InitializeComponent();
            lstAdvancedButtons = new List<Button>();

            //this.AutoScroll = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (BeginShown != null)
                BeginShown(this, EventArgs.Empty);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (this.DialogResult == DialogResult.Cancel && this.DiscardCanceling)
            {
                MessageBox.Show("Отмена операции невозможна.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Добавление действия
        /// </summary>
        /// <param name="actionText"></param>
        /// <param name="method"></param>
        /// <param name="needClose"></param>
        public Button AddAction(string actionText, MethodInvoker method, bool needClose)
        {
            return this.AddAction(actionText, method, needClose, (Point?)null, (AnchorStyles?)null, true);
        }

        /// <summary>
        /// Добавление действия
        /// </summary>
        /// <param name="actionText"></param>
        /// <param name="method"></param>
        /// <param name="needClose"></param>
        /// <param name="isEnabled"></param>
        public Button AddAction(string actionText, MethodInvoker method, bool needClose, bool isEnabled)
        {
            return this.AddAction(actionText, method, needClose, (Point?)null, (AnchorStyles?)null, isEnabled);
        }

         /// <summary>
        /// Добавление действия
        /// </summary>
        /// <param name="actionText"></param>
        /// <param name="method"></param>
        /// <param name="needClose"></param>
        /// <param name="location"></param>
        /// <param name="anchor"></param>
        /// <param name="isEnabled"></param>
        public Button AddAction(string actionText, MethodInvoker method, bool needClose, Point? location, AnchorStyles? anchor)
        {
            return this.AddAction(actionText, method, needClose, location, anchor, true);
        }

        /// <summary>
        /// Добавление действия
        /// </summary>
        /// <param name="actionText"></param>
        /// <param name="method"></param>
        /// <param name="needClose"></param>
        /// <param name="location"></param>
        /// <param name="anchor"></param>
        /// <param name="isEnabled"></param>
        public Button AddAction(string actionText, MethodInvoker method, bool needClose, Point? location, AnchorStyles? anchor, bool isEnabled)
        {
            var button = new Button();
            button.Text = actionText;

            // Вычислим расположение добавленной кнопки
            var advancedButtonLocation = new Point(10, 8);
            if (lstAdvancedButtons.Count > 0)
            {
                var previousAdvancedButton = lstAdvancedButtons[lstAdvancedButtons.Count - 1];
                advancedButtonLocation = previousAdvancedButton.Location;
                advancedButtonLocation.X += previousAdvancedButton.Width + 6;
            }

            button.Location = location ?? advancedButtonLocation;
            button.Anchor = anchor ?? AnchorStyles.Left;
            button.Enabled = isEnabled;
            
            button.Click += (s, e) => 
            {
                if (needClose)
                {
                    this.Hide();
                    this.DialogResult = DialogResult.Cancel;
                }

                method.Invoke(); 
            };
            this.pnlButtons.Controls.Add(button);
            lstAdvancedButtons.Add(button);

            return button;
        }

        public void Close(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }
    }
}
