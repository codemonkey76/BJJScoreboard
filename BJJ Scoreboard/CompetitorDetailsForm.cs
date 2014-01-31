using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BJJA.Scoreboard.Classes;

namespace BJJA.Scoreboard
{
    public partial class CompetitorDetailsForm : Form
    {
        List<string> ages = new List<string>();
        List<string> weights = new List<string>();
        List<string> skills = new List<string>();
        List<string> style = new List<string>();
        List<string> sex = new List<string>();
        Competitor_Details details;

        public Competitor_Details Details
        {
            get
            {
                Competitor_Details d = new Competitor_Details();
                d.Age = cbAges.SelectedValue.ToString();
                d.Weight = cbWeights.SelectedValue.ToString();
                d.Style = cbStyles.SelectedValue.ToString();
                d.Skill = cbSkills.SelectedValue.ToString();
                d.ColorName = tbColorCompetitor.Text;
                d.WhiteName = tbWhiteCompetitor.Text;
                d.Sex = cbSex.SelectedValue.ToString();
                return d;
            }
        }
        public CompetitorDetailsForm(Competitor_Details details)
        {
            InitializeComponent();
            this.details = details;
            ages = new List<string>();
            PopulateAges();
            PopulateWeights();
            PopulateSkills();
            PopulateStyles();
            PopulateSexes();
            cbAges.DataSource = ages;
            cbWeights.DataSource = weights;
            cbSkills.DataSource = skills;
            cbStyles.DataSource = style;
            cbSex.DataSource = sex;
            cbAges.SelectedItem = details.Age;
            cbWeights.SelectedItem = details.Weight;
            cbSkills.SelectedItem = details.Skill;
            cbStyles.SelectedItem = details.Style;
            cbSex.SelectedItem = details.Sex;
        }
        public void PopulateWeights()
        {
            weights.Add("Rooster");
            weights.Add("Light-Feather");
            weights.Add("Feather");
            weights.Add("Light");
            weights.Add("Middle");
            weights.Add("Medium-Heavy");
            weights.Add("Heavy");
            weights.Add("Super-Heavy");
            weights.Add("Ultra-Heavy");
            weights.Add("Open");
        }
        public void PopulateSexes()
        {
            sex.Add("Male");
            sex.Add("Female");
        }
        public void PopulateStyles()
        {
            style.Add("Gi");
            style.Add("No-Gi");
        }
        public void PopulateSkills()
        {
            skills.Add("White Belt");
            skills.Add("Blue Belt");
            skills.Add("Purple Belt");
            skills.Add("Brown Belt");
            skills.Add("Black Belt");
        }

        public void PopulateAges()
        {
            ages.Add("Mighty Mite I (<=4)");
            ages.Add("Mighty Mite II (<=5)");
            ages.Add("Mighty Mite III (<=6)");
            ages.Add("Pee Wee I (<=7)");
            ages.Add("Pee Wee II (<=8)");
            ages.Add("Pee Wee III (<=9)");
            ages.Add("Junior I (<=10)");
            ages.Add("Junior II (<=11)");
            ages.Add("Junior III (<=12)");
            ages.Add("Teen I (<=13)");
            ages.Add("Teen II (<=14)");
            ages.Add("Teen III (<=15)");
            ages.Add("Juvenile I (<=16)");
            ages.Add("Juvenile II (<=17)");
            ages.Add("Adult");
            ages.Add("Master (30+)");
            ages.Add("Senior 1 (36+)");
            ages.Add("Senior 2 (41+)");
            ages.Add("Senior 3 (46+)");
            ages.Add("Senior 4 (51+)");
            ages.Add("Senior 5 (56+)");
        }
    }
}
