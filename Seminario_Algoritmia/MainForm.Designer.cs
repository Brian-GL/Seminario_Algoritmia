/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 02/10/2019
 * Hora: 10:23
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Seminario_Algoritmia
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label lblTitulo;
		private System.Windows.Forms.Button btnAbrirImagen;
		private System.Windows.Forms.Label lblImageName;
		private System.Windows.Forms.TextBox txbImageName;
		private System.Windows.Forms.DataGridView dgvVertexs;
		private System.Windows.Forms.DataGridViewButtonColumn Vertex;
		private System.Windows.Forms.DataGridViewButtonColumn X;
		private System.Windows.Forms.DataGridViewButtonColumn Y;
		private System.Windows.Forms.DataGridViewButtonColumn Vertical_Ratio;
		private System.Windows.Forms.DataGridViewButtonColumn Horizontal_Ratio;
		public System.Windows.Forms.PictureBox ptbImage;
		private System.Windows.Forms.DataGridView dgvGraph;
		private System.Windows.Forms.DataGridViewButtonColumn Origin;
		private System.Windows.Forms.DataGridViewButtonColumn Weight;
		private System.Windows.Forms.DataGridViewButtonColumn Destination;
		private System.Windows.Forms.Button btnAgregarNuevoCebo;
		private System.Windows.Forms.Button btnSimular;
		private System.Windows.Forms.ProgressBar myProgressBar;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnjAleatoridad;
		private System.Windows.Forms.Button buttonKruskal;
		private System.Windows.Forms.Button buttonPrim;
		private System.Windows.Forms.Button buttonComparacion;
		private System.Windows.Forms.Button buttonDijkstra;
		private System.Windows.Forms.Button buttonPresasDepredadores;
		
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.lblTitulo = new System.Windows.Forms.Label();
			this.btnAbrirImagen = new System.Windows.Forms.Button();
			this.lblImageName = new System.Windows.Forms.Label();
			this.txbImageName = new System.Windows.Forms.TextBox();
			this.dgvVertexs = new System.Windows.Forms.DataGridView();
			this.Vertex = new System.Windows.Forms.DataGridViewButtonColumn();
			this.X = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Y = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Vertical_Ratio = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Horizontal_Ratio = new System.Windows.Forms.DataGridViewButtonColumn();
			this.ptbImage = new System.Windows.Forms.PictureBox();
			this.dgvGraph = new System.Windows.Forms.DataGridView();
			this.Origin = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Weight = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Destination = new System.Windows.Forms.DataGridViewButtonColumn();
			this.btnAgregarNuevoCebo = new System.Windows.Forms.Button();
			this.btnSimular = new System.Windows.Forms.Button();
			this.myProgressBar = new System.Windows.Forms.ProgressBar();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnjAleatoridad = new System.Windows.Forms.Button();
			this.buttonKruskal = new System.Windows.Forms.Button();
			this.buttonPrim = new System.Windows.Forms.Button();
			this.buttonComparacion = new System.Windows.Forms.Button();
			this.buttonDijkstra = new System.Windows.Forms.Button();
			this.buttonPresasDepredadores = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvVertexs)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ptbImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvGraph)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblTitulo.BackColor = System.Drawing.Color.White;
			this.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTitulo.Font = new System.Drawing.Font("Tw Cen MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitulo.Location = new System.Drawing.Point(0, 0);
			this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTitulo.Name = "lblTitulo";
			this.lblTitulo.Size = new System.Drawing.Size(226, 32);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "ETAPA 5";
			this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnAbrirImagen
			// 
			this.btnAbrirImagen.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnAbrirImagen.BackColor = System.Drawing.Color.White;
			this.btnAbrirImagen.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAbrirImagen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnAbrirImagen.Location = new System.Drawing.Point(0, 46);
			this.btnAbrirImagen.Margin = new System.Windows.Forms.Padding(2);
			this.btnAbrirImagen.Name = "btnAbrirImagen";
			this.btnAbrirImagen.Size = new System.Drawing.Size(226, 42);
			this.btnAbrirImagen.TabIndex = 1;
			this.btnAbrirImagen.Text = "OPEN IMAGE";
			this.btnAbrirImagen.UseVisualStyleBackColor = false;
			this.btnAbrirImagen.Click += new System.EventHandler(this.BtnAbrirImagenClick);
			// 
			// lblImageName
			// 
			this.lblImageName.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblImageName.BackColor = System.Drawing.Color.Transparent;
			this.lblImageName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblImageName.Font = new System.Drawing.Font("Tw Cen MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblImageName.Location = new System.Drawing.Point(247, 0);
			this.lblImageName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblImageName.Name = "lblImageName";
			this.lblImageName.Size = new System.Drawing.Size(180, 32);
			this.lblImageName.TabIndex = 2;
			this.lblImageName.Text = "Image Name:";
			this.lblImageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txbImageName
			// 
			this.txbImageName.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txbImageName.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txbImageName.Location = new System.Drawing.Point(246, 46);
			this.txbImageName.Multiline = true;
			this.txbImageName.Name = "txbImageName";
			this.txbImageName.ReadOnly = true;
			this.txbImageName.Size = new System.Drawing.Size(181, 42);
			this.txbImageName.TabIndex = 3;
			// 
			// dgvVertexs
			// 
			this.dgvVertexs.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.dgvVertexs.BackgroundColor = System.Drawing.Color.White;
			this.dgvVertexs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvVertexs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Vertex,
			this.X,
			this.Y,
			this.Vertical_Ratio,
			this.Horizontal_Ratio});
			this.dgvVertexs.GridColor = System.Drawing.Color.White;
			this.dgvVertexs.Location = new System.Drawing.Point(0, 103);
			this.dgvVertexs.Name = "dgvVertexs";
			this.dgvVertexs.RowHeadersVisible = false;
			this.dgvVertexs.Size = new System.Drawing.Size(429, 239);
			this.dgvVertexs.TabIndex = 5;
			this.dgvVertexs.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvVertexsCellContentDoubleClick);
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
			// ptbImage
			// 
			this.ptbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.ptbImage.BackColor = System.Drawing.Color.White;
			this.ptbImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ptbImage.Cursor = System.Windows.Forms.Cursors.Cross;
			this.ptbImage.Location = new System.Drawing.Point(434, 0);
			this.ptbImage.Name = "ptbImage";
			this.ptbImage.Size = new System.Drawing.Size(920, 623);
			this.ptbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.ptbImage.TabIndex = 6;
			this.ptbImage.TabStop = false;
			this.ptbImage.DoubleClick += new System.EventHandler(this.PtbImageDoubleClick);
			// 
			// dgvGraph
			// 
			this.dgvGraph.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.dgvGraph.BackgroundColor = System.Drawing.Color.White;
			this.dgvGraph.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
			this.dgvGraph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGraph.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Origin,
			this.Weight,
			this.Destination});
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle6.Format = "N6";
			dataGridViewCellStyle6.NullValue = null;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvGraph.DefaultCellStyle = dataGridViewCellStyle6;
			this.dgvGraph.GridColor = System.Drawing.Color.White;
			this.dgvGraph.Location = new System.Drawing.Point(0, 348);
			this.dgvGraph.Name = "dgvGraph";
			this.dgvGraph.RowHeadersVisible = false;
			this.dgvGraph.Size = new System.Drawing.Size(429, 297);
			this.dgvGraph.TabIndex = 9;
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
			// btnAgregarNuevoCebo
			// 
			this.btnAgregarNuevoCebo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAgregarNuevoCebo.BackColor = System.Drawing.Color.White;
			this.btnAgregarNuevoCebo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregarNuevoCebo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnAgregarNuevoCebo.Location = new System.Drawing.Point(11, 652);
			this.btnAgregarNuevoCebo.Margin = new System.Windows.Forms.Padding(2);
			this.btnAgregarNuevoCebo.Name = "btnAgregarNuevoCebo";
			this.btnAgregarNuevoCebo.Size = new System.Drawing.Size(96, 73);
			this.btnAgregarNuevoCebo.TabIndex = 11;
			this.btnAgregarNuevoCebo.Text = "ADD CEBO";
			this.btnAgregarNuevoCebo.UseVisualStyleBackColor = false;
			this.btnAgregarNuevoCebo.Click += new System.EventHandler(this.BtnAgregarNuevoCeboClick);
			// 
			// btnSimular
			// 
			this.btnSimular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSimular.BackColor = System.Drawing.Color.White;
			this.btnSimular.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSimular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnSimular.Location = new System.Drawing.Point(295, 653);
			this.btnSimular.Margin = new System.Windows.Forms.Padding(2);
			this.btnSimular.Name = "btnSimular";
			this.btnSimular.Size = new System.Drawing.Size(132, 72);
			this.btnSimular.TabIndex = 12;
			this.btnSimular.Text = "SIMULATION";
			this.btnSimular.UseVisualStyleBackColor = false;
			this.btnSimular.Click += new System.EventHandler(this.BtnSimularClick);
			// 
			// myProgressBar
			// 
			this.myProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.myProgressBar.Cursor = System.Windows.Forms.Cursors.AppStarting;
			this.myProgressBar.Location = new System.Drawing.Point(432, 629);
			this.myProgressBar.Name = "myProgressBar";
			this.myProgressBar.Size = new System.Drawing.Size(920, 23);
			this.myProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.myProgressBar.TabIndex = 13;
			// 
			// btnReset
			// 
			this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnReset.BackColor = System.Drawing.Color.White;
			this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnReset.Location = new System.Drawing.Point(111, 653);
			this.btnReset.Margin = new System.Windows.Forms.Padding(2);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(60, 72);
			this.btnReset.TabIndex = 14;
			this.btnReset.Text = "RESET";
			this.btnReset.UseVisualStyleBackColor = false;
			this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
			// 
			// btnjAleatoridad
			// 
			this.btnjAleatoridad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnjAleatoridad.BackColor = System.Drawing.Color.White;
			this.btnjAleatoridad.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnjAleatoridad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnjAleatoridad.Location = new System.Drawing.Point(175, 653);
			this.btnjAleatoridad.Margin = new System.Windows.Forms.Padding(2);
			this.btnjAleatoridad.Name = "btnjAleatoridad";
			this.btnjAleatoridad.Size = new System.Drawing.Size(116, 72);
			this.btnjAleatoridad.TabIndex = 15;
			this.btnjAleatoridad.Text = "ALEATORIDAD";
			this.btnjAleatoridad.UseVisualStyleBackColor = false;
			this.btnjAleatoridad.Click += new System.EventHandler(this.BtnjAleatoridadClick);
			// 
			// buttonKruskal
			// 
			this.buttonKruskal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonKruskal.BackColor = System.Drawing.Color.White;
			this.buttonKruskal.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonKruskal.Enabled = false;
			this.buttonKruskal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.buttonKruskal.Location = new System.Drawing.Point(434, 657);
			this.buttonKruskal.Margin = new System.Windows.Forms.Padding(2);
			this.buttonKruskal.Name = "buttonKruskal";
			this.buttonKruskal.Size = new System.Drawing.Size(129, 68);
			this.buttonKruskal.TabIndex = 16;
			this.buttonKruskal.Text = "KRUSKAL";
			this.buttonKruskal.UseVisualStyleBackColor = false;
			this.buttonKruskal.Click += new System.EventHandler(this.ButtonKruskalClick);
			// 
			// buttonPrim
			// 
			this.buttonPrim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonPrim.BackColor = System.Drawing.Color.White;
			this.buttonPrim.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonPrim.Enabled = false;
			this.buttonPrim.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.buttonPrim.Location = new System.Drawing.Point(567, 657);
			this.buttonPrim.Margin = new System.Windows.Forms.Padding(2);
			this.buttonPrim.Name = "buttonPrim";
			this.buttonPrim.Size = new System.Drawing.Size(129, 68);
			this.buttonPrim.TabIndex = 17;
			this.buttonPrim.Text = "PRIM";
			this.buttonPrim.UseVisualStyleBackColor = false;
			this.buttonPrim.Click += new System.EventHandler(this.ButtonPrimClick);
			// 
			// buttonComparacion
			// 
			this.buttonComparacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonComparacion.BackColor = System.Drawing.Color.White;
			this.buttonComparacion.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonComparacion.Enabled = false;
			this.buttonComparacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.buttonComparacion.Location = new System.Drawing.Point(700, 657);
			this.buttonComparacion.Margin = new System.Windows.Forms.Padding(2);
			this.buttonComparacion.Name = "buttonComparacion";
			this.buttonComparacion.Size = new System.Drawing.Size(129, 68);
			this.buttonComparacion.TabIndex = 18;
			this.buttonComparacion.Text = "COMPARACIÓN";
			this.buttonComparacion.UseVisualStyleBackColor = false;
			this.buttonComparacion.Click += new System.EventHandler(this.ButtonComparacionClick);
			// 
			// buttonDijkstra
			// 
			this.buttonDijkstra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonDijkstra.BackColor = System.Drawing.Color.White;
			this.buttonDijkstra.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonDijkstra.Enabled = false;
			this.buttonDijkstra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.buttonDijkstra.Location = new System.Drawing.Point(833, 657);
			this.buttonDijkstra.Margin = new System.Windows.Forms.Padding(2);
			this.buttonDijkstra.Name = "buttonDijkstra";
			this.buttonDijkstra.Size = new System.Drawing.Size(129, 68);
			this.buttonDijkstra.TabIndex = 19;
			this.buttonDijkstra.Text = "DIJKSTRA";
			this.buttonDijkstra.UseVisualStyleBackColor = false;
			this.buttonDijkstra.Click += new System.EventHandler(this.ButtonDijkstraClick);
			// 
			// buttonPresasDepredadores
			// 
			this.buttonPresasDepredadores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonPresasDepredadores.BackColor = System.Drawing.Color.White;
			this.buttonPresasDepredadores.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonPresasDepredadores.Enabled = false;
			this.buttonPresasDepredadores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.buttonPresasDepredadores.Location = new System.Drawing.Point(966, 657);
			this.buttonPresasDepredadores.Margin = new System.Windows.Forms.Padding(2);
			this.buttonPresasDepredadores.Name = "buttonPresasDepredadores";
			this.buttonPresasDepredadores.Size = new System.Drawing.Size(129, 68);
			this.buttonPresasDepredadores.TabIndex = 20;
			this.buttonPresasDepredadores.Text = "PRESAS Y DEPREDADORES";
			this.buttonPresasDepredadores.UseVisualStyleBackColor = false;
			this.buttonPresasDepredadores.Click += new System.EventHandler(this.ButtonPresasDepredadoresClick);
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1356, 729);
			this.Controls.Add(this.buttonPresasDepredadores);
			this.Controls.Add(this.buttonDijkstra);
			this.Controls.Add(this.buttonComparacion);
			this.Controls.Add(this.buttonPrim);
			this.Controls.Add(this.buttonKruskal);
			this.Controls.Add(this.btnjAleatoridad);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.myProgressBar);
			this.Controls.Add(this.btnSimular);
			this.Controls.Add(this.btnAgregarNuevoCebo);
			this.Controls.Add(this.dgvGraph);
			this.Controls.Add(this.ptbImage);
			this.Controls.Add(this.dgvVertexs);
			this.Controls.Add(this.txbImageName);
			this.Controls.Add(this.lblImageName);
			this.Controls.Add(this.btnAbrirImagen);
			this.Controls.Add(this.lblTitulo);
			this.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.MinimumSize = new System.Drawing.Size(1364, 736);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Seminario_Algoritmia";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dgvVertexs)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ptbImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvGraph)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
