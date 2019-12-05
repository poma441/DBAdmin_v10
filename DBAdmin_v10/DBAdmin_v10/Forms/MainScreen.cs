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
        public MainScreen()
        {
            InitializeComponent();
        }

        DataClasses1DataContext db;

        public void DesignOfDataGridView(System.Windows.Forms.DataGridView dataGridView1)
        {
            dataGridView1.Columns[2].Width = 235;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[7].Width = 200;
            dataGridView1.Columns[5].Width = 125;
            dataGridView1.Columns[4].Width = 125;
            dataGridView1.Columns[3].Width = 125;
            int rowCount = dataGridView1.RowCount;
            for (int i = 0; i < rowCount; ++i)
                dataGridView1.Rows[i].Height = 50;
        }

        public void MainScreen_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            dataGridView1.DataSource = db.Users;
            DesignOfDataGridView(dataGridView1);

        }

        private void buttonPress(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert)
            {
                InsertButton_Click(this, null);
            }

            if (e.KeyData == Keys.Delete)
            {
                DeleteButton_Click(this, null);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ChangeButton_Click(this, null);
        }

        private void MainScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void StripMenuInsert_Click(object sender, EventArgs e)
        {
            InsertButton_Click(this, null);
        }

        private void StripMenuChange_Click(object sender, EventArgs e)
        {
            ChangeButton_Click(this, null);
        }

        private void StripMenuDelete_Click(object sender, EventArgs e)
        {
            DeleteButton_Click(this, null);
        }
     
        private void InsertButton_Click(object sender, EventArgs e)
        {

            insertUsersScreen insertUsr = new insertUsersScreen(this);
             insertUsr.ShowDialog();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            ChangeUsersScreen changeInfoScreen = new ChangeUsersScreen(this);
            changeInfoScreen.txtLogin.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            changeInfoScreen.txtPassword.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            changeInfoScreen.txtSurname.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            changeInfoScreen.txtName.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[5].Value != null)
            {
                changeInfoScreen.txtPatronymic.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                changeInfoScreen.txtPatronymic.Text = null;
            }

            changeInfoScreen.txtPosition.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            changeInfoScreen.txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            changeInfoScreen.ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
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
                DesignOfDataGridView(dataGridView1);
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

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
