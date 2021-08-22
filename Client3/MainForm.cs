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
            Console.WriteLine("Main Form here");
            Console.WriteLine(client);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        //join room at random
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //send request to server to join room
                string joinRoomMessage = "GOINTO" + Globals.DELIMITER;
                byte[] msg = Encoding.UTF8.GetBytes(joinRoomMessage);
                Globals.SendMessage(client, msg);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        //join room by Room Code
        private void button2_Click(object sender, EventArgs e)
        {
            var roomCodeInput = txtRoomCodeInput.Text;
            if(roomCodeInput != "")
            {
                //send request to server to join room
                string joinRoomMessage = "GOINTO " + roomCodeInput + Globals.DELIMITER;
                byte[] msg = Encoding.UTF8.GetBytes(joinRoomMessage);
                Globals.SendMessage(client, msg);
            }
            else
            {
                MessageBox.Show("Please fill the room code");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            //send request create room to server
            string createRoomMessage = "CREATE" + Globals.DELIMITER;
            byte[] msg = Encoding.UTF8.GetBytes(createRoomMessage);
            Globals.SendMessage(client, msg);
        }
        /// <summary>
        /// close mainform and open playform
        /// </summary>
        private void showPlayForm()
        {
            
            Hide();
            var playform = new Client3.PlayForm();
            playform.Closed += (s, args) => this.Close();
            playform.Show();
        }
    }
}
