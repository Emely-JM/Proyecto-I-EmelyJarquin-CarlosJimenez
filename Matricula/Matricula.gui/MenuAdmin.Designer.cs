namespace Matricula.gui
{
    partial class MenuAdmin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCRUDCarreras = new System.Windows.Forms.Button();
            this.btnCRUDAdmin = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 58);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(247, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "MENÚ PRINCIPAL";
            // 
            // btnCRUDCarreras
            // 
            this.btnCRUDCarreras.Image = global::Matricula.gui.Properties.Resources.icons8_mortarboard_125px;
            this.btnCRUDCarreras.Location = new System.Drawing.Point(189, 78);
            this.btnCRUDCarreras.Name = "btnCRUDCarreras";
            this.btnCRUDCarreras.Size = new System.Drawing.Size(159, 138);
            this.btnCRUDCarreras.TabIndex = 2;
            this.btnCRUDCarreras.UseVisualStyleBackColor = true;
            this.btnCRUDCarreras.Click += new System.EventHandler(this.btnCRUDCarreras_Click);
            // 
            // btnCRUDAdmin
            // 
            this.btnCRUDAdmin.AccessibleDescription = "";
            this.btnCRUDAdmin.Image = global::Matricula.gui.Properties.Resources.icons8_business_group_125px_1;
            this.btnCRUDAdmin.Location = new System.Drawing.Point(12, 78);
            this.btnCRUDAdmin.Name = "btnCRUDAdmin";
            this.btnCRUDAdmin.Size = new System.Drawing.Size(159, 138);
            this.btnCRUDAdmin.TabIndex = 1;
            this.btnCRUDAdmin.UseVisualStyleBackColor = true;
            this.btnCRUDAdmin.Click += new System.EventHandler(this.btnCRUDAdmin_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCRUDCarreras);
            this.Controls.Add(this.btnCRUDAdmin);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "MenuAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCRUDAdmin;
        private System.Windows.Forms.Button btnCRUDCarreras;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}