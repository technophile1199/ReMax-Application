﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReMax
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        SqlConnection mycon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RemaxDataSet;Integrated Security=True");
        

        private void btn_AddClient_Click(object sender, EventArgs e)
        {
       

            mycon.Open();
            string gender = "";
            if (radioButtonMale.Checked == true)
            {
                gender = radioButtonMale.Text;
            }
            else
            {
                gender = radioButtonFemale.Text;
            }
            //Inserting data in to table
            if (clsGLobalVariables.method == "add")
            {
              

                SqlCommand mycmdClients = new SqlCommand("INSERT INTO Clients (Name, Email, Phone, Address, Password, Gender, Notes, refEmployee) " +
                    " VALUES('" + txt_name.Text + "','" + txt_mail.Text + "','" + txt_phone.Text + "','" + txt_Addr.Text + "','" + txt_pwd.Text + "','" + gender +
                    "','" + txt_notes.Text + "','" + cbAgentName.SelectedItem.ToString() + "')", mycon);
                SqlDataAdapter da = new SqlDataAdapter(mycmdClients);
                var dsClientsAdd = new DataSet();
                da.Fill(dsClientsAdd);

                MessageBox.Show("Clients is Added Successfully!", "Data Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (clsGLobalVariables.method == "edit")
            {
                SqlCommand mycmdeditClients = new SqlCommand("UPDATE Clients " +
                    "SET Name ='" + txt_name.Text + "', Email ='" + txt_mail.Text +
                    "', Phone =" + txt_phone.Text + ", Password ='" + txt_pwd.Text +
                    "', Address ='" + txt_Addr.Text + "', Notes = '" + txt_notes.Text +
                    "', Gender ='" + gender + "', refEmployee ='" + cbAgentName.SelectedItem.ToString() + "' WHERE Name = '"+clsGLobalVariables.Id+"'"
                    , mycon);
                SqlDataAdapter daeditClients = new SqlDataAdapter(mycmdeditClients);
                var dsClientsEdit = new DataSet();
                daeditClients.Fill(dsClientsEdit);

                MessageBox.Show("Clients Detail has been Updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            mycon.Close();
            this.Close();
            frmClientsView clientsView = new frmClientsView();
            clientsView.Show();
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void frmClientAdd_Load(object sender, EventArgs e)
        {
            mycon.Open();

            string cmd = "SELECT Name FROM Employees WHERE Position = 'Agent'";
            SqlDataAdapter daAGENTFETCH = new SqlDataAdapter(cmd, mycon);

            DataTable agnetNames = new DataTable();
            daAGENTFETCH.Fill(agnetNames);

            for(int i = 0; i<agnetNames.Rows.Count ; i++)
            {
                cbAgentName.Items.Add(agnetNames.Rows[i]["Name"].ToString());
            }
            mycon.Close();

            if(clsGLobalVariables.method == "edit")
            {
                mycon.Open();
                btn_AddClient.Text = "Edit Client";

                string cmdclinet = "SELECT * FROM Clients WHERE Name = '"+clsGLobalVariables.Id+"'";
                SqlDataAdapter daClient = new SqlDataAdapter(cmdclinet, mycon);

                DataTable Clientdetails = new DataTable();
                daClient.Fill(Clientdetails);

                txt_name.Text = Clientdetails.Rows[0]["Name"].ToString();
                txt_phone.Text = Clientdetails.Rows[0]["Phone"].ToString();
                txt_mail.Text = Clientdetails.Rows[0]["Email"].ToString();
                txt_Addr.Text = Clientdetails.Rows[0]["Address"].ToString();
                txt_pwd.Text = Clientdetails.Rows[0]["Password"].ToString();
                txt_notes.Text = Clientdetails.Rows[0]["Notes"].ToString();
                cbAgentName.SelectedItem = Clientdetails.Rows[0]["refEmployee"].ToString();
                if (Clientdetails.Rows[0]["Gender"].ToString() == "Female")
                {
                    radioButtonFemale.Checked = true;
                }
                else
                {
                    radioButtonMale.Checked = true;
                }
                mycon.Close();
            }
        }

        private void btn_ClearClient_Click(object sender, EventArgs e)
        {

            txt_Addr.Text = "";
            txt_mail.Text = "";
            txt_name.Text = "";
            txt_phone.Text = "";
            txt_Addr.Text = "";
            cbAgentName.Text = "";
            txt_notes.Text = "";
            radioButtonFemale.Checked = false;
            radioButtonMale.Checked = false;
            this.Close();
        }
    }
}
