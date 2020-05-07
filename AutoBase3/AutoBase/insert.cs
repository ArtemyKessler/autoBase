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
    public partial class insert : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\AutoBase.mdf;Integrated Security = True");

        Form2 frm2;
        public insert(Form2 fg)
        {
            InitializeComponent();
            this.frm2 = fg;
        }

        public void insert_Load(object sender, EventArgs e)
        {
            db.Open();
            string selid = frm2.dgv.CurrentRow.Cells["ФИО"].Value.ToString();
            SqlCommand command = db.CreateCommand();
            command.CommandText = "SELECT COUNT (*) FROM Cars WHERE NameRider = N'" + selid + "'";
            int val = (int)command.ExecuteScalar();
            db.Close();
            if (val > 0)
            { textBox1.Enabled = false; }
            
                textBox1.Text= frm2.dgv.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = frm2.dgv.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = frm2.dgv.CurrentRow.Cells[3].Value.ToString();
           
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void insBtn_Click(object sender, EventArgs e)

        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                db.Open();

                try
                {
                   
                    string selid = frm2.dgv.CurrentRow.Cells["ФИО"].Value.ToString();
                    SqlCommand cmd = db.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "UPDATE Riders SET RidDock=N'" + textBox2.Text + "',Klass=N'" + comboBox1.Text + "'  WHERE Name = N'" + selid + "'";
                    cmd.ExecuteNonQuery();
                    

                }
                finally
                {
                    db.Close();
                    this.Close();
                }
                frm2.Form2_Load(sender, e);
            }
            else { MessageBox.Show("Некоторые поля остались пустыми, заполните их!"); }



            

        }
    }
}
