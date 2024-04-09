/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 13/10/2019
 * Hora: 19:33
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Seminario_Algoritmia
{
	partial class Aleatoriedad_Form
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label lblTituloAleatoriedad;
		private System.Windows.Forms.Label lblNumAgentesGen;
		private System.Windows.Forms.NumericUpDown nudValor;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.DataGridView dgvVertexs;
		private System.Windows.Forms.DataGridViewButtonColumn Vertex;
		private System.Windows.Forms.DataGridViewButtonColumn X;
		private System.Windows.Forms.DataGridViewButtonColumn Y;
		private System.Windows.Forms.DataGridViewButtonColumn Vertical_Ratio;
		private System.Windows.Forms.DataGridViewButtonColumn Horizontal_Ratio;
		private System.Windows.Forms.Label lblVerticesDisponibles;
		
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.lblTituloAleatoriedad = new System.Windows.Forms.Label();
			this.lblNumAgentesGen = new System.Windows.Forms.Label();
			this.nudValor = new System.Windows.Forms.NumericUpDown();
			this.btnAccept = new System.Windows.Forms.Button();
			this.dgvVertexs = new System.Windows.Forms.DataGridView();
			this.Vertex = new System.Windows.Forms.DataGridViewButtonColumn();
			this.X = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Y = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Vertical_Ratio = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Horizontal_Ratio = new System.Windows.Forms.DataGridViewButtonColumn();
			this.lblVerticesDisponibles = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nudValor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvVertexs)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTituloAleatoriedad
			// 
			this.lblTituloAleatoriedad.BackColor = System.Drawing.Color.White;
			this.lblTituloAleatoriedad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTituloAleatoriedad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lblTituloAleatoriedad.Font = new System.Drawing.Font("Tw Cen MT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTituloAleatoriedad.Location = new System.Drawing.Point(174, 9);
			this.lblTituloAleatoriedad.Name = "lblTituloAleatoriedad";
			this.lblTituloAleatoriedad.Size = new System.Drawing.Size(188, 47);
			this.lblTituloAleatoriedad.TabIndex = 0;
			this.lblTituloAleatoriedad.Text = "ALEATORIEDAD";
			this.lblTituloAleatoriedad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblNumAgentesGen
			// 
			this.lblNumAgentesGen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblNumAgentesGen.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNumAgentesGen.Location = new System.Drawing.Point(11, 65);
			this.lblNumAgentesGen.Name = "lblNumAgentesGen";
			this.lblNumAgentesGen.Size = new System.Drawing.Size(131, 197);
			this.lblNumAgentesGen.TabIndex = 1;
			this.lblNumAgentesGen.Text = "Numero de agentes a generar:";
			this.lblNumAgentesGen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudValor
			// 
			this.nudValor.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.nudValor.Font = new System.Drawing.Font("Tw Cen MT Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nudValor.Location = new System.Drawing.Point(10, 277);
			this.nudValor.Name = "nudValor";
			this.nudValor.Size = new System.Drawing.Size(132, 36);
			this.nudValor.TabIndex = 2;
			this.nudValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnAccept
			// 
			this.btnAccept.BackColor = System.Drawing.Color.White;
			this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAccept.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAccept.Location = new System.Drawing.Point(11, 339);
			this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(132, 90);
			this.btnAccept.TabIndex = 13;
			this.btnAccept.Text = "ACEPTAR";
			this.btnAccept.UseVisualStyleBackColor = false;
			this.btnAccept.Click += new System.EventHandler(this.BtnAcceptClick);
			// 
			// dgvVertexs
			// 
			this.dgvVertexs.BackgroundColor = System.Drawing.Color.White;
			this.dgvVertexs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvVertexs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Vertex,
			this.X,
			this.Y,
			this.Vertical_Ratio,
			this.Horizontal_Ratio});
			this.dgvVertexs.GridColor = System.Drawing.Color.White;
			this.dgvVertexs.Location = new System.Drawing.Point(159, 105);
			this.dgvVertexs.Name = "dgvVertexs";
			this.dgvVertexs.Size = new System.Drawing.Size(429, 328);
			this.dgvVertexs.TabIndex = 14;
			// 
			// Vertex
			// 
			this.Vertex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Vertex.DefaultCellStyle = dataGridViewCellStyle1;
			this.Vertex.HeaderText = "Vertex";
			this.Vertex.Name = "Vertex";
			this.Vertex.ReadOnly = true;
			// 
			// X
			// 
			this.X.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tw Cen MT", 11.25F);
			this.X.DefaultCellStyle = dataGridViewCellStyle2;
			this.X.HeaderText = "X";
			this.X.Name = "X";
			this.X.ReadOnly = true;
			// 
			// Y
			// 
			this.Y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Tw Cen MT", 11.25F);
			this.Y.DefaultCellStyle = dataGridViewCellStyle3;
			this.Y.HeaderText = "Y";
			this.Y.Name = "Y";
			this.Y.ReadOnly = true;
			// 
			// Vertical_Ratio
			// 
			this.Vertical_Ratio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Tw Cen MT", 11.25F);
			this.Vertical_Ratio.DefaultCellStyle = dataGridViewCellStyle4;
			this.Vertical_Ratio.HeaderText = "Vertical Ratio";
			this.Vertical_Ratio.Name = "Vertical_Ratio";
			this.Vertical_Ratio.ReadOnly = true;
			// 
			// Horizontal_Ratio
			// 
			this.Horizontal_Ratio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Tw Cen MT", 11.25F);
			this.Horizontal_Ratio.DefaultCellStyle = dataGridViewCellStyle5;
			this.Horizontal_Ratio.HeaderText = "Horizontal Ratio";
			this.Horizontal_Ratio.Name = "Horizontal_Ratio";
			this.Horizontal_Ratio.ReadOnly = true;
			// 
			// lblVerticesDisponibles
			// 
			this.lblVerticesDisponibles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblVerticesDisponibles.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVerticesDisponibles.Location = new System.Drawing.Point(159, 65);
			this.lblVerticesDisponibles.Name = "lblVerticesDisponibles";
			this.lblVerticesDisponibles.Size = new System.Drawing.Size(429, 37);
			this.lblVerticesDisponibles.TabIndex = 15;
			this.lblVerticesDisponibles.Text = "Vertices Disponibles:";
			this.lblVerticesDisponibles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Aleatoriedad_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(600, 440);
			this.Controls.Add(this.lblVerticesDisponibles);
			this.Controls.Add(this.dgvVertexs);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.nudValor);
			this.Controls.Add(this.lblNumAgentesGen);
			this.Controls.Add(this.lblTituloAleatoriedad);
			this.MaximizeBox = false;
			this.Name = "Aleatoriedad_Form";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CREATE ALEATORIEDAD";
			((System.ComponentModel.ISupportInitialize)(this.nudValor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvVertexs)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
