using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BJJA.Scoreboard.UIControls.Classes
{
    class DropDownForm : Form
    {
        bool _Canceled;
        bool _CloseDropDownCalled;

        public DropDownForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.KeyPreview = true;  // to catch the ESC key
            this.StartPosition = FormStartPosition.Manual;

            // The ColorUI control is hosted by a Panel, which provides the simple border frame
            // not available for Forms.
            Panel p = new Panel();
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Dock = DockStyle.Fill;
            this.Controls.Add(p);
        }
        public void SetControl(Control ctl)
        {
            ((Panel)this.Controls[0]).Controls.Add(ctl);
        }
        public bool Canceled
        {
            get { return _Canceled; }
        }
        public void CloseDropDown()
        {
            _CloseDropDownCalled = true;
            this.Hide();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if ((e.Modifiers == 0) && (e.KeyCode == Keys.Escape))
                this.Hide();
        }
        protected override void OnDeactivate(EventArgs e)
        {
            // We set the Owner to Nothing BEFORE calling the base class.
            // If we wouldn't do it, the Picker form would lose focus after 
            // the dropdown is closed.
            this.Owner = null;

            base.OnDeactivate(e);

            // If the form was closed by any other means as the CloseDropDown call, it is because
            // the user clicked outside the form, or pressed the ESC key.
            if (!_CloseDropDownCalled)
                _Canceled = true;

            this.Hide();
        }
    }
}
