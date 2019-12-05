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
    public partial class ChangeUsersScreen : Form, IChangeInfoScreen
    {
        private MainScreen mainS;

        public ChangeUsersScreen()
        {
            InitializeComponent();
        }

        public ChangeUsersScreen(MainScreen f)
        {
            InitializeComponent();
            mainS = f;
        }

        private void ChangeUsersScreen_Load(object sender, EventArgs e)
        {

        }
        string pattern0 = @"(?=^.{3,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$";
        //string pattern = @"(?=^.{10,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$";
        string pattern1 = "^[А-ЯЁ][а-яё]+$";
        string pattern2 = @"^(?!Commit)(?!Delete)(?!Insert)(?!Join)(?!Merge)(?!Rollback)(?!Savepoint)(?!Select)(?!Truncate)(?!Union)(?!Update)[a-zA-Z][a-zA-Z0-9-_\.]{1,20}$";

        public string LoginText { get { return txtLogin.Text; } set => txtLogin.Text = value; }
        public string PasswordText { get { return txtPassword.Text; } set => txtPassword.Text = value; }
        public string SurnameText { get { return txtSurname.Text; } set => txtSurname.Text = value; }
        public string NameText { get { return txtName.Text; } set => txtName.Text = value; }
        public string PatronymicText { get { return txtPatronymic.Text; } set => txtPatronymic.Text = value; }
        public string PositionText { get { return txtPosition.Text; } set => txtPosition.Text = value; }
        public string IDText { get { return txtID.Text; } set => txtID.Text = value; }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length == 0 || Regex.IsMatch(txtPassword.Text, pattern0) == false)
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
                lblmsgLogin.Text = "При создании логина использовать \n только английский алфавит, цифры  и символы: \n - и _ (длина логина не менее четырех символов).\n Не используйте зарезервированные слова SQL.";
                errorProvider4.SetError(this.txtLogin, "При создании логина использовать \n только английский алфавит и символы: \n - и _ (длина логина не менее четырех символов) ");
            }
            else
            {
                errorProvider4.Clear();
                lblmsgLogin.Text = "";
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtName.Text, pattern1) == false)
            {
                lblmsgName.ForeColor = Color.FromArgb(78, 184, 206);
                lblmsgName.Text = "Имя с большой буквы";
                txtName.Focus();
                errorProvider5.SetError(this.txtName, "Имя с большой буквы");
            }
            else
            {
                errorProvider5.Clear();
                lblmsgName.Text = "";
            }

        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtSurname.Text, pattern1) == false)
            {
                lblmsgSurname.ForeColor = Color.FromArgb(78, 184, 206);
                lblmsgSurname.Text = "Фамилия с большой буквы";
                txtSurname.Focus();
                errorProvider6.SetError(this.txtSurname, "Фамилия с большой буквы");
            }
            else
            {
                errorProvider6.Clear();
                lblmsgSurname.Text = "";
            }
        }

        private void txtPatronymic_TextChanged(object sender, EventArgs e)
        {
            if (txtPatronymic.Text.Length > 0)
            {
                if (Regex.IsMatch(txtPatronymic.Text, pattern1) == false)
                {
                    lblmsgPatronymic.ForeColor = Color.FromArgb(78, 184, 206);
                    lblmsgPatronymic.Text = "Отчество с большой буквы";
                    txtPatronymic.Focus();
                    errorProvider7.SetError(this.txtPatronymic, "Отчество с большой буквы");
                }
                else
                {
                    errorProvider7.Clear();
                    lblmsgPatronymic.Text = "";
                }
            }
        }

        private void txtPosition_TextChanged(object sender, EventArgs e)
        {
            if (txtPosition.Text.Length == 0)
            {
                lblmsgPosition.ForeColor = Color.FromArgb(78, 184, 206);
                lblmsgPosition.Text = "Поле не может быть пустым";
                errorProvider8.SetError(this.txtPosition, "Поле не может быть пустым");
            }
            else
            {
                errorProvider8.Clear();
                lblmsgPosition.Text = "";
            }
        }

        private void buttonChangeUsrInfo_Click(object sender, EventArgs e)
        {
            if (lblmsgPosition.Text != "" || lblmsgPatronymic.Text != "" || lblmsgSurname.Text != "" || lblmsgName.Text != "" || lblmsgLogin.Text != "" || lblmsg.Text == "Слишком легкий пароль"
               || lblmsg.Text == "Пароль должен содержать минимум одну: \n заглавную букву, цифру и строчную букву \n (длина не менее пяти символов)" || txtLogin.Text == "" || txtPassword.Text == "" || txtSurname.Text == "" || txtName.Text == "" || txtPatronymic.Text == "" || txtPosition.Text == "")
            {
                MessageBox.Show("Incorrect data", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ChangeUserInfoPresenter changeUserPresenter = new ChangeUserInfoPresenter(this);
                if (changeUserPresenter.ChangeUserInfoInDB())
                {
                    MessageBox.Show("Информация о пользователе успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    mainS.MainScreen_Load(sender, e);
                }
                else
                    MessageBox.Show("Не удалось изменить информацию о пользователе(логин уже существует)", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

        private void txtLogin_Click(object sender, EventArgs e)
        {
            panelLogin.BackColor = Color.FromArgb(78, 184, 206);
            txtLogin.ForeColor = Color.FromArgb(78, 184, 206);
            lblLogin.ForeColor = Color.FromArgb(78, 184, 206);

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;
            lblPassword.ForeColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;
            lblSurname.ForeColor = Color.WhiteSmoke;

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;
            lblName.ForeColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;
            lblPatronymic.ForeColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;
            lblPosition.ForeColor = Color.WhiteSmoke;
        }

        private void txtLogin_Enter(object sender, EventArgs e)
        {
            panelLogin.BackColor = Color.FromArgb(78, 184, 206);
            txtLogin.ForeColor = Color.FromArgb(78, 184, 206);
            lblLogin.ForeColor = Color.FromArgb(78, 184, 206);

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;
            lblPassword.ForeColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;
            lblSurname.ForeColor = Color.WhiteSmoke;

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;
            lblName.ForeColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;
            lblPatronymic.ForeColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;
            lblPosition.ForeColor = Color.WhiteSmoke;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {

            panelPassword.BackColor = Color.FromArgb(78, 184, 206);
            txtPassword.ForeColor = Color.FromArgb(78, 184, 206);
            lblPassword.ForeColor = Color.FromArgb(78, 184, 206);

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;
            lblLogin.ForeColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;
            lblSurname.ForeColor = Color.WhiteSmoke;

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;
            lblName.ForeColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;
            lblPatronymic.ForeColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;
            lblPosition.ForeColor = Color.WhiteSmoke;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            panelPassword.BackColor = Color.FromArgb(78, 184, 206);
            txtPassword.ForeColor = Color.FromArgb(78, 184, 206);
            lblPassword.ForeColor = Color.FromArgb(78, 184, 206);

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;
            lblLogin.ForeColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;
            lblSurname.ForeColor = Color.WhiteSmoke;

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;
            lblName.ForeColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;
            lblPatronymic.ForeColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;
            lblPosition.ForeColor = Color.WhiteSmoke;
        }

        private void txtSurname_Click(object sender, EventArgs e)
        {

            txtSurname.ForeColor = Color.FromArgb(78, 184, 206);
            panelSurname.BackColor = Color.FromArgb(78, 184, 206);
            lblSurname.ForeColor = Color.FromArgb(78, 184, 206);

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;
            lblLogin.ForeColor = Color.WhiteSmoke;

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;
            lblPassword.ForeColor = Color.WhiteSmoke;

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;
            lblName.ForeColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;
            lblPatronymic.ForeColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;
            lblPosition.ForeColor = Color.WhiteSmoke;
        }

        private void txtSurname_Enter(object sender, EventArgs e)
        {
            txtSurname.ForeColor = Color.FromArgb(78, 184, 206);
            panelSurname.BackColor = Color.FromArgb(78, 184, 206);
            lblSurname.ForeColor = Color.FromArgb(78, 184, 206);

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;
            lblLogin.ForeColor = Color.WhiteSmoke;

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;
            lblPassword.ForeColor = Color.WhiteSmoke;

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;
            lblName.ForeColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;
            lblPatronymic.ForeColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;
            lblPosition.ForeColor = Color.WhiteSmoke;
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            txtName.ForeColor = Color.FromArgb(78, 184, 206);
            panelName.BackColor = Color.FromArgb(78, 184, 206);
            lblName.ForeColor = Color.FromArgb(78, 184, 206);

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;
            lblLogin.ForeColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;
            lblSurname.ForeColor = Color.WhiteSmoke;

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;
            lblPassword.ForeColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;
            lblPatronymic.ForeColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;
            lblPosition.ForeColor = Color.WhiteSmoke;
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtName.ForeColor = Color.FromArgb(78, 184, 206);
            panelName.BackColor = Color.FromArgb(78, 184, 206);
            lblName.ForeColor = Color.FromArgb(78, 184, 206);

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;
            lblLogin.ForeColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;
            lblSurname.ForeColor = Color.WhiteSmoke;

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;
            lblPassword.ForeColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;
            lblPatronymic.ForeColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;
            lblPosition.ForeColor = Color.WhiteSmoke;
        }

        private void txtPatronymic_Click(object sender, EventArgs e)
        {
            txtPatronymic.ForeColor = Color.FromArgb(78, 184, 206);
            panelPatronymic.BackColor = Color.FromArgb(78, 184, 206);
            lblPatronymic.ForeColor = Color.FromArgb(78, 184, 206);

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;
            lblLogin.ForeColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;
            lblSurname.ForeColor = Color.WhiteSmoke;

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;
            lblPassword.ForeColor = Color.WhiteSmoke;

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;
            lblName.ForeColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;
            lblPosition.ForeColor = Color.WhiteSmoke;
        }

        private void txtPatronymic_Enter(object sender, EventArgs e)
        {
            txtPatronymic.ForeColor = Color.FromArgb(78, 184, 206);
            panelPatronymic.BackColor = Color.FromArgb(78, 184, 206);
            lblPatronymic.ForeColor = Color.FromArgb(78, 184, 206);

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;
            lblLogin.ForeColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;
            lblSurname.ForeColor = Color.WhiteSmoke;

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;
            lblPassword.ForeColor = Color.WhiteSmoke;

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;
            lblName.ForeColor = Color.WhiteSmoke;

            txtPosition.ForeColor = Color.WhiteSmoke;
            panelPosition.BackColor = Color.WhiteSmoke;
            lblPosition.ForeColor = Color.WhiteSmoke;
        }

        private void txtPosition_Click(object sender, EventArgs e)
        {
            txtPosition.ForeColor = Color.FromArgb(78, 184, 206);
            panelPosition.BackColor = Color.FromArgb(78, 184, 206);
            lblPosition.ForeColor = Color.FromArgb(78, 184, 206);

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;
            lblLogin.ForeColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;
            lblSurname.ForeColor = Color.WhiteSmoke;

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;
            lblPassword.ForeColor = Color.WhiteSmoke;

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;
            lblName.ForeColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;
            lblPatronymic.ForeColor = Color.WhiteSmoke;
        }

        private void txtPosition_Enter(object sender, EventArgs e)
        {
            txtPosition.ForeColor = Color.FromArgb(78, 184, 206);
            panelPosition.BackColor = Color.FromArgb(78, 184, 206);
            lblPosition.ForeColor = Color.FromArgb(78, 184, 206);

            txtLogin.ForeColor = Color.WhiteSmoke;
            panelLogin.BackColor = Color.WhiteSmoke;
            lblLogin.ForeColor = Color.WhiteSmoke;

            txtSurname.ForeColor = Color.WhiteSmoke;
            panelSurname.BackColor = Color.WhiteSmoke;
            lblSurname.ForeColor = Color.WhiteSmoke;

            txtPassword.ForeColor = Color.WhiteSmoke;
            panelPassword.BackColor = Color.WhiteSmoke;
            lblPassword.ForeColor = Color.WhiteSmoke;

            txtName.ForeColor = Color.WhiteSmoke;
            panelName.BackColor = Color.WhiteSmoke;
            lblName.ForeColor = Color.WhiteSmoke;

            txtPatronymic.ForeColor = Color.WhiteSmoke;
            panelPatronymic.BackColor = Color.WhiteSmoke;
            lblPatronymic.ForeColor = Color.WhiteSmoke;
        }

        private void buttonChange_MouseMove(object sender, MouseEventArgs e)
        {
            buttonChangeUsrInfo.BackColor = Color.FromArgb(78, 184, 206);
        }

        private void buttonChange_MouseLeave(object sender, EventArgs e)
        {
            buttonChangeUsrInfo.BackColor = Color.FromArgb(78, 184, 206);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
