namespace Client3
{
    partial class LoginForm
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
            this.txtUsernameLogin = new System.Windows.Forms.TextBox();
            this.txtPasswordLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnShowPass = new System.Windows.Forms.Button();
            this.btnHidePass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsernameLogin
            // 
            this.txtUsernameLogin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsernameLogin.Location = new System.Drawing.Point(455, 186);
            this.txtUsernameLogin.Name = "txtUsernameLogin";
            this.txtUsernameLogin.Size = new System.Drawing.Size(321, 30);
            this.txtUsernameLogin.TabIndex = 0;
            // 
            // txtPasswordLogin
            // 
            this.txtPasswordLogin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordLogin.Location = new System.Drawing.Point(455, 298);
            this.txtPasswordLogin.Name = "txtPasswordLogin";
            this.txtPasswordLogin.PasswordChar = '*';
            this.txtPasswordLogin.Size = new System.Drawing.Size(321, 30);
            this.txtPasswordLogin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(524, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(326, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(326, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username";
            // 
            // btnLogin
            // 
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Location = new System.Drawing.Point(660, 428);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(102, 34);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.Location = new System.Drawing.Point(466, 428);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(85, 34);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // btnShowPass
            // 
            this.btnShowPass.BackColor = System.Drawing.Color.White;
            this.btnShowPass.BackgroundImage = global::Client3.Properties.Resources.visibility_show1;
            this.btnShowPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowPass.FlatAppearance.BorderSize = 0;
            this.btnShowPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPass.Location = new System.Drawing.Point(737, 300);
            this.btnShowPass.Name = "btnShowPass";
            this.btnShowPass.Size = new System.Drawing.Size(25, 25);
            this.btnShowPass.TabIndex = 8;
            this.btnShowPass.UseVisualStyleBackColor = false;
            this.btnShowPass.Click += new System.EventHandler(this.btnShowPass_Click);
            // 
            // btnHidePass
            // 
            this.btnHidePass.BackColor = System.Drawing.Color.White;
            this.btnHidePass.BackgroundImage = global::Client3.Properties.Resources.visibility;
            this.btnHidePass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHidePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHidePass.FlatAppearance.BorderSize = 0;
            this.btnHidePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHidePass.Location = new System.Drawing.Point(737, 301);
            this.btnHidePass.Name = "btnHidePass";
            this.btnHidePass.Size = new System.Drawing.Size(25, 25);
            this.btnHidePass.TabIndex = 7;
            this.btnHidePass.UseVisualStyleBackColor = false;
            this.btnHidePass.Click += new System.EventHandler(this.btnHidePass_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 656);
            this.Controls.Add(this.btnShowPass);
            this.Controls.Add(this.btnHidePass);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPasswordLogin);
            this.Controls.Add(this.txtUsernameLogin);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsernameLogin;
        private System.Windows.Forms.TextBox txtPasswordLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnHidePass;
        private System.Windows.Forms.Button btnShowPass;
    }
}

