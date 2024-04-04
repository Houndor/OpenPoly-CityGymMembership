using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CityGymMembership
{
    public partial class CityGymMembership : Form
    {
        public CityGymMembership()
        {
            InitializeComponent();
        }

        public void bCalculate_Click(object sender, EventArgs e)

        {
            //Calculating the Base weekly rate
            int BaseCost = 0;

            if (rBasic.Checked)   //For the basic package
            {
                if (rThreeMonths.Checked)
                {
                    BaseCost = 13;
                }
                else if (rTwelveMonths.Checked)
                {
                    BaseCost = 11;
                }
                else if (rTwentyFourMonths.Checked)
                {
                    BaseCost = 10;
                }
            }
            else if (rRegular.Checked)  //For the Regular package
            {
                if (rThreeMonths.Checked)
                {
                    BaseCost = 14;
                }
                else if (rTwelveMonths.Checked)
                {
                    BaseCost = 12;
                }
                else if (rTwentyFourMonths.Checked)
                {
                    BaseCost = 11;
                }
            }
            else if (rPremium.Checked)  //For the Premium package
            {
                if (rThreeMonths.Checked)
                {
                    BaseCost = 16;
                }
                else if (rTwelveMonths.Checked)
                {
                    BaseCost = 14;
                }
                else if (rTwentyFourMonths.Checked)
                {
                    BaseCost = 12;
                }
            }
            tMemCosts.Text = BaseCost.ToString();   //Show the base cost in the Membership cost field

            //Calculate the Extras

            int Extra = 0;

            if (cAccess.Checked)
            {
                Extra += 1;
            }
            if (cTrainer.Checked)
            {
                Extra += 20;
            }
            if (cConsultation.Checked)
            {
                Extra += 20;
            }
            if (cRentals.Checked)
            {
                Extra += 2;
            }

            tExtraCosts.Text = Extra.ToString();    //Shows the extra costs in the Extra Cost field


            //Calculating the dicount

            double Discount = 0;

            if (rBank.Checked)
            {
                Discount = (BaseCost + Extra) * 0.01;
            }

            tDiscounts.Text = Discount.ToString("F2");   //Shows the dicount in the total discount field


            //Calculate Net Memebership Costs

            double NetCost;

            NetCost = BaseCost + Extra - Discount;
            tNetCost.Text = NetCost.ToString("F2");          //Shows the net cost in the Net Membership Costs field


            //Calculate Regular Payment Amount

            double RegPay = NetCost;

            if (rMonthly.Checked)
            {
                RegPay = NetCost * 4;
            }
            tRegPayAmount.Text = RegPay.ToString("F2");      //Shows the payment amount in the regular payment field
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void bAdd_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("c:/Temp/members.txt", true);

            //membership data written to file
            string output = " ";
            output += "First Name: " + tFirstName.Text + "\r\n";
            output += "Last Name: " + tLastName.Text + "\r\n";
            output += "Address: " + tAddress.Text + "\r\n";
            output += "Mobile Number: " + tMobileNumber.Text + "\r\n";
            output += "Regular payment amount: " + tRegPayAmount.Text + "\r\n";
            output += "Number: " + tNumber.Text + "\r\n";

            string Frequency = "";
            if (rWeekly.Checked)
            {
                Frequency = "Weekly";
            }
            else
            {
                Frequency = "Monthly";
            }
            output += "Frequency: " + Frequency + "\r\n";
            output += "" + "\r\n";
            output += "" + "\r\n";

            sw.WriteLine(output);
            sw.Close();

            tSaved.Text = ("The data has been written successfully");
        }
        
    }
}
