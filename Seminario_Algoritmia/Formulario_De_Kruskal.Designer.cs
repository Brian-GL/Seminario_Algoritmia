/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 30/10/2019
 * Hora: 16:05
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Seminario_Algoritmia
{
	partial class Formulario_De_Kruskal
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBoxKruskal;
		private System.Windows.Forms.Button buttonAnimarKruskal;
		private System.Windows.Forms.DataGridView dgvGraph;
		private System.Windows.Forms.DataGridViewButtonColumn Origin;
		private System.Windows.Forms.DataGridViewButtonColumn Weight;
		private System.Windows.Forms.DataGridViewButtonColumn Destination;
		private System.Windows.Forms.Label labelCostoARM;
		private System.Windows.Forms.TextBox textBoxCostoTotal;
		private System.Windows.Forms.TextBox textBoxNumeroBosques;
		private System.Windows.Forms.Label labelNumeroBosques;
		private System.Windows.Forms.Button buttonAgregarCebo;
		private System.Windows.Forms.Button buttonSimular;
		private System.Windows.Forms.ComboBox comboBoxPrimerAgente;
		private System.Windows.Forms.ComboBox comboBoxSegundoAgente;
		private System.Windows.Forms.Label labelPrimerAgente;
		private System.Windows.Forms.Label labelAgente2;
		
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
			this.pictureBoxKruskal = new System.Windows.Forms.PictureBox();
			this.buttonAnimarKruskal = new System.Windows.Forms.Button();
			this.dgvGraph = new System.Windows.Forms.DataGridView();
			this.Origin = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Weight = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Destination = new System.Windows.Forms.DataGridViewButtonColumn();
			this.labelCostoARM = new System.Windows.Forms.Label();
			this.textBoxCostoTotal = new System.Windows.Forms.TextBox();
			this.textBoxNumeroBosques = new System.Windows.Forms.TextBox();
			this.labelNumeroBosques = new System.Windows.Forms.Label();
			this.buttonAgregarCebo = new System.Windows.Forms.Button();
			this.buttonSimular = new System.Windows.Forms.Button();
			this.comboBoxPrimerAgente = new System.Windows.Forms.ComboBox();
			this.comboBoxSegundoAgente = new System.Windows.Forms.ComboBox();
			this.labelPrimerAgente = new System.Windows.Forms.Label();
			this.labelAgente2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxKruskal)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvGraph)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxKruskal
			// 
			this.pictureBoxKruskal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBoxKruskal.BackColor = System.Drawing.Color.White;
			this.pictureBoxKruskal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxKruskal.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxKruskal.Name = "pictureBoxKruskal";
			this.pictureBoxKruskal.Size = new System.Drawing.Size(1033, 703);
			this.pictureBoxKruskal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxKruskal.TabIndex = 0;
			this.pictureBoxKruskal.TabStop = false;
			// 
			// buttonAnimarKruskal
			// 
			this.buttonAnimarKruskal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAnimarKruskal.BackColor = System.Drawing.Color.White;
			this.buttonAnimarKruskal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonAnimarKruskal.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAnimarKruskal.Location = new System.Drawing.Point(1051, 356);
			this.buttonAnimarKruskal.Name = "buttonAnimarKruskal";
			this.buttonAnimarKruskal.Size = new System.Drawing.Size(290, 59);
			this.buttonAnimarKruskal.TabIndex = 1;
			this.buttonAnimarKruskal.Text = "ANIMAR KRUSKAL";
			this.buttonAnimarKruskal.UseVisualStyleBackColor = false;
			this.buttonAnimarKruskal.Click += new System.EventHandler(this.ButtonAnimarKruskalClick);
			// 
			// dgvGraph
			// 
			this.dgvGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvGraph.BackgroundColor = System.Drawing.Color.DimGray;
			this.dgvGraph.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
			this.dgvGraph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGraph.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Origin,
			this.Weight,
			this.Destination});
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.Format = "N6";
			dataGridViewCellStyle1.NullValue = null;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvGraph.DefaultCellStyle = dataGridViewCellStyle1;
			this.dgvGraph.GridColor = System.Drawing.Color.White;
			this.dgvGraph.Location = new System.Drawing.Point(1051, 15);
			this.dgvGraph.Name = "dgvGraph";
			this.dgvGraph.RowHeadersVisible = false;
			this.dgvGraph.Size = new System.Drawing.Size(290, 335);
			this.dgvGraph.TabIndex = 10;
			// 
			// Origin
			// 
			this.Origin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Origin.HeaderText = "Origin";
			this.Origin.Name = "Origin";
			this.Origin.ReadOnly = true;
			this.Origin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// Weight
			// 
			this.Weight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Weight.HeaderText = "Weight";
			this.Weight.Name = "Weight";
			this.Weight.ReadOnly = true;
			this.Weight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// Destination
			// 
			this.Destination.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Destination.HeaderText = "Destination";
			this.Destination.Name = "Destination";
			this.Destination.ReadOnly = true;
			// 
			// labelCostoARM
			// 
			this.labelCostoARM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.labelCostoARM.BackColor = System.Drawing.Color.Transparent;
			this.labelCostoARM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelCostoARM.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCostoARM.ForeColor = System.Drawing.Color.White;
			this.labelCostoARM.Location = new System.Drawing.Point(1051, 428);
			this.labelCostoARM.Name = "labelCostoARM";
			this.labelCostoARM.Size = new System.Drawing.Size(286, 23);
			this.labelCostoARM.TabIndex = 11;
			this.labelCostoARM.Text = "Costo Del ARM:";
			// 
			// textBoxCostoTotal
			// 
			this.textBoxCostoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCostoTotal.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxCostoTotal.Location = new System.Drawing.Point(1051, 454);
			this.textBoxCostoTotal.Name = "textBoxCostoTotal";
			this.textBoxCostoTotal.Size = new System.Drawing.Size(286, 27);
			this.textBoxCostoTotal.TabIndex = 12;
			// 
			// textBoxNumeroBosques
			// 
			this.textBoxNumeroBosques.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNumeroBosques.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxNumeroBosques.Location = new System.Drawing.Point(1051, 522);
			this.textBoxNumeroBosques.Name = "textBoxNumeroBosques";
			this.textBoxNumeroBosques.Size = new System.Drawing.Size(290, 27);
			this.textBoxNumeroBosques.TabIndex = 14;
			// 
			// labelNumeroBosques
			// 
			this.labelNumeroBosques.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumeroBosques.BackColor = System.Drawing.Color.Transparent;
			this.labelNumeroBosques.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelNumeroBosques.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNumeroBosques.ForeColor = System.Drawing.Color.White;
			this.labelNumeroBosques.Location = new System.Drawing.Point(1051, 492);
			this.labelNumeroBosques.Name = "labelNumeroBosques";
			this.labelNumeroBosques.Size = new System.Drawing.Size(286, 24);
			this.labelNumeroBosques.TabIndex = 13;
			this.labelNumeroBosques.Text = "Número De Bosques:";
			// 
			// buttonAgregarCebo
			// 
			this.buttonAgregarCebo.BackColor = System.Drawing.Color.White;
			this.buttonAgregarCebo.Enabled = false;
			this.buttonAgregarCebo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonAgregarCebo.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAgregarCebo.Location = new System.Drawing.Point(1051, 558);
			this.buttonAgregarCebo.Name = "buttonAgregarCebo";
			this.buttonAgregarCebo.Size = new System.Drawing.Size(123, 52);
			this.buttonAgregarCebo.TabIndex = 15;
			this.buttonAgregarCebo.Text = "AGREGAR CEBO";
			this.buttonAgregarCebo.UseVisualStyleBackColor = false;
			this.buttonAgregarCebo.Click += new System.EventHandler(this.ButtonAgregarCeboClick);
			// 
			// buttonSimular
			// 
			this.buttonSimular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSimular.BackColor = System.Drawing.Color.White;
			this.buttonSimular.Enabled = false;
			this.buttonSimular.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonSimular.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSimular.Location = new System.Drawing.Point(1189, 560);
			this.buttonSimular.Name = "buttonSimular";
			this.buttonSimular.Size = new System.Drawing.Size(149, 49);
			this.buttonSimular.TabIndex = 18;
			this.buttonSimular.Text = "SIMULAR";
			this.buttonSimular.UseVisualStyleBackColor = false;
			this.buttonSimular.Click += new System.EventHandler(this.ButtonSimularClick);
			// 
			// comboBoxPrimerAgente
			// 
			this.comboBoxPrimerAgente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxPrimerAgente.Enabled = false;
			this.comboBoxPrimerAgente.Font = new System.Drawing.Font("Maiandra GD", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxPrimerAgente.ForeColor = System.Drawing.Color.Black;
			this.comboBoxPrimerAgente.FormattingEnabled = true;
			this.comboBoxPrimerAgente.Location = new System.Drawing.Point(1183, 631);
			this.comboBoxPrimerAgente.Name = "comboBoxPrimerAgente";
			this.comboBoxPrimerAgente.Size = new System.Drawing.Size(155, 33);
			this.comboBoxPrimerAgente.TabIndex = 19;
			this.comboBoxPrimerAgente.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPrimerAgenteSelectedIndexChanged);
			// 
			// comboBoxSegundoAgente
			// 
			this.comboBoxSegundoAgente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSegundoAgente.Enabled = false;
			this.comboBoxSegundoAgente.Font = new System.Drawing.Font("Maiandra GD", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxSegundoAgente.ForeColor = System.Drawing.Color.Black;
			this.comboBoxSegundoAgente.FormattingEnabled = true;
			this.comboBoxSegundoAgente.Location = new System.Drawing.Point(1183, 682);
			this.comboBoxSegundoAgente.Name = "comboBoxSegundoAgente";
			this.comboBoxSegundoAgente.Size = new System.Drawing.Size(155, 33);
			this.comboBoxSegundoAgente.TabIndex = 20;
			this.comboBoxSegundoAgente.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSegundoAgenteSelectedIndexChanged);
			// 
			// labelPrimerAgente
			// 
			this.labelPrimerAgente.BackColor = System.Drawing.Color.Turquoise;
			this.labelPrimerAgente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelPrimerAgente.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPrimerAgente.ForeColor = System.Drawing.Color.White;
			this.labelPrimerAgente.Location = new System.Drawing.Point(1051, 631);
			this.labelPrimerAgente.Name = "labelPrimerAgente";
			this.labelPrimerAgente.Size = new System.Drawing.Size(123, 33);
			this.labelPrimerAgente.TabIndex = 21;
			this.labelPrimerAgente.Text = "AGENTE #1:";
			this.labelPrimerAgente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelAgente2
			// 
			this.labelAgente2.BackColor = System.Drawing.Color.Maroon;
			this.labelAgente2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelAgente2.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAgente2.ForeColor = System.Drawing.Color.White;
			this.labelAgente2.Location = new System.Drawing.Point(1051, 682);
			this.labelAgente2.Name = "labelAgente2";
			this.labelAgente2.Size = new System.Drawing.Size(123, 33);
			this.labelAgente2.TabIndex = 22;
			this.labelAgente2.Text = "AGENTE #2:";
			this.labelAgente2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Formulario_De_Kruskal
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1350, 727);
			this.Controls.Add(this.labelAgente2);
			this.Controls.Add(this.labelPrimerAgente);
			this.Controls.Add(this.comboBoxSegundoAgente);
			this.Controls.Add(this.comboBoxPrimerAgente);
			this.Controls.Add(this.buttonSimular);
			this.Controls.Add(this.buttonAgregarCebo);
			this.Controls.Add(this.textBoxNumeroBosques);
			this.Controls.Add(this.labelNumeroBosques);
			this.Controls.Add(this.textBoxCostoTotal);
			this.Controls.Add(this.labelCostoARM);
			this.Controls.Add(this.dgvGraph);
			this.Controls.Add(this.buttonAnimarKruskal);
			this.Controls.Add(this.pictureBoxKruskal);
			this.MinimumSize = new System.Drawing.Size(1364, 766);
			this.Name = "Formulario_De_Kruskal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "KRUSKAL";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxKruskal)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvGraph)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
