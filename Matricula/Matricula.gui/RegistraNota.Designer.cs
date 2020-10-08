﻿namespace Matricula.gui
{
    partial class RegistraNota
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.cmbEstudiante = new System.Windows.Forms.ComboBox();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProyecto = new System.Windows.Forms.TextBox();
            this.txtLaboratorio = new System.Windows.Forms.TextBox();
            this.txtExamenes = new System.Windows.Forms.TextBox();
            this.txtPruebasCortas = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 59);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(198, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar notas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Id periodo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Id materia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Id estudiante:";
            // 
            // txtNota
            // 
            this.txtNota.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNota.Location = new System.Drawing.Point(490, 94);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(128, 26);
            this.txtNota.TabIndex = 5;
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Items.AddRange(new object[] {
            "I Cuatrimestre",
            "II Cuatrimestre",
            "III Cuatrimestre"});
            this.cmbPeriodo.Location = new System.Drawing.Point(114, 89);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(242, 26);
            this.cmbPeriodo.TabIndex = 6;
            this.cmbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cmbPeriodo_SelectedIndexChanged);
            // 
            // cmbEstudiante
            // 
            this.cmbEstudiante.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstudiante.FormattingEnabled = true;
            this.cmbEstudiante.Location = new System.Drawing.Point(131, 203);
            this.cmbEstudiante.Name = "cmbEstudiante";
            this.cmbEstudiante.Size = new System.Drawing.Size(224, 26);
            this.cmbEstudiante.TabIndex = 8;
            this.cmbEstudiante.SelectedIndexChanged += new System.EventHandler(this.cmbEstudiante_SelectedIndexChanged);
            // 
            // cmbMateria
            // 
            this.cmbMateria.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(114, 145);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(242, 26);
            this.cmbMateria.TabIndex = 9;
            this.cmbMateria.SelectedIndexChanged += new System.EventHandler(this.cmbMateria_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Pts proyecto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Pts laboratorios:";
            // 
            // txtEstado
            // 
            this.txtEstado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(507, 145);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(154, 26);
            this.txtEstado.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 380);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Pts examenes:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 435);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Pts pruebas cortas:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(439, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 18);
            this.label9.TabIndex = 15;
            this.label9.Text = "Nota:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(439, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 18);
            this.label10.TabIndex = 16;
            this.label10.Text = "Estado:";
            // 
            // txtProyecto
            // 
            this.txtProyecto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProyecto.Location = new System.Drawing.Point(131, 261);
            this.txtProyecto.Name = "txtProyecto";
            this.txtProyecto.Size = new System.Drawing.Size(224, 26);
            this.txtProyecto.TabIndex = 17;
            this.txtProyecto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProyecto_KeyPress);
            // 
            // txtLaboratorio
            // 
            this.txtLaboratorio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLaboratorio.Location = new System.Drawing.Point(155, 319);
            this.txtLaboratorio.Name = "txtLaboratorio";
            this.txtLaboratorio.Size = new System.Drawing.Size(201, 26);
            this.txtLaboratorio.TabIndex = 18;
            this.txtLaboratorio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLaboratorio_KeyPress);
            // 
            // txtExamenes
            // 
            this.txtExamenes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExamenes.Location = new System.Drawing.Point(144, 372);
            this.txtExamenes.Name = "txtExamenes";
            this.txtExamenes.Size = new System.Drawing.Size(212, 26);
            this.txtExamenes.TabIndex = 19;
            this.txtExamenes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExamenes_KeyPress);
            // 
            // txtPruebasCortas
            // 
            this.txtPruebasCortas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPruebasCortas.Location = new System.Drawing.Point(176, 427);
            this.txtPruebasCortas.Name = "txtPruebasCortas";
            this.txtPruebasCortas.Size = new System.Drawing.Size(181, 26);
            this.txtPruebasCortas.TabIndex = 20;
            this.txtPruebasCortas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPruebasCortas_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(26, 480);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 18);
            this.label11.TabIndex = 21;
            this.label11.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(76, 472);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(81, 26);
            this.txtTotal.TabIndex = 22;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = global::Matricula.gui.Properties.Resources.icons8_ok_25px;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(442, 463);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(104, 35);
            this.btnAceptar.TabIndex = 23;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::Matricula.gui.Properties.Resources.icons8_cancel_25px;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(557, 463);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 35);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // RegistraNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 522);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPruebasCortas);
            this.Controls.Add(this.txtExamenes);
            this.Controls.Add(this.txtLaboratorio);
            this.Controls.Add(this.txtProyecto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.cmbEstudiante);
            this.Controls.Add(this.cmbPeriodo);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "RegistraNota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.ComboBox cmbEstudiante;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProyecto;
        private System.Windows.Forms.TextBox txtLaboratorio;
        private System.Windows.Forms.TextBox txtExamenes;
        private System.Windows.Forms.TextBox txtPruebasCortas;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}