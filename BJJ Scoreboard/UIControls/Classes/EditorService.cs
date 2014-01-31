using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Runtime.InteropServices;

namespace BJJA.Scoreboard.UIControls.Classes
{
    class EditorService : IWindowsFormsEditorService, IServiceProvider
    {
        ColorPicker _Picker;
        DropDownForm _DropDownHolder;
        bool _Canceled;

        public EditorService(ColorPicker owner)
        {
            _Picker = owner;
        }

        public bool Canceled
        {
            get { return _Canceled; }
        }

        public void CloseDropDown()
        {
            if (_DropDownHolder != null)
                _DropDownHolder.CloseDropDown();
        }
        public void DropDownControl(Control control)
        {
            _Canceled = false;

            _DropDownHolder = new DropDownForm();
            _DropDownHolder.Bounds = control.Bounds;
            _DropDownHolder.SetControl(control);

            Control PickerForm = this.GetParentForm(_Picker);
            if ((PickerForm != null) && (PickerForm.GetType() == typeof(Form)))
                _DropDownHolder.Owner = (Form)PickerForm;
            this.PositionDropDownHolder();
            _DropDownHolder.Show();
            this.DoModalLoop();
            _Canceled = _DropDownHolder.Canceled;
            _DropDownHolder.Dispose();
            _DropDownHolder = null;
        }
        void PositionDropDownHolder()
        {
            // Convert _Picker location to screen coordinates.
            Point Loc = _Picker.Parent.PointToScreen(_Picker.Location);

            Rectangle ScreenRect = Screen.PrimaryScreen.WorkingArea;

            // Position the dropdown X coordinate in order to be displayed in its entirety.
            if (Loc.X < ScreenRect.X)
                Loc.X = ScreenRect.X;
            else
            {
                if ((Loc.X + _DropDownHolder.Width) > ScreenRect.Right)
                    Loc.X = ScreenRect.Right - _DropDownHolder.Width;
            }


            // Do the same for the Y coordinate.
            if ((Loc.Y + _Picker.Height + _DropDownHolder.Height) > ScreenRect.Bottom)
                Loc.Offset(0, -_DropDownHolder.Height);// dropdown will be above the picker control
            else
                Loc.Offset(0, _Picker.Height);// dropdown will be below the picker

            _DropDownHolder.Location = Loc;
        }
        void DoModalLoop()
        {
            Debug.Assert(_DropDownHolder != null);
            while (_DropDownHolder.Visible)
            {
                Application.DoEvents();
                // The sollowing is the undocumented User32 call. For more information
                // see the accompanying article at http://www.vbinfozine.com/a_colorpicker.shtml
                MsgWaitForMultipleObjects(1, null, true, 5, 255);
            }
        }
        
        // Don't forget to declare the DllImport methods as Shared!
        [DllImport("user32.dll")]
        static extern uint MsgWaitForMultipleObjects(uint nCount, IntPtr[] pHandles,
           bool bWaitAll, uint dwMilliseconds, uint dwWakeMask);

        public DialogResult ShowDialog(Form dialog)
        {
            throw new NotSupportedException();
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.Equals(typeof(IWindowsFormsEditorService)))
                return this;
            return null;
        }
        Control GetParentForm(Control ctl)
        {
            while(true)
            {
                if (ctl.Parent==null)
                    return ctl;
                else
                    ctl = ctl.Parent;               
            }            
        }
    }
}
