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
    public partial class UpdateFrm : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\AutoBase.mdf;Integrated Security = True");

        CarsFrm crsf;
        public UpdateFrm(CarsFrm cf)
        {
            InitializeComponent();
            this.crsf = cf;
        }

        private void UpdateFrm_Load(object sender, EventArgs e)
        {
            db.Open();
            string selid = crsf.dgv.CurrentRow.Cells[0].Value.ToString();
            SqlCommand command = db.CreateCommand();
            command.CommandText = "SELECT COUNT (*) FROM Voyage WHERE NameAuto = N'" + selid + "'";
            int val = (int)command.ExecuteScalar();

            if (val > 0)
            { textBox1.Enabled = false; }
            else { }

            textBox1.Text = crsf.dgv.CurrentRow.Cells[0].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(crsf.dgv.CurrentRow.Cells[1].Value.ToString()); 

            textBox2.Text = crsf.dgv.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = crsf.dgv.CurrentRow.Cells[3].Value.ToString();

           

           
            try
            {


                string query = "SELECT Name FROM Riders";//переменная выборки данных из таблицы с переименованием столбцов
                SqlDataAdapter adapter = new SqlDataAdapter(query, db);//команда 
                DataTable tbl = new DataTable();// создание таблицы
                adapter.Fill(tbl);
                comboBox2.DataSource = tbl;
                comboBox2.DisplayMember = "Name";
                //comboBox2.Items.Add(comboBox2.DisplayMember.ToString());
               
            }
            finally
            {
                string name = crsf.dgv.CurrentRow.Cells[4].Value.ToString();

                db.Close();
                comboBox2.Text = name;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                db.Open();
                try
                {

                    string selid = crsf.dgv.CurrentRow.Cells["Марка-Модель"].Value.ToString();
                    SqlCommand cmd = db.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Cars SET NameAuto=N'" + textBox1.Text + "',Date=N'" + numericUpDown1.Value + "',GosNum=N'" + textBox2.Text + "',Klass=N'" + comboBox1.Text + "',NameRider=N'" + comboBox2.Text + "'  WHERE NameAuto = N'" + selid + "'";
                    cmd.ExecuteNonQuery();

                }
                finally
                {
                    db.Close();
                }
                crsf.CarsFrm_Load(sender, e);
                this.Close();
            }
            else { MessageBox.Show("Некоторые поля остались пустыми, заполните их!"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
