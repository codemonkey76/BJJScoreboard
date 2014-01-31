using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BJJA.Scoreboard
{
    public partial class frmSettings : Form
    {
        public frmSettings()//Image image)
        {
            InitializeComponent();
            
            whiteScoreOn.DataBindings.Add(new Binding("Color", Properties.Settings.Default, "whiteScoreOn"));
            whiteScoreOff.DataBindings.Add(new Binding("Color", Properties.Settings.Default, "whiteScoreOff"));
            whiteScoreBg.DataBindings.Add(new Binding("Color", Properties.Settings.Default, "whiteScoreBg"));

            whiteAdvOn.DataBindings.Add(new Binding("Color", Properties.Settings.Default, "whiteAdvOn"));
            whiteAdvOff.DataBindings.Add(new Binding("Color", Properties.Settings.Default, "whiteAdvOff"));
            whiteAdvBg.DataBindings.Add(new Binding("Color", Properties.Settings.Default, "whiteAdvBg"));

            whitePenOn.DataBindings.Add(new Binding("Color", Properties.Settings.Default, "whitePenOn"));
            whitePenOff.DataBindings.Add(new Binding("Color", Properties.Settings.Default, "whitePenOff"));
            whitePenBg.DataBindings.Add(new Binding("Color", Properties.Settings.Default, "whitePenBg"));

        }
        string _image;
        public string Image
        {
            get { return _image; }
        }
        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            pb1.Image = global::BJJA.Scoreboard.Properties.Resources.default_800x600;
            _image = null;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _image = openFileDialog1.FileName;
                pb1.Image = System.Drawing.Image.FromFile(_image);
            }
        }        
    }
}
