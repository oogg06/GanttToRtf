using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GanttToWord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

   
        private void btnElegirFichero_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult eleccion;
            dlg.Filter = "gan files (*.gan)|*.gan|All files (*.*)|*.*";
            eleccion = dlg.ShowDialog();

            if (eleccion == DialogResult.OK)
            {
                txtFile.Text = dlg.FileName;
            }            
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtFile.Text))
            {
                MessageBox.Show(txtFile.Text + " doesn't exist. Please choose another file");
                txtFile.Text = "";
            }
            GanttToRTFConverter conv = new GanttToRTFConverter(txtFile.Text);
            conv.convert("ddd.rtf");
        }

     
    }
}
