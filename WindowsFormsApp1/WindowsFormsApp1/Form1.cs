using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void praktDBBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.praktDBBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataBaseDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataBaseDataSet.PraktDB". При необходимости она может быть перемещена или удалена.
            this.praktDBTableAdapter.Fill(this.dataBaseDataSet.PraktDB);

        }

        private void очиститьВсеПоляToolStripMenuItem_Click(object sender, EventArgs e) // Очистка полей ввода данных
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)       // Сохранение
        {
            this.Validate();
            this.praktDBBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataBaseDataSet);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();     // Выход
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)  // Информация о программе
        {
            MessageBox.Show("Программа разработана" + "\n" +
                "студентом группы ИСП-32" + "\n" +
                "Гришковым Кириллом" + "\n" +
                "Для выполнения заданий учебной практики");
        }

        private void button1_Click(object sender, EventArgs e)  // Кнопка добавить
        {
            string
                A1 = textBox1.Text,                     // Наименование организации
                A3 = textBox3.Text,                     //  Название субьекта Рф
                A4 = textBox4.Text,                     // Населенный пункт
                A5 = textBox5.Text;                     // Улица
            int A2 = Convert.ToInt32(textBox2.Text),    // Индекс
                A6 = Convert.ToInt32(textBox6.Text);    // Дом
            this.praktDBTableAdapter.InsertQuery(A1,A2,A3,A4,A5,A6);        // Внесение данных в БД
            this.praktDBTableAdapter.Fill(this.dataBaseDataSet.PraktDB);    // Сохранение данных в БД
        }

        private void button5_Click(object sender, EventArgs e)  // Удалить выбранную строку
        {
            int Code = Convert.ToInt32(textBox14.Text);         // Выбор строки
            this.praktDBTableAdapter.DeleteQuery(Code);         // Удаление
            this.praktDBTableAdapter.Fill(this.dataBaseDataSet.PraktDB);
        }

        private void удалитьВсеToolStripMenuItem_Click(object sender, EventArgs e)  // Удалить все
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить все данные?", "Удалить все", MessageBoxButtons.YesNo);  // Окно подтверждения
            if (dialogResult== DialogResult.Yes)        // Подтверждение
            {
            this.praktDBTableAdapter.DeleteQuery1();    // Удаление всехданных из бд если действие подтверждено
            this.praktDBTableAdapter.Fill(this.dataBaseDataSet.PraktDB);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string
                B1 = textBox8.Text,                     // Наименование организации
                B3 = textBox10.Text,                    //  Название субьекта Рф
                B4 = textBox11.Text,                    // Населенный пункт
                B5 = textBox12.Text;                    // Улица
            int B2 = Convert.ToInt32(textBox9.Text),    // Индекс
                B6 = Convert.ToInt32(textBox13.Text),   // Дом
                BCode = Convert.ToInt32(textBox7.Text);  // Номер
            this.praktDBTableAdapter.UpdateQuery(B1, B2, B3, B4, B5, B6, BCode);
            this.praktDBTableAdapter.Fill(this.dataBaseDataSet.PraktDB);
        }

        private void button6_Click(object sender, EventArgs e)      // Поиск предприятий находящихся в одном городе
        {
            try
            {
                string City = textBox15.Text;
                this.praktDBTableAdapter.FillBy(this.dataBaseDataSet.PraktDB, City);
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)      // Поиск организаций находящихся на одной улице
        {
            try
            {
                string Street = textBox16.Text;
                this.praktDBTableAdapter.FillBy1(this.dataBaseDataSet.PraktDB, Street);
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)  // Кнопка сброс для запросов
        {
            this.praktDBTableAdapter.Fill(this.dataBaseDataSet.PraktDB);
        }
    }
}
