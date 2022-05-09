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
    public partial class Form1 : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= ARM.accdb"; //Обозначение базы данных
        private OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);//Подключение к БД
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Name = textBox2.Text;
            string Model = textBox3.Text;
            string PriceDay = textBox4.Text;
            string Price = textBox5.Text;
            string query = "INSERT INTO Автомобили ([Марка],[Модель],[Суточная цена],[Цена автомобиля]) VALUES ('" + Name + "','" + Model + "','"+PriceDay+"','"+Price+"')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.Close();
        }
    }
}
