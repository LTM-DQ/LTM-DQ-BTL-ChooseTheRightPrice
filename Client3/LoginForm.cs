using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client3.Properties;

namespace Client3
{
    public partial class LoginForm : Form
    {
        public static LoginForm instance;
        IPEndPoint IP;
        public Socket client;
        public TextBox txt1;
        public LoginForm()
        {
            InitializeComponent();
            instance = this;
            ConnectServer();
            Thread listen = new Thread(() => Globals.ReceiveMessage(client));
            listen.IsBackground = true;
            listen.Start();
            txt1 = txtPasswordLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsernameLogin.Text;
            string password = txtPasswordLogin.Text;
            if (username != "" && password != "")
            {
                string loginMessage = "SIGNIN " + username + "\n" + password + Globals.DELIMITER;
                byte[] msg = Encoding.UTF8.GetBytes(loginMessage);
                Globals.SendMessage(client, msg);
            }
            else
            {
                MessageBox.Show("Username or password isn't correct.");
            }

        }


        /// <summary>
        /// Kết nối tới server
        /// </summary>
        void ConnectServer()
        {
            try
            {
                IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5500);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(IP);

            }
            catch (Exception)
            {
                MessageBox.Show("Connect fail !");
            }

        }

        /// <summary>
        /// close connection to server
        /// </summary>
        void CloseConnection()
        {
            client.Close();
        }



        private void handleMessage(String opcode, String payload)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnHidePass_Click(object sender, EventArgs e)
        {
            if (txtPasswordLogin.PasswordChar == '\0')
            {
                btnShowPass.BringToFront();
                txtPasswordLogin.PasswordChar = '*';
            }
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (txtPasswordLogin.PasswordChar == '*')
            {
                btnHidePass.BringToFront();
                txtPasswordLogin.PasswordChar = '\0';
            }
        }

    }
}


