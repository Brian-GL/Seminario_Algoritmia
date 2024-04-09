/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 28/10/2019
 * Hora: 8:58
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Seminario_Algoritmia
{
	/// <summary>
	/// Description of ImagenGrande.
	/// </summary>
	public partial class ImagenGrande : Form
	{
		Bitmap imagen;
		public ImagenGrande(Bitmap bmp)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			imagen = bmp;
		}
		void ImagenGrandeLoad(object sender, EventArgs e)
		{
			pictureBoxImagen.Image = imagen;
		}
		void ImagenGrandeFormClosing(object sender, FormClosingEventArgs e)
		{
			this.Dispose();
		}
		void PictureBoxImagenMouseDown(object sender, MouseEventArgs e)
		{
			MessageBox.Show(e.X.ToString(),e.Y.ToString());
		}

	}
}
