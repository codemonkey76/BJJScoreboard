using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using BJJA.Scoreboard.UIControls.Classes;
using System.Diagnostics;

namespace BJJA.Scoreboard.UIControls
{
    [DefaultProperty("Color"), DefaultEvent("ColorChanged")]
    public partial class ColorPicker : Control
    {
        CheckBox _CheckBox;
        bool _TextDisplayed = true;
        EditorService _EditorService;
        public event EventHandler ColorChanged;
        const string DefaultColorName = "Black";

        #region Constructors
        public ColorPicker(Color c)
        {
            InitializeComponent();
            _CheckBox = new CheckBox();
            _CheckBox.Appearance = Appearance.Button;
            _CheckBox.Dock = DockStyle.Fill;
            _CheckBox.TextAlign = ContentAlignment.MiddleCenter;
            _CheckBox.CheckStateChanged+=new EventHandler(OnCheckStateChanged);
            this.SetColor(c);
            this.Controls.Add(_CheckBox);
            _EditorService = new EditorService(this);
        }
        public ColorPicker() : this(Color.FromName(DefaultColorName)) { }
        #endregion

        void SetColor(Color c)
        {
            // Sets the associated CheckBox color and Text according to the TextDisplayed property value.
            _CheckBox.BackColor = c;
            _CheckBox.ForeColor = this.GetInvertedColor(c);
            if (_TextDisplayed)
                _CheckBox.Text = c.Name;
            else
                _CheckBox.Text = String.Empty;
        }
        Color GetInvertedColor(Color c)
        {
            // Primitive color inversion.
            if (((int)c.R + (int)c.G + (int)c.B) > ((255 * 3) / 2))
                return Color.Black;
            else
                return Color.White;
        }
        void CloseDropDown()
        {
            _EditorService.CloseDropDown();
        }

        #region Properties
        [Description("The currently selected color."), Category("Appearance"), DefaultValue(typeof(Color), DefaultColorName)]
        public Color Color
        {
            get
            {
                return _CheckBox.BackColor;
            }
            set
            {
                this.SetColor(value);
                if (ColorChanged != null) ColorChanged(this, EventArgs.Empty);
            }
        }
        [Description("True meanse the control displays the currently selected color's name, False otherwise."), Category("Appearance"), DefaultValue(true)]
        public bool TextDisplayed
        {
            get
            {
                return _TextDisplayed;
            }
            set
            {
                _TextDisplayed = value;
                this.SetColor(this.Color);
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
        #endregion

        // If the associated CheckBox is checked, the drop-down UI is displayed.
        // Otherwise it is closed.
        void OnCheckStateChanged(object sender, EventArgs e)
        {
            if (_CheckBox.CheckState == CheckState.Checked)
                this.ShowDropDown();
            else
                this.CloseDropDown();
        }
        void ShowDropDown()
        {
            try
            {
                // This is the Color type editor - it displays the drop-down UI calling
                // our IWindowsFormsEditorService implementation.
                System.Drawing.Design.ColorEditor Editor = new System.Drawing.Design.ColorEditor();

                // Display the UI.
                Color C = this.Color;
                object NewValue = Editor.EditValue(_EditorService, C);

                // If the user didn't cancel the selection, remember the new color.
                if ((NewValue != null) && (!_EditorService.Canceled))
                    this.Color = (Color)NewValue;

                // Finally, "pop-up" the associated CheckBox.
                _CheckBox.CheckState = CheckState.Unchecked;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }
        // No need to display ForeColor and BackColor and Text in the property browser:
    }
}