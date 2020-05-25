using System;
using System.Windows.Forms;
namespace DOtel
{
    public partial class SOTR : Form
    {               
        public SOTR()
        {
            InitializeComponent();
        }

        private void SOTR_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "отдел_кадровDataSet.Задачи". При необходимости она может быть перемещена или удалена.
            this.задачиTableAdapter.Fill(this.отдел_кадровDataSet.Задачи);
            label4.Text = AUTH.myLogin;           
            ID.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            status.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }       
    }
}
