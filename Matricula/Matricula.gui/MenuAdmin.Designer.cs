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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAsignacion = new System.Windows.Forms.Button();
            this.btnCRUDPersonas = new System.Windows.Forms.Button();
            this.btnCRUDMateria = new System.Windows.Forms.Button();
            this.btnCRUDCarreras = new System.Windows.Forms.Button();
            this.btnCRUDAdmin = new System.Windows.Forms.Button();
            this.btnCRUDUsuarios = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 58);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(263, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "MENÚ PRINCIPAL";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // btnAsignacion
            // 
            this.btnAsignacion.Image = global::Matricula.gui.Properties.Resources.icons8_assignment_return_125px;
            this.btnAsignacion.Location = new System.Drawing.Point(514, 78);
            this.btnAsignacion.Name = "btnAsignacion";
            this.btnAsignacion.Size = new System.Drawing.Size(219, 138);
            this.btnAsignacion.TabIndex = 5;
            this.btnAsignacion.UseVisualStyleBackColor = true;
            this.btnAsignacion.Click += new System.EventHandler(this.btnAsignacion_Click);
            // 
            // btnCRUDPersonas
            // 
            this.btnCRUDPersonas.Image = global::Matricula.gui.Properties.Resources.icons8_user_groups_125px;
            this.btnCRUDPersonas.Location = new System.Drawing.Point(278, 231);
            this.btnCRUDPersonas.Name = "btnCRUDPersonas";
            this.btnCRUDPersonas.Size = new System.Drawing.Size(219, 138);
            this.btnCRUDPersonas.TabIndex = 4;
            this.btnCRUDPersonas.UseVisualStyleBackColor = true;
            this.btnCRUDPersonas.Click += new System.EventHandler(this.btnCRUDPersonas_Click);
            // 
            // btnCRUDMateria
            // 
            this.btnCRUDMateria.Image = global::Matricula.gui.Properties.Resources.icons8_course_assign_125px;
            this.btnCRUDMateria.Location = new System.Drawing.Point(46, 231);
            this.btnCRUDMateria.Name = "btnCRUDMateria";
            this.btnCRUDMateria.Size = new System.Drawing.Size(219, 138);
            this.btnCRUDMateria.TabIndex = 3;
            this.btnCRUDMateria.UseVisualStyleBackColor = true;
            this.btnCRUDMateria.Click += new System.EventHandler(this.btnCRUDMateria_Click);
            // 
            // btnCRUDCarreras
            // 
            this.btnCRUDCarreras.Image = global::Matricula.gui.Properties.Resources.icons8_mortarboard_125px;
            this.btnCRUDCarreras.Location = new System.Drawing.Point(278, 78);
            this.btnCRUDCarreras.Name = "btnCRUDCarreras";
            this.btnCRUDCarreras.Size = new System.Drawing.Size(219, 138);
            this.btnCRUDCarreras.TabIndex = 2;
            this.btnCRUDCarreras.UseVisualStyleBackColor = true;
            this.btnCRUDCarreras.Click += new System.EventHandler(this.btnCRUDCarreras_Click);
            // 
            // btnCRUDAdmin
            // 
            this.btnCRUDAdmin.AccessibleDescription = "";
            this.btnCRUDAdmin.Image = global::Matricula.gui.Properties.Resources.icons8_business_group_125px_1;
            this.btnCRUDAdmin.Location = new System.Drawing.Point(46, 78);
            this.btnCRUDAdmin.Name = "btnCRUDAdmin";
            this.btnCRUDAdmin.Size = new System.Drawing.Size(219, 138);
            this.btnCRUDAdmin.TabIndex = 1;
            this.btnCRUDAdmin.UseVisualStyleBackColor = true;
            this.btnCRUDAdmin.Click += new System.EventHandler(this.btnCRUDAdmin_Click);
            // 
            // btnCRUDUsuarios
            // 
            this.btnCRUDUsuarios.Location = new System.Drawing.Point(514, 231);
            this.btnCRUDUsuarios.Name = "btnCRUDUsuarios";
            this.btnCRUDUsuarios.Size = new System.Drawing.Size(219, 138);
            this.btnCRUDUsuarios.TabIndex = 6;
            this.btnCRUDUsuarios.Text = "CRUD Usuarios";
            this.btnCRUDUsuarios.UseVisualStyleBackColor = true;
            this.btnCRUDUsuarios.Click += new System.EventHandler(this.btnCRUDUsuarios_Click);
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 395);
            this.Controls.Add(this.btnCRUDUsuarios);
            this.Controls.Add(this.btnAsignacion);
            this.Controls.Add(this.btnCRUDPersonas);
            this.Controls.Add(this.btnCRUDMateria);
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
        private System.Windows.Forms.Button btnCRUDMateria;
        private System.Windows.Forms.Button btnCRUDPersonas;
        private System.Windows.Forms.Button btnAsignacion;
        private System.Windows.Forms.Button btnCRUDUsuarios;
    }
}