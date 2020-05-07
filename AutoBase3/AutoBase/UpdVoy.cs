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
    public partial class UpdVoy : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\AutoBase.mdf;Integrated Security = True");
        VoyageFrm vf1;
        public UpdVoy(VoyageFrm vf)
        {
            InitializeComponent();
            this.vf1 = vf;
        }

        private void UpdVoy_Load(object sender, EventArgs e)
        {
            textBox1.Text = vf1.dgv.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker1.Text = vf1.dgv.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker2.Text = vf1.dgv.CurrentRow.Cells[2].Value.ToString();
          
            comboBox1.Text = vf1.dgv.CurrentRow.Cells[5].Value.ToString();
            textBox2.Text = vf1.dgv.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Text = vf1.dgv.CurrentRow.Cells[3].Value.ToString();
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

       

       
        private void button1_Click_1(object sender, EventArgs e)
        {
             this.Close();
        }

        private void addBtn_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                if (dateTimePicker1.Value.ToOADate() < dateTimePicker2.Value.ToOADate())
                {

                    db.Open();
                    try
                    {

                        string selid = vf1.dgv.CurrentRow.Cells["Название фирмы"].Value.ToString();
                        SqlCommand cmd = db.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Voyage SET NameOrg=N'" + textBox1.Text + "',Date=N'" + dateTimePicker1.Text + "',DateFinish=N'" + dateTimePicker2.Text + "',NameAuto=N'"+comboBox2.Text.ToString()+"',Way=N'" + textBox2.Text + "',Type=N'" + comboBox1.Text + "'  WHERE NameOrg = N'" + selid + "'";
                        cmd.ExecuteNonQuery();

                    }
                    finally
                    {
                        db.Close();
                    }
                    vf1.VoyageFrm_Load(sender, e);
                    this.Close();
                }
                else { MessageBox.Show("Дата отправления должна быть раньше прибытия"); }
            }
            else { MessageBox.Show("Некоторые поля остались пустыми, заполните их!"); }
        }
    }
}
