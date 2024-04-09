/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 02/10/2019
 * Hora: 10:23
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Windows.Forms;

namespace Seminario_Algoritmia
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var mainform = new MainForm();
			mainform.ShowDialog();
			mainform.Dispose();
		}
		
	}
}
