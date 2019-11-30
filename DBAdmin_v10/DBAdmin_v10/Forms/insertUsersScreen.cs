using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace DBAdmin_v10
{
    public partial class insertUsersScreen : Form, IInsertScreen
    {
        private MainScreen mainS;

        public insertUsersScreen()
        {
            InitializeComponent();
        }

        public insertUsersScreen(MainScreen f)
        {
            InitializeComponent();
            mainS = f;
        }

        string pattern0 = @"(?=^.{3,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$";
        //string pattern = @"(?=^.{10,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$";
        string pattern1 = "^[А-ЯЁ][а-яё]+$";
        string pattern2 = @"^[a-zA-Z][a-zA-Z0-9-_\.]{3,20}$";

        public string LoginText { get { return txtLogin.Text; } set => txtLogin.Text = value; }
        public string PasswordText { get { return txtPassword.Text; } set => txtPassword.Text = value; }
        public string SurnameText { get { return txtSurname.Text; } set => txtSurname.Text = value; }
        public string NameText { get { return txtName.Text; } set => txtName.Text = value; }
        public string PatronymicText { get { return txtPatronymic.Text; } set => txtPatronymic.Text = value; }
        public string PositionText { get { return txtPosition.Text; } set => txtPosition.Text = value; }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if(txtPassword.Text.Length == 0 || Regex.IsMatch(txtPassword.Text, pattern0) == false)
            {
                lblmsg.ForeColor = Color.FromArgb(78, 184, 206);
                lblmsg.Text = "Пароль должен содержать минимум одну: \n заглавную букву, цифру и строчную букву \n (длина не менее пяти символов)";
            }
            if (Regex.IsMatch(txtPassword.Text, pattern0) == false || txtPassword.Text.Length == 0)
            {
                txtPassword.Focus();
                errorProvider1.SetError(this.txtPassword, "Пароль должен содержать минимум 1 заглавную букву и 1 цифру ");

            }
            else
            {
                if ((txtPassword.Text.Length < 5 && txtPassword.Text.Length > 0) || txtPassword.Text.Length == 0)
                {

                    txtPassword.Focus();
                    errorProvider1.SetError(this.txtPassword, "Пароль должен содержать минимум 1 заглавную букву и 1 цифру ");
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Text = "Слишком легкий пароль ";
                }
                else
                {
                    errorProvider1.Clear();


                }
                if (txtPassword.Text.Length >= 5 && txtPassword.Text.Length < 9)
                {
                    lblmsg.ForeColor = System.Drawing.Color.Yellow;
                    lblmsg.Text = "Средний пароль ";

                }



                if (txtPassword.Text.Length >= 9)
                {
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    lblmsg.Text = "Надежный пароль ";

                }

            }

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
        
            if (Regex.IsMatch(txtLogin.Text, pattern2) == false)
            {

                txtLogin.Focus();
                lblmsgLogin.ForeColor = Color.FromArgb(78, 184, 206);
                lblmsgLogin.Text = "При создании логина использовать \n только английский алфавит, цифры  и символы: \n - и _ (длина логина не менее четырех символов) ";
                errorProvider4.SetError(this.txtLogin, "При создании логина использовать \n только английский алфавит и символы: \n - и _ (длина логина не менее четырех символов) ");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtName.Text, pattern1) == false)
            {
                txtName.Focus();
                errorProvider5.SetError(this.txtName, "Имя с большой буквы");
            }
            else
            {
                errorProvider5.Clear();
            }

        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtSurname.Text, pattern1) == false)
            {
                txtSurname.Focus();
                errorProvider6.SetError(this.txtSurname, "Фамилия с большой буквы");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void txtPatronymic_TextChanged(object sender, EventArgs e)
        {
            if (txtPatronymic.Text.Length > 0)
            {
                if (Regex.IsMatch(txtPatronymic.Text, pattern1) == false)
                {
                    txtPatronymic.Focus();
                    errorProvider7.SetError(this.txtPatronymic, "Отчество с большой буквы");
                }
                else
                {
                    errorProvider7.Clear();
                }
            }
        }

        private void txtPosition_TextChanged(object sender, EventArgs e)
        {
            if (txtPosition.Text.Length == 0)
            {
                errorProvider8.SetError(this.txtPosition, "Поле не может быть пустым");
            }
            else
            {
                errorProvider8.Clear();
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            InsertUserPresenter insertUserPresenter = new InsertUserPresenter(this);

            if (insertUserPresenter.InsertUserToDB())
            {
                MessageBox.Show("Пользователь успешно добавлен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
                mainS.MainScreen_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Не удалось добавить пользователя(логин уже существует)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
            txtLogin.Clear();
            panelLogin.BackColor = Color.FromArgb(78, 184, 206);
            txtLogin.ForeColor = Color.FromArgb(78, 184, 206);

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            panelPassword.BackColor = Color.FromArgb(78, 184, 206);
            txtPassword.ForeColor = Color.FromArgb(78, 184, 206);

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            txtName.Clear();

            txtName.ForeColor = Color.FromArgb(78, 184, 206);
            panelName.BackColor = Color.FromArgb(78, 184, 206);

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;
        }

        private void txtPatronymic_Click(object sender, EventArgs e)
        {
            txtPatronymic.Clear();

            txtPatronymic.ForeColor = Color.FromArgb(78, 184, 206);
            panelPatronymic.BackColor = Color.FromArgb(78, 184, 206);

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;
        }

        private void txtSurname_Click(object sender, EventArgs e)
        {
            txtSurname.Clear();

            txtSurname.ForeColor = Color.FromArgb(78, 184, 206);
            panelSurname.BackColor = Color.FromArgb(78, 184, 206);

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;
        }

        private void txtPosition_Click(object sender, EventArgs e)
        {
            txtPosition.Clear();

            txtPosition.ForeColor = Color.FromArgb(78, 184, 206);
            panelPosition.BackColor = Color.FromArgb(78, 184, 206);

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;
        }

        private void buttonInsert_MouseMove(object sender, MouseEventArgs e)
        {
            buttonInsert.BackColor = Color.FromArgb(78, 184, 206);
        }

        private void buttonInsert_MouseLeave(object sender, EventArgs e)
        {
            buttonInsert.BackColor = Color.FromArgb(78, 184, 206);
        }

    }
}
