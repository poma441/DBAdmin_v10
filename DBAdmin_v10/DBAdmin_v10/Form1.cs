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

     
    }
}
