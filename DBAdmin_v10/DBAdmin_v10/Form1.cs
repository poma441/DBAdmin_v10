using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBAdmin_v10
{
    public partial class Form1 : Form, IAppView
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataClasses1DataContext db;

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            dataGridView1.DataSource = db.Users;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form button1 = new Form2();
            button1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            dataGridView1.DataSource = db.Users;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*Form3 changeInfoScreen = new Form3();
            changeInfoScreen.txtLogin.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            changeInfoScreen.txtPassword.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            changeInfoScreen.txtSurname.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            changeInfoScreen.txtName.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            changeInfoScreen.txtPatronymic.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            changeInfoScreen.txtPosition.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            changeInfoScreen.ShowDialog();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            DeleteUserPresenter presenter = new DeleteUserPresenter();
            presenter.DeleteUserFromDB(id);
            db = new DataClasses1DataContext();
            dataGridView1.DataSource = db.Users;
        }
    }
}
