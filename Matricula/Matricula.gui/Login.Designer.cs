namespace Matricula.gui
{
    partial class Login
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
            this.tabAdmin = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCancelarAdmin = new System.Windows.Forms.Button();
            this.btnAceptarAdmin = new System.Windows.Forms.Button();
            this.txtPassAdmin = new System.Windows.Forms.TextBox();
            this.txtUsuAdmin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCancelarStuden = new System.Windows.Forms.Button();
            this.btnAceptarStuden = new System.Windows.Forms.Button();
            this.txtPassStuden = new System.Windows.Forms.TextBox();
            this.txtUsuStuden = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCancelarTeachers = new System.Windows.Forms.Button();
            this.txtAceparTeachers = new System.Windows.Forms.Button();
            this.txtPassTeachers = new System.Windows.Forms.TextBox();
            this.txtUsuTeachers = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabAdmin.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabPage1);
            this.tabAdmin.Controls.Add(this.tabPage2);
            this.tabAdmin.Controls.Add(this.tabPage3);
            this.tabAdmin.Location = new System.Drawing.Point(-2, -1);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(415, 243);
            this.tabAdmin.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnCancelarAdmin);
            this.tabPage1.Controls.Add(this.btnAceptarAdmin);
            this.tabPage1.Controls.Add(this.txtPassAdmin);
            this.tabPage1.Controls.Add(this.txtUsuAdmin);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(407, 217);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Admin";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnCancelarAdmin
            // 
            this.btnCancelarAdmin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarAdmin.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnCancelarAdmin.Image = global::Matricula.gui.Properties.Resources.icons8_cancel_25px;
            this.btnCancelarAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarAdmin.Location = new System.Drawing.Point(285, 159);
            this.btnCancelarAdmin.Name = "btnCancelarAdmin";
            this.btnCancelarAdmin.Size = new System.Drawing.Size(104, 35);
            this.btnCancelarAdmin.TabIndex = 6;
            this.btnCancelarAdmin.Text = "Cancelar";
            this.btnCancelarAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarAdmin.UseVisualStyleBackColor = true;
            this.btnCancelarAdmin.Click += new System.EventHandler(this.btnCancelarAdmin_Click);
            // 
            // btnAceptarAdmin
            // 
            this.btnAceptarAdmin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptarAdmin.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnAceptarAdmin.Image = global::Matricula.gui.Properties.Resources.icons8_ok_25px;
            this.btnAceptarAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptarAdmin.Location = new System.Drawing.Point(179, 159);
            this.btnAceptarAdmin.Name = "btnAceptarAdmin";
            this.btnAceptarAdmin.Size = new System.Drawing.Size(100, 35);
            this.btnAceptarAdmin.TabIndex = 5;
            this.btnAceptarAdmin.Text = "Aceptar";
            this.btnAceptarAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptarAdmin.UseVisualStyleBackColor = true;
            this.btnAceptarAdmin.Click += new System.EventHandler(this.btnAceptarAdmin_Click);
            // 
            // txtPassAdmin
            // 
            this.txtPassAdmin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassAdmin.Location = new System.Drawing.Point(180, 109);
            this.txtPassAdmin.Multiline = true;
            this.txtPassAdmin.Name = "txtPassAdmin";
            this.txtPassAdmin.PasswordChar = '*';
            this.txtPassAdmin.Size = new System.Drawing.Size(209, 33);
            this.txtPassAdmin.TabIndex = 4;
            // 
            // txtUsuAdmin
            // 
            this.txtUsuAdmin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuAdmin.Location = new System.Drawing.Point(180, 38);
            this.txtUsuAdmin.Multiline = true;
            this.txtUsuAdmin.Name = "txtUsuAdmin";
            this.txtUsuAdmin.Size = new System.Drawing.Size(209, 33);
            this.txtUsuAdmin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(176, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(176, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Matricula.gui.Properties.Resources.LoginForm1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(410, 220);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCancelarStuden);
            this.tabPage2.Controls.Add(this.btnAceptarStuden);
            this.tabPage2.Controls.Add(this.txtPassStuden);
            this.tabPage2.Controls.Add(this.txtUsuStuden);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(407, 217);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Students";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCancelarStuden
            // 
            this.btnCancelarStuden.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarStuden.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnCancelarStuden.Image = global::Matricula.gui.Properties.Resources.icons8_cancel_25px;
            this.btnCancelarStuden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarStuden.Location = new System.Drawing.Point(282, 160);
            this.btnCancelarStuden.Name = "btnCancelarStuden";
            this.btnCancelarStuden.Size = new System.Drawing.Size(104, 35);
            this.btnCancelarStuden.TabIndex = 12;
            this.btnCancelarStuden.Text = "Cancelar";
            this.btnCancelarStuden.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarStuden.UseVisualStyleBackColor = true;
            this.btnCancelarStuden.Click += new System.EventHandler(this.btnCancelarStuden_Click);
            // 
            // btnAceptarStuden
            // 
            this.btnAceptarStuden.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptarStuden.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnAceptarStuden.Image = global::Matricula.gui.Properties.Resources.icons8_ok_25px;
            this.btnAceptarStuden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptarStuden.Location = new System.Drawing.Point(176, 160);
            this.btnAceptarStuden.Name = "btnAceptarStuden";
            this.btnAceptarStuden.Size = new System.Drawing.Size(100, 35);
            this.btnAceptarStuden.TabIndex = 11;
            this.btnAceptarStuden.Text = "Aceptar";
            this.btnAceptarStuden.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptarStuden.UseVisualStyleBackColor = true;
            this.btnAceptarStuden.Click += new System.EventHandler(this.btnAceptarStuden_Click);
            // 
            // txtPassStuden
            // 
            this.txtPassStuden.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassStuden.Location = new System.Drawing.Point(177, 110);
            this.txtPassStuden.Multiline = true;
            this.txtPassStuden.Name = "txtPassStuden";
            this.txtPassStuden.PasswordChar = '*';
            this.txtPassStuden.Size = new System.Drawing.Size(209, 33);
            this.txtPassStuden.TabIndex = 10;
            // 
            // txtUsuStuden
            // 
            this.txtUsuStuden.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuStuden.Location = new System.Drawing.Point(177, 39);
            this.txtUsuStuden.Multiline = true;
            this.txtUsuStuden.Name = "txtUsuStuden";
            this.txtUsuStuden.Size = new System.Drawing.Size(209, 33);
            this.txtUsuStuden.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkGray;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(173, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Contraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkGray;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(173, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Usuario:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Matricula.gui.Properties.Resources.LoginForm2;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(404, 217);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnCancelarTeachers);
            this.tabPage3.Controls.Add(this.txtAceparTeachers);
            this.tabPage3.Controls.Add(this.txtPassTeachers);
            this.tabPage3.Controls.Add(this.txtUsuTeachers);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.pictureBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(407, 217);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Teachers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCancelarTeachers
            // 
            this.btnCancelarTeachers.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarTeachers.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnCancelarTeachers.Image = global::Matricula.gui.Properties.Resources.icons8_cancel_25px;
            this.btnCancelarTeachers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarTeachers.Location = new System.Drawing.Point(283, 160);
            this.btnCancelarTeachers.Name = "btnCancelarTeachers";
            this.btnCancelarTeachers.Size = new System.Drawing.Size(104, 35);
            this.btnCancelarTeachers.TabIndex = 18;
            this.btnCancelarTeachers.Text = "Cancelar";
            this.btnCancelarTeachers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarTeachers.UseVisualStyleBackColor = true;
            this.btnCancelarTeachers.Click += new System.EventHandler(this.btnCancelarTeachers_Click);
            // 
            // txtAceparTeachers
            // 
            this.txtAceparTeachers.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAceparTeachers.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtAceparTeachers.Image = global::Matricula.gui.Properties.Resources.icons8_ok_25px;
            this.txtAceparTeachers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtAceparTeachers.Location = new System.Drawing.Point(177, 160);
            this.txtAceparTeachers.Name = "txtAceparTeachers";
            this.txtAceparTeachers.Size = new System.Drawing.Size(100, 35);
            this.txtAceparTeachers.TabIndex = 17;
            this.txtAceparTeachers.Text = "Aceptar";
            this.txtAceparTeachers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtAceparTeachers.UseVisualStyleBackColor = true;
            this.txtAceparTeachers.Click += new System.EventHandler(this.txtAceparTeachers_Click);
            // 
            // txtPassTeachers
            // 
            this.txtPassTeachers.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassTeachers.Location = new System.Drawing.Point(178, 110);
            this.txtPassTeachers.Multiline = true;
            this.txtPassTeachers.Name = "txtPassTeachers";
            this.txtPassTeachers.PasswordChar = '*';
            this.txtPassTeachers.Size = new System.Drawing.Size(209, 33);
            this.txtPassTeachers.TabIndex = 16;
            // 
            // txtUsuTeachers
            // 
            this.txtUsuTeachers.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuTeachers.Location = new System.Drawing.Point(178, 39);
            this.txtUsuTeachers.Multiline = true;
            this.txtUsuTeachers.Name = "txtUsuTeachers";
            this.txtUsuTeachers.Size = new System.Drawing.Size(209, 33);
            this.txtUsuTeachers.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkGray;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(174, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Contraseña:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DarkGray;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(174, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Usuario:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Matricula.gui.Properties.Resources.LoginForm2;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(407, 217);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(413, 241);
            this.Controls.Add(this.tabAdmin);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.tabAdmin.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtPassAdmin;
        private System.Windows.Forms.TextBox txtUsuAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCancelarAdmin;
        private System.Windows.Forms.Button btnAceptarAdmin;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnCancelarStuden;
        private System.Windows.Forms.Button btnAceptarStuden;
        private System.Windows.Forms.TextBox txtPassStuden;
        private System.Windows.Forms.TextBox txtUsuStuden;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelarTeachers;
        private System.Windows.Forms.Button txtAceparTeachers;
        private System.Windows.Forms.TextBox txtPassTeachers;
        private System.Windows.Forms.TextBox txtUsuTeachers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}