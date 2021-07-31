namespace Client3
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnJoinRoomRandom = new System.Windows.Forms.Button();
            this.btnJoinRoomByCode = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCreateRoom = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1256, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1191, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // btnJoinRoomRandom
            // 
            this.btnJoinRoomRandom.Location = new System.Drawing.Point(134, 289);
            this.btnJoinRoomRandom.Name = "btnJoinRoomRandom";
            this.btnJoinRoomRandom.Size = new System.Drawing.Size(280, 83);
            this.btnJoinRoomRandom.TabIndex = 3;
            this.btnJoinRoomRandom.Text = "Play Now";
            this.btnJoinRoomRandom.UseVisualStyleBackColor = true;
            this.btnJoinRoomRandom.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnJoinRoomByCode
            // 
            this.btnJoinRoomByCode.Location = new System.Drawing.Point(520, 289);
            this.btnJoinRoomByCode.Name = "btnJoinRoomByCode";
            this.btnJoinRoomByCode.Size = new System.Drawing.Size(280, 83);
            this.btnJoinRoomByCode.TabIndex = 4;
            this.btnJoinRoomByCode.Text = "Join Room";
            this.btnJoinRoomByCode.UseVisualStyleBackColor = true;
            this.btnJoinRoomByCode.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(520, 252);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(280, 22);
            this.textBox1.TabIndex = 5;
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.Location = new System.Drawing.Point(920, 289);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(280, 83);
            this.btnCreateRoom.TabIndex = 6;
            this.btnCreateRoom.Text = "Create room";
            this.btnCreateRoom.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(517, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enter the room code";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 677);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCreateRoom);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnJoinRoomByCode);
            this.Controls.Add(this.btnJoinRoomRandom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnJoinRoomRandom;
        private System.Windows.Forms.Button btnJoinRoomByCode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCreateRoom;
        private System.Windows.Forms.Label label3;
    }
}