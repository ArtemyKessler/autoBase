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
    public partial class addRid : Form
    {
        Form2 frm2;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\AutoBase.mdf;Integrated Security = True");
        public addRid(Form2 fg)
        {
            
        InitializeComponent();
            this.frm2 = fg;
        }
       
         private void addRid_Load(object sender, EventArgs e)
        {

        }

      
       
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                con.Open();
                string query = "INSERT INTO Riders (Name, RidDock, Klass) VALUES(N'" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + comboBox1.Text + "')";
                SqlDataAdapter sna = new SqlDataAdapter(query, con);
                sna.SelectCommand.ExecuteNonQuery();
                con.Close();
                frm2.Form2_Load(sender, e);
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
