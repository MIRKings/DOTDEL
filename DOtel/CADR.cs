using DOtel.Properties;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace DOtel
{
    public partial class CADR : Form
    {
        public static string sqlConnection = @"Data Source=DESKTOP-1Q46A8D\SQLEXPRESS;Initial Catalog=Отдел_кадров;Integrated Security=True";
        private SqlConnection Connection = new SqlConnection(sqlConnection);
        private bool IsColl;
        public CADR()
        {
            InitializeComponent();             
        }  
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsColl)
            {
                MENUBUTTON.Image = Resources.Collapse_Arrow_20px;
                panel1.Height += 10;
                if (panel1.Size == panel1.MaximumSize)
                {
                    timer1.Stop();
                    IsColl = false;
                }
            }
            else
            {
                MENUBUTTON.Image = Resources.Expand_Arrow_20px;

                panel1.Height -= 10;
                if (panel1.Size == panel1.MinimumSize)
                {
                    timer1.Stop();
                    IsColl = true;
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }     
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AUTH auth = new AUTH();
            auth.Show();
        }      
        private void CADR_Load(object sender, EventArgs e)
        {            
            Connection.Open();
            // TODO: данная строка кода позволяет загрузить данные в таблицу "отдел_кадровDataSet.Оценка_сотрудников". При необходимости она может быть перемещена или удалена.
            this.оценка_сотрудниковTableAdapter.Fill(this.отдел_кадровDataSet.Оценка_сотрудников);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "отдел_кадровDataSet.Задачи". При необходимости она может быть перемещена или удалена.
            this.задачиTableAdapter.Fill(this.отдел_кадровDataSet.Задачи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "отдел_кадровDataSet.Штатное_расписание". При необходимости она может быть перемещена или удалена.
            this.штатное_расписаниеTableAdapter.Fill(this.отдел_кадровDataSet.Штатное_расписание);
        }
        private void ZADACHIBUTTON_Click(object sender, EventArgs e)
        {
            panelZADACHI.BringToFront();
            panelZADACHI.Visible = true;
            panelZADACHI.Dock = DockStyle.Fill;
        }
        private void raspisanieBUTTON_Click(object sender, EventArgs e)
        {
            panel_RASPIS.BringToFront();
            panel_RASPIS.Visible = true;
            panel_RASPIS.Dock = DockStyle.Fill;

        }
        private void OCENKABUTTON_Click(object sender, EventArgs e)
        {
            
            panelOCENKA.BringToFront();
            panelOCENKA.Visible = true;
            panelOCENKA.Dock = DockStyle.Fill;
        }           
        //УДАЛЕНИЕ 1 ПАНЕЛИ
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить данную строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string del = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string cmdSTR = "DELETE FROM dbo.Штатное_расписание WHERE ID_Штатной_единицы = '" + del + "';";
                SqlCommand command = new SqlCommand(cmdSTR, Connection);
                command.ExecuteNonQuery();                
                this.штатное_расписаниеTableAdapter.Fill(this.отдел_кадровDataSet.Штатное_расписание);
            }
        }
        // УДАЛЕНИЕ 2 ПАНЕЛИ
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить данную строку?", "Удалить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string del = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                string cmdSTR = "DELETE FROM dbo.Задачи WHERE ID_сотрудника = '" + del + "';";
                SqlCommand command = new SqlCommand(cmdSTR, Connection);
                command.ExecuteNonQuery();
                this.задачиTableAdapter.Fill(this.отдел_кадровDataSet.Задачи);
            }
        }
        //УДАЛЕНИЕ 3 ПАНЕЛИ
        private void удалитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить данную строку?", "Удалить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string del = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                string cmdSTR = "DELETE FROM dbo.Оценка_сотрудников WHERE ID_сотрудника = '" + del + "';";
                SqlCommand command = new SqlCommand(cmdSTR, Connection);
                command.ExecuteNonQuery();
                this.оценка_сотрудниковTableAdapter.Fill(this.отдел_кадровDataSet.Оценка_сотрудников);
            }
        }
        //СОРТИРОВКА 1 ПАНЕЛИ 
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox2.Text == "По убыванию")
            {
                dataGridView1.Sort(dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex], ListSortDirection.Descending);

            }
            else if (toolStripComboBox2.Text == " По возрастанию")
            {
                dataGridView1.Sort(dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex], ListSortDirection.Ascending);
            }
        }
        //СОРТИРОВКА 2 ПАНЕЛИ
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox3.Text == "По убыванию")
            {
                dataGridView2.Sort(dataGridView2.Columns[dataGridView2.CurrentCell.ColumnIndex], ListSortDirection.Descending);
            }
            else if (toolStripComboBox3.Text == " По возрастанию")
            {
                dataGridView2.Sort(dataGridView2.Columns[dataGridView2.CurrentCell.ColumnIndex], ListSortDirection.Ascending);
            }
        }
        // СОРТИРОВКА 3 ПАНЕЛИ
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
         if (toolStripComboBox1.Text == "По убыванию")
            {
                dataGridView3.Sort(dataGridView3.Columns[dataGridView3.CurrentCell.ColumnIndex], ListSortDirection.Descending);
            }
            else if (toolStripComboBox1.Text == " По возрастанию")
            {
                dataGridView3.Sort(dataGridView3.Columns[dataGridView3.CurrentCell.ColumnIndex], ListSortDirection.Ascending);
            }
        }
        //задачи
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            задачиTableAdapter.Update(отдел_кадровDataSet.Задачи);
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            оценка_сотрудниковTableAdapter.Update(отдел_кадровDataSet.Оценка_сотрудников);
        }
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            штатное_расписаниеTableAdapter.Update(отдел_кадровDataSet.Штатное_расписание);
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            CADR cadr = new CADR();
            cadr.Show();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
             CADR cadr = new CADR();
            cadr.Show();
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
             CADR cadr = new CADR();
            cadr.Show();
        }
        //удалить всё штатное расписание
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = new object();            
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = new object();
        }
        //СПРАВКА
        private void сПРАВКАToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для того что бы просмотреть существующие разделы, нажмите на кнопку МЕНЮ.\n" +
                "Перед вами развернется меню приложения.\n" +
                "Нажмите на кнопку Штатное расписание:\n" +
                "Вы моежете добавлять и изменять данные, также удалять и сортировать в отдельном порядке. \n" +
                "Внизу окна штатное расписание разверенется еще одно меню для сохранение информации в базе данных. \n"+
                "Так же вы можете открыть ещё 1 окно для удобности работы.\n" +
                "В Меню задачи вы можете распределять задачи сотрудников удаленно, так же отслеживать их выполнение. \n" +
                "В меню оценки сотрудников, прошедших аттестацию вы можете оценить их.",
                "СПРАВКА", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //О ПРОГРАММЕ
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Windows Forms(.NET Framework 4.7.2\n" +
                "Приложение НИИ РОССТАТ для десктопной работы (1.0)" +
                "12.03.2020 ", "О ПРОГРАММЕ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
