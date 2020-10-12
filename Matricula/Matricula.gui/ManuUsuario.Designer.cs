namespace Matricula.gui
{
    partial class ManuUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManuUsuario));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMatricula = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosPendientes = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarPrematriculaDeMateriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEvaluacion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNotas = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripMenuItemContrasena = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manúToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(532, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manúToolStripMenuItem
            // 
            this.manúToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMatricula,
            this.pagosPendientes,
            this.eliminarPrematriculaDeMateriaToolStripMenuItem,
            this.toolStripMenuItemEvaluacion,
            this.toolStripMenuItemNotas,
            this.toolStripMenuItemContrasena,
            this.salirToolStripMenuItem});
            this.manúToolStripMenuItem.Name = "manúToolStripMenuItem";
            this.manúToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.manúToolStripMenuItem.Text = "Menú de estudiantes";
            // 
            // toolStripMenuItemMatricula
            // 
            this.toolStripMenuItemMatricula.Name = "toolStripMenuItemMatricula";
            this.toolStripMenuItemMatricula.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItemMatricula.Text = "Matricula";
            this.toolStripMenuItemMatricula.Click += new System.EventHandler(this.toolStripMenuItemMatricula_Click);
            // 
            // pagosPendientes
            // 
            this.pagosPendientes.Name = "pagosPendientes";
            this.pagosPendientes.Size = new System.Drawing.Size(213, 22);
            this.pagosPendientes.Text = "Pagos pendientes";
            this.pagosPendientes.Click += new System.EventHandler(this.pagosPendientes_Click);
            // 
            // eliminarPrematriculaDeMateriaToolStripMenuItem
            // 
            this.eliminarPrematriculaDeMateriaToolStripMenuItem.Name = "eliminarPrematriculaDeMateriaToolStripMenuItem";
            this.eliminarPrematriculaDeMateriaToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.eliminarPrematriculaDeMateriaToolStripMenuItem.Text = "Eliminar / desertar materia";
            this.eliminarPrematriculaDeMateriaToolStripMenuItem.Click += new System.EventHandler(this.eliminarPrematriculaDeMateriaToolStripMenuItem_Click);
            // 
            // toolStripMenuItemEvaluacion
            // 
            this.toolStripMenuItemEvaluacion.Name = "toolStripMenuItemEvaluacion";
            this.toolStripMenuItemEvaluacion.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItemEvaluacion.Text = "Evaluación del curso";
            this.toolStripMenuItemEvaluacion.Click += new System.EventHandler(this.toolStripMenuItemEvaluacion_Click);
            // 
            // toolStripMenuItemNotas
            // 
            this.toolStripMenuItemNotas.Name = "toolStripMenuItemNotas";
            this.toolStripMenuItemNotas.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItemNotas.Text = "Notas";
            this.toolStripMenuItemNotas.Click += new System.EventHandler(this.toolStripMenuItemNotas_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(532, 305);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripMenuItemContrasena
            // 
            this.toolStripMenuItemContrasena.Name = "toolStripMenuItemContrasena";
            this.toolStripMenuItemContrasena.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItemContrasena.Text = "Cambiar contraseña";
            this.toolStripMenuItemContrasena.Click += new System.EventHandler(this.toolStripMenuItemContrasena_Click);
            // 
            // ManuUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 332);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "ManuUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manúToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMatricula;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEvaluacion;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNotas;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem pagosPendientes;
        private System.Windows.Forms.ToolStripMenuItem eliminarPrematriculaDeMateriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemContrasena;
    }
}