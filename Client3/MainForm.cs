using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client3
{
    public partial class MainForm : Form
    {
        public static MainForm instance;
        Socket client;
        public MainForm()
        {
            InitializeComponent();
            instance = this;
            client = LoginForm.instance.client;
            Console.WriteLine(client);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
