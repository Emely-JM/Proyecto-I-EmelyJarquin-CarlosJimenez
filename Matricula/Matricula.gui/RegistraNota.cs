using Matricula.bo;
using Matricula.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matricula.gui
{
    public partial class RegistraNota : Form
    {
        private ValidaDatos validar;
        private RegistroNotaBO log;
        private MatriculaEstudianteBO logE;
        private List<MatriculaEstudiante> listaE;
        private AsignacionBO logA;
        private List<Asignacion> listaA;

        /// <summary>
        /// Método que imprime un errorProvider en el textBox pasado por parámetro 
        /// y con el mensaje indicado en el parámetro
        /// </summary>
        /// <param name="text"> representa el textBox al que se le dará foco para imprimir el mensaje</param>
        /// <param name="mensaje"> representa el mensaje que se desea imprimir </param>
        private void mensajeText(TextBox text, string mensaje)
        {
            errorProvider1.SetError(text, mensaje);
            text.Focus();
            return;
        }

        /// <summary>
        /// Carga los combos con los datos de la matricula.
        /// </summary>
        private void cargarCombo(string id)
        {
            listaA = logA.getLista();
            for (int i = 0; i < listaA.Count; i++)
            {
                if (listaA[i].idProf.Equals(id))
                {
                    cmbMateria.Items.Add(listaA[i].idMateria);
                    cmbMateria.SelectedIndex = 0;
                    cmbPeriodo.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Carga el combos de los estudiantes según la materia seleccionada
        /// </summary>
        /// <param name="idMateria"></param>
        public void cargarComboEstudiantes(string idMateria)
        {
            listaE = logE.getLista();
            cmbEstudiante.Items.Clear();
            cmbEstudiante.Text = "";
            for (int i = 0; i < listaE.Count; i++)
            {
                if (listaE[i].estado.Equals("Matriculado") && listaE[i].idMateria.Equals(idMateria))
                {
                    cmbEstudiante.Items.Add(listaE[i].idPersona);
                    cmbEstudiante.SelectedIndex = 0;
                }
            }

        }

        /// <summary>
        /// Válida que no hayan errores en las cajas text y combos.
        /// Envia los datos a guardar en BO y crea el archivo
        /// </summary>
        private void aceptar()
        {
            int suma = 0;
            int proyectos = 0;
            int labs = 0;
            int exams = 0;
            int pruebasC = 0;
            float nota = 0;
            if (log.permitirNota(cmbPeriodo.Text, cmbEstudiante.Text, cmbMateria.Text) != -1)
            {
                MessageBox.Show("Ya calificó a este estudiante", "Calificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!txtProyecto.Text.Equals(""))
                {
                    errorProvider1.SetError(txtProyecto, "");
                    if (!txtLaboratorio.Text.Equals(""))
                    {
                        errorProvider1.SetError(txtLaboratorio, "");
                        if (!txtExamenes.Text.Equals(""))
                        {
                            errorProvider1.SetError(txtExamenes, "");
                            if (!txtPruebasCortas.Text.Equals(""))
                            {
                                errorProvider1.SetError(txtPruebasCortas, "");
                                proyectos = int.Parse(txtProyecto.Text);
                                labs = int.Parse(txtLaboratorio.Text);
                                exams = int.Parse(txtExamenes.Text);
                                pruebasC = int.Parse(txtPruebasCortas.Text);
                                suma = proyectos + labs + exams + pruebasC;
                                txtTotal.Text = suma.ToString();
                                if (suma <= 100)
                                {
                                    nota = log.calculaNota(proyectos, labs, exams, pruebasC);
                                    txtNota.Text = nota.ToString();
                                    if (nota >= 70)
                                    {
                                        txtEstado.Text = "Aprobado";
                                    }
                                    else
                                    {
                                        txtEstado.Text = "Reprobado";
                                    }
                                    log.agregar(cmbPeriodo.Text, cmbMateria.Text, cmbEstudiante.Text, int.Parse(txtNota.Text), txtEstado.Text);
                                    log.crearArchivo();
                                    MessageBox.Show("Total de pts obtenidos: " + txtTotal.Text + "\nNota obtenida: " + txtNota.Text + "\nEstado: " + txtEstado.Text, "Calificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                {
                                    mensajeText(txtTotal, "La suma de pts de los proyectos, laboratorios, examenes y pruebas cortas no puede superar los 100 pts");
                                }
                            }
                            else
                            {
                                mensajeText(txtPruebasCortas, "Debe ingresar los puntos obtenidos por el estudiante");
                            }

                        }
                        else
                        {
                            mensajeText(txtExamenes, "Debe ingresar los puntos obtenidos por el estudiante");
                        }

                    }
                    else
                    {
                        mensajeText(txtLaboratorio, "Debe ingresar los puntos obtenidos por el estudiante");
                    }

                }
                else
                {
                    mensajeText(txtProyecto, "Debe ingresar los puntos obtenidos por el estudiante");
                }
            }



        }

        public RegistraNota(string id)
        {
            InitializeComponent();
            log = new RegistroNotaBO();
            logE = new MatriculaEstudianteBO();
            validar = new ValidaDatos();
            listaE = new List<MatriculaEstudiante>();
            logA = new AsignacionBO();
            listaA = new List<Asignacion>();
            cargarCombo(id);
        }

        private void txtProyecto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }

        private void txtLaboratorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }

        private void txtExamenes_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }

        private void txtPruebasCortas_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboEstudiantes(cmbMateria.Text);
        }
    }
}
