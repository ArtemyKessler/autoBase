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
    public partial class AddVoy : Form
    {
        VoyageFrm frm;
        SqlConnection db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\AutoBase.mdf;Integrated Security = True");

        public AddVoy(VoyageFrm vf)
        {
            InitializeComponent();
            this.frm = vf;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddVoy_Load(object sender, EventArgs e)
        {
            db.Open();
            try
            {


                string query = "SELECT NameAuto FROM Cars";//переменная выборки данных из таблицы с переименованием столбцов
                SqlDataAdapter adapter = new SqlDataAdapter(query, db);//команда 
                DataTable tbl = new DataTable();// создание таблицы
                adapter.Fill(tbl);
                comboBox2.DataSource = tbl;
                comboBox2.DisplayMember = "NameAuto";
               // comboBox2.Items.Add(comboBox2.DisplayMember.ToString());

            }
            finally
            {


                db.Close();

            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""  && comboBox1.Text != "")
            {
                if (dateTimePicker1.Value.ToOADate() > dateTimePicker2.Value.ToOADate())
                {
                    MessageBox.Show("Дата отправления должна быть раньше прибытия");
                }

                else
                {
                    db.Open();
                    string way = textBox2.Text + " - " + textBox3.Text;
                    string query = "INSERT INTO Voyage (NameOrg,Date,DateFinish,NameAuto,Way,Type) VALUES(N'" + textBox1.Text + "',N'" + this.dateTimePicker1.Text + "',N'" + this.dateTimePicker2.Text + "',N'"+comboBox2.Text.ToString()+"',N'" + way + "',N'" + comboBox1.Text.ToString() + "')";
                    SqlDataAdapter sna = new SqlDataAdapter(query, db);
                    sna.SelectCommand.ExecuteNonQuery();



                    db.Close();
                    frm.VoyageFrm_Load(sender, e);

                    this.Close();
                }
            }
            
        }
    }
}
