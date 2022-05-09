using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CARшеринг
{
    public partial class car : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= ARM.accdb";
        private OleDbConnection myConnection;
        public car()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void car_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aRMDataSet.Автомобили". При необходимости она может быть перемещена или удалена.
            this.автомобилиTableAdapter.Fill(this.aRMDataSet.Автомобили);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ля добавления автомобиля стоит перейти на кнопку добавить. Для удаления автомобиля, стоит перейти на кнопку Удалить.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string query = "SELECT [Код автомобиля], Марка, Модель, [Суточная цена], [Цена автомобиля] FROM Автомобили WHERE [Код автомобиля] LIKE '%" + Name + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView1.DataSource = автомобилиBindingSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 af = new Form1();
            af.Owner = this;
            af.Show();
        }

        private void car_Activated(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView1.DataSource = автомобилиBindingSource;
            this.автомобилиTableAdapter.Fill(this.aRMDataSet.Автомобили);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM Автомобили WHERE [Код автомобиля] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.автомобилиTableAdapter.Fill(this.aRMDataSet.Автомобили);
            textBox1.Clear();
        }
    }
}
