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
            this.lblRoomCode = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlStartGame = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.pnlPlaying = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblCountDown = new System.Windows.Forms.Label();
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
            this.labelResult = new System.Windows.Forms.Label();
            this.pnlStartGame.SuspendLayout();
            this.pnlPlaying.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SlateBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(907, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Leave";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "RoomID";
            // 
            // lblRoomCode
            // 
            this.lblRoomCode.AutoSize = true;
            this.lblRoomCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomCode.Location = new System.Drawing.Point(130, 9);
            this.lblRoomCode.Name = "lblRoomCode";
            this.lblRoomCode.Size = new System.Drawing.Size(79, 29);
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
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(794, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(107, 25);
            this.lblUsername.TabIndex = 101;
            this.lblUsername.Text = "username";
            // 
            // pnlStartGame
            // 
            this.pnlStartGame.BackgroundImage = global::Client3.Properties.Resources.startgame1;
            this.pnlStartGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlStartGame.Controls.Add(this.label5);
            this.pnlStartGame.Controls.Add(this.btnStartGame);
            this.pnlStartGame.Location = new System.Drawing.Point(0, 0);
            this.pnlStartGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlStartGame.Name = "pnlStartGame";
            this.pnlStartGame.Size = new System.Drawing.Size(980, 389);
            this.pnlStartGame.TabIndex = 99;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(88, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(268, 43);
            this.label5.TabIndex = 1;
            this.label5.Text = "What\'s up bros";
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.SlateBlue;
            this.btnStartGame.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.ForeColor = System.Drawing.Color.White;
            this.btnStartGame.Location = new System.Drawing.Point(61, 200);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(313, 97);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "Start game";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // pnlPlaying
            // 
            this.pnlPlaying.BackgroundImage = global::Client3.Properties.Resources.play;
            this.pnlPlaying.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlPlaying.Controls.Add(this.pnlStartGame);
            this.pnlPlaying.Controls.Add(this.labelResult);
            this.pnlPlaying.Controls.Add(this.label4);
            this.pnlPlaying.Controls.Add(this.label2);
            this.pnlPlaying.Controls.Add(this.dataGridView2);
            this.pnlPlaying.Controls.Add(this.txtAnswer);
            this.pnlPlaying.Controls.Add(this.lblQuestion);
            this.pnlPlaying.Controls.Add(this.lblCountDown);
            this.pnlPlaying.Location = new System.Drawing.Point(22, 71);
            this.pnlPlaying.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPlaying.Name = "pnlPlaying";
            this.pnlPlaying.Size = new System.Drawing.Size(983, 391);
            this.pnlPlaying.TabIndex = 18;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Username,
            this.Score});
            this.dataGridView2.GridColor = System.Drawing.Color.DodgerBlue;
            this.dataGridView2.Location = new System.Drawing.Point(3, 136);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(243, 178);
            this.dataGridView2.TabIndex = 12;
            // 
            // Username
            // 
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // Score
            // 
            this.Score.HeaderText = "Score";
            this.Score.Name = "Score";
            this.Score.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(738, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Price You Guess";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(363, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 29);
            this.label2.TabIndex = 101;
            this.label2.Text = "Result:";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnswer.Location = new System.Drawing.Point(691, 191);
            this.txtAnswer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(255, 39);
            this.txtAnswer.TabIndex = 7;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(270, 75);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(0, 29);
            this.lblQuestion.TabIndex = 5;
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.Location = new System.Drawing.Point(922, 58);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(43, 46);
            this.lblCountDown.TabIndex = 4;
            this.lblCountDown.Text = "5";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Client3.Properties.Resources.backgrounduser;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
            this.panel2.Location = new System.Drawing.Point(22, 466);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(983, 205);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // labelAnswer3
            // 
            this.labelAnswer3.AutoSize = true;
            this.labelAnswer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswer3.ForeColor = System.Drawing.Color.Red;
            this.labelAnswer3.Location = new System.Drawing.Point(813, 24);
            this.labelAnswer3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAnswer3.Name = "labelAnswer3";
            this.labelAnswer3.Size = new System.Drawing.Size(0, 25);
            this.labelAnswer3.TabIndex = 11;
            // 
            // labelAnswer2
            // 
            this.labelAnswer2.AutoSize = true;
            this.labelAnswer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswer2.ForeColor = System.Drawing.Color.Red;
            this.labelAnswer2.Location = new System.Drawing.Point(573, 24);
            this.labelAnswer2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAnswer2.Name = "labelAnswer2";
            this.labelAnswer2.Size = new System.Drawing.Size(0, 25);
            this.labelAnswer2.TabIndex = 10;
            // 
            // labelAnswer1
            // 
            this.labelAnswer1.AutoSize = true;
            this.labelAnswer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswer1.ForeColor = System.Drawing.Color.Red;
            this.labelAnswer1.Location = new System.Drawing.Point(351, 24);
            this.labelAnswer1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAnswer1.Name = "labelAnswer1";
            this.labelAnswer1.Size = new System.Drawing.Size(0, 25);
            this.labelAnswer1.TabIndex = 9;
            this.labelAnswer1.Click += new System.EventHandler(this.labelAnswer1_Click);
            // 
            // labelAnswer0
            // 
            this.labelAnswer0.AutoSize = true;
            this.labelAnswer0.BackColor = System.Drawing.SystemColors.Control;
            this.labelAnswer0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswer0.ForeColor = System.Drawing.Color.Red;
            this.labelAnswer0.Location = new System.Drawing.Point(145, 24);
            this.labelAnswer0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAnswer0.Name = "labelAnswer0";
            this.labelAnswer0.Size = new System.Drawing.Size(0, 25);
            this.labelAnswer0.TabIndex = 8;
            // 
            // lblUser4
            // 
            this.lblUser4.AutoSize = true;
            this.lblUser4.BackColor = System.Drawing.Color.Transparent;
            this.lblUser4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser4.ForeColor = System.Drawing.Color.White;
            this.lblUser4.Location = new System.Drawing.Point(796, 151);
            this.lblUser4.Name = "lblUser4";
            this.lblUser4.Size = new System.Drawing.Size(0, 25);
            this.lblUser4.TabIndex = 7;
            // 
            // lblUser3
            // 
            this.lblUser3.AutoSize = true;
            this.lblUser3.BackColor = System.Drawing.Color.Transparent;
            this.lblUser3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser3.ForeColor = System.Drawing.Color.White;
            this.lblUser3.Location = new System.Drawing.Point(554, 151);
            this.lblUser3.Name = "lblUser3";
            this.lblUser3.Size = new System.Drawing.Size(0, 25);
            this.lblUser3.TabIndex = 6;
            // 
            // lblUser2
            // 
            this.lblUser2.AutoSize = true;
            this.lblUser2.BackColor = System.Drawing.Color.Transparent;
            this.lblUser2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser2.ForeColor = System.Drawing.Color.White;
            this.lblUser2.Location = new System.Drawing.Point(331, 151);
            this.lblUser2.Name = "lblUser2";
            this.lblUser2.Size = new System.Drawing.Size(0, 25);
            this.lblUser2.TabIndex = 5;
            // 
            // lblUser1
            // 
            this.lblUser1.AutoSize = true;
            this.lblUser1.BackColor = System.Drawing.Color.Transparent;
            this.lblUser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser1.ForeColor = System.Drawing.Color.White;
            this.lblUser1.Location = new System.Drawing.Point(120, 151);
            this.lblUser1.Name = "lblUser1";
            this.lblUser1.Size = new System.Drawing.Size(0, 25);
            this.lblUser1.TabIndex = 4;
            // 
            // picBoxUser4
            // 
            this.picBoxUser4.BackColor = System.Drawing.Color.Transparent;
            this.picBoxUser4.Location = new System.Drawing.Point(776, 63);
            this.picBoxUser4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxUser4.Name = "picBoxUser4";
            this.picBoxUser4.Size = new System.Drawing.Size(103, 86);
            this.picBoxUser4.TabIndex = 3;
            this.picBoxUser4.TabStop = false;
            this.picBoxUser4.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // picBoxUser3
            // 
            this.picBoxUser3.BackColor = System.Drawing.Color.Transparent;
            this.picBoxUser3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxUser3.Location = new System.Drawing.Point(542, 63);
            this.picBoxUser3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxUser3.Name = "picBoxUser3";
            this.picBoxUser3.Size = new System.Drawing.Size(103, 86);
            this.picBoxUser3.TabIndex = 2;
            this.picBoxUser3.TabStop = false;
            // 
            // picBoxUser1
            // 
            this.picBoxUser1.BackColor = System.Drawing.Color.Transparent;
            this.picBoxUser1.Location = new System.Drawing.Point(113, 63);
            this.picBoxUser1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxUser1.Name = "picBoxUser1";
            this.picBoxUser1.Size = new System.Drawing.Size(103, 86);
            this.picBoxUser1.TabIndex = 0;
            this.picBoxUser1.TabStop = false;
            // 
            // picBoxUser2
            // 
            this.picBoxUser2.BackColor = System.Drawing.Color.Transparent;
            this.picBoxUser2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxUser2.Location = new System.Drawing.Point(322, 63);
            this.picBoxUser2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxUser2.Name = "picBoxUser2";
            this.picBoxUser2.Size = new System.Drawing.Size(103, 86);
            this.picBoxUser2.TabIndex = 1;
            this.picBoxUser2.TabStop = false;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.Location = new System.Drawing.Point(500, 221);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(26, 29);
            this.labelResult.TabIndex = 10;
            this.labelResult.Text = "0";
            this.labelResult.Click += new System.EventHandler(this.labelResult_Click);
            // 
            // PlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1026, 669);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblRoomCode);
            this.Controls.Add(this.pnlPlaying);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PlayForm";
            this.Text = "PlayForm";
            this.Load += new System.EventHandler(this.PlayForm_Load);
            this.pnlStartGame.ResumeLayout(false);
            this.pnlStartGame.PerformLayout();
            this.pnlPlaying.ResumeLayout(false);
            this.pnlPlaying.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlPlaying;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Label lblCountDown;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label labelResult;
    }
}