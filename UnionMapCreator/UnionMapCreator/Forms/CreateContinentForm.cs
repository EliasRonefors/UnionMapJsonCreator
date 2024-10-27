using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnionMapCreator
{
    public partial class CreateContinentForm : Form
    {
        List<Continent> myContinentsReferences;

        public CreateContinentForm(ref List<Continent> someContinentReferences)
        {
            myContinentsReferences = someContinentReferences;
            InitializeComponent();
        }

        private void CreateContinentForm_Load(object sender, EventArgs e)
        {

        }

        private void CreateContinent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ContinentNameBox.Text))
            {
                MessageBox.Show("Please enter a Name.", "Warning");
            }
            else if (string.IsNullOrEmpty(ContinentTroopBox.Text))
            {
                MessageBox.Show("Please enter a Troop Bonus amount.", "Warning");
            }
            else
            {
                if (int.TryParse(ContinentTroopBox.Text, out int troopsAmountResult))
                {
                    myContinentsReferences.Add(new Continent(ContinentNameBox.Text, troopsAmountResult));
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Troop Bonus must be of Type Integer.", "Warning");
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
