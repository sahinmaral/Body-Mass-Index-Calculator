using BodyMassIndexCalculator.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodyMassIndexCalculator
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            cmbHeight.SelectedIndex = 1;
            cmbWeight.SelectedIndex = 0;
        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double Bmi;
            string TrimmedBmi;
            string BmiCategory;

            Measurements measurements = new Measurements();

            try
            {
                measurements.Height = float.Parse(txtHeight.Text);
                measurements.Weight = float.Parse(txtWeight.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Enter height or weight");
            }

            measurements.HeightType = cmbHeight.SelectedIndex;
            measurements.WeightType = cmbWeight.SelectedIndex;

            Bmi = measurements.MeasureBMI(measurements.Weight , measurements.Height , measurements.WeightType , measurements.HeightType);
            TrimmedBmi = Bmi.ToString();
            TrimmedBmi = TrimmedBmi.Substring(0, 5);

            BmiCategory = measurements.GetBMICategories(Bmi);

            lblResult.Text = "BMI : "+TrimmedBmi+"\r\n"+"Category : "+BmiCategory;
        }


    }
}
