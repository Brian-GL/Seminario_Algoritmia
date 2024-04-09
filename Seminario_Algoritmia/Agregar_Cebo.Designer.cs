/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 23/09/2019
 * Time: 02:05 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Seminario_Algoritmia
{
	partial class Form_Agregar_Agentes_Manual
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label lblTituloAgregarAgentesManual;
		private System.Windows.Forms.DataGridView dgvDatosVertices;
		private System.Windows.Forms.DataGridViewButtonColumn Vertice;
		private System.Windows.Forms.DataGridViewTextBoxColumn X;
		private System.Windows.Forms.DataGridViewTextBoxColumn Y;
		private System.Windows.Forms.Label lblSeleccion;
		
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.lblTituloAgregarAgentesManual = new System.Windows.Forms.Label();
			this.dgvDatosVertices = new System.Windows.Forms.DataGridView();
			this.Vertice = new System.Windows.Forms.DataGridViewButtonColumn();
			this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lblSeleccion = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvDatosVertices)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTituloAgregarAgentesManual
			// 
			this.lblTituloAgregarAgentesManual.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblTituloAgregarAgentesManual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTituloAgregarAgentesManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lblTituloAgregarAgentesManual.Font = new System.Drawing.Font("Tw Cen MT Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTituloAgregarAgentesManual.Location = new System.Drawing.Point(105, 9);
			this.lblTituloAgregarAgentesManual.Name = "lblTituloAgregarAgentesManual";
			this.lblTituloAgregarAgentesManual.Size = new System.Drawing.Size(280, 44);
			this.lblTituloAgregarAgentesManual.TabIndex = 0;
			this.lblTituloAgregarAgentesManual.Text = "Agregar Nuevo Cebo";
			this.lblTituloAgregarAgentesManual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgvDatosVertices
			// 
			this.dgvDatosVertices.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.dgvDatosVertices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDatosVertices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Vertice,
			this.X,
			this.Y});
			this.dgvDatosVertices.Location = new System.Drawing.Point(4, 92);
			this.dgvDatosVertices.Name = "dgvDatosVertices";
			this.dgvDatosVertices.Size = new System.Drawing.Size(494, 281);
			this.dgvDatosVertices.TabIndex = 2;
			this.dgvDatosVertices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDatosVerticesCellDoubleClick);
			// 
			// Vertice
			// 
			this.Vertice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Vertice.DefaultCellStyle = dataGridViewCellStyle1;
			this.Vertice.HeaderText = "Vertice";
			this.Vertice.Name = "Vertice";
			this.Vertice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Vertice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// X
			// 
			this.X.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.X.HeaderText = "Coordenada En X";
			this.X.Name = "X";
			// 
			// Y
			// 
			this.Y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Y.HeaderText = "Coordenada En Y";
			this.Y.Name = "Y";
			// 
			// lblSeleccion
			// 
			this.lblSeleccion.Font = new System.Drawing.Font("Tw Cen MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSeleccion.Location = new System.Drawing.Point(3, 66);
			this.lblSeleccion.Name = "lblSeleccion";
			this.lblSeleccion.Size = new System.Drawing.Size(382, 23);
			this.lblSeleccion.TabIndex = 3;
			this.lblSeleccion.Text = "Seleccione un vertice dando doble click:";
			// 
			// Form_Agregar_Agentes_Manual
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(510, 385);
			this.Controls.Add(this.lblSeleccion);
			this.Controls.Add(this.dgvDatosVertices);
			this.Controls.Add(this.lblTituloAgregarAgentesManual);
			this.MaximizeBox = false;
			this.Name = "Form_Agregar_Agentes_Manual";
			this.Text = "Agregar_Agentes_Manual";
			((System.ComponentModel.ISupportInitialize)(this.dgvDatosVertices)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
