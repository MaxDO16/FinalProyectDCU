using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'agendaElectronicaDataSet.Contactos' Puede moverla o quitarla según sea necesario.
            this.contactosTableAdapter.Fill(this.agendaElectronicaDataSet.Contactos);

        }

        private void contactosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.contactosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.agendaElectronicaDataSet);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            contactosBindingSource.MoveFirst();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contactosBindingSource.MovePrevious();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            contactosBindingSource.MoveNext();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            contactosBindingSource.MoveLast();
        }

        private void ActualizarNumeroRegistro()
        {
            string Ps = Convert.ToString(contactosBindingSource.Position + 1);
            string RT = Convert.ToString(contactosBindingSource.Count);
            Lregs.Text = Ps + " / " + RT;
        }

        private void iDTextBox_TextChanged(object sender, EventArgs e)
        {
            if(iDTextBox.Text == "")
                LbID.ForeColor = Color.Red;
            else
                LbID.ForeColor = Color.Black;

            ActualizarNumeroRegistro();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            contactosBindingSource.AddNew();
            iDTextBox.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            contactosBindingSource.CancelEdit();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Completo())
                try
                {
                    contactosBindingSource.EndEdit();
                    contactosTableAdapter.Update(agendaElectronicaDataSet.Contactos);
                    Blk();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se Guardo / " + ex.Message, "A T E N C I O N");

                }
            else
                MessageBox.Show("Registro Incompleto", "A T E N C I O N");
        }

        private void Blk()
        {
            BnCancelar.Enabled = true;
            contactosDataGridView.Enabled = false;
            contactosBindingNavigator.Enabled = false;
            panel2.Enabled = false;
            BnNuevo.Enabled = false;
            BtnBorrar.Enabled = false;

        }

        private void DBlk()
        {
            BnCancelar.Enabled = true;
            contactosDataGridView.Enabled = true;
            contactosBindingNavigator.Enabled = true;
            panel2.Enabled = true;
            BnNuevo.Enabled = true;
            BtnBorrar.Enabled = true;

        }

        private bool Completo()
        {
            if ((iDTextBox.Text != "")&&(nombreTextBox.Text !=""))
                return true;
            else
                return false;

        }

        private void nombreTextBox_TextChanged(object sender, EventArgs e)
        {
            if (nombreTextBox.Text == "")
                Lnombre.ForeColor = Color.Red;
            else
                Lnombre.ForeColor = Color.Black;
        }

        private void apellidoLabel_Click(object sender, EventArgs e)
        {
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult OP = MessageBox.Show("Eliminar?", "ATENCION", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (OP == DialogResult.Yes)
            {
                contactosBindingSource.RemoveCurrent();
                contactosTableAdapter.Update(agendaElectronicaDataSet.Contactos);
                this.contactosTableAdapter.Fill(this.agendaElectronicaDataSet.Contactos);
            }
        }
    }


}
