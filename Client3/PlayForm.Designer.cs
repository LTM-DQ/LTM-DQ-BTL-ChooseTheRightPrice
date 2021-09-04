namespace Client3
{
    partial class PlayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPlaying = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.pnlStartGame = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelAnswer3 = new System.Windows.Forms.Label();
            this.labelAnswer2 = new System.Windows.Forms.Label();
            this.labelAnswer1 = new System.Windows.Forms.Label();
            this.labelAnswer0 = new System.Windows.Forms.Label();
            this.lblUser4 = new System.Windows.Forms.Label();
            this.lblUser3 = new System.Windows.Forms.Label();
            this.lblUser2 = new System.Windows.Forms.Label();
            this.lblUser1 = new System.Windows.Forms.Label();
            this.picBoxUser4 = new System.Windows.Forms.PictureBox();
            this.picBoxUser3 = new System.Windows.Forms.PictureBox();
            this.picBoxUser1 = new System.Windows.Forms.PictureBox();
            this.picBoxUser2 = new System.Windows.Forms.PictureBox();
            this.lblRoomCode = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPlaying.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlStartGame.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(861, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Leave";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "RoomCode";
            // 
            // pnlPlaying
            // 
            this.pnlPlaying.Controls.Add(this.dataGridView2);
            this.pnlPlaying.Controls.Add(this.label4);
            this.pnlPlaying.Controls.Add(this.button2);
            this.pnlPlaying.Controls.Add(this.txtAnswer);
            this.pnlPlaying.Controls.Add(this.pictureBox1);
            this.pnlPlaying.Controls.Add(this.lblQuestion);
            this.pnlPlaying.Controls.Add(this.lblCountDown);
            this.pnlPlaying.Location = new System.Drawing.Point(20, 65);
            this.pnlPlaying.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPlaying.Name = "pnlPlaying";
            this.pnlPlaying.Size = new System.Drawing.Size(958, 332);
            this.pnlPlaying.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(700, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Price You Guess";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(702, 216);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 54);
            this.button2.TabIndex = 8;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtAnswer
            // 
            this.txtAnswer.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnswer.Location = new System.Drawing.Point(702, 145);
            this.txtAnswer.Margin = new System.Windows.Forms.Padding(2);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(192, 32);
            this.txtAnswer.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Client3.Properties.Resources.egg;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(361, 86);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 227);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(406, 39);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(215, 20);
            this.lblQuestion.TabIndex = 5;
            this.lblQuestion.Text = "What is the price of 10 eggs?";
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.Location = new System.Drawing.Point(881, 15);
            this.lblCountDown.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(55, 37);
            this.lblCountDown.TabIndex = 4;
            this.lblCountDown.Text = "30";
            // 
            // pnlStartGame
            // 
            this.pnlStartGame.Controls.Add(this.label5);
            this.pnlStartGame.Controls.Add(this.btnStartGame);
            this.pnlStartGame.Location = new System.Drawing.Point(19, 61);
            this.pnlStartGame.Margin = new System.Windows.Forms.Padding(2);
            this.pnlStartGame.Name = "pnlStartGame";
            this.pnlStartGame.Size = new System.Drawing.Size(957, 343);
            this.pnlStartGame.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(347, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(207, 35);
            this.label5.TabIndex = 1;
            this.label5.Text = "What\'s up bros";
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStartGame.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.ForeColor = System.Drawing.Color.White;
            this.btnStartGame.Location = new System.Drawing.Point(329, 154);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(235, 79);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "Start game";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelAnswer3);
            this.panel2.Controls.Add(this.labelAnswer2);
            this.panel2.Controls.Add(this.labelAnswer1);
            this.panel2.Controls.Add(this.labelAnswer0);
            this.panel2.Controls.Add(this.lblUser4);
            this.panel2.Controls.Add(this.lblUser3);
            this.panel2.Controls.Add(this.lblUser2);
            this.panel2.Controls.Add(this.lblUser1);
            this.panel2.Controls.Add(this.picBoxUser4);
            this.panel2.Controls.Add(this.picBoxUser3);
            this.panel2.Controls.Add(this.picBoxUser1);
            this.panel2.Controls.Add(this.picBoxUser2);
            this.panel2.Location = new System.Drawing.Point(20, 402);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(958, 198);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // labelAnswer3
            // 
            this.labelAnswer3.AutoSize = true;
            this.labelAnswer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswer3.Location = new System.Drawing.Point(758, 9);
            this.labelAnswer3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAnswer3.Name = "labelAnswer3";
            this.labelAnswer3.Size = new System.Drawing.Size(51, 20);
            this.labelAnswer3.TabIndex = 11;
            this.labelAnswer3.Text = "label7";
            // 
            // labelAnswer2
            // 
            this.labelAnswer2.AutoSize = true;
            this.labelAnswer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswer2.Location = new System.Drawing.Point(562, 9);
            this.labelAnswer2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAnswer2.Name = "labelAnswer2";
            this.labelAnswer2.Size = new System.Drawing.Size(51, 20);
            this.labelAnswer2.TabIndex = 10;
            this.labelAnswer2.Text = "label6";
            // 
            // labelAnswer1
            // 
            this.labelAnswer1.AutoSize = true;
            this.labelAnswer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswer1.ForeColor = System.Drawing.Color.Red;
            this.labelAnswer1.Location = new System.Drawing.Point(372, 10);
            this.labelAnswer1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAnswer1.Name = "labelAnswer1";
            this.labelAnswer1.Size = new System.Drawing.Size(51, 20);
            this.labelAnswer1.TabIndex = 9;
            this.labelAnswer1.Text = "label3";
            // 
            // labelAnswer0
            // 
            this.labelAnswer0.AutoSize = true;
            this.labelAnswer0.BackColor = System.Drawing.Color.Black;
            this.labelAnswer0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswer0.ForeColor = System.Drawing.Color.Red;
            this.labelAnswer0.Location = new System.Drawing.Point(168, 9);
            this.labelAnswer0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAnswer0.Name = "labelAnswer0";
            this.labelAnswer0.Size = new System.Drawing.Size(45, 20);
            this.labelAnswer0.TabIndex = 8;
            this.labelAnswer0.Text = "0000";
            // 
            // lblUser4
            // 
            this.lblUser4.AutoSize = true;
            this.lblUser4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser4.Location = new System.Drawing.Point(759, 135);
            this.lblUser4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser4.Name = "lblUser4";
            this.lblUser4.Size = new System.Drawing.Size(0, 17);
            this.lblUser4.TabIndex = 7;
            // 
            // lblUser3
            // 
            this.lblUser3.AutoSize = true;
            this.lblUser3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser3.Location = new System.Drawing.Point(563, 135);
            this.lblUser3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser3.Name = "lblUser3";
            this.lblUser3.Size = new System.Drawing.Size(0, 17);
            this.lblUser3.TabIndex = 6;
            // 
            // lblUser2
            // 
            this.lblUser2.AutoSize = true;
            this.lblUser2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser2.Location = new System.Drawing.Point(373, 135);
            this.lblUser2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser2.Name = "lblUser2";
            this.lblUser2.Size = new System.Drawing.Size(0, 17);
            this.lblUser2.TabIndex = 5;
            // 
            // lblUser1
            // 
            this.lblUser1.AutoSize = true;
            this.lblUser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser1.Location = new System.Drawing.Point(182, 135);
            this.lblUser1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser1.Name = "lblUser1";
            this.lblUser1.Size = new System.Drawing.Size(0, 17);
            this.lblUser1.TabIndex = 4;
            // 
            // picBoxUser4
            // 
            this.picBoxUser4.Location = new System.Drawing.Point(742, 33);
            this.picBoxUser4.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxUser4.Name = "picBoxUser4";
            this.picBoxUser4.Size = new System.Drawing.Size(77, 70);
            this.picBoxUser4.TabIndex = 3;
            this.picBoxUser4.TabStop = false;
            this.picBoxUser4.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // picBoxUser3
            // 
            this.picBoxUser3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxUser3.Location = new System.Drawing.Point(548, 33);
            this.picBoxUser3.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxUser3.Name = "picBoxUser3";
            this.picBoxUser3.Size = new System.Drawing.Size(77, 70);
            this.picBoxUser3.TabIndex = 2;
            this.picBoxUser3.TabStop = false;
            // 
            // picBoxUser1
            // 
            this.picBoxUser1.Location = new System.Drawing.Point(157, 33);
            this.picBoxUser1.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxUser1.Name = "picBoxUser1";
            this.picBoxUser1.Size = new System.Drawing.Size(77, 70);
            this.picBoxUser1.TabIndex = 0;
            this.picBoxUser1.TabStop = false;
            // 
            // picBoxUser2
            // 
            this.picBoxUser2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxUser2.Location = new System.Drawing.Point(361, 33);
            this.picBoxUser2.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxUser2.Name = "picBoxUser2";
            this.picBoxUser2.Size = new System.Drawing.Size(77, 70);
            this.picBoxUser2.TabIndex = 1;
            this.picBoxUser2.TabStop = false;
            // 
            // lblRoomCode
            // 
            this.lblRoomCode.AutoSize = true;
            this.lblRoomCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomCode.Location = new System.Drawing.Point(148, 33);
            this.lblRoomCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomCode.Name = "lblRoomCode";
            this.lblRoomCode.Size = new System.Drawing.Size(60, 24);
            this.lblRoomCode.TabIndex = 5;
            this.lblRoomCode.Text = "label9";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Username,
            this.Score});
            this.dataGridView2.Location = new System.Drawing.Point(14, 41);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(243, 195);
            this.dataGridView2.TabIndex = 12;
            // 
            // Username
            // 
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            // 
            // Score
            // 
            this.Score.HeaderText = "Score";
            this.Score.Name = "Score";
            // 
            // PlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 609);
            this.Controls.Add(this.lblRoomCode);
            this.Controls.Add(this.pnlStartGame);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlPlaying);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PlayForm";
            this.Text = "PlayForm";
            this.Load += new System.EventHandler(this.PlayForm_Load);
            this.pnlPlaying.ResumeLayout(false);
            this.pnlPlaying.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlStartGame.ResumeLayout(false);
            this.pnlStartGame.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlPlaying;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Label lblCountDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblUser4;
        private System.Windows.Forms.Label lblUser3;
        private System.Windows.Forms.Label lblUser2;
        private System.Windows.Forms.Label lblUser1;
        private System.Windows.Forms.PictureBox picBoxUser4;
        private System.Windows.Forms.PictureBox picBoxUser3;
        private System.Windows.Forms.PictureBox picBoxUser2;
        private System.Windows.Forms.PictureBox picBoxUser1;
        private System.Windows.Forms.Label lblRoomCode;
        private System.Windows.Forms.Panel pnlStartGame;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelAnswer3;
        private System.Windows.Forms.Label labelAnswer2;
        private System.Windows.Forms.Label labelAnswer1;
        private System.Windows.Forms.Label labelAnswer0;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
    }
}