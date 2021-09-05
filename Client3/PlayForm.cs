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
using System.Net.Sockets;

namespace Client3
{
    public partial class PlayForm : Form
    {
        public static PlayForm instance;
        public Label labelRoomCode, lblResult;
        public Label labelQues;
        public Timer countDownTimePlay, countDownTimeWait;
        public Label[] labelUsers = new Label[4];
        public Label[] labelAnswers = new Label[4];
        public PictureBox[] pictureBoxUsers = new PictureBox[4];
        public Panel panelStartGame;
        public Panel panelPlaying;
        public Panel labelCountDown;
        public Button buttonStartGame;
        public DataGridView tableScore;
        Socket client;
        public int i;

        public PlayForm()
        {
            InitializeComponent();
            instance = this;
            client = LoginForm.instance.client;

            labelRoomCode = lblRoomCode;
            client = LoginForm.instance.client;
            labelQues = lblQuestion;
            countDownTimePlay = timer1;
            countDownTimeWait = timer2;

            labelUsers[0] = lblUser1;
            pictureBoxUsers[0] = picBoxUser1;
            labelAnswers[0] = labelAnswer0;

            labelUsers[1] = lblUser2;
            pictureBoxUsers[1] = picBoxUser2;
            labelAnswers[1] = labelAnswer1;

            labelUsers[2] = lblUser3;
            pictureBoxUsers[2] = picBoxUser3;
            labelAnswers[2] = labelAnswer2;

            labelUsers[3] = lblUser4;
            pictureBoxUsers[3] = picBoxUser4;
            labelAnswers[3] = labelAnswer3;

            panelStartGame = pnlStartGame;
            panelPlaying = pnlPlaying;

            buttonStartGame = btnStartGame;
            i = 5;
            tableScore = dataGridView2;
            lblResult = labelResult;
        }
        
        private void PlayForm_Load(object sender, EventArgs e)
        {

        }

        private void PlayForm_FormClosing(object sender, FormClosingEventArgs e)
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
            //Send message start game to server
            string message = "STARTT " + Globals.DELIMITER;
            byte[] msg = Encoding.UTF8.GetBytes(message);
            Globals.SendMessage(client, msg);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i--;
            lblCountDown.Text = i.ToString();
            if (i == 0)
            {
                var answer = txtAnswer.Text;
                timer1.Enabled = false;
                i = 5;
                lblCountDown.Text = i.ToString();
                string message;
                if (answer != "")
                    message = "ANSWER " + answer + Globals.DELIMITER;
                else
                    message = "ANSWER " + Globals.DELIMITER;
                byte[] msg = Encoding.UTF8.GetBytes(message);
                Globals.SendMessage(client, msg);
                timer2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        //Leave room
        private void button1_Click(object sender, EventArgs e)
        {
            //send request to server to join room
            string joinRoomMessage = "EXITRM" + Globals.DELIMITER;
            byte[] msg = Encoding.UTF8.GetBytes(joinRoomMessage);
            Globals.SendMessage(client, msg);
        }

        private void lblCountDown_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            i--;
            lblCountDown.Text = i.ToString();
            if (i == 0)
            {
                timer2.Enabled = false;
                i = 2;
                lblCountDown.Text = i.ToString();
                string message = "QUIZZZ " + Globals.DELIMITER;
                byte[] msg = Encoding.UTF8.GetBytes(message);
                Globals.SendMessage(client, msg);
                timer1.Enabled = true;
                labelResult.Text = "0";
            }
        }
    }
}
