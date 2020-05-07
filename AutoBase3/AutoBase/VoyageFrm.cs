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
    public partial class VoyageFrm : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\AutoBase.mdf;Integrated Security = True");

        public VoyageFrm()
        {
            InitializeComponent();
        }

        public void VoyageFrm_Load(object sender, EventArgs e)
        {
            db.Open();

            string query = "SELECT  NameOrg AS 'Название фирмы', Date AS 'Дата выезда', DateFinish AS 'Дата приезда',NameAuto AS Машина,Way AS Маршрут,Type AS Тип FROM Voyage";//переменная выборки данных из таблицы с переименованием столбцов
            SqlDataAdapter adapter = new SqlDataAdapter(query, db);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);

            dgv.DataSource = tbl;
            dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           

            db.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddVoy adv = new AddVoy(this);
            adv.ShowDialog();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            db.Open();
            try
            {

                string selid = dgv.CurrentRow.Cells[0].Value.ToString();
                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "DELETE FROM Voyage WHERE NameOrg = N'" + selid + "'";
                cmd.ExecuteNonQuery();

            }
            finally
            {
                db.Close();
            }
            VoyageFrm_Load(sender, e);
        }

        private void insBtn_Click(object sender, EventArgs e)
        {
            UpdVoy uv = new UpdVoy(this);
            uv.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.Open();
            string query = "INSERT INTO List (DateTo, DateFinish, Way,GosNum, NameRider,Type, NameAuto) SELECT Voyage.Date AS 'Дата Выезда', Voyage.DateFinish AS 'Дата возвращения', Voyage.Way AS 'Маршрут', Cars.GosNum AS 'Гос.№', Cars.NameRider AS 'ФИО водителя', Voyage.Type AS 'Тип перевозки', Cars.NameAuto AS Машина FROM Voyage INNER JOIN Cars ON Voyage.NameOrg =  N'" + dgv.CurrentRow.Cells[0].Value.ToString() + "' AND Cars.NameAuto = Voyage.NameAuto  ";
            SqlDataAdapter sna = new SqlDataAdapter(query, db);

            sna.SelectCommand.ExecuteNonQuery();
            db.Close();

            MessageBox.Show("Путевой лист создан!");
        }
    }
}
