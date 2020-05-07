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
    public partial class Form2 : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\AutoBase.mdf;Integrated Security = True");




        public Form2()
        {
         
            InitializeComponent();
               
        }
        
        
        public void Form2_Load(object sender, EventArgs e)
        { 
            db.Open();
                     
                string query = "SELECT Id, Name AS ФИО, RidDock AS '№Вод.Уд.', Klass AS Категория FROM Riders";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db); 
                DataTable tbl = new DataTable();
                adapter.Fill(tbl);
            
                dgv.DataSource = tbl;
                dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns[0].Visible = false;
               
            db.Close();

        }
       
        private void addBtn_Click(object sender, EventArgs e)
        {
            addRid f3 = new addRid(this);
            f3.ShowDialog();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            db.Open();
            string selid = dgv.CurrentRow.Cells["ФИО"].Value.ToString();
            SqlCommand command = db.CreateCommand();
           command.CommandText = "SELECT COUNT (*) FROM Cars WHERE NameRider = N'"+selid+"'";
            int val = (int)command.ExecuteScalar();
         
            if (val == 0)
            {
                try
                {

                   
                    SqlCommand cmd = db.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "DELETE FROM Riders WHERE Name = N'" + selid + "'";
                    cmd.ExecuteNonQuery();

                }
                finally
                {
                    db.Close();
                }
                Form2_Load(sender, e);
            }
            else { MessageBox.Show("Эта запись используется в другой таблице");
                db.Close();
            }
           
        }

        private void insBtn_Click(object sender, EventArgs e)
        {

            
                insert f4 = new insert(this);
                    f4.ShowDialog();

           
       
           

        }
    }
}
