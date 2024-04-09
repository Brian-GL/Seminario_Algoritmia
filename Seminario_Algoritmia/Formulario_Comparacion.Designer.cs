/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 13/11/2019
 * Time: 01:43 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Seminario_Algoritmia
{
	partial class Formulario_Comparacion
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBoxGrafo;
		private System.Windows.Forms.Label labelNodoIncial;
		private System.Windows.Forms.Button buttonAnimar;
		private System.Windows.Forms.ComboBox comboBoxNodos;
		private System.Windows.Forms.DataGridView dgvGraphKruskal;
		private System.Windows.Forms.DataGridViewButtonColumn Origin;
		private System.Windows.Forms.DataGridViewButtonColumn Weight;
		private System.Windows.Forms.DataGridViewButtonColumn Destination;
		private System.Windows.Forms.DataGridView dgvGraphPrim;
		private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
		private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
		private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
		private System.Windows.Forms.Label labelKruskal;
		private System.Windows.Forms.Label labelPrim;
		private System.Windows.Forms.Label labelPesoKruskal;
		private System.Windows.Forms.Label labelPesoPrim;
		
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
			this.pictureBoxGrafo = new System.Windows.Forms.PictureBox();
			this.labelNodoIncial = new System.Windows.Forms.Label();
			this.buttonAnimar = new System.Windows.Forms.Button();
			this.comboBoxNodos = new System.Windows.Forms.ComboBox();
			this.dgvGraphKruskal = new System.Windows.Forms.DataGridView();
			this.Origin = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Weight = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Destination = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dgvGraphPrim = new System.Windows.Forms.DataGridView();
			this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.labelKruskal = new System.Windows.Forms.Label();
			this.labelPrim = new System.Windows.Forms.Label();
			this.labelPesoKruskal = new System.Windows.Forms.Label();
			this.labelPesoPrim = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrafo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvGraphKruskal)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvGraphPrim)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxGrafo
			// 
			this.pictureBoxGrafo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBoxGrafo.BackColor = System.Drawing.Color.White;
			this.pictureBoxGrafo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxGrafo.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxGrafo.Name = "pictureBoxGrafo";
			this.pictureBoxGrafo.Size = new System.Drawing.Size(1033, 703);
			this.pictureBoxGrafo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxGrafo.TabIndex = 1;
			this.pictureBoxGrafo.TabStop = false;
			// 
			// labelNodoIncial
			// 
			this.labelNodoIncial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.labelNodoIncial.BackColor = System.Drawing.Color.Transparent;
			this.labelNodoIncial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelNodoIncial.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNodoIncial.ForeColor = System.Drawing.Color.White;
			this.labelNodoIncial.Location = new System.Drawing.Point(1051, 317);
			this.labelNodoIncial.Name = "labelNodoIncial";
			this.labelNodoIncial.Size = new System.Drawing.Size(290, 23);
			this.labelNodoIncial.TabIndex = 31;
			this.labelNodoIncial.Text = "Nodo Inicial:";
			// 
			// buttonAnimar
			// 
			this.buttonAnimar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAnimar.BackColor = System.Drawing.Color.White;
			this.buttonAnimar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonAnimar.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAnimar.Location = new System.Drawing.Point(1051, 370);
			this.buttonAnimar.Name = "buttonAnimar";
			this.buttonAnimar.Size = new System.Drawing.Size(287, 34);
			this.buttonAnimar.TabIndex = 29;
			this.buttonAnimar.Text = "ANIMAR";
			this.buttonAnimar.UseVisualStyleBackColor = false;
			this.buttonAnimar.Click += new System.EventHandler(this.ButtonAnimarClick);
			// 
			// comboBoxNodos
			// 
			this.comboBoxNodos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxNodos.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxNodos.FormattingEnabled = true;
			this.comboBoxNodos.Location = new System.Drawing.Point(1051, 338);
			this.comboBoxNodos.Name = "comboBoxNodos";
			this.comboBoxNodos.Size = new System.Drawing.Size(290, 24);
			this.comboBoxNodos.TabIndex = 30;
			// 
			// dgvGraphKruskal
			// 
			this.dgvGraphKruskal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvGraphKruskal.BackgroundColor = System.Drawing.Color.White;
			this.dgvGraphKruskal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
			this.dgvGraphKruskal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGraphKruskal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
			this.dgvGraphKruskal.DefaultCellStyle = dataGridViewCellStyle1;
			this.dgvGraphKruskal.GridColor = System.Drawing.Color.White;
			this.dgvGraphKruskal.Location = new System.Drawing.Point(1048, 38);
			this.dgvGraphKruskal.Name = "dgvGraphKruskal";
			this.dgvGraphKruskal.RowHeadersVisible = false;
			this.dgvGraphKruskal.Size = new System.Drawing.Size(290, 207);
			this.dgvGraphKruskal.TabIndex = 32;
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
			// dgvGraphPrim
			// 
			this.dgvGraphPrim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvGraphPrim.BackgroundColor = System.Drawing.Color.White;
			this.dgvGraphPrim.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
			this.dgvGraphPrim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGraphPrim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.dataGridViewButtonColumn1,
			this.dataGridViewButtonColumn2,
			this.dataGridViewButtonColumn3});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.Format = "N6";
			dataGridViewCellStyle2.NullValue = null;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvGraphPrim.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvGraphPrim.GridColor = System.Drawing.Color.White;
			this.dgvGraphPrim.Location = new System.Drawing.Point(1051, 454);
			this.dgvGraphPrim.Name = "dgvGraphPrim";
			this.dgvGraphPrim.RowHeadersVisible = false;
			this.dgvGraphPrim.Size = new System.Drawing.Size(290, 221);
			this.dgvGraphPrim.TabIndex = 33;
			// 
			// dataGridViewButtonColumn1
			// 
			this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewButtonColumn1.HeaderText = "Origin";
			this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
			this.dataGridViewButtonColumn1.ReadOnly = true;
			this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// dataGridViewButtonColumn2
			// 
			this.dataGridViewButtonColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewButtonColumn2.HeaderText = "Weight";
			this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
			this.dataGridViewButtonColumn2.ReadOnly = true;
			this.dataGridViewButtonColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// dataGridViewButtonColumn3
			// 
			this.dataGridViewButtonColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewButtonColumn3.HeaderText = "Destination";
			this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
			this.dataGridViewButtonColumn3.ReadOnly = true;
			// 
			// labelKruskal
			// 
			this.labelKruskal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.labelKruskal.BackColor = System.Drawing.Color.Transparent;
			this.labelKruskal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelKruskal.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelKruskal.ForeColor = System.Drawing.Color.White;
			this.labelKruskal.Location = new System.Drawing.Point(1048, 12);
			this.labelKruskal.Name = "labelKruskal";
			this.labelKruskal.Size = new System.Drawing.Size(290, 23);
			this.labelKruskal.TabIndex = 34;
			this.labelKruskal.Text = "KRUSKAL:";
			// 
			// labelPrim
			// 
			this.labelPrim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.labelPrim.BackColor = System.Drawing.Color.Transparent;
			this.labelPrim.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelPrim.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPrim.ForeColor = System.Drawing.Color.White;
			this.labelPrim.Location = new System.Drawing.Point(1051, 428);
			this.labelPrim.Name = "labelPrim";
			this.labelPrim.Size = new System.Drawing.Size(290, 23);
			this.labelPrim.TabIndex = 35;
			this.labelPrim.Text = "PRIM:";
			// 
			// labelPesoKruskal
			// 
			this.labelPesoKruskal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.labelPesoKruskal.BackColor = System.Drawing.Color.Transparent;
			this.labelPesoKruskal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelPesoKruskal.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPesoKruskal.ForeColor = System.Drawing.Color.White;
			this.labelPesoKruskal.Location = new System.Drawing.Point(1048, 248);
			this.labelPesoKruskal.Name = "labelPesoKruskal";
			this.labelPesoKruskal.Size = new System.Drawing.Size(290, 23);
			this.labelPesoKruskal.TabIndex = 36;
			// 
			// labelPesoPrim
			// 
			this.labelPesoPrim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.labelPesoPrim.BackColor = System.Drawing.Color.Transparent;
			this.labelPesoPrim.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelPesoPrim.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPesoPrim.ForeColor = System.Drawing.Color.White;
			this.labelPesoPrim.Location = new System.Drawing.Point(1048, 678);
			this.labelPesoPrim.Name = "labelPesoPrim";
			this.labelPesoPrim.Size = new System.Drawing.Size(290, 23);
			this.labelPesoPrim.TabIndex = 37;
			// 
			// Formulario_Comparacion
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1350, 727);
			this.Controls.Add(this.labelPesoPrim);
			this.Controls.Add(this.labelPesoKruskal);
			this.Controls.Add(this.labelPrim);
			this.Controls.Add(this.labelKruskal);
			this.Controls.Add(this.dgvGraphPrim);
			this.Controls.Add(this.dgvGraphKruskal);
			this.Controls.Add(this.labelNodoIncial);
			this.Controls.Add(this.buttonAnimar);
			this.Controls.Add(this.comboBoxNodos);
			this.Controls.Add(this.pictureBoxGrafo);
			this.MinimumSize = new System.Drawing.Size(1366, 766);
			this.Name = "Formulario_Comparacion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Formulario_Comparacion";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrafo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvGraphKruskal)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvGraphPrim)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
