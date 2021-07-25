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
            Thread listen = new Thread(()=> Globals.ReceiveMessage(client));
            listen.IsBackground = true;
            listen.Start();
            txt1 = txtPasswordLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsernameLogin.Text;
            string password = txtPasswordLogin.Text;
            if(username != "" && password != "")
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
            if(txtPasswordLogin.PasswordChar == '*')
            {
                btnHidePass.BringToFront();
                txtPasswordLogin.PasswordChar = '\0';
            }
        }
    }
}

public static class Globals
{
    public const String DELIMITER = "\r\n";
    /// <summary>
    /// send message to server
    /// </summary>
    /// <param name="msg">byte array to send</param> 
    /// <returns>int: 0 if send success, errorCode if fail</returns>
    public static int SendMessage(Socket client, byte[] msg)
    {
        try
        {
            int byteCount = client.Send(msg, 0, msg.Length, SocketFlags.None);
            Console.WriteLine("Sent {0} bytes.", byteCount);
        }
        catch (SocketException e)
        {
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
            return (e.ErrorCode);
        }
        return 0;
    }


    /// <summary>
    /// receive message from server
    /// </summary>
    public static void ReceiveMessage(Socket client)
    {
        try
        {

            while (true)
            {
                byte[] messageRcv = new byte[256];
                // Get reply from the server.
                int byteRcv = client.Receive(messageRcv, 0, client.Available,
                                           SocketFlags.None);
                if (byteRcv > 0)
                {
                    messageRcv[byteRcv] = 0;
                    string dataReceive = Encoding.UTF8.GetString(messageRcv);
                    Console.WriteLine(dataReceive);
                    string opcode = dataReceive.Substring(0, 3);
                    string payload = dataReceive.Substring(4);
                    Console.WriteLine(opcode);
                    Console.WriteLine(payload);
                    handleMessage(opcode, payload);
                }
            }

        }
        catch (Exception)
        {
            Console.WriteLine("Cannot receive message.");
        }

    }

    public static void handleMessage(String opcode, String payload)
    {
        if (opcode == "210")
        {
            //open main form
            Client3.LoginForm.instance.Invoke((MethodInvoker)delegate
            {
                // close the form on the forms thread
                Client3.LoginForm.instance.Hide();
                var mainform1 = new Client3.MainForm();
                mainform1.Closed += (s, args) => Client3.LoginForm.instance.Close();
                mainform1.Show();
            });
        }
    }
}
