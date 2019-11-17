using DBAdmin_v10.Properties;
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
    public partial class MainScreen : Form, IAppView
    {
        Image Check = Resources.reload;
        public MainScreen()
        {
            InitializeComponent();
            pictureBox1.Image = Check;
        }

        DataClasses1DataContext db;

        private void MainScreen_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            dataGridView1.DataSource = db.Users;
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Form button1 = new insertUsersScreen();
            button1.ShowDialog();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            dataGridView1.DataSource = db.Users;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {

            Form button1 = new ChangeUsersScreen();
            button1.ShowDialog();
            /*Form3 changeInfoScreen = new Form3();
            changeInfoScreen.txtLogin.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            changeInfoScreen.txtPassword.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            changeInfoScreen.txtSurname.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            changeInfoScreen.txtName.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            changeInfoScreen.txtPatronymic.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            changeInfoScreen.txtPosition.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            changeInfoScreen.ShowDialog();*/
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            DeleteUserPresenter presenter = new DeleteUserPresenter();
            presenter.DeleteUserFromDB(id);
            db = new DataClasses1DataContext();
            dataGridView1.DataSource = db.Users;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            int Check_Width = Check.Width + ((Check.Width * 15) / 100);
            int Check_Height = Check.Height + ((Check.Height * 15) / 100);

            Bitmap Check_1 = new Bitmap(Check_Width, Check_Height);
            Graphics g = Graphics.FromImage(Check_1);
            g.DrawImage(Check, new Rectangle(Point.Empty, Check_1.Size));
            pictureBox1.Image = Check_1;

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            dataGridView1.DataSource = db.Users;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Check;
        }
    }
}
