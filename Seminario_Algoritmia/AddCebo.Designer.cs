/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 02/11/2019
 * Hora: 20:33
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Seminario_Algoritmia
{
	partial class AddCebo
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label lblTituloAgregarAgentesManual;
		private System.Windows.Forms.Label lblSeleccion;
		private System.Windows.Forms.DataGridView dgvDatosVertices;
		private System.Windows.Forms.DataGridViewTextBoxColumn Nodo;
		
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
			this.lblTituloAgregarAgentesManual = new System.Windows.Forms.Label();
			this.lblSeleccion = new System.Windows.Forms.Label();
			this.dgvDatosVertices = new System.Windows.Forms.DataGridView();
			this.Nodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvDatosVertices)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTituloAgregarAgentesManual
			// 
			this.lblTituloAgregarAgentesManual.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblTituloAgregarAgentesManual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTituloAgregarAgentesManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lblTituloAgregarAgentesManual.Font = new System.Drawing.Font("Tw Cen MT Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTituloAgregarAgentesManual.Location = new System.Drawing.Point(43, 9);
			this.lblTituloAgregarAgentesManual.Name = "lblTituloAgregarAgentesManual";
			this.lblTituloAgregarAgentesManual.Size = new System.Drawing.Size(280, 44);
			this.lblTituloAgregarAgentesManual.TabIndex = 1;
			this.lblTituloAgregarAgentesManual.Text = "Agregar Nuevo Cebo";
			this.lblTituloAgregarAgentesManual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSeleccion
			// 
			this.lblSeleccion.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSeleccion.Location = new System.Drawing.Point(12, 72);
			this.lblSeleccion.Name = "lblSeleccion";
			this.lblSeleccion.Size = new System.Drawing.Size(347, 27);
			this.lblSeleccion.TabIndex = 4;
			this.lblSeleccion.Text = "Seleccione un vertice dando doble click:";
			// 
			// dgvDatosVertices
			// 
			this.dgvDatosVertices.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.dgvDatosVertices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDatosVertices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Nodo});
			this.dgvDatosVertices.Location = new System.Drawing.Point(12, 102);
			this.dgvDatosVertices.Name = "dgvDatosVertices";
			this.dgvDatosVertices.Size = new System.Drawing.Size(347, 281);
			this.dgvDatosVertices.TabIndex = 5;
			this.dgvDatosVertices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDatosVerticesCellDoubleClick);
			// 
			// Nodo
			// 
			this.Nodo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Nodo.HeaderText = "NODOS";
			this.Nodo.Name = "Nodo";
			// 
			// AddCebo
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(371, 395);
			this.Controls.Add(this.dgvDatosVertices);
			this.Controls.Add(this.lblSeleccion);
			this.Controls.Add(this.lblTituloAgregarAgentesManual);
			this.Name = "AddCebo";
			this.Text = "ADD CEBO";
			((System.ComponentModel.ISupportInitialize)(this.dgvDatosVertices)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
