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

        string patternForValidationPassword = @"(?=^.{3,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$";
        string patternForValidationNameSurnamePatronymic = "^[А-ЯЁ][а-яё]+$";
        string patternForValidationLogin = @"^(?!Commit)(?!Delete)(?!Insert)(?!Join)(?!Merge)(?!Rollback)(?!Savepoint)(?!Select)(?!Truncate)(?!Union)(?!Update)[a-zA-Z][a-zA-Z0-9-_\.]{1,20}$";
        int shortPassLength = 5;
        int mediumPassLength = 9;
        int emptyField = 0;
        int shortLoginLength = 4;
        public string LoginText { get { return txtLogin.Text; } set => txtLogin.Text = value; }
        public string PasswordText { get { return txtPassword.Text; } set => txtPassword.Text = value; }
        public string SurnameText { get { return txtSurname.Text; } set => txtSurname.Text = value; }
        public string NameText { get { return txtName.Text; } set => txtName.Text = value; }
        public string PatronymicText { get { return txtPatronymic.Text; } set => txtPatronymic.Text = value; }
        public string PositionText { get { return txtPosition.Text; } set => txtPosition.Text = value; }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length == emptyField || Regex.IsMatch(txtPassword.Text, patternForValidationPassword) == false)
            {
                lblmsg.ForeColor = Color.FromArgb(78, 184, 206);
                lblmsg.Text = "Пароль должен содержать минимум одну: \n заглавную букву, цифру и строчную букву \n (длина не менее пяти символов)";
            }
            if (Regex.IsMatch(txtPassword.Text, patternForValidationPassword) == false || txtPassword.Text.Length == emptyField)
            {
                txtPassword.Focus();
                errorProviderPassword.SetError(this.txtPassword, "Пароль должен содержать минимум 1 заглавную букву и 1 цифру ");

            }
            else
            {
                if ((txtPassword.Text.Length < shortPassLength && txtPassword.Text.Length > 0) || txtPassword.Text.Length == emptyField)
                {

                    txtPassword.Focus();
                    errorProviderPassword.SetError(this.txtPassword, "Пароль должен содержать минимум 1 заглавную букву и 1 цифру ");
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Text = "Слишком легкий пароль ";
                }
                else
                {
                    errorProviderPassword.Clear();


                }
                if (txtPassword.Text.Length >= shortPassLength && txtPassword.Text.Length < mediumPassLength)
                {
                    lblmsg.ForeColor = System.Drawing.Color.Yellow;
                    lblmsg.Text = "Средний пароль ";

                }



                if (txtPassword.Text.Length >= mediumPassLength)
                {
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    lblmsg.Text = "Надежный пароль ";

                }

            }

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

            if (Regex.IsMatch(txtLogin.Text, patternForValidationLogin) == false || txtLogin.Text.Length < shortLoginLength)
            {

                txtLogin.Focus();
                lblmsgLogin.ForeColor = Color.FromArgb(78, 184, 206);
                lblmsgLogin.Text = "При создании логина использовать \n только английский алфавит, цифры  и символы: \n - и _ (длина логина не менее четырех символов).\n Не используйте зарезервированные слова SQL.";
                errorProviderLogin.SetError(this.txtLogin, "При создании логина использовать \n только английский алфавит и символы: \n - и _ (длина логина не менее четырех символов) ");
            }
            else
            {
                errorProviderLogin.Clear();
                lblmsgLogin.Text = "";
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtName.Text, patternForValidationNameSurnamePatronymic) == false)
            {
                lblmsgName.ForeColor = Color.FromArgb(78, 184, 206);
                lblmsgName.Text = "Имя с большой буквы";
                txtName.Focus();
                errorProviderName.SetError(this.txtName, "Имя с большой буквы");
            }
            else
            {
                errorProviderName.Clear();
                lblmsgName.Text = "";
            }

        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtSurname.Text, patternForValidationNameSurnamePatronymic) == false)
            {
                lblmsgSurname.ForeColor = Color.FromArgb(78, 184, 206);
                lblmsgSurname.Text = "Фамилия с большой буквы";
                txtSurname.Focus();
                errorProviderSurname.SetError(this.txtSurname, "Фамилия с большой буквы");
            }
            else
            {
                errorProviderSurname.Clear();
                lblmsgSurname.Text = "";
            }
        }

        private void txtPatronymic_TextChanged(object sender, EventArgs e)
        {
            if (txtPatronymic.Text.Length > emptyField)
            {
                if (Regex.IsMatch(txtPatronymic.Text, patternForValidationNameSurnamePatronymic) == false)
                {
                    lblmsgPatronymic.ForeColor = Color.FromArgb(78, 184, 206);
                    lblmsgPatronymic.Text = "Отчество с большой буквы";
                    txtPatronymic.Focus();
                    errorProviderPatronymic.SetError(this.txtPatronymic, "Отчество с большой буквы");
                }
                else
                {
                    errorProviderPatronymic.Clear();
                    lblmsgPatronymic.Text = "";
                }
            }
            else
            {
                errorProviderPatronymic.Clear();
                lblmsgPatronymic.Text = "";
            }
        }

        private void txtPosition_TextChanged(object sender, EventArgs e)
        {
            if (txtPosition.Text.Length == emptyField)
            {
                lblmsgPosition.ForeColor = Color.FromArgb(78, 184, 206);
                lblmsgPosition.Text = "Поле не может быть пустым";
                errorProviderPosition.SetError(this.txtPosition, "Поле не может быть пустым");
            }
            else
            {
                errorProviderPosition.Clear();
                lblmsgPosition.Text = "";
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (lblmsgPosition.Text != "" || lblmsgSurname.Text != "" || lblmsgName.Text != "" || lblmsgLogin.Text != "" || lblmsg.Text == "Слишком легкий пароль"
               || lblmsg.Text == "Пароль должен содержать минимум одну: \n заглавную букву, цифру и строчную букву \n (длина не менее пяти символов)" || txtLogin.Text == "" || txtPassword.Text == "" || txtSurname.Text == "" || txtName.Text == "" || txtPosition.Text == "")
            {
                MessageBox.Show("Некорректно введены данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
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
        }
   
        private void buttonInsert_MouseMove(object sender, MouseEventArgs e)
        {
            buttonInsert.BackColor = Color.FromArgb(78, 184, 206);
        }

        private void buttonInsert_MouseLeave(object sender, EventArgs e)
        {
            buttonInsert.BackColor = Color.FromArgb(78, 184, 206);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
