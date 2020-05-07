using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AutoBase
{
    public partial class CarsFrm : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\AutoBase.mdf;Integrated Security = True");

        public CarsFrm()
        {
            InitializeComponent();
           
        }

        public void CarsFrm_Load(object sender, EventArgs e)
        {
           
            db.Open();

            string query = "SELECT NameAuto AS 'Марка-модель',Date AS 'Год',GosNum AS 'Гос.№',Klass AS Категория,NameRider AS 'ФИО водителя' FROM Cars";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);

            dgv.DataSource = tbl;
            
            dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          

            db.Close();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            db.Open();
            string selid = dgv.CurrentRow.Cells[0].Value.ToString();
            SqlCommand command = db.CreateCommand();
            command.CommandText = "SELECT COUNT (*) FROM Voyage WHERE NameAuto = N'" + selid + "'";
            int val = (int)command.ExecuteScalar();
            

            if (val == 0 )
            {
                try
                {


                    SqlCommand cmd = db.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "DELETE FROM Cars WHERE NameAuto = N'" + selid + "'";
                    cmd.ExecuteNonQuery();

                }
                finally
                {
                    db.Close();
                }
                CarsFrm_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Эта запись используется в другой таблице");
                db.Close();
            }
           
          

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            addCars ac = new addCars(this);
            ac.ShowDialog();
        }

        private void insBtn_Click(object sender, EventArgs e)
        {
            UpdateFrm upf = new UpdateFrm(this);
            upf.ShowDialog();
        }
    }
}
