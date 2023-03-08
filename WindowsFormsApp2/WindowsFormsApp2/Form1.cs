using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       private string obtenerinfo(string archivo)
        {
            string informacion;

            informacion = archivo+"existe\r\n\r\n";

            informacion += "creacion: " + File.GetCreationTime(archivo) + "\r\n";

            informacion += "ultima modificacion: " + File.GetLastWriteTime(archivo) + "\r\n";

            informacion += "ultimo acceso " + File.GetLastAccessTime(archivo) + "\r\n"+ "\r\n";

            return informacion;
        }


        // se invoca cuando el usuairio uno cree
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //determina si el usuario oprimio la tecla enter



            if(e.KeyCode == Keys.Enter)
            {

                string archivo;  //archivo


                //obtiene el archivo o directorio especificado

                archivo = textBox1.Text;

                //determine  si archivo  es un archivo
                if (File.Exists(archivo))
                {
                    textBox2.Text = archivo;
                    try
                    {
                        StreamReader sr = new StreamReader(archivo);
                        textBox2.Text += sr.ReadToEnd();
                    }
                    catch(IOException)
                    {

                        MessageBox.Show("Error al leer el archivo","Error el archivo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        throw;
                    }
                  

                }
                else if (Directory.Exists(archivo))
                {
                    string[] listaD;

                    textBox2.Text = obtenerinfo(archivo);


                    listaD = Directory.GetDirectories(archivo);

                    textBox2.Text += "\r\n\r\nContenido del directorio: \r\n";

                    for(int i = 0; i < listaD.Length; i++)
                    {

                        textBox2.Text += listaD[i]+"\r\n";

                    }
                }
                else
                {
                    MessageBox.Show(textBox1.Text+ " no existe","error de archivo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }




            }







        }
    }
}
