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
    public partial class frmHouses : Form
    {
        public frmHouses()
        {
            InitializeComponent();
        }

        SqlConnection mycon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RemaxDataSet;Integrated Security=True");

        private void btn_AddHouse_Click(object sender, EventArgs e)
        {
            clsGLobalVariables.method = "add";
            this.Close();
            frmHouseAdd frmHouseAdd = new frmHouseAdd();
            frmHouseAdd.Show();
            
        }

        private void frmHouses_Load(object sender, EventArgs e)
        {
            mycon.Open();

            DataTable dtHouses = new DataTable();
            //dtClients = clsGLobalVariables.myset.Tables["Clients"];

            SqlCommand mycmdHouseFetch = new SqlCommand("SELECT * FROM Houses ", mycon);
            SqlDataAdapter daHouseFetch = new SqlDataAdapter(mycmdHouseFetch);
            var dsHouse = new DataSet();
            daHouseFetch.Fill(dsHouse);

            MessageBox.Show("Good we have a data");
            dataHouses.DataSource = dsHouse.Tables[0];
            mycon.Close();
        }

        private void dataHouses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_EditHouse_Click(object sender, EventArgs e)
        {
            clsGLobalVariables.method = "edit";
            this.Close();
            try
            {
                clsGLobalVariables.Id = dataHouses.SelectedRows[0].Cells[0].Value.ToString();
                frmHouseAdd frmHouseAdd = new frmHouseAdd();
                frmHouseAdd.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please Select the Row of House you want to edit","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        
            }
            
        }

        private void btn_DeleteHouse_Click(object sender, EventArgs e)
        {
            clsGLobalVariables.Id = dataHouses.SelectedRows[0].Cells[0].Value.ToString();

            mycon.Open();
            SqlCommand mycmddeleteHouses = new SqlCommand("DELETE FROM Houses WHERE HouseID =" + Convert.ToInt32(clsGLobalVariables.Id.ToString()), mycon);
            SqlDataAdapter daHousesdelete = new SqlDataAdapter(mycmddeleteHouses);
            var dsHousesdelete = new DataSet();
            daHousesdelete.Fill(dsHousesdelete);
            mycon.Close();
            this.Close();
            MessageBox.Show("The Houses has been deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmHouses house = new frmHouses();
            house.Show();
        }
    }
}
