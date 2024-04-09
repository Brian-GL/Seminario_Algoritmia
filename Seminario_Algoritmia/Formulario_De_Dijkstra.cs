/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 25/11/2019
 * Hora: 15:03
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;

namespace Seminario_Algoritmia
{
	/// <summary>
	/// Description of Formulario_De_Dijkstra.
	/// </summary>
	public partial class Formulario_De_Dijkstra : Form
	{
		Graph<Circulo> myCircleGraph = new Graph<Circulo>();
		Bitmap bitmapFondo, bitmapFrente;
		List<Color> colorList;
		List<List<Circulo>> caminos;
		int contador = 0;
		public Formulario_De_Dijkstra(Graph<Circulo> graph, Bitmap bmp)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			colorList = new List<Color>();
			caminos = new List<List<Circulo>>();
			myCircleGraph = graph;
			bitmapFondo = new Bitmap(bmp);
			pictureBoxDijsktra.BackgroundImage = bitmapFondo;
			
			pictureBoxDijsktra.BackgroundImageLayout = ImageLayout.Zoom;
			
			//we can not use Green, Black and White:
			
			colorList.Add(Color.Aqua);
			colorList.Add(Color.Red);
			colorList.Add(Color.Wheat);
			colorList.Add(Color.PaleGoldenrod);
			colorList.Add(Color.Purple);
			colorList.Add(Color.SaddleBrown);
			colorList.Add(Color.Gray);
			colorList.Add(Color.Thistle);
			colorList.Add(Color.Tomato);
			colorList.Add(Color.Navy);
			colorList.Add(Color.Ivory);
			colorList.Add(Color.Silver);
			colorList.Add(Color.SpringGreen);
			colorList.Add(Color.PowderBlue);
			colorList.Add(Color.Magenta);
			colorList.Add(Color.Sienna);
			colorList.Add(Color.SeaGreen);
			colorList.Add(Color.SteelBlue);
			colorList.Add(Color.Firebrick);
			colorList.Add(Color.Khaki);
			colorList.Add(Color.OldLace);
			colorList.Add(Color.Blue);
			colorList.Add(Color.Brown);
			colorList.Add(Color.BlueViolet);
			colorList.Add(Color.Yellow);
			colorList.Add(Color.Turquoise);
			colorList.Add(Color.DarkOrange);
			colorList.Add(Color.DarkViolet);
			colorList.Add(Color.Violet);
			colorList.Add(Color.Cyan);

			for(int i = 0; i < myCircleGraph.Size_Nodes();i++){
				comboBoxNodos.Items.Add(myCircleGraph[i].data.GetID());
				comboBoxCebos.Items.Add(myCircleGraph[i].data.GetID());
			}
			
