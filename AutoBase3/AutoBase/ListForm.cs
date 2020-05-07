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
    public partial class ListForm : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\AutoBase.mdf;Integrated Security = True");

        public ListForm()
        {
            InitializeComponent();
        }

        

        public void ListForm_Load(object sender, EventArgs e)
        {
            db.Open();

            string query = "SELECT Id AS '№', NameAuto AS Авто , GosNum AS 'Гос.№', NameRider AS Водитель , DateTo AS 'Дата выезда' , DateFinish AS 'Дата возврата',Way AS Маршрут, Type AS 'Тип перевозки' FROM List";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);

            dgv.DataSource = tbl;
           dgv.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

           
                string car = "SELECT * FROM Cars";
                SqlDataAdapter carad = new SqlDataAdapter(car, db);
                DataTable carad1 = new DataTable();
                carad.Fill(carad1);
                comboBox2.DataSource = carad1;
                comboBox2.DisplayMember = "NameAuto";


            string ride = "SELECT * FROM Riders";
            SqlDataAdapter ridad = new SqlDataAdapter(ride, db);
            DataTable rid = new DataTable();
            ridad.Fill(rid);
            comboBox1.DataSource = rid;
            comboBox1.DisplayMember = "Name";


           
            

            
                db.Close();
            
        }
        private void DelBtn_Click(object sender, EventArgs e)
        {
            db.Open();
            try
            {

                string selid = dgv.CurrentRow.Cells[0].Value.ToString();
                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "DELETE FROM List WHERE Id = N'" + selid + "'";
                cmd.ExecuteNonQuery();

            }
            finally
            {
                db.Close();
            }
            ListForm_Load(sender, e);
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            PrintForm pf = new PrintForm(this);
            pf.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListForm_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.Open();
            SqlCommand command = db.CreateCommand();
            command.CommandText = "SELECT COUNT (*) FROM List WHERE NameAuto = N'" + comboBox2.Text.ToString() + "'";
            int val = (int)command.ExecuteScalar();
            if (val != 0)
            {
                string query = "SELECT Id AS '№', NameAuto AS Авто , GosNum AS 'Гос.№', NameRider AS Водитель , DateTo AS 'Дата выезда' , DateFinish AS 'Дата возврата',Way AS Маршрут, Type AS 'Тип перевозки' FROM List WHERE NameAuto = N'" + comboBox2.Text.ToString() + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db);
                DataTable tbl = new DataTable();
                adapter.Fill(tbl);

                dgv.DataSource = tbl;
                dgv.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else { MessageBox.Show("Путевых листов с данной машиной нет!"); }
            db.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.Open();
            SqlCommand command = db.CreateCommand();
            command.CommandText = "SELECT COUNT (*) FROM List WHERE NameRider = N'" + comboBox1.Text.ToString() + "'";
            int val = (int)command.ExecuteScalar();
            if (val != 0)
            {
                string query = "SELECT Id AS '№', NameAuto AS Авто , GosNum AS 'Гос.№', NameRider AS Водитель , DateTo AS 'Дата выезда' , DateFinish AS 'Дата возврата',Way AS Маршрут, Type AS 'Тип перевозки' FROM List WHERE NameRider = N'" + comboBox1.Text.ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);

            dgv.DataSource = tbl;
            dgv.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else { MessageBox.Show("Путевых листов с данным водителем нет!"); }
            db.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.Open();
            SqlCommand command = db.CreateCommand();
            command.CommandText = "SELECT COUNT (*) FROM List WHERE DateTo = N'" + dateTimePicker1.Text + "'";
            int val = (int)command.ExecuteScalar();
            if (val != 0)
            {
                string query = "SELECT Id AS '№', NameAuto AS Авто , GosNum AS 'Гос.№', NameRider AS Водитель , DateTo AS 'Дата выезда' , DateFinish AS 'Дата возврата',Way AS Маршрут, Type AS 'Тип перевозки' FROM List WHERE DateTo = N'" + dateTimePicker1.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);

            dgv.DataSource = tbl;
            dgv.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else { MessageBox.Show("Путевых листов с датой отъезда в этот день нет!"); }
            db.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            db.Open();
            SqlCommand command = db.CreateCommand();
            command.CommandText = "SELECT COUNT (*) FROM List WHERE DateFinish = N'" + dateTimePicker1.Text + "'";
            int val = (int)command.ExecuteScalar();
            if (val != 0)
            {
                string query = "SELECT Id AS '№', NameAuto AS Авто , GosNum AS 'Гос.№', NameRider AS Водитель , DateTo AS 'Дата выезда' , DateFinish AS 'Дата возврата',Way AS Маршрут, Type AS 'Тип перевозки' FROM List WHERE DateFinish = N'" + dateTimePicker1.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db);
                DataTable tbl = new DataTable();
                adapter.Fill(tbl);

                dgv.DataSource = tbl;
                dgv.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else { MessageBox.Show("Путевых листов с датой приезда в этот день нет!"); }
            db.Close();
        }
    }
}
