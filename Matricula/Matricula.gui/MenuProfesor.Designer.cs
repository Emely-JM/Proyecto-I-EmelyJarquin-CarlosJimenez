﻿namespace Matricula.gui
{
    partial class MenuProfesor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuProfesor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosAsignados = new System.Windows.Forms.ToolStripMenuItem();
            this.Notas = new System.Windows.Forms.ToolStripMenuItem();
            this.ListaEstudiantes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemContrasena = new System.Windows.Forms.ToolStripMenuItem();
            this.salir = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(770, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cursosAsignados,
            this.Notas,
            this.ListaEstudiantes,
            this.toolStripMenuItemContrasena,
            this.salir});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "Menú";
            // 
            // cursosAsignados
            // 
            this.cursosAsignados.Name = "cursosAsignados";
            this.cursosAsignados.Size = new System.Drawing.Size(180, 22);
            this.cursosAsignados.Text = "Cursos asignados";
            this.cursosAsignados.Click += new System.EventHandler(this.cursosAsignados_Click);
            // 
            // Notas
            // 
            this.Notas.Name = "Notas";
            this.Notas.Size = new System.Drawing.Size(180, 22);
            this.Notas.Text = "Registrar notas";
            this.Notas.Click += new System.EventHandler(this.Notas_Click);
            // 
            // ListaEstudiantes
            // 
            this.ListaEstudiantes.Name = "ListaEstudiantes";
            this.ListaEstudiantes.Size = new System.Drawing.Size(180, 22);
            this.ListaEstudiantes.Text = "Lista de estudiantes";
            this.ListaEstudiantes.Click += new System.EventHandler(this.ListaEstudiantes_Click);
            // 
            // toolStripMenuItemContrasena
            // 
            this.toolStripMenuItemContrasena.Name = "toolStripMenuItemContrasena";
            this.toolStripMenuItemContrasena.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemContrasena.Text = "Cambiar contraseña";
            this.toolStripMenuItemContrasena.Click += new System.EventHandler(this.toolStripMenuItemContrasena_Click);
            // 
            // salir
            // 
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(180, 22);
            this.salir.Text = "Salir";
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Matricula.gui.Properties.Resources.ceuniver_0;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(772, 398);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MenuProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 422);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MenuProfesor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú de profesores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuProfesor_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cursosAsignados;
        private System.Windows.Forms.ToolStripMenuItem ListaEstudiantes;
        private System.Windows.Forms.ToolStripMenuItem Notas;
        private System.Windows.Forms.ToolStripMenuItem salir;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemContrasena;
    }
}