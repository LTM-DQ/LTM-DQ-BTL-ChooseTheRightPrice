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
    public partial class PlayForm : Form
    {
        public static PlayForm instance;
        public Label labelRoomCode;
        public Label[] labelUsers = new Label[4];
        public PictureBox[] pictureBoxUsers = new PictureBox[4];
        public Panel panelStartGame;
        public Panel panelPlaying;
        public Button buttonStartGame;
        Socket client;
        public PlayForm()
        {
            InitializeComponent();
            instance = this;
            client = LoginForm.instance.client;

            labelRoomCode = lblRoomCode;

            labelUsers[0] = lblUser1;
            pictureBoxUsers[0] = picBoxUser1;

            labelUsers[1] = lblUser2;
            pictureBoxUsers[1] = picBoxUser2;

            labelUsers[2] = lblUser3;
            pictureBoxUsers[2] = picBoxUser3;

            labelUsers[3] = lblUser4;
            pictureBoxUsers[3] = picBoxUser4;

            panelStartGame = pnlStartGame;
            panelPlaying = pnlPlaying;

            buttonStartGame = btnStartGame;
        }
        
        private void PlayForm_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            pnlStartGame.Visible = false;
            
            //Send message start game to server

        }

        //Leave room
        private void button1_Click(object sender, EventArgs e)
        {
            //send request to server to join room
            string joinRoomMessage = "EXITRM" + Globals.DELIMITER;
            byte[] msg = Encoding.UTF8.GetBytes(joinRoomMessage);
            Globals.SendMessage(client, msg);
        }
    }
}
