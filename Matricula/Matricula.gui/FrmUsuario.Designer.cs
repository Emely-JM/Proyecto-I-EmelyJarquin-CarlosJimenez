namespace Matricula.gui
{
    partial class FrmUsuario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuario));
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.objData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtbCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtbIdPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtbNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtbTipoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkbActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnContrasena = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Location = new System.Drawing.Point(12, 12);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(814, 50);
            this.pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(220, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(375, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Mantenimiento de Usuarios";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(104, 73);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(250, 31);
            this.txtBuscar.TabIndex = 1;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(12, 76);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(86, 25);
            this.lblCodigo.TabIndex = 7;
            this.lblCodigo.Text = "Código:";
            // 
            // tabla
            // 
            this.tabla.AllowUserToAddRows = false;
            this.tabla.AllowUserToDeleteRows = false;
            this.tabla.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.objData,
            this.txtbCodigo,
            this.txtbIdPersona,
            this.txtbNombre,
            this.txtbTipoUsuario,
            this.chkbActivo});
            this.tabla.Location = new System.Drawing.Point(12, 114);
            this.tabla.Name = "tabla";
            this.tabla.ReadOnly = true;
            this.tabla.RowHeadersVisible = false;
            this.tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla.Size = new System.Drawing.Size(814, 315);
            this.tabla.TabIndex = 8;
            // 
            // objData
            // 
            this.objData.HeaderText = "Data";
            this.objData.Name = "objData";
            this.objData.ReadOnly = true;
            this.objData.Visible = false;
            // 
            // txtbCodigo
            // 
            this.txtbCodigo.HeaderText = "Código";
            this.txtbCodigo.Name = "txtbCodigo";
            this.txtbCodigo.ReadOnly = true;
            // 
            // txtbIdPersona
            // 
            this.txtbIdPersona.HeaderText = "ID Persona";
            this.txtbIdPersona.Name = "txtbIdPersona";
            this.txtbIdPersona.ReadOnly = true;
            // 
            // txtbNombre
            // 
            this.txtbNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtbNombre.HeaderText = "Nombre";
            this.txtbNombre.Name = "txtbNombre";
            this.txtbNombre.ReadOnly = true;
            // 
            // txtbTipoUsuario
            // 
            this.txtbTipoUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtbTipoUsuario.HeaderText = "Tipo de usuario";
            this.txtbTipoUsuario.Name = "txtbTipoUsuario";
            this.txtbTipoUsuario.ReadOnly = true;
            // 
            // chkbActivo
            // 
            this.chkbActivo.HeaderText = "Activo";
            this.chkbActivo.Name = "chkbActivo";
            this.chkbActivo.ReadOnly = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::Matricula.gui.Properties.Resources.icons8_plus_25px_1;
            this.btnAgregar.Location = new System.Drawing.Point(648, 68);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(40, 40);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnContrasena
            // 
            this.btnContrasena.Image = global::Matricula.gui.Properties.Resources.icons8_password_25px_1;
            this.btnContrasena.Location = new System.Drawing.Point(786, 68);
            this.btnContrasena.Name = "btnContrasena";
            this.btnContrasena.Size = new System.Drawing.Size(40, 40);
            this.btnContrasena.TabIndex = 5;
            this.btnContrasena.UseVisualStyleBackColor = true;
            this.btnContrasena.Click += new System.EventHandler(this.btnContrasena_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::Matricula.gui.Properties.Resources.icons8_minus_25px_1;
            this.btnEliminar.Location = new System.Drawing.Point(740, 68);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(40, 40);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::Matricula.gui.Properties.Resources.icons8_edit_25px_1;
            this.btnEditar.Location = new System.Drawing.Point(694, 68);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(40, 40);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Matricula.gui.Properties.Resources.icons8_search_25px_1;
            this.btnBuscar.Location = new System.Drawing.Point(360, 68);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(40, 40);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 441);
            this.Controls.Add(this.tabla);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnContrasena);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.pnlTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Matricula 0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUsuario_FormClosing);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnContrasena;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn objData;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtbCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtbIdPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtbNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtbTipoUsuario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkbActivo;
    }
}