			DrawWeight(graph);
		}
		void ButtonObtenerCaminosClick(object sender, EventArgs e)
		{
			
			if(comboBoxNodos.Text.Length >= 1 && NoLetras()){
				dataGridViewCaminos.Rows.Clear();
				caminos.Clear();
				//obtener los caminos del vertice origen a los demás vértices:
				
				var circuloOrigen = GetCirculo(int.Parse(comboBoxNodos.SelectedItem.ToString()));
				
				contador= myCircleGraph.Size_Nodes()-1;
				for(int i = 0; i < myCircleGraph.Size_Nodes();i++){
					var nodo = myCircleGraph[i].data;
					if(!circuloOrigen.Equals(nodo)){
						
						int renglon = dataGridViewCaminos.Rows.Add();
						dataGridViewCaminos.Rows[renglon].Cells["ORIGEN"].Value = circuloOrigen.GetID();
						var camino = myCircleGraph.Dijkstra_Path(circuloOrigen,nodo);
						
						dataGridViewCaminos.Rows[renglon].Cells["DESTINO"].Value = nodo;
						caminos.Add(camino.firstData);
						string way = "";
						
						for(int j = 0; j < camino.firstData.Count;j++){
							way+= (j < camino.firstData.Count-1) ? camino.firstData[j].GetID()+" -> " : camino.firstData[j].ToString();
						}
						dataGridViewCaminos.Rows[renglon].Cells["CAMINO"].Value = (way == String.Empty) ? "NO HAY CAMINO" :way;
						dataGridViewCaminos.Rows[renglon].Cells["PESO"].Value = camino.secondData;
						dataGridViewCaminos.Rows[renglon].Cells["MOSTRAR_CAMINO"].Value = "✔";
						dataGridViewCaminos.Rows[renglon].Cells["MOSTRAR_CAMINO"].Style.BackColor = colorList[renglon%30];
					}
				}
				MessageBox.Show("CAMINOS OBTENIDOS SATISFACTORIAMENTE","INFORMACIÓN",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				buttonLimpiarCaminos.Enabled = comboBoxCebos.Enabled = buttonAnimarRecorrido.Enabled = true;
				comboBoxCebos.Items.RemoveAt(comboBoxNodos.SelectedIndex);
				
				bitmapFrente = new Bitmap(bitmapFondo);
				pictureBoxDijsktra.Image = bitmapFrente; 
				
			}
		}
		
		bool NoLetras(){
			
			for(int i = 0; i < comboBoxNodos.Text.Length;i++){
				if(!Char.IsDigit(comboBoxNodos.Text[i]))
					return false;
			}
			
			return true;
		}
		
		bool NoLetters(){
			
			for(int i = 0; i < comboBoxCebos.Text.Length;i++){
				if(!Char.IsDigit(comboBoxCebos.Text[i]))
				return false;
			}
			
			return true;
		}
		
		Circulo GetCirculo(int id){
			
			for(int i = 0; i  < myCircleGraph.Size_Nodes();i++){
				if(myCircleGraph[i].data.GetID() == id){
					return myCircleGraph[i].data;
				}
			}
			
			return null;
			
		}
		
		void DrawWeight(Graph<Circulo> graph){
			var graficos = Graphics.FromImage(pictureBoxDijsktra.BackgroundImage);
			var listaAristas = graph.GetEdges();
			for(int i = 0; i <listaAristas.Count;i++){
				
				var drawFont = new Font("Arial", 8);
				var middlePoint = GetMiddlePoint(listaAristas[i].firstData.GetPuntoCentral(),listaAristas[i].thirdData.GetPuntoCentral());
				var cadena = Convert.ToInt32(listaAristas[i].secondData).ToString();
				graficos.DrawString((cadena),drawFont,new SolidBrush(Color.Black),middlePoint.X,middlePoint.Y);
				
	
			}
			graficos.Dispose();
			pictureBoxDijsktra.Refresh();
		}
		
		Point GetMiddlePoint(Point a, Point b){
			double middleX = 0;
			double middleY = 0;
			
			middleX = (a.X + b.X) /2;
			middleY = (a.Y + b.Y)/2;
			
			return new Point(Convert.ToInt32(middleX),Convert.ToInt32(middleY));
		}
		void DataGridViewCaminosCellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.ColumnIndex == 4 && contador > 0){
				// Dibujar Camino:
				var listaAuxiliar = caminos[e.RowIndex];
				for(int i = 0; i < listaAuxiliar.Count-1;i++){
					var graficos = Graphics.FromImage(bitmapFrente);
					graficos.DrawLine(new Pen(colorList[e.RowIndex%30],contador),listaAuxiliar[i].GetPuntoCentral(),listaAuxiliar[i+1].GetPuntoCentral());
					graficos.Dispose();
					
					contador--;
				}
				pictureBoxDijsktra.Refresh();
			}
		}
		void ButtonLimpiarCaminosClick(object sender, EventArgs e)
		{
			contador = myCircleGraph.Size_Nodes()-1;
			var graficos = Graphics.FromImage(bitmapFrente);
			graficos.Clear(Color.Transparent);
			graficos.Dispose();
			
			pictureBoxDijsktra.Refresh();
		}
		
		Point GetPoint(string id){
			
			for(int i = 0; i  < myCircleGraph.Size_Nodes();i++){
				if(myCircleGraph[i].data.GetID().ToString().Equals(id)){
					return myCircleGraph[i].data.GetPuntoCentral();
				}
			}
			
			return new Point(-1,-1);
			
		}
		
		void ButtonAnimarRecorridoClick(object sender, EventArgs e)
		{
			
			if(comboBoxNodos.Text.Length >= 1 && NoLetras() && comboBoxCebos.Text.Length >= 1 && NoLetters()){
				//Dibujar los agentes:
				var graficos = Graphics.FromImage(bitmapFrente);
				graficos.Clear(Color.Transparent);
				graficos.Dispose();

				var grafics = Graphics.FromImage(bitmapFrente);
				var punto = GetPoint(comboBoxNodos.SelectedItem.ToString());
				grafics.FillEllipse(new SolidBrush(Color.DarkRed),new Rectangle(punto.X,punto.Y,20,20));
				punto = GetPoint(comboBoxCebos.Text);
				grafics.FillEllipse(new SolidBrush(Color.Black),new Rectangle(punto.X,punto.Y,20,20));
				pictureBoxDijsktra.Refresh();
				grafics.Dispose();
				
				
				int pos = 0;
				for(int i = 0; i< dataGridViewCaminos.Rows.Count;i++){
					if(dataGridViewCaminos.Rows[i].Cells["DESTINO"].Value.ToString().Equals(comboBoxCebos.SelectedItem.ToString())){
						pos = i;
						break;
					}
				}

				var listaAuxiliar = caminos[pos];
				if(listaAuxiliar.Count == 0){
					MessageBox.Show("!NO HAY CAMINO!","INFORMACIÓN",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}else{
					for(int i = 0; i < listaAuxiliar.Count-1;i++){
						var listaPuntos = GetWay(listaAuxiliar[i].GetPuntoCentral(),listaAuxiliar[i+1].GetPuntoCentral(),5);
						for(int j = 0; j < listaPuntos.Count;j++){
							DrawCircle(listaPuntos[j],Color.DarkRed);
							DrawCircle(punto,Color.Black);
							pictureBoxDijsktra.Refresh();
							ClearBitmap();
						}
						
					}
					
					MessageBox.Show("¡ANIMACIÓN REALIZADA CORRECTAMENTE!","INFORMACIÓN",MessageBoxButtons.OK,MessageBoxIcon.Information);
					
				}
				
				
				ClearBitmap();
				pictureBoxDijsktra.Refresh();
				
			}
		}
		void DrawCircle(Point p,Color c){
			var graficos = Graphics.FromImage(bitmapFrente);	
			graficos.FillEllipse(new SolidBrush(c),new Rectangle(p.X,p.Y,20,20));
			graficos.Dispose();
			
		}
		void ClearBitmap(){
			var graficos = Graphics.FromImage(bitmapFrente);
			graficos.Clear(Color.Transparent);
			graficos.Dispose();
		}
		
		
		void Formulario_De_DijkstraFormClosing(object sender, FormClosingEventArgs e)
		{
			colorList.Clear();
			caminos.Clear();
			
		}
		
		public List<Point> GetWay(Point origen, Point destino, int velocidad)
		{
			var Posiciones = new List<Point>();
			var m = Circulo.Pendiente(origen,destino);
	
			var dy = Math.Abs(origen.Y - destino.Y);
			var dx = Math.Abs(origen.X - destino.X);
			
			if(dx >= dy){
			   //y = mx + b	
				
			   if(origen.X <= destino.X){
				   	var puntos = Agente.OrderPoints_By_X(origen,destino);
					var b = Circulo.B(puntos.firstData,m);
					var Xk = puntos.firstData.X;
					var Yk = puntos.firstData.Y;
					double Ysumante = puntos.firstData.Y;
					while(Xk <= puntos.secondData.X){
						Posiciones.Add(new Point(Xk,Yk));
						Ysumante = (m * Xk)+b;
						Yk = Convert.ToInt32(Math.Round(Ysumante));
						Xk+=velocidad;
					}
			   }
			   else{
			   		var puntos = new Pair<Point,Point>(origen,destino);
					var b = Circulo.B(puntos.firstData,m);
					var Xk = puntos.firstData.X;
					var Yk = puntos.firstData.Y;
					double Ysumante = puntos.firstData.Y;
					while(Xk >= puntos.secondData.X){
						Posiciones.Add(new Point(Xk,Yk));
						Ysumante = (m * Xk)+b;
						Yk = Convert.ToInt32(Math.Round(Ysumante));
						Xk-=velocidad;
					}
			   }
			}
			else{
				// x = (y-b)/m
				if(origen.Y <= destino.Y){
					var puntos = Agente.OrderPoints_By_Y(origen,destino);
					var b = Circulo.B(puntos.firstData,m);
					var Xk = puntos.firstData.X;
					var Yk = puntos.firstData.Y;
					double Xsumante = puntos.firstData.X;
					while(Yk <= puntos.secondData.Y){
						Posiciones.Add(new Point(Xk,Yk));
						Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
						Xk = Convert.ToInt32(Math.Round(Xsumante));
						Yk+=velocidad;
						
					}
				}
				else{
					var puntos = new Pair<Point,Point>(origen,destino);
					var b = Circulo.B(puntos.firstData,m);
					var Xk = puntos.firstData.X;
					var Yk = puntos.firstData.Y;
					double Xsumante = puntos.firstData.X;
					while(Yk >= puntos.secondData.Y){
						Posiciones.Add(new Point(Xk,Yk));
						Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
						Xk = Convert.ToInt32(Math.Round(Xsumante));
						Yk-=velocidad;
					}
				}

			}
			
			return Posiciones;
		
		}
		
		
		
	}
	
	
	
}
