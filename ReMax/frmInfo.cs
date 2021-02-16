using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReMax
{
    public partial class frmInfo : Form
    {
        public frmInfo()
        {
            InitializeComponent();
        }

        private void frmInfo_Load(object sender, EventArgs e)
        {
            txtInfo.AppendText("Welcome to Remax Application");
            txtInfo.AppendText(Environment.NewLine);
            txtInfo.AppendText("Version 1.0");
            txtInfo.AppendText(Environment.NewLine);
            txtInfo.AppendText("It is a application that enhances an user to browse and invest their hard earned money for looking for houses");
            txtInfo.AppendText(Environment.NewLine);
            txtInfo.AppendText("Here a person can look for houses and then book their Agent to handle the proceedings of the Property Documentation");
            txtInfo.AppendText(Environment.NewLine);
            txtInfo.AppendText("LaSalle College - Fall 2020");
            txtInfo.AppendText(Environment.NewLine);
            txtInfo.AppendText("Guided by : Fode Toure");
            txtInfo.AppendText(Environment.NewLine);
            txtInfo.AppendText("Developed by : Manan Pandya");
            txtInfo.AppendText(Environment.NewLine);
        }
    }
}
