﻿using DBAdmin_v10.Properties;
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
            ChangeUsersScreen changeInfoScreen = new ChangeUsersScreen();
            changeInfoScreen.txtLogin.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            changeInfoScreen.txtPassword.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            changeInfoScreen.txtSurname.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            changeInfoScreen.txtName.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            changeInfoScreen.txtPatronymic.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            changeInfoScreen.txtPosition.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            changeInfoScreen.txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            changeInfoScreen.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DialogResult result = MessageBox.Show(
                    "Вы действительно хотите удалить выбранных пользователей?",
                    "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    List<int> ids = new List<int>();

                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        ids.Add(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    }

                    DeleteUserPresenter preseneter = new DeleteUserPresenter();

                    if (preseneter.DeleteUserFromDB(ids))
                    {
                        MessageBox.Show("Пользователи успешно удалены", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    };
                }

                db = new DataClasses1DataContext();
                dataGridView1.DataSource = db.Users;
            }
            else
            {
                MessageBox.Show(
                    "Выберите пользователей для удаления",
                    "Пользоватеь не выбран!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
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

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonChange_Click(this, null);
        }

        private void buttonPress(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert)
            {
                buttonInsert_Click(this, null);
            }

            if (e.KeyData == Keys.Delete)
            {
                buttonDelete_Click(this, null);
            }
        }
    }
}