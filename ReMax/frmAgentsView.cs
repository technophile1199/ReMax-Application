using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReMax
{
    public partial class frmAgentsView : Form
    {
        public frmAgentsView()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        SqlConnection mycon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RemaxDataSet;Integrated Security=True");
       
        private void frmAgentsView_Load(object sender, EventArgs e)
        {
            mycon.Open();

           
            //dtClients = clsGLobalVariables.myset.Tables["Clients"];

            SqlCommand mycmdAgents = new SqlCommand("SELECT * FROM Employees ", mycon);
            SqlDataAdapter daAgentsView = new SqlDataAdapter(mycmdAgents);
            var dsAgentsView = new DataSet();
            daAgentsView.Fill(dsAgentsView);

            if (clsGLobalVariables.post.Substring(0, 5) != "Admin")
            {

            }
            else
            {
                MessageBox.Show("Good we have a data");
                dataAgentView.DataSource = dsAgentsView.Tables[0];
            }
            mycon.Close();
        }

        private void btn_AddEmployee_Click(object sender, EventArgs e)
        {
            clsGLobalVariables.method = "add";
            frmAgentAdd frmAgentAdd = new frmAgentAdd();
            frmAgentAdd.Show();
            this.Close();
        }

        private void btn_EditEmployee_Click(object sender, EventArgs e)
        {
            clsGLobalVariables.method = "edit";
            try
            {
                clsGLobalVariables.Id = dataAgentView.SelectedRows[0].Cells[1].Value.ToString();
                frmAgentAdd frmAgentAdd = new frmAgentAdd();
                frmAgentAdd.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please Select the Row of Agent you want to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Close();
        }

        private void btn_DeleteEmployee_Click(object sender, EventArgs e)
        {
            clsGLobalVariables.Id = dataAgentView.SelectedRows[0].Cells[1].Value.ToString();
            mycon.Open();
            SqlCommand mycmddeleteAgents = new SqlCommand("DELETE FROM Employees WHERE Name ='"+clsGLobalVariables.Id.ToString()+"'", mycon);
            SqlDataAdapter daAgentsdelete = new SqlDataAdapter(mycmddeleteAgents);
            var dsAgentsdelete = new DataSet();
            daAgentsdelete.Fill(dsAgentsdelete);
            mycon.Close();
            this.Close();

            MessageBox.Show("The Agents has been deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmAgentsView agentsView = new frmAgentsView();
            agentsView.Show();
        }
    }
}
