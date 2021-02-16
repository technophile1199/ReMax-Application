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
    public partial class frmClientsView : Form
    {
        public frmClientsView()
        {
            InitializeComponent();
        }
        SqlConnection mycon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RemaxDataSet;Integrated Security=True");

        private void frmClientsView_Load(object sender, EventArgs e)
        {

            mycon.Open();

 
           
            

            if (clsGLobalVariables.post.Substring(0, 5) != "Admin")
            {
                MessageBox.Show(clsGLobalVariables.ClientName);
                SqlCommand mycmd4 = new SqlCommand("SELECT * FROM Clients WHERE refEmployee='"+clsGLobalVariables.ClientName+"'", mycon);
                SqlDataAdapter da = new SqlDataAdapter(mycmd4);
                var dsClients = new DataSet();
                da.Fill(dsClients);

                dataResultClient.DataSource = dsClients.Tables[0];
            }
            else
            {
                SqlCommand mycmd4 = new SqlCommand("SELECT * FROM Clients ", mycon);
                SqlDataAdapter da = new SqlDataAdapter(mycmd4);
                var dsClients = new DataSet();
                da.Fill(dsClients);
                
                  dataResultClient.DataSource = dsClients.Tables[0];
            }

            mycon.Close();
        }

        private void btn_AddClient_Click(object sender, EventArgs e)
        {
            clsGLobalVariables.method = "add";
            frmClient frmClientAdd = new frmClient();
            frmClientAdd.Show();
            this.Close();
        }

        private void dataResultClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_EditClient_Click(object sender, EventArgs e)
        {
            try
            {
                clsGLobalVariables.method = "edit";
                clsGLobalVariables.Id = dataResultClient.SelectedRows[0].Cells[0].Value.ToString();
                frmClient frmClientAdd = new frmClient();
                frmClientAdd.Show();
            }
            catch
            {
                MessageBox.Show("Please Select the Row of Client you want to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Close();
        }

        private void btn_DeleteClient_Click(object sender, EventArgs e)
        {
            clsGLobalVariables.Id = dataResultClient.SelectedRows[0].Cells[0].Value.ToString();
            
            mycon.Open();
            SqlCommand mycmddeleteClients = new SqlCommand("DELETE FROM Clients WHERE Name ='" + clsGLobalVariables.Id.ToString() + "'", mycon);
            SqlDataAdapter daClientsdelete = new SqlDataAdapter(mycmddeleteClients);
            var dsClientsdelete = new DataSet();
            daClientsdelete.Fill(dsClientsdelete);
            mycon.Close();
            this.Close();
            MessageBox.Show("The Client has been deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmClientsView client = new frmClientsView();
            client.Show();
            
        }
    }
}
