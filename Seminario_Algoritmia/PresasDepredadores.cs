/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 04/12/2019
 * Hora: 11:52
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace Seminario_Algoritmia
{
	/// <summary>
	/// Description of PresasDepredadores.
	/// </summary>
	public partial class PresasDepredadores : Form
	{
		List<Presa> listaDePresas;
		List<Depredador> listaDeDepredadores;
		Graph<Circulo> myCircleGraph;
		Bitmap bitmapFrente, bitmapFondo;
		public PresasDepredadores(Graph<Circulo> graph, Bitmap bmp)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			bitmapFrente = new Bitmap(bmp);
			bitmapFondo = new Bitmap(bmp);
			myCircleGraph = graph;
			pictureBoxGrafo.BackgroundImage  = bitmapFondo;
			pictureBoxGrafo.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBoxGrafo.Image = bitmapFrente;
			listaDePresas = new List<Presa>();
			listaDeDepredadores = new List<Depredador>();
	
			//inicializar los combobox con los valores del grafo
			
			for(int i = 0; i < graph.Size_Nodes();i++){
				var value = graph[i];
				comboBoxPresaOrigen.Items.Add(value);
				comboBoxPresasDestino.Items.Add(value);
				comboBoxDepredador.Items.Add(value);
			}
			
		}
		
		//obtiene el 
		Graph<Circulo>.GraphNode<Circulo> GetNodo(int id){
			for(int i = 0; i  < myCircleGraph.Size_Nodes();i++){
				if(myCircleGraph[i].data.GetID() == id){
					return myCircleGraph[i];
				}
			}
			return null;
		}
		
		void ButtonAgregarPresaClick(object sender, EventArgs e){
			
			//si el objeto seleccionado en cualquier combobox de la presa es nulo,entonces marcamos error
			if(comboBoxPresaOrigen.SelectedItem == null
			  || comboBoxPresasDestino.SelectedItem == null){
				MessageBox.Show("INGRESE UN ORIGEN Y UN DESTINO VÁLIDO POR FAVOR","ERROR", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			
			//Si el origen y el destino para crear la presa es igual, marcamos error
			if(comboBoxPresaOrigen.SelectedItem.Equals(comboBoxPresasDestino.SelectedItem)){
				MessageBox.Show("EL NODO ORIGEN DEBE DE SER DESIGUAL AL NODO DESTINO","ERROR", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			
			//crear presa:
			var nuevaPresa = new Presa(listaDePresas.Count);

			//casteo de nodo origen seleccionado:
			var nodoOrigen = (Graph<Circulo>.GraphNode<Circulo>)comboBoxPresaOrigen.SelectedItem;
			var nodoDestino = (Graph<Circulo>.GraphNode<Circulo>)comboBoxPresasDestino.SelectedItem;
			//Obtener el camino de dijkstra del nodo origen hasta el nodo destino seleccionado
			var DijkstraWay = myCircleGraph.Dijkstra_Way(nodoOrigen.data,nodoDestino.data);
			
			//agregar los nuevos datos a la presa:
			nuevaPresa.SetVerticeOrigen(nodoOrigen); //aqui tambien se setea el valor del punto actual
			nuevaPresa.SetCaminoDijkstra(DijkstraWay);
			
			//obtenemos el nodo destino de la presa, el cual es el primer nodo de DijsktraWay:
			if(DijkstraWay.Count == 0){//si no hay camino, entonces el nodo destino será igual al nodo Origen
				nuevaPresa.SetVerticeDestino(nodoOrigen);
			}else{//si hay camino, entonces el nodo destino será el primer valor de la lista de camino de dijkstra
				nuevaPresa.SetVerticeDestino(DijkstraWay.First());
				//aqui ya podemos obtener el camino del nodo origen al nodo destino:
				nuevaPresa.ObtenerCamino();
			}
			
			//dibujar presa
			DrawCircle(nuevaPresa.GetPosicionActual(),Color.DarkOrange);
			pictureBoxGrafo.Refresh();
			
			//agregar datos de la presa en el datagridview
			string way = "";
			for(int j = 0; j < DijkstraWay.Count;j++)
				way+=(j < DijkstraWay.Count-1) ? DijkstraWay[j].data.GetID()+"," : DijkstraWay[j].data.GetID().ToString();
			
			if(way == string.Empty)
				way = "NO HAY CAMINO";
			
			int indice = dataGridViewInformacionPresas.Rows.Add();
			dataGridViewInformacionPresas.Rows[indice].Cells["ID_PRESA"].Value = nuevaPresa.GetID();
			dataGridViewInformacionPresas.Rows[indice].Cells["RESISTENCIA_PRESA"].Value = 1;
			dataGridViewInformacionPresas.Rows[indice].Cells["NODO_ORIGEN_PRESA"].Value = "🔑"+ nodoOrigen.data.GetID();
			dataGridViewInformacionPresas.Rows[indice].Cells["NODO_DESTINO_PRESA"].Value = "🔑"+ nuevaPresa.GetVerticeDestino().data.GetID();
			dataGridViewInformacionPresas.Rows[indice].Cells["CAMINO_PRESA"].Value = way;

			//removemos el nodo del combobox para que ya no sea utilizable, tanto para las presas como los depredadores
			var item = comboBoxPresaOrigen.SelectedItem;
			comboBoxPresaOrigen.Items.Remove(item);
			comboBoxDepredador.Items.Remove(item);
			comboBoxPresaOrigen.SelectedItem = null;
			
			
			//agregar la nueva presa a la lista de presas:
			listaDePresas.Add(nuevaPresa);	
			
			//si el número de presas más el número de depredadores es igual al 
			//número de nodos del grafo, bloquemos el añadir presas y depredadores.
			if(listaDePresas.Count + listaDeDepredadores.Count == myCircleGraph.Size_Nodes())
				buttonAgregarPresa.Enabled = buttonAgregarDepredador.Enabled = false;
		}
		
		void ButtonAgregarDepredadorClick(object sender, EventArgs e)
		{
			if(comboBoxDepredador.SelectedItem == null){
				MessageBox.Show("INGRESE UN ORIGEN VÁLIDO POR FAVOR","ERROR", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			
			//crear nuevo depredador:
			var nuevoDepredador = new Depredador(listaDeDepredadores.Count);
			
			//obtener el nodo origen:
			var nodoOrigen = (Graph<Circulo>.GraphNode<Circulo>)comboBoxDepredador.SelectedItem; //casteo
			nodoOrigen.data.SetAgenteQueMeHaVisitado(nuevoDepredador.GetID(),1); //generamos la bandera de visitado para el nuevo depredador
			
			//agregar datos del depredador:
			nuevoDepredador.SetVerticeOrigen(nodoOrigen);
			
			
			
			//añadir la información de los depredadores
			int indice = dataGridViewInformacionDepredadores.Rows.Add();
			dataGridViewInformacionDepredadores.Rows[indice].Cells["ID_DEPREDADOR"].Value = nuevoDepredador.GetID();
			dataGridViewInformacionDepredadores.Rows[indice].Cells["DEPREDADOR_NODO_ORIGEN"].Value = "🔑"+ nodoOrigen.data.GetID();
			
			//removemos el nodo del combobox para que ya no sea utilizable, tanto para las presas como los depredadores
			var item = comboBoxDepredador.SelectedItem;
			comboBoxPresaOrigen.Items.Remove(item);
			comboBoxDepredador.Items.Remove(item);
			comboBoxDepredador.SelectedItem = null;

			//buscar las adyacencias del vertice Origen del depredador:
			var listaAdyacencias = nodoOrigen.EdgeList();
			
			//si la lista esta vacia, quiere decir que no hay a donde ir:
			if(listaAdyacencias.Count == 0){
				//agregamos el vertice destino como el mismo vertice origen
				nuevoDepredador.SetVerticeDestino(nodoOrigen);
			}else{
				//si hay adyacencias, entonces tomamos la primera opcion:
				nuevoDepredador.SetVerticeDestino(listaAdyacencias.First());
				//aumentamos bandera de tal vertice, visitado por este depredador:
				//obtenemos el camino:
				nuevoDepredador.ObtenerCamino();
			}
			
			//agregar el nuevo depredador a la lista de depredadores:
			listaDeDepredadores.Add(nuevoDepredador);	
			
			//si el número de presas más el número de depredadores es igual al 
			//número de nodos del grafo, bloquemos el añadir presas y depredadores.
			if(listaDePresas.Count + listaDeDepredadores.Count == myCircleGraph.Size_Nodes())
				buttonAgregarPresa.Enabled = buttonAgregarDepredador.Enabled = false;
			
			//dibujar depredador
			
			DrawDepredador(nuevoDepredador);
			pictureBoxGrafo.Refresh();
			
			dataGridViewInformacionDepredadores.Rows[indice].Cells["DEPREDADOR_NODO_DESTINO"].Value = "🔑"+ nuevoDepredador.GetVerticeDestino().data.GetID();
		}
		void PresasDepredadoresFormClosing(object sender, FormClosingEventArgs e){
			listaDePresas.Clear();
			listaDeDepredadores.Clear();
		}
		
		void DrawCircle(Point p,Color c){
			var graficos = Graphics.FromImage(bitmapFrente);	
			graficos.FillEllipse(new SolidBrush(c),new Rectangle(p.X,p.Y,20,20));
			graficos.Dispose();
			
		}
		void ButtonSimularClick(object sender, EventArgs e)
		{
			if(listaDeDepredadores.Count == 0 || listaDePresas.Count == 0){
				MessageBox.Show("INGRESE PRIMERAMENTE UNA PRESA Y UN DEPREDADOR POR FAVOR","ERROR", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			
			for(int i = 0; i < myCircleGraph.Size_Nodes();i++){
				for(int j = 0; j < listaDeDepredadores.Count;j++){
					if(myCircleGraph[i].data.getBandera(listaDeDepredadores[j].GetID()) != 1){
						//marcamos este valor en cero para cada nodo y cada depredador que aún no tenga valor
						myCircleGraph[i].data.SetAgenteQueMeHaVisitado(listaDeDepredadores[j].GetID(),0);
					}
				}
			}

			//animar todo:

			bool continuarAnimando = true;
			
			while(continuarAnimando){
				int tieneCamino = 0;
				for(int i = 0; i < listaDePresas.Count;i++){
					//si la presa tiene camino:
					
					if(!listaDePresas[i].CaminoDeDijkstraVacio()){
						
						//Actualizar posicionActual:
						listaDePresas[i].Caminar();
						
						var puntoActual = listaDePresas[i].GetPosicionActual();
						
						//Dibujar:
						if(listaDePresas[i].GetDepredadorMeSigue() == null)
							DrawCircle(puntoActual,Color.DarkOrange);
						else
							DrawCircle(puntoActual,Color.DarkSalmon);
							
						var seRestaVida = RestarVida(puntoActual);
						bool zonaSegura = Circulo.Distance(puntoActual,listaDePresas[i].GetVerticeDestino().data.GetPuntoCentral()) > listaDePresas[i].GetVerticeDestino().data.GetRadioNorte();
						bool safezone = Circulo.Distance(puntoActual,listaDePresas[i].GetVerticeOrigen().data.GetPuntoCentral()) > listaDePresas[i].GetVerticeOrigen().data.GetRadioNorte();
						
						if(seRestaVida && (zonaSegura || safezone)) {
							//restar vida:
							var value = listaDePresas[i].GetResistencia();
							if (value == 0) {//si la presa ya no tiene más resistencia, entonces:
								//el depredador que tenga tal presa a acechar se le borra tal presa:
								for (int k = 0; k < listaDeDepredadores.Count; k++) {
									if (listaDeDepredadores[k].GetPresaASeguir() != null){
										if (listaDeDepredadores[k].GetPresaASeguir().GetID() == listaDePresas[i].GetID()) {
											listaDeDepredadores[k].SetPresaASeguir(null);
											//resetear la velocidad
											listaDeDepredadores[k].SetVelocidad(5);
											//actualizar datagridview:
											dataGridViewInformacionDepredadores.Rows[k].Cells["DEPREDADOR_ID_PRESA"].Value = "";
											dataGridViewInformacionDepredadores.Refresh();
											break;
										}
									}
								}
								//la presa se le borra el depredador:
								listaDePresas[i].SetDepredadorMeSigue(null);
								//se elimina la presa:
								listaDePresas.RemoveAt(i);
								//se actualiza el datagridview
								dataGridViewInformacionPresas.Rows.RemoveAt(i);
								dataGridViewInformacionPresas.Refresh();
								continue;
							}
							
							listaDePresas[i].DisminuirResistencia();
							dataGridViewInformacionPresas.Rows[i].Cells["RESISTENCIA_PRESA"].Value = listaDePresas[i].GetResistencia();
							dataGridViewInformacionPresas.Refresh();
			
						}
	
						//si la presa llegó al vértice destino
						if(listaDePresas[i].GetListaDePuntos().Count == 0){
							listaDePresas[i].SetPresaEnPeligro(false);
							//removemos el nodo origen del camino
								
							listaDePresas[i].RemoverPrimerVerticeDelCaminoDeDijkstra(); //Aqui se actualiza el vertice origen y el destino
							//actualizar datagridview:
							for(int w = 0; w < dataGridViewInformacionPresas.Rows.Count;w++){
								if(int.Parse(dataGridViewInformacionPresas.Rows[w].Cells["ID_PRESA"].Value.ToString()) == listaDePresas[i].GetID()){
									dataGridViewInformacionPresas.Rows[w].Cells["NODO_ORIGEN_PRESA"].Value = "🔑"+ listaDePresas[i].GetVerticeOrigen().data.GetID();
									dataGridViewInformacionPresas.Rows[w].Cells["NODO_DESTINO_PRESA"].Value = "🔑"+listaDePresas[i].GetVerticeDestino().data.GetID();
									dataGridViewInformacionPresas.Refresh();
									break;
								}
								
							}
							if (listaDePresas[i].CaminoDeDijkstraVacio()) {
								//llego al destino, entonces rompemos el ciclo y sumamos una vida.
								listaDePresas[i].AumentarResistencia();
								dataGridViewInformacionPresas.Rows[i].Cells["RESISTENCIA_PRESA"].Value = listaDePresas[i].GetResistencia();
								dataGridViewInformacionPresas.Refresh();
								continuarAnimando = false;
								break;
							}
							
							//obtenemos la nueva lista de puntos y un nuevo destino:
							//el cual ya se obtuvo cuando se elimino el primer vétice del camino de dijkstra
							listaDePresas[i].ObtenerCamino();
							
//							MessageBox.Show("NODO ORIGEN: "+listaDePresas[i].GetVerticeOrigen().data+"\n"+
//								            "NODO DESTINO: "+listaDePresas[i].GetVerticeDestino().data,"PRESA");
														
							//ver si un depredador se dirige o está en el nodo nuevo a dirigirse:
																		
							for(int k = 0; k < listaDeDepredadores.Count;k++){
								if(listaDeDepredadores[k].GetVerticeDestino().data.Equals(listaDePresas[i].GetVerticeDestino().data)
								   || listaDeDepredadores[k].GetVerticeOrigen().data.Equals(listaDePresas[i].GetVerticeDestino().data)){
									//hay peligro, cambiar de ruta:
									var listadenodosadyacentes = listaDePresas[i].GetVerticeOrigen().EdgeListWithout(listaDePresas[i].GetVerticeDestino());
									Graph<Circulo>.GraphNode<Circulo> nodoAMoverme = null;
									
									for(int j = 0; j < listadenodosadyacentes.Count;j++){
										//buscar si hay un depredador en tal nodo con su vertice origen:
										bool hueleAPeligro = false;
										for(int m = 0; m < listaDeDepredadores.Count;m++){
											if(/*listaDeDepredadores[m].GetVerticeOrigen().data.Equals(listadenodosadyacentes[j].data)
											  || */listaDeDepredadores[m].GetVerticeDestino().data.Equals(listadenodosadyacentes[j].data)){
												hueleAPeligro = true;
												break;
											}
										}
										
										if(!hueleAPeligro){
											nodoAMoverme = listadenodosadyacentes[j];
											//MessageBox.Show(nodoAMoverme.data.ToString(),"NODO A MOVERME");
											break;
										}
											
									}
									
									//si el nodo a moverse no es nulo, quiere decir que podemos movernos a otro nodo
									if(nodoAMoverme != null){
										//listaDePresas[i].SetPresaEnPeligro(true);
										//si hay una opcion, se salvó:
										//nos moveremos a esa posición, además, tendremos que obtener otro camino de dijkstra empenzando en el mismo
										listaDePresas[i].SetVerticeDestino(nodoAMoverme);
										//MessageBox.Show("NODO A MOVERME: "+nodoAMoverme.data.ToString());
										var lastNode = listaDePresas[i].GetCaminoDijsktra().Last();
										var caminoDijkstra = myCircleGraph.Dijkstra_Way(nodoAMoverme.data,lastNode.data);
										
										caminoDijkstra.Insert(0,nodoAMoverme);
										listaDePresas[i].SetCaminoDijkstra(caminoDijkstra);
										//obtenemos de nuevo el camino
										
										//actualizar datagridview:
										string way  = "";
										for(int j = 0; j < caminoDijkstra.Count;j++)
											way+=(j < caminoDijkstra.Count-1) ? caminoDijkstra[j].data.GetID()+"," : caminoDijkstra[j].data.GetID().ToString();
										
										if(way == string.Empty)
											way = "NO HAY CAMINO";
										//Actualizar datagridview:
										for(int n = 0; n < dataGridViewInformacionPresas.Rows.Count;n++){
											if(dataGridViewInformacionPresas.Rows[n].Cells["ID_PRESA"].Value.ToString() == listaDePresas[i].GetID().ToString()){
												dataGridViewInformacionPresas.Rows[n].Cells["NODO_DESTINO_PRESA"].Value = "🔑"+listaDePresas[i].GetVerticeDestino().data.GetID();
												dataGridViewInformacionPresas.Rows[n].Cells["CAMINO_PRESA"].Value = way;
												dataGridViewInformacionPresas.Refresh();
												break;
											}
										}
										
										//obtenemos el nuevo camino:
										listaDePresas[i].ObtenerCamino();
										
									}
									break;
								}
							}
						}
						//si está en algún punto de la arista:
						else{
							//si no está en peligro, puede estarlo:
						
							//revisar si hay un depredador cercano, para cambiar de ruta:
							for(int k = 0; k < listaDeDepredadores.Count;k++){
								//si hay algún depredador con vertice destino igual al origen de esta presa
								
								if(listaDeDepredadores[k].GetVerticeDestino().data.Equals(listaDePresas[i].GetVerticeOrigen().data)
								   && listaDePresas[i].GetVerticeDestino().data.Equals(listaDeDepredadores[k].GetVerticeOrigen().data)){
									//la presa debe de regresarse:
									//además, debemos de recalcular un nuevo destino, origen
									//listaDePresas[i].SetPresaEnPeligro(true);
									//MessageBox.Show("ÁNGULO DEL DEPREDADOR: "+anguloDelDepredador,"ANGULO DE LA PRESA: "+anguloDeLaPresa);
									listaDePresas[i].ObtenerCaminoDeRegreso();
									//MessageBox.Show("PRESA ORIGEN: "+listaDePresas[i].GetVerticeOrigen().data,"PRESA DESTINO: "+listaDePresas[i].GetVerticeDestino().data);
		
									//buscar un nuevo nodo a ir (DESTINO) dependiendo del nodo Origen de la presa:
									var listadenodosadyacentes = listaDePresas[i].GetVerticeOrigen().EdgeListWithout(listaDePresas[i].GetVerticeDestino());
									Graph<Circulo>.GraphNode<Circulo> nodoAMoverme = null;
									
									for(int j = 0; j < listadenodosadyacentes.Count;j++){
										//buscar si hay un depredador en tal nodo con su vertice origen:
										bool hueleAPeligro = false;
										for(int m = 0; m < listaDeDepredadores.Count;m++){
											if(/*listaDeDepredadores[m].GetVerticeOrigen().data.Equals(listadenodosadyacentes[j].data)
											  || */listaDeDepredadores[m].GetVerticeDestino().data.Equals(listadenodosadyacentes[j].data)){
												hueleAPeligro = true;
												break;
											}
										}
										
										if(!hueleAPeligro){
											nodoAMoverme = listadenodosadyacentes[j];
											//MessageBox.Show(nodoAMoverme.data.ToString(),"NODO A MOVERME");
											break;
										}
											
									}
									
									//si el nodo a moverse no es nulo, quiere decir que podemos movernos a otro nodo
									if(nodoAMoverme != null){
										
										//si hay una opcion, se salvó:
										//nos moveremos a esa posición, además, tendremos que obtener otro camino de dijkstra empenzando en el mismo
										listaDePresas[i].SetVerticeDestino(nodoAMoverme);
										//MessageBox.Show("NODO A MOVERME: "+nodoAMoverme.data.ToString());
										var lastNode = listaDePresas[i].GetCaminoDijsktra().Last();
										var caminoDijkstra = myCircleGraph.Dijkstra_Way(nodoAMoverme.data,lastNode.data);
										
										caminoDijkstra.Insert(0,nodoAMoverme);
										listaDePresas[i].SetCaminoDijkstra(caminoDijkstra);
										//obtenemos de nuevo el camino
										
										//actualizar datagridview:
										string way  = "";
										for(int j = 0; j < caminoDijkstra.Count;j++)
											way+=(j < caminoDijkstra.Count-1) ? caminoDijkstra[j].data.GetID()+"," : caminoDijkstra[j].data.GetID().ToString();
										
										if(way == string.Empty)
											way = "NO HAY CAMINO";
										//Actualizar datagridview:
										for(int n = 0; n < dataGridViewInformacionPresas.Rows.Count;n++){
											if(dataGridViewInformacionPresas.Rows[n].Cells["ID_PRESA"].Value.ToString() == listaDePresas[i].GetID().ToString()){
												dataGridViewInformacionPresas.Rows[n].Cells["NODO_DESTINO_PRESA"].Value = "🔑"+listaDePresas[i].GetVerticeDestino().data.GetID();
												dataGridViewInformacionPresas.Rows[n].Cells["CAMINO_PRESA"].Value = way;
												dataGridViewInformacionPresas.Refresh();
												break;
											}
										}
										
										//agregar el nuevo camino:
										//listaDePresas[i].AgregarCamino();
										
									}
	
									listaDePresas[i].AgregarCamino();
									break;
								}
							
							}//end for
						
							
						}//end si esta en algún  punto de la lista
					
					}
					else{
						tieneCamino++;
					}
				}
				
				if(!continuarAnimando || tieneCamino == listaDePresas.Count || listaDePresas.Count == 0)
					break;
				
				//animar depredadores:
				
				for(int i = 0; i < listaDeDepredadores.Count;i++){
					//animar depredadores:
					var listaDePuntos = listaDeDepredadores[i].GetListaDePuntos();
					if(listaDePuntos.Count != 0){//si hay puntos de la lista de puntos todavia:
						//mover el depredador:
						var nuevoPunto = listaDeDepredadores[i].GetListaDePuntos().First();
						if(listaDeDepredadores[i].GetPresaASeguir() == null){
							for(int q = 0; q < 4;q++){
								if(listaDeDepredadores[i].GetListaDePuntos().Count != 0){
									listaDeDepredadores[i].GetListaDePuntos().RemoveAt(0);
								}else{
									break;
								}
							}
						}
						else{
							var distancia = Circulo.Distance(listaDeDepredadores[i].GetPosicionActual(),listaDeDepredadores[i].GetPresaASeguir().GetPosicionActual());
							double velocidad = 100/distancia * 5;
							int velocity = 5;
							if(velocidad > 50)
								velocity = 50;
							else
								velocity = Convert.ToInt32(velocidad);
							
							for(int q = 0; q < velocity;q++){
								if(listaDeDepredadores[i].GetListaDePuntos().Count != 0){
									listaDeDepredadores[i].GetListaDePuntos().RemoveAt(0);
								}else{
									break;
								}
							}
						}
						
						DrawDepredador(listaDeDepredadores[i]);
						listaDeDepredadores[i].SetPosicionActual(nuevoPunto);
						
//						//buscar si existe una presa cercano a él:
						double distanciaMenor = Double.PositiveInfinity;
						int posicionPresa = -1; 
						for(int j = 0; j < listaDePresas.Count;j++){
							var distancia = Circulo.Distance(listaDeDepredadores[i].GetPosicionActual(),listaDePresas[j].GetPosicionActual());
							if(distancia <= 150){//si la distancia de este depredador con respecto a la presa es menor o igual a 150 pixels (radio)
								if(distancia < distanciaMenor){//ahora, si esta distancia es menor a las otras, esta presa será la mejor opcion:
									distanciaMenor = distancia;
									posicionPresa = j;
								}
							}
						}
						
						if(posicionPresa != -1){
							//si existe presa:
							//actualizar datos de los mismos:
							
							var presa = listaDePresas[posicionPresa];
							
							if(presa.GetDepredadorMeSigue() == null){
								//esta presa no tiene depredador asociado, entonces se actualiza directo
								
								listaDePresas[posicionPresa].SetDepredadorMeSigue(listaDeDepredadores[i]);
								listaDeDepredadores[i].SetPresaASeguir(presa);
								//actualizar datagridview:
								dataGridViewInformacionDepredadores.Rows[i].Cells["DEPREDADOR_ID_PRESA"].Value = presa.GetID();
								dataGridViewInformacionPresas.Rows[posicionPresa].Cells["ID_DEPREDADOR_ACECHO"].Value = listaDeDepredadores[i].GetID();
								dataGridViewInformacionDepredadores.Refresh();
								dataGridViewInformacionPresas.Refresh();
							}
							else{
								//esta presa tiene depredador asociado:
								
								//Si la presa tiene un depredador diferente entonces si cambiamos.
								if(!presa.GetDepredadorMeSigue().GetID().Equals(listaDeDepredadores[i].GetID())){
									dataGridViewInformacionDepredadores.Rows[presa.GetDepredadorMeSigue().GetID()].Cells["DEPREDADOR_ID_PRESA"].Value = "";
									for(int k = 0; k < listaDeDepredadores.Count;k++){
										if(listaDeDepredadores[k].GetPresaASeguir() != null){
											if(listaDeDepredadores[k].GetPresaASeguir().GetID() == presa.GetID()){
												listaDeDepredadores[k].SetPresaASeguir(null); //Este depredador ya no seguirá a tal presa.												break;
											}
										}
									}
									
									listaDePresas[posicionPresa].SetDepredadorMeSigue(listaDeDepredadores[i]);
									listaDeDepredadores[i].SetPresaASeguir(presa);
									//actualizar datagridview:
									dataGridViewInformacionDepredadores.Rows[i].Cells["DEPREDADOR_ID_PRESA"].Value = presa.GetID();
									dataGridViewInformacionPresas.Rows[posicionPresa].Cells["ID_DEPREDADOR_ACECHO"].Value = listaDeDepredadores[i].GetID();
									dataGridViewInformacionDepredadores.Refresh();
									dataGridViewInformacionPresas.Refresh();
								}
								
								
							}
						}
						
					}
					else{//buscar un nuevo camino:
						//MessageBox.Show("CAMINO ACABADO PARA DEPREDADOR");
						//si el depredador aún no tiene presa a seguir
						if(listaDeDepredadores[i].GetPresaASeguir() == null){
							//buscar si hay presas cercanas al depredador:
							double distanciaMenor = Double.PositiveInfinity;
							int posicionPresa = -1; 
							for(int j = 0; j < listaDePresas.Count;j++){
								var distancia = Circulo.Distance(listaDeDepredadores[i].GetPosicionActual(),listaDePresas[j].GetPosicionActual());
								if(distancia <= 150){//si la distancia de este depredador con respecto a la presa es menor o igual a 200 pixels (radio)
									if(distancia < distanciaMenor){//ahora, si esta distancia es menor a las otras, esta presa será la mejor opcion:
										distanciaMenor = distancia;
										posicionPresa = j;
									}
								}
							}
							
							//aún no hay presa que acechar, el depredador se mueve random, por lo que debemos de buscar un nuevo nodo a ir
							if(posicionPresa == -1){
								var nodoAIr = ListaAdyacencia(listaDeDepredadores[i]);
								//aumentamos la bandera del nodo destino, ya que en este momento hemos llegado a éste
								listaDeDepredadores[i].GetVerticeDestino().data.incrementBandera(listaDeDepredadores[i].GetID());
								
								if(nodoAIr == null){
									// no hay camino:
									DrawDepredador(listaDeDepredadores[i]);
								}else{
									//si hay camino
									listaDeDepredadores[i].SetVerticeOrigen(listaDeDepredadores[i].GetVerticeDestino());
									listaDeDepredadores[i].SetVerticeDestino(nodoAIr);
									//obtenemos el nuevo camino:
									listaDeDepredadores[i].ObtenerCamino();
								}
							}
							//se encontró una presa para seguir
							else
							{
								var presa = listaDePresas[posicionPresa];
								if(listaDePresas[posicionPresa].GetDepredadorMeSigue() == null){
									//esta presa no tiene depredador asociado, entonces se actualiza directo
									
									listaDePresas[posicionPresa].SetDepredadorMeSigue(listaDeDepredadores[i]);
									listaDeDepredadores[i].SetPresaASeguir(presa);
									//actualizar datagridview:
									dataGridViewInformacionDepredadores.Rows[i].Cells["DEPREDADOR_ID_PRESA"].Value = presa.GetID();
									dataGridViewInformacionPresas.Rows[posicionPresa].Cells["ID_DEPREDADOR_ACECHO"].Value = listaDeDepredadores[i].GetID();
									dataGridViewInformacionDepredadores.Refresh();
									dataGridViewInformacionPresas.Refresh();
								}
								else{
									//esta presa tiene depredador asociado, por lo tanto debemos de desvincular los datos:
									
									dataGridViewInformacionDepredadores.Rows[presa.GetDepredadorMeSigue().GetID()].Cells["DEPREDADOR_ID_PRESA"].Value = "";
									for(int k = 0; k < listaDeDepredadores.Count;k++){
										if(listaDeDepredadores[k].GetPresaASeguir() != null){
											if(listaDeDepredadores[k].GetPresaASeguir().GetID() == presa.GetID()){
												listaDeDepredadores[k].SetPresaASeguir(null); //Este depredador ya no seguirá a tal presa.
												break;
											}
										}
									}
									
									listaDePresas[posicionPresa].SetDepredadorMeSigue(listaDeDepredadores[i]);
									listaDeDepredadores[i].SetPresaASeguir(presa);
									//actualizar datagridview:
									dataGridViewInformacionDepredadores.Rows[i].Cells["DEPREDADOR_ID_PRESA"].Value = presa.GetID();
									dataGridViewInformacionPresas.Rows[posicionPresa].Cells["ID_DEPREDADOR_ACECHO"].Value = listaDeDepredadores[i].GetID();
									dataGridViewInformacionDepredadores.Refresh();
									dataGridViewInformacionPresas.Refresh();
								}
								
								//obtener el  ángulo respecto a la presa:
								var angulo = Agente.GetAngulo(listaDeDepredadores[i].GetVerticeOrigen().data.GetPuntoCentral(),presa.GetVerticeDestino().data.GetPuntoCentral());
								angulo = 360 - angulo;
								//buscar el mejor nodo con respecto a tal ángulo:
								var listaAdyacencias = listaDeDepredadores[i].GetVerticeDestino().EdgeList();
								var colaAngular = new List<Pair<Graph<Circulo>.GraphNode<Circulo>, double>>();
								bool meMuevoMejor = false;
								for (int j = 0; j < listaAdyacencias.Count; j++)
								{
									if(listaAdyacencias[j].data.Equals(listaDeDepredadores[i].GetPresaASeguir().GetVerticeDestino().data)
									  ||  listaAdyacencias[j].data.Equals(listaDeDepredadores[i].GetPresaASeguir().GetVerticeOrigen().data)){
										//mejor me muevo a esta posicion:
										meMuevoMejor = true;
										//MessageBox.Show("NODO A IR: "+listaAdyacencias[j].data.ToString(),"SE ENCONTRO PRESA A SEGUIR");
										listaDeDepredadores[i].GetVerticeDestino().data.incrementBandera(listaDeDepredadores[i].GetID());
										listaDeDepredadores[i].SetVerticeOrigen(listaDeDepredadores[i].GetVerticeDestino());
										listaDeDepredadores[i].SetVerticeDestino(listaAdyacencias[j]);
										listaDeDepredadores[i].ObtenerCamino();
										break;	
									}
									var anguloArista = Agente.GetAngulo(listaDeDepredadores[i].GetVerticeOrigen().data.GetPuntoCentral(),listaAdyacencias[j].data.GetPuntoCentral());
									anguloArista = 360 - anguloArista;
									colaAngular.Add(new Pair<Graph<Circulo>.GraphNode<Circulo>, double>(listaAdyacencias[j], anguloArista));
									colaAngular.Add(new Pair<Graph<Circulo>.GraphNode<Circulo>, double>(listaAdyacencias[j], anguloArista + 360));
	
								}
	
								if(!meMuevoMejor){
									//ordenar la lista de angulos respecto a la mejor diferencia
									OrdenarAngulos(ref colaAngular, angulo,listaDeDepredadores[i].GetID());
									//mover a la primera posicion:
									listaDeDepredadores[i].GetVerticeDestino().data.incrementBandera(listaDeDepredadores[i].GetID());
									listaDeDepredadores[i].SetVerticeOrigen(listaDeDepredadores[i].GetVerticeDestino());
									listaDeDepredadores[i].SetVerticeDestino(colaAngular.First().firstData);
								
									listaDeDepredadores[i].ObtenerCamino();
								}
							}
						}
						//ya tiene presa a seguir
						else{
							//obtener el ángulo respecto a la presa:
							var presa = listaDeDepredadores[i].GetPresaASeguir();
							var angulo = Agente.GetAngulo(listaDeDepredadores[i].GetVerticeOrigen().data.GetPuntoCentral(),presa.GetVerticeDestino().data.GetPuntoCentral());
							angulo = 360 - angulo;
							//buscar el mejor nodo con respecto a tal ángulo:
							var listaAdyacencias = listaDeDepredadores[i].GetVerticeDestino().EdgeList();
							var colaAngular = new List<Pair<Graph<Circulo>.GraphNode<Circulo>, double>>();
							bool meMuevoMejor = false;
							for (int j = 0; j < listaAdyacencias.Count; j++)
							{
								if(listaAdyacencias[j].data.Equals(listaDeDepredadores[i].GetPresaASeguir().GetVerticeDestino().data)
								   || listaAdyacencias[j].data.Equals(listaDeDepredadores[i].GetPresaASeguir().GetVerticeOrigen().data)){
									//mejor me muevo a esta posicion:
									meMuevoMejor = true;
									//MessageBox.Show("NODO A IR: "+listaAdyacencias[j].data.ToString(),"YA TIENE PRESA A SEGUIR");
									listaDeDepredadores[i].GetVerticeDestino().data.incrementBandera(listaDeDepredadores[i].GetID());
									listaDeDepredadores[i].SetVerticeOrigen(listaDeDepredadores[i].GetVerticeDestino());
									listaDeDepredadores[i].SetVerticeDestino(listaAdyacencias[j]);
									listaDeDepredadores[i].ObtenerCamino();
									break;	
								}
								
								var anguloArista = Agente.GetAngulo(listaDeDepredadores[i].GetVerticeOrigen().data.GetPuntoCentral(),listaAdyacencias[j].data.GetPuntoCentral());
								anguloArista = 360 - anguloArista;
								colaAngular.Add(new Pair<Graph<Circulo>.GraphNode<Circulo>, double>(listaAdyacencias[j], anguloArista));
								colaAngular.Add(new Pair<Graph<Circulo>.GraphNode<Circulo>, double>(listaAdyacencias[j], anguloArista + 360));

							}

							if(!meMuevoMejor){
								//ordenar la lista de angulos respecto a la mejor diferencia
								OrdenarAngulos(ref colaAngular, angulo, listaDeDepredadores[i].GetID());
								//mover a la primera posicion:
								listaDeDepredadores[i].GetVerticeDestino().data.incrementBandera(listaDeDepredadores[i].GetID());
								listaDeDepredadores[i].SetVerticeOrigen(listaDeDepredadores[i].GetVerticeDestino());
								listaDeDepredadores[i].SetVerticeDestino(colaAngular.First().firstData);
								listaDeDepredadores[i].ObtenerCamino();
							}
							
						}
					
						//MessageBox.Show("NODO A IR: "+listaDeDepredadores[i].GetVerticeDestino().data.ToString(),"VERTICE DESTINO");
						dataGridViewInformacionDepredadores.Rows[i].Cells["DEPREDADOR_NODO_ORIGEN"].Value = "🔑"+ listaDeDepredadores[i].GetVerticeOrigen().data.GetID();
						dataGridViewInformacionDepredadores.Rows[i].Cells["DEPREDADOR_NODO_DESTINO"].Value = "🔑"+ listaDeDepredadores[i].GetVerticeDestino().data.GetID();
						dataGridViewInformacionDepredadores.Refresh();
					}
				}
				
				pictureBoxGrafo.Refresh();
				ClearBitmap();
			}
			
			MessageBox.Show("SIMULACIÓN REALIZADA CORRECTAMENTE","INFORMACIÓN",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			
		}
		
		void DrawDepredador(Depredador depredador){
			var graficos = Graphics.FromImage(bitmapFrente);	
			//dibujar depredador:
			if(depredador.GetPresaASeguir() == null)
				graficos.FillEllipse(new SolidBrush(Color.Red),new Rectangle(depredador.GetPosicionActual().X,depredador.GetPosicionActual().Y,20,20));
			else{
				graficos.FillEllipse(new SolidBrush(Color.DarkRed),new Rectangle(depredador.GetPosicionActual().X,depredador.GetPosicionActual().Y,20,20));
				var nuevoPunto = new Point(depredador.GetPosicionActual().X+10,depredador.GetPosicionActual().Y+10);
				var angulo = Agente.GetAngulo(nuevoPunto,depredador.GetPresaASeguir().GetPosicionActual());
				angulo = angulo*(Math.PI/180);
				var x = Math.Cos(angulo)*40;
				var y = Math.Sin(angulo)*40;
				var newPen = new Pen(Color.DarkViolet,5);
				newPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
				graficos.DrawLine(newPen,nuevoPunto.X,nuevoPunto.Y,Convert.ToInt32(nuevoPunto.X+x),Convert.ToInt32(nuevoPunto.Y+y));
				newPen.Dispose();
			}
			graficos.DrawEllipse(new Pen(Color.Black),new Rectangle(depredador.GetPosicionActual().X-150,depredador.GetPosicionActual().Y-150,300,300));
	
			graficos.Dispose();
		}
		
		void ClearBitmap(){
			var graficos = Graphics.FromImage(bitmapFrente);
			graficos.Clear(Color.Transparent);
			graficos.Dispose();
		}

		public Point GetPuntoPresa(int id)
		{
			for(int i = 0; i < listaDePresas.Count; i++)
			{
				if (listaDePresas[i].GetID().Equals(id))
					return listaDePresas[i].GetPosicionActual();
			}

			return new Point(-1,-1);
		}
		
		void OrdenarAngulos(ref List<Pair<Graph<Circulo>.GraphNode<Circulo>, double>> lista, double anguloNodo, int id){
			var min = 0;
			//anguloNodo = anguloGraphNode			

			for (int i = 0; i < lista.Count; ++i) {
				min = i;
		        for (int j = i+1; j < lista.Count; ++j){
					double diferenciaJ = Math.Abs(anguloNodo-lista[j].secondData);
					double diferenciaMin = Math.Abs(anguloNodo-lista[min].secondData);
		        	if(diferenciaJ < diferenciaMin)
		                min = j;
				}
				
				var intercambio = lista[i];
		        lista[i] = lista[min];
		        lista[min] = intercambio;
		        
		    }
			
			//ahora ordenamos por banderas
//			min = 0;
//			for (int i = 0; i < lista.Count; ++i) {
//				min = i;
//				
//		        for (int j = i+1; j < lista.Count; ++j){
//					
//					if(lista[j].firstData.data.getBandera(id) < lista[min].firstData.data.getBandera(id))
//		                min = j;
//				}
//				
//				var intercambio = lista[i];
//		        lista[i] = lista[min];
//		        lista[min] = intercambio;
//		    }
		}

		bool RestarVida(Point puntoPresa){
			for(int i = 0; i < listaDeDepredadores.Count;i++){
				var distancia = Circulo.Distance(puntoPresa,listaDeDepredadores[i].GetPosicionActual());
				if(Math.Abs(distancia) <= 20)
					return true;
			}
			return false;
		}
		
		
		Graph<Circulo>.GraphNode<Circulo> Get_Node(Depredador a){
			//Buscar el vertice que tenga la misma posicion que el agente:
			for(int i = 0; i < myCircleGraph.Size_Nodes();i++){
				if(myCircleGraph[i].data.GetPuntoCentral().Equals(a.GetPosicionActual())){
					return myCircleGraph[i];
				}
			}
			
			return null;
		}
		
		Graph<Circulo>.GraphNode<Circulo> ListaAdyacencia(Depredador depredador){
			var listaAuxiliar = new List<Pair<Graph<Circulo>.GraphNode<Circulo>,int>>();
			var aux = depredador.GetVerticeDestino().adyacentEdge;
			while(aux != null){
				listaAuxiliar.Add(new Pair<Graph<Circulo>.GraphNode<Circulo>, int>(aux.adyacentNode,aux.adyacentNode.data.getBandera(depredador.GetID())));
				aux = aux.nextEdge;
			}

			
			
			return (listaAuxiliar.Count != 0)? listaAuxiliar.OrderBy(x => x.secondData).ToList().First().firstData : null;
		}
		void PictureBoxGrafoDoubleClick(object sender, EventArgs e)
		{
			var resultado = MessageBox.Show("¿DESEA LIMPIAR EL PICTUREBOX?","PREGUNTA",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if(resultado == DialogResult.Yes){
				ClearBitmap();
				pictureBoxGrafo.Refresh();
				listaDePresas.Clear();
				listaDeDepredadores.Clear();
				comboBoxDepredador.Items.Clear();
				comboBoxPresaOrigen.Items.Clear();
				comboBoxPresasDestino.Items.Clear();
				dataGridViewInformacionDepredadores.Rows.Clear();
				dataGridViewInformacionPresas.Rows.Clear();
				for(int i = 0; i < myCircleGraph.Size_Nodes();i++){
					var value = myCircleGraph[i];
					myCircleGraph[i].data.ClearAgentesQueMeHanVisitado();
					comboBoxPresasDestino.Items.Add(value);
					comboBoxPresaOrigen.Items.Add(value);
					comboBoxDepredador.Items.Add(value);
				}
				buttonAgregarDepredador.Enabled = buttonAgregarPresa.Enabled = true;
				
			}
		}
		void NumericUpDownDepredadoresValueChanged(object sender, EventArgs e)
		{
			this.numericUpDownDepredadores.Maximum = myCircleGraph.Size_Nodes() - (listaDePresas.Count) - listaDeDepredadores.Count;
		}
		void NumericUpDownPresasValueChanged(object sender, EventArgs e)
		{
			this.numericUpDownPresas.Maximum = myCircleGraph.Size_Nodes() - (listaDePresas.Count) - listaDeDepredadores.Count;
		}
		void ButtonAgregarClick(object sender, EventArgs e)
		{
			if(numericUpDownDepredadores.Value + numericUpDownPresas.Value + 
			   listaDePresas.Count + listaDeDepredadores.Count > myCircleGraph.Size_Nodes()){
				MessageBox.Show("EL NÚMERO DE PRESAS EXISTENTES, MÁS EL NÚMERO DE DEPREDADORES EXISTENTES.\n" +
				                "MÁS EL NÚMERO INGRESADO DE PRESAS Y MÁS EL NÚMERO INGRESADO DE DEPREDADORES SUPERA EL\n" +
				                "NÚMERO DE NODOS DEL GRAFO EXISTENTES","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			else{
				//si es válido:
				
				//agregamos primero las presas:
				var random = new Random();
				var otroRandom = new Random();
				int cont = 0;
				
				while(cont < numericUpDownPresas.Value){
					int pos = random.Next(0,comboBoxPresaOrigen.Items.Count-1);
					int posDestino = random.Next(0,comboBoxPresasDestino.Items.Count-1);

					//crear presa en tal posicion del comboboxPresaOrigen:
					
					var nuevaPresa = new Presa(listaDePresas.Count);
		
					//casteo de nodo origen seleccionado:
					var nodoOrigen = (Graph<Circulo>.GraphNode<Circulo>)comboBoxPresaOrigen.Items[pos];
					//seleccionar nodo destino:
					
					var nodoDestino = (Graph<Circulo>.GraphNode<Circulo>)comboBoxPresasDestino.Items[posDestino];
					//Obtener el camino de dijkstra del nodo origen hasta el nodo destino seleccionado
					var DijkstraWay = myCircleGraph.Dijkstra_Way(nodoOrigen.data,nodoDestino.data);
					
					//agregar los nuevos datos a la presa:
					nuevaPresa.SetVerticeOrigen(nodoOrigen); //aqui tambien se setea el valor del punto actual
					nuevaPresa.SetCaminoDijkstra(DijkstraWay);
					
					//obtenemos el nodo destino de la presa, el cual es el primer nodo de DijsktraWay:
					if(DijkstraWay.Count == 0){//si no hay camino, entonces el nodo destino será igual al nodo Origen
						nuevaPresa.SetVerticeDestino(nodoOrigen);
					}else{//si hay camino, entonces el nodo destino será el primer valor de la lista de camino de dijkstra
						nuevaPresa.SetVerticeDestino(DijkstraWay.First());
						//aqui ya podemos obtener el camino del nodo origen al nodo destino:
						nuevaPresa.ObtenerCamino();
					}
					
					//dibujar presa
					DrawCircle(nuevaPresa.GetPosicionActual(),Color.DarkOrange);
					pictureBoxGrafo.Refresh();
					
					//agregar datos de la presa en el datagridview
					string way = "";
					for(int j = 0; j < DijkstraWay.Count;j++)
						way+=(j < DijkstraWay.Count-1) ? DijkstraWay[j].data.GetID()+"," : DijkstraWay[j].data.GetID().ToString();
					
					if(way == string.Empty)
						way = "NO HAY CAMINO";
					
					int indice = dataGridViewInformacionPresas.Rows.Add();
					dataGridViewInformacionPresas.Rows[indice].Cells["ID_PRESA"].Value = nuevaPresa.GetID();
					dataGridViewInformacionPresas.Rows[indice].Cells["RESISTENCIA_PRESA"].Value = 1;
					dataGridViewInformacionPresas.Rows[indice].Cells["NODO_ORIGEN_PRESA"].Value = "🔑"+ nodoOrigen.data.GetID();
					dataGridViewInformacionPresas.Rows[indice].Cells["NODO_DESTINO_PRESA"].Value = "🔑"+ nuevaPresa.GetVerticeDestino().data.GetID();
					dataGridViewInformacionPresas.Rows[indice].Cells["CAMINO_PRESA"].Value = way;
		
					//removemos el nodo del combobox para que ya no sea utilizable, tanto para las presas como los depredadores
					var item = comboBoxPresaOrigen.Items[pos];
					comboBoxPresaOrigen.Items.Remove(item);
					comboBoxDepredador.Items.Remove(item);
					comboBoxPresaOrigen.Refresh();
					
					//agregar la nueva presa a la lista de presas:
					listaDePresas.Add(nuevaPresa);	
					
					//si el número de presas más el número de depredadores es igual al 
					//número de nodos del grafo, bloquemos el añadir presas y depredadores.
					if(listaDePresas.Count + listaDeDepredadores.Count == myCircleGraph.Size_Nodes())
						buttonAgregarPresa.Enabled = buttonAgregarDepredador.Enabled = false;
						
						cont++;
						
				}//end while

				
				//agregar depredadores:
				
				var depredadoresRandom = new Random();
				cont = 0; 
				while(cont < numericUpDownDepredadores.Value){
					int pos = depredadoresRandom.Next(0,comboBoxDepredador.Items.Count);
					//crear nuevo depredador:
					var nuevoDepredador = new Depredador(listaDeDepredadores.Count);
					
					//obtener el nodo origen:
					var nodoOrigen = (Graph<Circulo>.GraphNode<Circulo>)comboBoxDepredador.Items[pos]; //casteo
					nodoOrigen.data.SetAgenteQueMeHaVisitado(nuevoDepredador.GetID(),1);
					//agregar datos del depredador:
					nuevoDepredador.SetVerticeOrigen(nodoOrigen);
					
					//dibujar depredador
					
					DrawCircle(nodoOrigen.data.GetPuntoCentral(),Color.Red);
					pictureBoxGrafo.Refresh();
					
					//añadir la información de los depredadores
					int indice = dataGridViewInformacionDepredadores.Rows.Add();
					dataGridViewInformacionDepredadores.Rows[indice].Cells["ID_DEPREDADOR"].Value = nuevoDepredador.GetID();
					dataGridViewInformacionDepredadores.Rows[indice].Cells["DEPREDADOR_NODO_ORIGEN"].Value = "🔑"+ nodoOrigen.data.GetID();
					
					//removemos el nodo del combobox para que ya no sea utilizable, tanto para las presas como los depredadores
					var item = comboBoxDepredador.Items[pos];
					comboBoxPresaOrigen.Items.Remove(item);
					comboBoxDepredador.Items.Remove(item);
					comboBoxDepredador.Refresh();
					
						
					//buscar las adyacencias del vertice Origen del depredador:
					
					var listaAdyacencias = nodoOrigen.EdgeList();
					
					//si la lista esta vacia, quiere decir que no hay a donde ir:
					if(listaAdyacencias.Count == 0){
						//agregamos el vertice destino como el mismo vertice origen
						nuevoDepredador.SetVerticeDestino(nodoOrigen);
					}else{
						//si hay adyacencias, entonces tomamos la primera opcion:
						nuevoDepredador.SetVerticeDestino(listaAdyacencias.First());
						//aumentamos bandera de tal vertice, visitado por este depredador:
						//obtenemos el camino:
						nuevoDepredador.ObtenerCamino();
					}
					
					
					//agregar el nuevo depredador a la lista de depredadores:
					listaDeDepredadores.Add(nuevoDepredador);	
					
					//si el número de presas más el número de depredadores es igual al 
					//número de nodos del grafo, bloquemos el añadir presas y depredadores.
					if(listaDePresas.Count + listaDeDepredadores.Count == myCircleGraph.Size_Nodes())
						buttonAgregarPresa.Enabled = buttonAgregarDepredador.Enabled = false;
					cont++;
				}
				
			}

		}
		
	}
}
