/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 30/10/2019
 * Hora: 16:05
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Seminario_Algoritmia
{
	/// <summary>
	/// Description of Formulario_De_Kruskal.
	/// </summary>
	public partial class Formulario_De_Kruskal : Form
	{
		Graph<Circulo> myCircleGraph = new Graph<Circulo>();
		List<Triplet<Circulo,double,Circulo>> listaKruskal;
		int numeroBosques;
		List<int> agentList = new List<int>();
		int cebo;
		Bitmap bitmapFondo, bitmapFrente;
		TimeSpan tiempoLista;
		
		public Formulario_De_Kruskal(Graph<Circulo> kruskalGraph, Bitmap bmp)
		{
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			// bmp es el de fondo 
			
			bitmapFondo = new Bitmap(bmp);
			var relojLista = new Stopwatch();
			relojLista.Start();
			var pair = kruskalGraph.KruskalFullList();
			relojLista.Stop();
			tiempoLista = relojLista.Elapsed;
			listaKruskal = pair.firstData;
			numeroBosques = pair.secondData;
			
			myCircleGraph = Graph<Circulo>.CreateGraph(listaKruskal);
			
			pictureBoxKruskal.BackgroundImage = bitmapFondo;
			pictureBoxKruskal.BackgroundImageLayout = ImageLayout.Zoom;

			for(int i = 0; i < kruskalGraph.Size_Nodes();i++){
				comboBoxPrimerAgente.Items.Add(kruskalGraph[i].data.ToString());
				comboBoxSegundoAgente.Items.Add(kruskalGraph[i].data.ToString());
			}
		
			cebo = -1;
			
			DrawWeight(kruskalGraph);
			dgvGraph.Sort(Weight,System.ComponentModel.ListSortDirection.Ascending);
			
		}

		
		void DrawWeight(Graph<Circulo> graph){
			var graficos = Graphics.FromImage(pictureBoxKruskal.BackgroundImage);
			var listaAristas = graph.GetEdges();
			for(int i = 0; i <listaAristas.Count;i++){
				
				var drawFont = new Font("Arial", 8);
				var middlePoint = GetMiddlePoint(listaAristas[i].firstData.GetPuntoCentral(),listaAristas[i].thirdData.GetPuntoCentral());
				var cadena = Convert.ToInt32(listaAristas[i].secondData).ToString();
				graficos.DrawString((cadena),drawFont,new SolidBrush(Color.Black),middlePoint.X,middlePoint.Y);
				
	
			}
			graficos.Dispose();
			pictureBoxKruskal.Refresh();
		}
		
		Point GetMiddlePoint(Point a, Point b){
			double middleX = 0;
			double middleY = 0;
			
			middleX = (a.X + b.X) /2;
			middleY = (a.Y + b.Y)/2;
			
			return new Point(Convert.ToInt32(middleX),Convert.ToInt32(middleY));
		}

		void DrawARM(Circulo c1,double w,Circulo c2){
			var graficos = Graphics.FromImage(bitmapFondo);
			//drawNode
			graficos.DrawLine(new Pen(Color.DarkOliveGreen,3),c1.GetPuntoCentral().X,c1.GetPuntoCentral().Y,c2.GetPuntoCentral().X,c2.GetPuntoCentral().Y);
			graficos.FillEllipse(new SolidBrush(Color.DarkOliveGreen),c1.GetPuntoOeste().X,c1.GetPuntoNorte().Y,c1.GetRadioHorizontal(),c1.GetRadioVertical());
			graficos.FillEllipse(new SolidBrush(Color.DarkOliveGreen),c2.GetPuntoOeste().X,c2.GetPuntoNorte().Y,c2.GetRadioHorizontal(),c2.GetRadioVertical());
			//drawdata
			graficos.Dispose();
			DrawData(c1); DrawData(c2);
			pictureBoxKruskal.Refresh();
		}
		void DrawData(Circulo c1){
			var graficos = Graphics.FromImage(bitmapFondo);
			var drawFont = new Font("Arial", c1.GetRadioNorte());
			graficos.DrawString(c1.ToString(),drawFont,new SolidBrush(Color.Black),c1.GetPuntoCentral().X,c1.GetPuntoCentral().Y);
			int centro = (c1.GetRadioNorte() + c1.GetRadioSur()) / 10;
			graficos.FillRectangle(new SolidBrush(Color.Black), new Rectangle(c1.GetPuntoCentral().X,c1.GetPuntoCentral().Y,centro,centro));
			graficos.Dispose();
		}
		
		
		void ButtonAnimarKruskalClick(object sender, EventArgs e)
		{
			
			double suma = 0;
			comboBoxPrimerAgente.Enabled = comboBoxSegundoAgente.Enabled = true;
			var relojArbol = new Stopwatch();
			relojArbol.Start();
			for(int i = 0; i < listaKruskal.Count;i++){

				DrawARM(listaKruskal[i].firstData,listaKruskal[i].secondData,listaKruskal[i].thirdData);
				suma+=listaKruskal[i].secondData;
				Thread.Sleep(1000);
				int renglon = dgvGraph.Rows.Add();
				dgvGraph.Rows[renglon].Cells["Origin"].Value = listaKruskal[i].firstData.ToString();
				dgvGraph.Rows[renglon].Cells["Weight"].Value =  listaKruskal[i].secondData;
				dgvGraph.Rows[renglon].Cells["Destination"].Value = listaKruskal[i].thirdData;
			}
			relojArbol.Stop();
			TimeSpan tiempoArbol = relojArbol.Elapsed;
			MessageBox.Show("ANIMACIÓN COMPLETADA\n\nTIEMPO DE LISTA: "+tiempoLista+"\n\nTIEMPO DEL ARBOL: "+tiempoArbol,"INFORMACIÓN",MessageBoxButtons.OK,MessageBoxIcon.Information);
			buttonAnimarKruskal.Enabled = false;
			textBoxCostoTotal.Text = suma.ToString();
			textBoxNumeroBosques.Text = numeroBosques.ToString();
			bitmapFrente = new Bitmap(bitmapFondo);
			pictureBoxKruskal.Image = bitmapFrente;

		}


		Point GetPoint(int id){
			
			for(int i = 0; i  < myCircleGraph.Size_Nodes();i++){
				if(myCircleGraph[i].data.GetID() == id){
					return myCircleGraph[i].data.GetPuntoCentral();
				}
			}
			
			return new Point(-1,-1);
			
		}
		Circulo GetCirculo(int id){
			
			for(int i = 0; i  < myCircleGraph.Size_Nodes();i++){
				if(myCircleGraph[i].data.GetID() == id){
					return myCircleGraph[i].data;
				}
			}
			
			return null;
			
		}
		
		void ButtonAgregarCeboClick(object sender, EventArgs e)
		{
			int number;
			var addCebo = new AddCebo(comboBoxPrimerAgente);
			addCebo.ShowDialog();
			number = addCebo.numero;
			if(agentList.Contains(number)){
				MessageBox.Show("YA HAY UN AGENTES CREADO EN TAL POSICION","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}else{
				cebo = number;
				var grafics = Graphics.FromImage(bitmapFrente);
				var punto = GetPoint(cebo);
				grafics.FillEllipse(new SolidBrush(Color.DarkBlue),new Rectangle(punto.X,punto.Y,20,20));
				pictureBoxKruskal.Refresh();
				grafics.Dispose();
				buttonAgregarCebo.Enabled = false;
				buttonSimular.Enabled = true;
			}
		
		}


		void ButtonSimularClick(object sender, EventArgs e)
		{
			
			if(agentList.Count == 1){
				var circuloCebo = GetCirculo(cebo);
				var rutaProfundidad = myCircleGraph.Depth_Travel_Total(GetCirculo(agentList.First()),circuloCebo);
				if(rutaProfundidad.Count == 0){
					MessageBox.Show("!NO HAY CAMINO!","INFORMACIÓN",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}else{
					for(int i = 0; i < rutaProfundidad.Count-1;i++){
						var listaPuntos = GetWay(rutaProfundidad[i].GetPuntoCentral(),rutaProfundidad[i+1].GetPuntoCentral(),5);
						for(int j = 0; j < listaPuntos.Count;j++){
							DrawCircle(listaPuntos[j],Color.Turquoise);
							//draw cebo:
							DrawCircle(circuloCebo.GetPuntoCentral(),Color.DarkBlue);
							pictureBoxKruskal.Refresh();
							ClearBitmap();
						}
						
					}
					
					MessageBox.Show("¡ANIMACIÓN REALIZADA CORRECTAMENTE!","INFORMACIÓN",MessageBoxButtons.OK,MessageBoxIcon.Information);
					ClearBitmap();
					pictureBoxKruskal.Refresh();
					agentList.Clear();
					//buttonAgregarCebo.Enabled = true;
					cebo = -1;
					buttonSimular.Enabled = false;
					
				}
				
			}
			else if(agentList.Count == 2){
				
				//hacer profundidad y anchura.
				var circuloCebo = GetCirculo(cebo);
				var circuloPrimero = GetCirculo(agentList.First());
				var circuloSegundo = GetCirculo(agentList.Last());
				var rutaProfundidad = myCircleGraph.Depth_Travel_Total(circuloPrimero,circuloCebo);
				var rutaAnchura = myCircleGraph.Width_Travel_Total(circuloSegundo,circuloCebo);
				if(rutaProfundidad.Count == 0 && rutaAnchura.Count == 0){
					MessageBox.Show("!NO HAY NINGÚN CAMINO PARA AMBOS!","INFORMACIÓN",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}else{
					if(rutaProfundidad.Count == 0){
						//hacer solo anchura:
						for(int i = 0; i < rutaAnchura.Count-1;i++){
							var listaPuntos = GetWay(rutaAnchura[i].GetPuntoCentral(),rutaAnchura[i+1].GetPuntoCentral(),15);
							for(int j = 0; j < listaPuntos.Count;j++){
								DrawCircle(listaPuntos[j],Color.Maroon);
								DrawCircle(circuloCebo.GetPuntoCentral(),Color.DarkBlue);
								DrawCircle(circuloPrimero.GetPuntoCentral(),Color.Turquoise);
								pictureBoxKruskal.Refresh();
								ClearBitmap();
							}
						}
						
						MessageBox.Show("¡ANIMACIÓN REALIZADA CORRECTAMENTE!","INFORMACIÓN",MessageBoxButtons.OK,MessageBoxIcon.Information);
						ClearBitmap();
						pictureBoxKruskal.Refresh();
						agentList.Clear();
						//buttonAgregarCebo.Enabled = true;
						cebo = -1;
						buttonSimular.Enabled = false;
						
					}
					else if(rutaAnchura.Count == 0){
						//hacer solo profundidad:
						for(int i = 0; i < rutaProfundidad.Count-1;i++){
							var listaPuntos = GetWay(rutaProfundidad[i].GetPuntoCentral(),rutaProfundidad[i+1].GetPuntoCentral(),15);
							for(int j = 0; j < listaPuntos.Count;j++){
								DrawCircle(listaPuntos[j],Color.Turquoise);
								DrawCircle(circuloSegundo.GetPuntoCentral(),Color.Maroon);
								DrawCircle(circuloCebo.GetPuntoCentral(),Color.DarkBlue);
								pictureBoxKruskal.Refresh();
								ClearBitmap();
							}
						}
						
						MessageBox.Show("¡ANIMACIÓN REALIZADA CORRECTAMENTE!","INFORMACIÓN",MessageBoxButtons.OK,MessageBoxIcon.Information);
						ClearBitmap();
						pictureBoxKruskal.Refresh();
						agentList.Clear();
						//buttonAgregarCebo.Enabled = true;
						cebo = -1;
						buttonSimular.Enabled = false;
						
					}
					else{
						//ninguno esta vacio:
						
						//8 a 6
	
						if(rutaAnchura.Count > rutaProfundidad.Count){
							//ruta anchura es el que tiene más nodos.
							
							for(int i = 0; i < rutaAnchura.Count-1;i++){
								var listaPuntosAnchura = GetWay(rutaAnchura[i].GetPuntoCentral(),rutaAnchura[i+1].GetPuntoCentral(),15);
								if(i < rutaProfundidad.Count-1){
									var listaPuntosProfundidad = GetWay(rutaProfundidad[i].GetPuntoCentral(),rutaProfundidad[i+1].GetPuntoCentral(),15);
									
									if(listaPuntosProfundidad.Count > listaPuntosAnchura.Count){
										 //lista profundidad tiene mas puntos.
		
										 for(int j = 0; j < listaPuntosProfundidad.Count;j++){
										 	DrawCircle(listaPuntosProfundidad[j],Color.Turquoise);
										 	DrawCircle(circuloCebo.GetPuntoCentral(),Color.DarkBlue);
										 	
										 	if(j < listaPuntosAnchura.Count)
										 		DrawCircle(listaPuntosAnchura[j],Color.Maroon);
										 	else
										 		DrawCircle(listaPuntosAnchura.Last(),Color.Maroon);
										 
										 	pictureBoxKruskal.Refresh();
											ClearBitmap();
										 	
									 	}
									 
									 }
									
									else if(listaPuntosAnchura.Count > listaPuntosProfundidad.Count){
										//lista anchura tiene mas puntos.
		
										 for(int j = 0; j < listaPuntosAnchura.Count;j++){
										 	DrawCircle(listaPuntosAnchura[j],Color.Maroon);
										 	DrawCircle(circuloCebo.GetPuntoCentral(),Color.DarkBlue);
										 	if(j < listaPuntosProfundidad.Count)
										 		DrawCircle(listaPuntosProfundidad[j],Color.Turquoise);
										 	else
										 		DrawCircle(listaPuntosProfundidad.Last(),Color.Turquoise);
										 
										 	pictureBoxKruskal.Refresh();
											ClearBitmap();
										 	
									 	}
									}
									
									else{
										 for(int j = 0; j < listaPuntosProfundidad.Count;j++){
										 	DrawCircle(listaPuntosProfundidad[j],Color.Turquoise);
										 	DrawCircle(circuloCebo.GetPuntoCentral(),Color.DarkBlue);
										 	DrawCircle(listaPuntosAnchura[j],Color.Maroon);
										 	pictureBoxKruskal.Refresh();
											ClearBitmap();
										 	
									 	}
									}
									
								}
								else{
									
									for(int j = 0; j < listaPuntosAnchura.Count;j++){
									 	DrawCircle(listaPuntosAnchura[j],Color.Maroon);
									 	DrawCircle(circuloCebo.GetPuntoCentral(),Color.DarkBlue);
									 	DrawCircle(circuloCebo.GetPuntoCentral(),Color.Turquoise);
									 	pictureBoxKruskal.Refresh();
										ClearBitmap();
									 	
								 	}
									
								}
							}
							
							
							
						}
						else if(rutaProfundidad.Count > rutaAnchura.Count){
							// ruta profundidad es el que tiene más nodos
								for(int i = 0; i < rutaProfundidad.Count-1;i++){
								var listaPuntosProfundidad = GetWay(rutaProfundidad[i].GetPuntoCentral(),rutaProfundidad[i+1].GetPuntoCentral(),15);
								if(i < rutaAnchura.Count-1){
									
									var listaPuntosAnchura = GetWay(rutaAnchura[i].GetPuntoCentral(),rutaAnchura[i+1].GetPuntoCentral(),15);
									
									if(listaPuntosProfundidad.Count > listaPuntosAnchura.Count){
										 //lista profundidad tiene mas puntos.
		
										 for(int j = 0; j < listaPuntosProfundidad.Count;j++){
										 	DrawCircle(listaPuntosProfundidad[j],Color.Turquoise);
										 	DrawCircle(circuloCebo.GetPuntoCentral(),Color.DarkBlue);
										 	if(j < listaPuntosAnchura.Count)
										 		DrawCircle(listaPuntosAnchura[j],Color.Maroon);
										 	else
										 		DrawCircle(listaPuntosAnchura.Last(),Color.Maroon);
										 
										 	pictureBoxKruskal.Refresh();
											ClearBitmap();
										 	
									 	}
									 
									 }
									
									else if(listaPuntosAnchura.Count > listaPuntosProfundidad.Count){
										//lista anchura tiene mas puntos.
		
										 for(int j = 0; j < listaPuntosAnchura.Count;j++){
										 	DrawCircle(listaPuntosAnchura[j],Color.Maroon);
										 	DrawCircle(circuloCebo.GetPuntoCentral(),Color.DarkBlue);
										 	if(j < listaPuntosProfundidad.Count)
										 		DrawCircle(listaPuntosProfundidad[j],Color.Turquoise);
										 	else
										 		DrawCircle(listaPuntosProfundidad.Last(),Color.Turquoise);
										 
										 	pictureBoxKruskal.Refresh();
											ClearBitmap();
										 	
									 	}
									}
									
									else{
										 for(int j = 0; j < listaPuntosProfundidad.Count;j++){
										 	DrawCircle(listaPuntosProfundidad[j],Color.Turquoise);
										 	DrawCircle(circuloCebo.GetPuntoCentral(),Color.DarkBlue);
										 	DrawCircle(listaPuntosAnchura[j],Color.Maroon);
										 	pictureBoxKruskal.Refresh();
											ClearBitmap();
										 	
									 	}
									}
									
								}
								else{
									 for(int j = 0; j < listaPuntosProfundidad.Count;j++){
									 	DrawCircle(listaPuntosProfundidad[j],Color.Turquoise);
									 	DrawCircle(circuloCebo.GetPuntoCentral(),Color.DarkBlue);
									 	DrawCircle(circuloCebo.GetPuntoCentral(),Color.Maroon);
									 	pictureBoxKruskal.Refresh();
										ClearBitmap();
									 	
								 	}
									
								}
							}
							
						}
						else{
							//ambos tienen la misma cantidad de nodos:
							
							for(int i = 0; i < rutaProfundidad.Count-1;i++){
								
								var listaPuntosProfundidad = GetWay(rutaProfundidad[i].GetPuntoCentral(),rutaProfundidad[i+1].GetPuntoCentral(),15);
								var listaPuntosAnchura = GetWay(rutaAnchura[i].GetPuntoCentral(),rutaAnchura[i+1].GetPuntoCentral(),15);
								
								if(listaPuntosProfundidad.Count > listaPuntosAnchura.Count){
									 //lista profundidad tiene mas puntos.
	
									 for(int j = 0; j < listaPuntosProfundidad.Count;j++){
									 	DrawCircle(listaPuntosProfundidad[j],Color.Turquoise);
									 	DrawCircle(circuloCebo.GetPuntoCentral(),Color.DarkBlue);
									 	if(j < listaPuntosAnchura.Count)
									 		DrawCircle(listaPuntosAnchura[j],Color.Maroon);
									 	else
									 		DrawCircle(listaPuntosAnchura.Last(),Color.Maroon);
									 
									 	pictureBoxKruskal.Refresh();
										ClearBitmap();
									 	
								 	}
								 
								 }
								
								else if(listaPuntosAnchura.Count > listaPuntosProfundidad.Count){
									//lista anchura tiene mas puntos.
	
									 for(int j = 0; j < listaPuntosAnchura.Count;j++){
									 	DrawCircle(listaPuntosAnchura[j],Color.Maroon);
									 	DrawCircle(circuloCebo.GetPuntoCentral(),Color.DarkBlue);
									 	if(j < listaPuntosProfundidad.Count)
									 		DrawCircle(listaPuntosProfundidad[j],Color.Turquoise);
									 	else
									 		DrawCircle(listaPuntosProfundidad.Last(),Color.Turquoise);
									 
									 	pictureBoxKruskal.Refresh();
										ClearBitmap();
									 	
								 	}
								}
								
								else{
									 for(int j = 0; j < listaPuntosProfundidad.Count;j++){
									 	DrawCircle(listaPuntosProfundidad[j],Color.Turquoise);
									 	DrawCircle(circuloCebo.GetPuntoCentral(),Color.DarkBlue);
									 	DrawCircle(listaPuntosAnchura[j],Color.Maroon);
									 	pictureBoxKruskal.Refresh();
										ClearBitmap();
									 	
								 	}
								}
								
							}
						}
						
						MessageBox.Show("¡ANIMACIÓN REALIZADA CORRECTAMENTE!","INFORMACIÓN",MessageBoxButtons.OK,MessageBoxIcon.Information);
						ClearBitmap();
						pictureBoxKruskal.Refresh();
						agentList.Clear();
						//buttonAgregarCebo.Enabled = true;
						cebo = -1;
						buttonSimular.Enabled = false;
					}

				}
				
			}
		
			comboBoxPrimerAgente.Enabled = comboBoxSegundoAgente.Enabled = true;
			comboBoxPrimerAgente.Text = comboBoxSegundoAgente.Text = "";
		}
	
		void Draw_Path(Circulo c1){
			var grafics = Graphics.FromImage(pictureBoxKruskal.BackgroundImage);
			var punto = GetPoint(agentList.Last());
			grafics.FillEllipse(new SolidBrush(Color.DarkGreen),c1.GetPuntoOeste().X,c1.GetPuntoNorte().Y,c1.GetRadioHorizontal(),c1.GetRadioVertical());
			grafics.Dispose();
			pictureBoxKruskal.Refresh();
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
		
		
		void ClearBitmap(){
			var graficos = Graphics.FromImage(bitmapFrente);
			graficos.Clear(Color.Transparent);
			graficos.Dispose();
		}
		
		void DrawCircle(Point p,Color c){
			var graficos = Graphics.FromImage(bitmapFrente);	
			graficos.FillEllipse(new SolidBrush(c),new Rectangle(p.X,p.Y,20,20));
			graficos.Dispose();
			
		}
		void ComboBoxPrimerAgenteSelectedIndexChanged(object sender, EventArgs e)
		{
			buttonAgregarCebo.Enabled = true;
			comboBoxPrimerAgente.Enabled = false;
			
			agentList.Add(Convert.ToInt32(comboBoxPrimerAgente.SelectedItem.ToString()));
			var grafics = Graphics.FromImage(bitmapFrente);
			var punto = GetPoint(agentList.Last());
			grafics.FillEllipse(new SolidBrush(Color.Turquoise),new Rectangle(punto.X,punto.Y,20,20));
			pictureBoxKruskal.Refresh();
			grafics.Dispose();
		}
		void ComboBoxSegundoAgenteSelectedIndexChanged(object sender, EventArgs e)
		{
			comboBoxSegundoAgente.Enabled = false;
			agentList.Add(Convert.ToInt32(comboBoxSegundoAgente.SelectedItem.ToString()));
		   	var grafics = Graphics.FromImage(bitmapFrente);
			var punto = GetPoint(agentList.Last());
			grafics.FillEllipse(new SolidBrush(Color.Maroon),new Rectangle(punto.X,punto.Y,20,20));
			pictureBoxKruskal.Refresh();
			grafics.Dispose();
		}
		
		

	
	}
}
