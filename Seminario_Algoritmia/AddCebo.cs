/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 02/11/2019
 * Hora: 20:33
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Seminario_Algoritmia
{
	/// <summary>
	/// Description of AddCebo.
	/// </summary>
	public partial class AddCebo : Form
	{
		public int numero;
		public AddCebo(ComboBox b)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			for(int i = 0; i < b.Items.Count;i++){
				var renglon = dgvDatosVertices.Rows.Add();
				dgvDatosVertices.Rows[renglon].Cells["Nodo"].Value = b.Items[i].ToString();
			}
			
		}
		void DgvDatosVerticesCellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			numero = Convert.ToInt32(dgvDatosVertices.Rows[e.RowIndex].Cells["Nodo"].Value);
			this.Close();
		}
	}
}
