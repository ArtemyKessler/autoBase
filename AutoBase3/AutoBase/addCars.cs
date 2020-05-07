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
    public partial class addCars : Form
    {
        CarsFrm frm;
        SqlConnection db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\AutoBase.mdf;Integrated Security = True");
        public addCars(CarsFrm crm)
        {
            InitializeComponent();
            this.frm = crm;
        }

        private void addCars_Load(object sender, EventArgs e)
        {
            db.Open();
            try
            {

            
            string query = "SELECT Name FROM Riders";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);
            comboBox2.DataSource = tbl;
            comboBox2.DisplayMember = "Name";
            //comboBox2.Items.Add(comboBox2.DisplayMember.ToString());
            }
            finally
            {
         
            db.Close();
                comboBox2.Text = "";
           }
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                db.Open();
                
                    string query = "INSERT INTO Cars (NameAuto,Date,GosNum,Klass,NameRider) VALUES(N'" + textBox1.Text + "','" + numericUpDown1.Value + "',N'" + textBox2.Text + "',N'" + comboBox1.Text + "',N'" + comboBox2.Text.ToString() + "')";
                    SqlDataAdapter sna = new SqlDataAdapter(query, db);
                    sna.SelectCommand.ExecuteNonQuery();


               
                    db.Close();
                    frm.CarsFrm_Load(sender, e);
                
                this.Close();
            }
            else
            { MessageBox.Show("Пожалуйста заполните поля!"); }
                   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
