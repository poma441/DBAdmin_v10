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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string pattern = @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";
        string pattern1 = "^[А-ЯЁ][а-яё]+$";
        string pattern2 = "^[A-Za-z]+$";


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox2.Text, pattern) == false && textBox2.Text.Length <= 3 && textBox2.Text.Length > 0)
            {
                textBox2.Focus();
                errorProvider1.SetError(this.textBox2, "Пароль должен содержать минимум 1 букву 1 цифру специальный символ и еще че-то");
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "Слишком легкий пароль ";
            }
            else
            {
                errorProvider1.Clear();
            }
            if (Regex.IsMatch(textBox2.Text, pattern) == false && textBox2.Text.Length <= 6 && textBox2.Text.Length > 3)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Пароль должен содержать минимум 1 букву, 1 цифру и 1 специальный символ");
                lblmsg.ForeColor = System.Drawing.Color.Yellow;
                lblmsg.Text = "Средний пароль ";
            }
            else
            {
                errorProvider2.Clear();
            }
            if (Regex.IsMatch(textBox2.Text, pattern) == false && textBox2.Text.Length > 6)
            {
                textBox2.Focus();
                errorProvider3.SetError(this.textBox2, "Пароль должен содержать минимум 1 букву, 1 цифру и 1 специальный символ");
                lblmsg.ForeColor = System.Drawing.Color.Green;
                lblmsg.Text = "Надежный пароль ";
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, pattern2) == false)
            {
                textBox1.Focus();
                errorProvider4.SetError(this.textBox1, "онли инглиш леттерс");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox4.Text, pattern1) == false)
            {
                textBox4.Focus();
                errorProvider5.SetError(this.textBox4, "Имя с большой буквы");
            }
            else
            {
                errorProvider5.Clear();
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox3.Text, pattern1) == false)
            {
                textBox3.Focus();
                errorProvider6.SetError(this.textBox3, "Фамилия с большой буквы");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 0)
            {
                if (Regex.IsMatch(textBox5.Text, pattern1) == false)
                {
                    textBox5.Focus();
                    errorProvider7.SetError(this.textBox5, "Отчество с большой буквы");
                }
                else
                {
                    errorProvider7.Clear();
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 0)
            {
                errorProvider8.SetError(this.textBox6, "Поле не может быть пустым");
            }
            else
            {
                errorProvider8.Clear();
            }
        }
    }
}
