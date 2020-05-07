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
using System.Timers;

namespace AutoBase
{
    public partial class PrintForm : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\AutoBase.mdf;Integrated Security = True");
        ListForm Lf;

        public PrintForm(ListForm lf1)
        {
            InitializeComponent();
            this.Lf = lf1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            
            Date.Text = DateTime.Now.ToString("dd-MM-yyyy");
                

            
            Rider.Text = Lf.dgv.CurrentRow.Cells[3].Value.ToString();
            N.Text = Lf.dgv.CurrentRow.Cells[0].Value.ToString();
            Auto.Text = Lf.dgv.CurrentRow.Cells[1].Value.ToString();
            Num.Text = Lf.dgv.CurrentRow.Cells[2].Value.ToString();
            db.Open();
            string selid = Lf.dgv.CurrentRow.Cells[0].Value.ToString();

            string query = "SELECT DateTo AS 'Дата выезда', DateFinish AS 'Дата приезда',Way As Маршрут, Type As 'Тип перевозки' FROM List WHERE Id=N'" + selid + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);

            dataGridView1.DataSource = tbl;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.ClearSelection();

            db.Close();



        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);

        }
        Bitmap bmp;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.Show();
            this.Close();
        }
    }
}
