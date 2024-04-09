/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 05/10/2019
 * Hora: 13:09
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Seminario_Algoritmia
{
	partial class Formulario_De_Animacion
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox ptbImagen;
		
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
			this.ptbImagen = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.ptbImagen)).BeginInit();
			this.SuspendLayout();
			// 
			// ptbImagen
			// 
			this.ptbImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.ptbImagen.BackColor = System.Drawing.Color.White;
			this.ptbImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ptbImagen.Location = new System.Drawing.Point(12, 12);
			this.ptbImagen.Name = "ptbImagen";
			this.ptbImagen.Size = new System.Drawing.Size(1328, 705);
			this.ptbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.ptbImagen.TabIndex = 0;
			this.ptbImagen.TabStop = false;
			this.ptbImagen.DoubleClick += new System.EventHandler(this.PtbImagenDoubleClick);
			// 
			// Formulario_De_Animacion
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1352, 729);
			this.Controls.Add(this.ptbImagen);
			this.Name = "Formulario_De_Animacion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Formulario_De_Animacion";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Formulario_De_AnimacionFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.ptbImagen)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
