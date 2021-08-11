using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Client3
{
    public partial class PlayForm : Form
    {
        public static PlayForm instance;
        public Label labelRoomCode;
        public Label labelQues;
        public Timer countDownTime;
        public Label[] labelUsers = new Label[4];
        public PictureBox[] pictureBoxUsers = new PictureBox[4];
        Socket client;
        public int i;

        public PlayForm()
        {
            InitializeComponent();
            instance = this;
            labelRoomCode = lblRoomCode;
            client = LoginForm.instance.client;
            labelQues = lblQuestion;
            countDownTime = timer1;

            labelUsers[0] = lblUser1;
            pictureBoxUsers[0] = picBoxUser1;

            labelUsers[1] = lblUser2;
            pictureBoxUsers[1] = picBoxUser2;

            labelUsers[2] = lblUser3;
            pictureBoxUsers[2] = picBoxUser3;

            labelUsers[3] = lblUser4;
            pictureBoxUsers[3] = picBoxUser4;

            i = 30;
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
            string message = "STARTT " + Globals.DELIMITER;
            byte[] msg = Encoding.UTF8.GetBytes(message);
            Globals.SendMessage(client, msg);

            message = "QUIZZZ " + Globals.DELIMITER;
            msg = Encoding.UTF8.GetBytes(message);
            Globals.SendMessage(client, msg);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i--;
            lblCountDown.Text = i.ToString();
            if (i == 0)
            {
                timer1.Enabled = false;
                i = 30;
                lblCountDown.Text = i.ToString();
            }
        }
    }
}
