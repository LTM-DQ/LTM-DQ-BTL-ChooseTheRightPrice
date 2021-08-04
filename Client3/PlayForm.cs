using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public PictureBox pictureBoxUser1;
        public PlayForm()
        {
            InitializeComponent();
            instance = this;
            labelRoomCode = lblRoomCode;
            labelUsers[0] = lblUser1;
            pictureBoxUser1 = picBoxUser1;
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
    }
}
