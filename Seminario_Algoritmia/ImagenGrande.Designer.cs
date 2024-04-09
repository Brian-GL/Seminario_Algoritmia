/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 28/10/2019
 * Hora: 8:58
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Seminario_Algoritmia
{
	partial class ImagenGrande
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBoxImagen;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBoxImagen = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxImagen
			// 
			this.pictureBoxImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.pictureBoxImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBoxImagen.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxImagen.Name = "pictureBoxImagen";
			this.pictureBoxImagen.Size = new System.Drawing.Size(1326, 703);
			this.pictureBoxImagen.TabIndex = 0;
			this.pictureBoxImagen.TabStop = false;
			this.pictureBoxImagen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxImagenMouseDown);
			// 
			// ImagenGrande
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1350, 727);
			this.Controls.Add(this.pictureBoxImagen);
			this.MinimumSize = new System.Drawing.Size(1360, 760);
			this.Name = "ImagenGrande";
			this.Text = "IMAGEN";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImagenGrandeFormClosing);
			this.Load += new System.EventHandler(this.ImagenGrandeLoad);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
