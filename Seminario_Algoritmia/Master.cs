/*
 * Created by SharpDevelop.
 * User: qwert
 * Date: 24/07/2019
 * Time: 12:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Seminario_Algoritmia
{
	/// <summary>
	/// Description of Graph.
	/// </summary>
	public class Graph<T>
	{
		//Edge
		public class GraphEdge<M>
		{
			public GraphEdge<M> nextEdge;
			public GraphNode<M> adyacentNode;
			public double weight;
			
			public GraphEdge(double peso, GraphNode<M> nodoAdyacente, GraphEdge<M> siguiente)
			{
				this.weight = peso;
				this.adyacentNode = nodoAdyacente;
				this.nextEdge = siguiente;
				
			}
			
			public override string ToString()
			{
				return string.Format("{0}", weight);
			}

		}
		//Node
		public class GraphNode<N>
		{
	
			public GraphNode<N> nextNode;
			public N data;
			public GraphEdge<N> adyacentEdge;	
			
			public GraphNode(N dato, GraphNode<N> siguiente, GraphEdge<N> aristaAdyacente)
			{
				this.data = dato;
				this.nextNode = siguiente;
				this.adyacentEdge = aristaAdyacente;
				
			}
			
			public List<GraphEdge<N>> Edges(){
				var nuevaLista = new List <GraphEdge<N>>();
				
				var auxiliar = this.adyacentEdge;
				
				while(auxiliar != null){
					nuevaLista.Add(auxiliar);
					auxiliar = auxiliar.nextEdge;
				}
				
				return nuevaLista;
				
			}

			public override string ToString()
			{
				return data.ToString();
			}
			public int Size_Edges(){
				var auxiliar = this.adyacentEdge;
				if(auxiliar == null) return 0;
				else{
					var counter = 0;
					while(auxiliar != null){
						counter++;
						auxiliar = auxiliar.nextEdge;
					}
					return counter;
				}
				
			}
			
			public List<GraphNode<N>> EdgeList(){
				var nuevaLista = new List <GraphNode<N>>();
				
				var auxiliar = this.adyacentEdge;
				
				while(auxiliar != null){
					nuevaLista.Add(auxiliar.adyacentNode);
					auxiliar = auxiliar.nextEdge;
				}
				
				return nuevaLista;
			}
			
			public List<GraphNode<N>> EdgeListWithout(GraphNode<T> value){
				var nuevaLista = new List <GraphNode<N>>();
				
				var auxiliar = this.adyacentEdge;
				
				while(auxiliar != null){
					if(!value.data.Equals(auxiliar.adyacentNode.data))
						nuevaLista.Add(auxiliar.adyacentNode);
					auxiliar = auxiliar.nextEdge;
				}
				
				return nuevaLista;
			}
			
			
			public List<GraphNode<N>> EdgeList(GraphNode<N> without){
				var nuevaLista = new List <GraphNode<N>>();
				
				var auxiliar = this.adyacentEdge;
				
				while(auxiliar != null){
					if(!auxiliar.adyacentNode.data.Equals(without.data)) nuevaLista.Add(auxiliar.adyacentNode);
					auxiliar = auxiliar.nextEdge;
				}
				
				return nuevaLista;
			}

	
		}

		private GraphNode<T> startNode;
		private List<Triplet<T,double,T>> edgesValues;
		private int numberNodes;
		private int NumberEdges;
		private double graphWeight;
		
		public Graph()
		{
			startNode = null;
			numberNodes = 0;
			NumberEdges = 0;
			graphWeight = 0;
			edgesValues = new List<Triplet<T, double, T>>();
		}
		
		
		public Graph(Graph<T> otherGraph){
			startNode = null;
			numberNodes = 0;
			NumberEdges = 0;
			edgesValues = new List<Triplet<T, double, T>>();
			
			//insertar nodos:
			for(int i = 0; i < otherGraph.Size_Nodes();i++){
				this.Insert_Node(otherGraph[i].data);
			}
			
			//insert edges:
			var helperList = new List<Triplet<T,double,T>>(otherGraph.edgesValues);
			for(int i = 0; i < helperList.Count;i++){
				this.Insert_Edge(helperList[i].secondData,helperList[i].firstData,helperList[i].thirdData);
			}
			
			helperList.Clear();
		}
		
		public List<Triplet<T,double,T>> GetEdges(){
			return edgesValues;
		}
		
		
		~Graph(){
			Clear();
		}
	
		
		public bool Empty(){
			return startNode == null;
		}
		public int Size_Nodes(){
			return numberNodes;
		}
		
		
		public int Get_Position(GraphNode<T> node){
			int k = 0;
			var auxiliar = startNode;
			while(auxiliar != null){
				if(auxiliar.data.Equals(node.data)) break;
				auxiliar = auxiliar.nextNode;
				k++;
			}
		 	return k;
		}
		
		public int Get_Position(T value){
			int k = 0;
			var auxiliar = startNode;
			while(auxiliar != null){
				if(auxiliar.data.Equals(value)) break;
				auxiliar = auxiliar.nextNode;
				k++;
			}
		 	return k;
		}
		
		public int Size_Edges(){
			return NumberEdges;
		}
		
		public void Insert_Node(T element){
			if(!Exist(element)){
				if(Empty()){
					var newNode = new GraphNode<T>(element,null,null);
					startNode = newNode;
				}
				else{
					var auxiliar = startNode;
					while(auxiliar.nextNode != null){
						auxiliar = auxiliar.nextNode;
					}
					var newNode = new GraphNode<T>(element,null,null);
					auxiliar.nextNode = newNode;
				}
				
				numberNodes++;
			}

		}
		
		public bool Exist(T element){
			var auxiliar = this.startNode;
			while(auxiliar != null){
				if(auxiliar.data.Equals(element)) return true;
				auxiliar = auxiliar.nextNode;
			}
			return false;
		}
		
		public GraphNode<T> Get_Node(T element){
			
			var auxiliar = startNode;
			while(auxiliar != null){
				if(element.Equals(auxiliar.data)) return auxiliar;
				auxiliar = auxiliar.nextNode;
			}
			
		 throw new Exception("THE NODE WITH SUCH A NAME DOES NOT EXIST");

		}
		
		public GraphNode<T> Get_Node(int pos){
			if(!Empty()){
				pos = pos % Size_Nodes();
				if(pos == 0) {
					return startNode;
				}
				else{
					var auxiliar = startNode;
					int cont = 0;
					while(cont < pos){
						auxiliar = auxiliar.nextNode;
						cont++;
					}
					
					return auxiliar;
				}
			}
			else{
				throw new Exception("EMPTY GRAPH");
			}
		}
		
		public void Insert_Edge(double value, T origen, T destino){
			if(!Exist_Edge(origen,destino)){
				var Origin = Get_Node(origen);
				var Destination = Get_Node(destino);
				
				var newEdge = new GraphEdge<T>(value,Destination,null);
				
				var auxiliar = Origin.adyacentEdge;
				
				if(auxiliar == null){
					
					Origin.adyacentEdge = newEdge;
				}
				else{
					while(auxiliar.nextEdge != null){
						auxiliar = auxiliar.nextEdge;
					}
					
					auxiliar.nextEdge = newEdge;
				}
				graphWeight+=value;
				
				edgesValues.Add(new Triplet<T,double,T>(origen,value,destino));
				
				NumberEdges++;
			}
			
		}
		
		public bool Exist_Edge(T origen, T destino){
			var Origin = Get_Node(origen);
			var Destination = Get_Node(destino);
			var auxiliar = Origin.adyacentEdge;
			if(auxiliar == null){
				return false;
			}
			else{
				while(auxiliar != null){
					if(auxiliar.adyacentNode.data.Equals(Destination.data)) return true;
					auxiliar = auxiliar.nextEdge;
				}
				
				return false;
			}
		}

		public void Clear(){
			var counter = 0;
			var numNodes = Size_Nodes();
			
			while(counter < numNodes){
				Delete_Node(startNode.data);
				counter++;
			}
			
			NumberEdges = 0;
			numberNodes = 0;
			startNode = null;
			graphWeight = 0;
			edgesValues.Clear();
			
			
		}
		
		public void Delete_Edge(T origin, T destination){
			var origen = Get_Node(origin);
			var destino = Get_Node(destination);
			
			
		    var ayudante_arista = origen.adyacentEdge;
		   	
		    if(ayudante_arista != null){
		    	
			    if(ayudante_arista.adyacentNode.data.Equals(destino.data)){
			    	origen.adyacentEdge = ayudante_arista.nextEdge;
			    	ayudante_arista = null;
			    	NumberEdges--;
			    }
			    else{
					GraphEdge<T> auxiliar_arista = null;
			        while(ayudante_arista != null){
			
						if(ayudante_arista.adyacentNode.data.Equals(destino.data)){
			                
			                auxiliar_arista.nextEdge = ayudante_arista.nextEdge;
			                ayudante_arista = null;
			                break;
			            }
			    		
			            auxiliar_arista = ayudante_arista;
			            ayudante_arista = ayudante_arista.nextEdge;
			            NumberEdges--;
			        }
			       
			    }
			    
			}
		}
		
		public void Delete_Node(T element){
			var Node = Get_Node(element);
			var auxiliar = startNode;
		    
		    GraphEdge<T> helper;
		
			//delete edges
		    while(auxiliar != null){
		
		        helper = auxiliar.adyacentEdge;
		        while(helper != null){
		
		        	if(helper.adyacentNode.data.Equals(Node.data)){
		        		Delete_Edge(auxiliar.data,helper.adyacentNode.data);
		        		Delete_Edge(helper.adyacentNode.data,auxiliar.data);
		                break;
		            }
		            helper = helper.nextEdge;
		        }
		
		        auxiliar = auxiliar.nextNode;
		    }
		
		    auxiliar = startNode;
		
		    if(startNode.data.Equals(Node.data)){
		        startNode = startNode.nextNode;
		        auxiliar = null;
		        numberNodes--;
		    }
		
		    else{
		    	GraphNode<T> auxiliar1 = null;
		    	
		    	while(auxiliar.data.Equals(Node.data)){
		            auxiliar1 = auxiliar;
		            auxiliar = auxiliar.nextNode;
		        }
		
		        auxiliar1.nextNode = auxiliar.nextNode;
		
		        auxiliar = null;
		        numberNodes--;
		    }

		}
		
		public int[,] Matrix(){
			int tam = Size_Nodes();
			var matriz = new int[tam,tam];
			int i = 0;
			
			for(int m = 0; m < tam; m++){
				for(int n = 0; n < tam;n++){
					matriz[m,n] = 0;
				}
			}
						
			var ayudante_vertice = startNode;
		
		    while(ayudante_vertice != null){
		        
		        var ayudante_arista = ayudante_vertice.adyacentEdge;
		        
		        if(ayudante_arista != null){
		        	

		        	 while(ayudante_arista != null){
		        		int valu = Get_Position(ayudante_arista.adyacentNode);
		        		
		        		if(valu != -1){
			        		matriz[i,valu] = 1;
			        		matriz[valu,i] = 1;
			        	}
		        		
			            ayudante_arista = ayudante_arista.nextEdge;
		        	}
		        }

		        ayudante_vertice = ayudante_vertice.nextNode;
		        i++;
		        
		    }
		    
		    return matriz;
		}
		
		public void Modify_Node(T value, T mod)
		{
			var Node = Get_Node(mod);
			var ayudante = startNode;
		
		    while(ayudante != null){
				if(ayudante.data.Equals(Node.data)) {
					ayudante.data = value;
		            break;
		        }
		        ayudante = ayudante.nextNode;
		    }
		
		}
		
		public void Modify_Edge(T origin, T destination, float weight)
		{
			 var origen = Get_Node(origin);
			 var destino = Get_Node(destination);
			 
		     var ayudante_arista = origen.adyacentEdge;
		     var auxiliar_arista = destino.adyacentEdge;
	
		
		     if(ayudante_arista.adyacentNode.data.Equals(destino.data) 
		        && auxiliar_arista.adyacentNode.data.Equals(origen.data)){
		     	origen.adyacentEdge.weight = weight;
		         destino.adyacentEdge.weight = weight;
		     }
		     else{
		
		         while(ayudante_arista != null){
		
		     		if(ayudante_arista.adyacentNode.data.Equals(destino.data)){
		                 ayudante_arista.weight = weight;
		                 break;
		     		}
		
		             ayudante_arista = ayudante_arista.nextEdge;
		
		         }
		
		         while(auxiliar_arista != null){
		     		if(auxiliar_arista.adyacentNode.data.Equals(origen.data)){
		                 auxiliar_arista.weight = weight;
		                 break;
		     		}
		             auxiliar_arista = auxiliar_arista.nextEdge;
		         }
		
		     }
		
		}
		
		public GraphNode<T> this[int index]{
			get {return this.Get_Node(index);}
		}
		
		public GraphEdge<T> this[int row, int column]{
			get {
				var auxiliar = this[row];
				
				return auxiliar.Edges()[column%auxiliar.Size_Edges()];
			}
		}
		
		//ALGORITHMS:
		
		//Recorrido en profundidad:
		public List<T> Depth_Travel(T value){
			var returnList = new List<T>();
			var Node_Stack = new Stack<GraphNode<T>>();
		    var visitedList = new List<T>();
		
		    Node_Stack.Push(Get_Node(value));
	
		    while(Node_Stack.Count != 0){
		        var actual = Node_Stack.Peek(); 
		        Node_Stack.Pop();
		
		        if(!visitedList.Contains(actual.data)){
		        	returnList.Add(actual.data);
		        	visitedList.Add(actual.data);
		
		            var auxiliar = actual.adyacentEdge;
		
		            while(auxiliar != null){
		              
		            	if(!visitedList.Contains(auxiliar.adyacentNode.data)){
		            		Node_Stack.Push(auxiliar.adyacentNode);
		            	}
		
		                auxiliar = auxiliar.nextEdge;
		            }
		
		        }//END NO Visited
		
		    }//END Stack EMPTY

      		visitedList.Clear();
			
			return returnList;
		}
			
		//Recorrido De Anchura:
		public List<T> Width_Travel(T value){
			
			var returnList = new List<T>();
			var Node_Queue = new Queue<GraphNode<T>>();
		    var visitedList = new List<T>();
		
		    Node_Queue.Enqueue(Get_Node(value));
	
		    while(Node_Queue.Count != 0){
		         
		         var actual = Node_Queue.Peek(); Node_Queue.Dequeue();

		         if(!visitedList.Contains(actual.data)){
		         	
		         	returnList.Add(actual.data);
		         	visitedList.Add(actual.data);
		
		            var auxiliar = actual.adyacentEdge;
		
		            while(auxiliar != null){
		               
		            	if(!visitedList.Contains(auxiliar.adyacentNode.data)){
		            		Node_Queue.Enqueue(auxiliar.adyacentNode);
		            	}
		
		                auxiliar = auxiliar.nextEdge;
		            }
		
		        }//END NO VISITADO
		
		    }//END COLA EMPTY
		
		    visitedList.Clear();
		    
		    return returnList;
		}
		
		//Ruta De Anchura:
		public List<T> Width_Path(T value1, T value2){
		
			var Node_Queue = new Queue<GraphNode<T>>();
			var returnList = new List<T>();
			var Node_Double_Stack = new Double_Stack<GraphNode<T>,GraphNode<T>>();
		    var visitedList = new List<T>();
		    var Destination = Get_Node(value2);
		
		    Node_Queue.Enqueue(Get_Node(value1));
		
		    while(Node_Queue.Count != 0){
		         var actual = Node_Queue.Peek();
		         Node_Queue.Dequeue();
		
		         if(!visitedList.Contains(actual.data)){
		
		         	if(actual.data.Equals(Destination.data)){
		
		               var  actual_Destination = Destination;
		
		                while(!Node_Double_Stack.Empty()){
		                	returnList.Add(actual_Destination.data);
		                	while(!Node_Double_Stack.Empty() 
		                	      && !Node_Double_Stack.Peek().secondData.data.Equals(actual_Destination.data)){
		                        
		                		Node_Double_Stack.Pop();
		                    }
		                	if(!Node_Double_Stack.Empty()){
		                		actual_Destination = Node_Double_Stack.Peek().firstData;
		                    }
		                }
		
		                break;
		            }
		
		         	visitedList.Add(actual.data);
		
		            var auxiliar = actual.adyacentEdge;
		
		            while(auxiliar != null){

		                if(!visitedList.Contains(auxiliar.adyacentNode.data)) {
		                    Node_Queue.Enqueue(auxiliar.adyacentNode);
		                    Node_Double_Stack.Push(actual,auxiliar.adyacentNode);
		                }
		
		                auxiliar = auxiliar.nextEdge;
		            }
		
		        }//END NO VISITADO
		
		    }//END COLA EMPTY
		
		    visitedList.Clear();
		    
		    returnList.Reverse();
		    
		    return returnList;
		}
		
		//Ruta Profundidad
		public List<T> Depth_Path(T value1, T value2)
		{
			var returnList = new List<T>();
			var Node_Stack = new Stack<GraphNode<T>>();
			var Node_DoubleStack = new Double_Stack<GraphNode<T>,GraphNode<T>>();
		    var visitedList = new List<T>();
		    var Destination = Get_Node(value2);
		
		    Node_Stack.Push(Get_Node(value1));
		
		    while(Node_Stack.Count != 0){
		         var actual = Node_Stack.Peek(); 
		         Node_Stack.Pop();
		
		         if(!visitedList.Contains(actual.data)){
		
		         	if(actual.data.Equals(Destination.data)){
		         		var actual_Destination = Destination;
		
		         		while(!Node_DoubleStack.Empty()){
		         			returnList.Add(actual_Destination.data);
		                    
		         			while(!Node_DoubleStack.Empty() 
		         			      && !Node_DoubleStack.Peek().secondData.data.Equals(actual_Destination.data)){
		                		
		         				Node_DoubleStack.Pop();
		                    }
		         			if(!Node_DoubleStack.Empty()){
		         				actual_Destination = Node_DoubleStack.Peek().firstData;
		                    }
		                }
		
		                break;
		            }
		
		         	visitedList.Add(actual.data);
		            var ayudante = actual.adyacentEdge;
		
		            while(ayudante != null){
		            
		            	if(!visitedList.Contains(ayudante.adyacentNode.data)) {
		                    Node_Stack.Push(ayudante.adyacentNode);
		                    Node_DoubleStack.Push(actual,ayudante.adyacentNode);
		                    
		                }
		
		                ayudante = ayudante.nextEdge;
		
		            }
		
		        }//END NO VISITADO
		
		    }//END COLA EMPTY
		
		    visitedList.Clear();
		    returnList.Reverse();
		    return returnList;
		}
		
		//Ruta Profundidad Total
		public List<T> Depth_Travel_Total(T value, T end){
			var returnList = new List<T>();
			
			var recorridoProfundidad = this.Depth_Travel(value);
			var llegueAlDestino = false;
			
			for(int i = 0; i < recorridoProfundidad.Count-1;i++){
				var rutaProfundidad = this.Depth_Path(recorridoProfundidad[i],recorridoProfundidad[i+1]);
				for(int j = 0; j < rutaProfundidad.Count;j++){
					returnList.Add(rutaProfundidad[j]);
					if(rutaProfundidad[j].Equals(end)){
						llegueAlDestino = true;
						break;
					}
				}
				
				if(llegueAlDestino)
					break;
			}
			return returnList;
		}

		
		//Ruta Anchura Total
		public List<T> Width_Travel_Total(T value, T end){
			var returnList = new List<T>();
			
			var recorridoAnchura = this.Width_Travel(value);
			var llegueAlDestino = false;
			
			for(int i = 0; i < recorridoAnchura.Count-1;i++){
				var rutaAnchura = this.Width_Path(recorridoAnchura[i],recorridoAnchura[i+1]);
				for(int j = 0; j < rutaAnchura.Count;j++){
					returnList.Add(rutaAnchura[j]);
					if(rutaAnchura[j].Equals(end)){
						llegueAlDestino = true;
						break;
					}
				}
				
				if(llegueAlDestino)
					break;
			}
			return returnList;
		}
		
		//Obtiene un arbol dependiendo de un valor del grafo
		public Tree<T> Get_Tree(T value){
			
			if(Empty()) throw new Exception("EMPTY GRAPH");
			else{
				var auxiliar = Get_Node(value).data; 

				var auxQueue_Tree_Nodes = new Queue<Tree_Node<T>>();
	
				var newTree = new Tree<T>(new Tree_Node<T>(null,value));
				auxQueue_Tree_Nodes.Enqueue(newTree.Root);
				
				while(auxQueue_Tree_Nodes.Count != 0){
						
					auxiliar = auxQueue_Tree_Nodes.Peek().data;
					var auxEdge = Get_Node(auxiliar).adyacentEdge;
					
					while(auxEdge != null){
						
						if(!auxQueue_Tree_Nodes.Peek().Get_Value_Fathers().Contains(auxEdge.adyacentNode.data)){
							var newTree_Node = new Tree_Node<T>(auxQueue_Tree_Nodes.Peek(),auxEdge.adyacentNode.data);
							auxQueue_Tree_Nodes.Peek().Add_Son(newTree_Node);
							auxQueue_Tree_Nodes.Enqueue(newTree_Node);
						}
						
						auxEdge = auxEdge.nextEdge;
					}
					
					auxQueue_Tree_Nodes.Dequeue();
					
				}
	
				return newTree;
			}
			
		}
		
		List<Foursome<GraphNode<T>,double,GraphNode<T>,bool>> inicializaVectorPesos(T origen){
			var returnList = new List<Foursome<GraphNode<T>,double,GraphNode<T>,bool>>();
			
			var auxiliar = this.startNode;
			while(auxiliar != null){
				if(auxiliar.data.Equals(origen))
					returnList.Add(new Foursome<GraphNode<T>,double,GraphNode<T>,bool>(auxiliar,0,auxiliar,false));
				else
					returnList.Add(new Foursome<GraphNode<T>,double,GraphNode<T>,bool>(auxiliar,double.PositiveInfinity,null,false));
				
				auxiliar = auxiliar.nextNode;
			}
			
			return returnList;
		}
		
		List<Foursome<GraphNode<T>,double,GraphNode<T>,bool>> inicializaVectorPesos(GraphNode<T> origen){
			var returnList = new List<Foursome<GraphNode<T>,double,GraphNode<T>,bool>>();
			
			var auxiliar = this.startNode;
			while(auxiliar != null){
				if(auxiliar.data.Equals(origen.data))
					returnList.Add(new Foursome<GraphNode<T>,double,GraphNode<T>,bool>(auxiliar,0,auxiliar,false));
				else
					returnList.Add(new Foursome<GraphNode<T>,double,GraphNode<T>,bool>(auxiliar,double.PositiveInfinity,null,false));
				
				auxiliar = auxiliar.nextNode;
			}
			
			return returnList;
		}
		
		void VDP(ref List<Foursome<GraphNode<T>,double,GraphNode<T>,bool>> lista, T origen){
			
			var auxiliar = this.startNode;
			while(auxiliar != null){
				if(auxiliar.data.Equals(origen))
					lista.Add(new Foursome<GraphNode<T>,double,GraphNode<T>,bool>(auxiliar,0,auxiliar,false));
				else
					lista.Add(new Foursome<GraphNode<T>,double,GraphNode<T>,bool>(auxiliar,double.PositiveInfinity,null,false));
				
				auxiliar = auxiliar.nextNode;
			}
			
		}
		
		
		public List<GraphNode<T>> Dijkstra_Way(T origen, T destino){
			var returnList = new List<GraphNode<T>>();
			returnList.Clear();
			//Inicialización
			var vectorDePesos = new List<Foursome<GraphNode<T>,double,GraphNode<T>,bool>>();
			VDP(ref vectorDePesos, origen);
			
			//firstData -> Nodo del vertice de pesos
			// secondData -> costo
			// thirdData -> Nodo predecesor o precedente
			// fourthData -> Definitivo

			for(int i = 0; i < Size_Nodes();i++){
				
				//Selección:
				//Obtener el valor mínimo de costo que no sea definitivo
				int indexOfMinimun = GetMinimunFromList(vectorDePesos);
				
				if(indexOfMinimun == -1)
					break;
				//marcar como definitivo:
				vectorDePesos[indexOfMinimun].fourthData = true;
				
				//Actualizar:
				//obtener las aristas del nodo inicial de la lista en tal posicion:
				var listaAristas = vectorDePesos[indexOfMinimun].firstData.Edges();
				
				for(int j = 0; j < listaAristas.Count;j++){
					ModifyList(ref vectorDePesos,listaAristas[j],vectorDePesos[indexOfMinimun].firstData);
				}	
			}
			
			//obtener camino y costo total:
			var Origen = Get_Node(origen);
			var Destino = Get_Node(destino);
			bool hayCamino = true;
			
			for(int j = 0; j < vectorDePesos.Count;j++){

				if(Destino == null){
					hayCamino = false;
					break;
				}
				
				if(Origen.data.Equals(Destino.data))
					break;
					
				for(int i = 0; i < vectorDePesos.Count;i++){	
					//buscar el nodo del vertice de pesos:
					if(Destino.data.Equals(vectorDePesos[i].firstData.data)){
						returnList.Add(Destino);
						Destino = vectorDePesos[i].thirdData;
						break;
					}
				}
			}
			
			if(hayCamino)
				returnList.Reverse();
			else
				returnList.Clear();
			

			return returnList;

		}

	
		public Pair<List<T>,double> Dijkstra_Path(T origen, T destino){
			var returnList = new List<T>();
			double costo = 0;
			
			//Inicialización
			var vectorDePesos = inicializaVectorPesos(origen);
			
			//firstData -> Nodo del vertice de pesos
			// secondData -> costo
			// thirdData -> Nodo predecesor o precedente
			// fourthData -> Definitivo

			for(int i = 0; i < Size_Nodes();i++){
				
				//Selección:
				//Obtener el valor mínimo de costo que no sea definitivo
				int indexOfMinimun = GetMinimunFromList(vectorDePesos);
				
				if(indexOfMinimun == -1)
					break;
				//marcar como definitivo:
				vectorDePesos[indexOfMinimun].fourthData = true;
				
				//Actualizar:
				//obtener las aristas del nodo inicial de la lista en tal posicion:
				var listaAristas = vectorDePesos[indexOfMinimun].firstData.Edges();
				
				for(int j = 0; j < listaAristas.Count;j++){
					ModifyList(ref vectorDePesos,listaAristas[j],vectorDePesos[indexOfMinimun].firstData);
				}	
			}
			
			//obtener camino y costo total:
			var Origen = Get_Node(origen);
			var Destino = Get_Node(destino);
			bool hayCamino = true;
			
			for(int j = 0; j < vectorDePesos.Count;j++){

				if(Destino == null){
					hayCamino = false;
					break;
				}
				
				
				if(Origen.data.Equals(Destino.data)){
					break;
				}
					
				
				for(int i = 0; i < vectorDePesos.Count;i++){	
					//buscar el nodo del vertice de pesos:
					if(Destino.data.Equals(vectorDePesos[i].firstData.data)){
						returnList.Add(Destino.data);
						Destino = vectorDePesos[i].thirdData;
						break;
					}
				}
			}
			
			for(int i = 0; i < vectorDePesos.Count;i++){
				if(vectorDePesos[i].firstData.data.Equals(destino)){
					costo = vectorDePesos[i].secondData;
					break;
				}
			}
			
			if(hayCamino){
				returnList.Add(origen);
				returnList.Reverse();
			}
			else{
				returnList.Clear();
				costo = graphWeight;
			}
			return new Pair<List<T>, double>(returnList,costo);

		}

	
		
		double GetCost(IList<Foursome<GraphNode<T>, double, GraphNode<T>, bool>> list,GraphNode<T> nodoSeleccion){
			
			for(int i = 0; i < list.Count;i++){
				if(list[i].firstData.data.Equals(nodoSeleccion.data))
					return list[i].secondData;
			}
			
			return 0;
			
		}
		
		void ModifyList(ref List<Foursome<GraphNode<T>,double,GraphNode<T>,bool>> list, GraphEdge<T> arista, GraphNode<T> nodoSeleccion){
			for(int i = 0; i < list.Count;i++){
				
				//si la arista en su campo nodo adyacente es igual al nodo del vertice del peso y si no es definitivo:
				if(list[i].firstData.data.Equals(arista.adyacentNode.data)){
					if(!list[i].fourthData){
						double nuevoCosto = arista.weight + GetCost(list,nodoSeleccion);
						if(list[i].secondData > nuevoCosto){
							list[i].secondData = nuevoCosto;
							list[i].thirdData = nodoSeleccion;
						}
					}
					break;
				}

			}
			
		}

		int GetMinimunFromList(IList<Foursome<GraphNode<T>, double, GraphNode<T>, bool>> list){
			double minimun = graphWeight;
			int pos = -1;
			for(int i = 0; i < list.Count;i++){
				var valueList = list[i];
				//si el valor no es definitivo, y el costo es menor al mínimo hasta el momento:
				if(!valueList.fourthData && valueList.secondData < minimun){
					minimun = valueList.secondData;
					pos = i;
				}
			}
			
			return pos;

		}

		public Pair<List<T>,double> Best_First_Search(T origen, T destino){
			var returnList = new List<T>();
			double costoActual = 0;
			GraphNode<T> verticeActual;
			bool hayCamino = false;
			var ListaDeCostos = new List<Pair<GraphNode<T>,double>>();
			var ListaOrdenada = new List<Pair<GraphNode<T>,double>>();
			var pila = new Stack<Pair<GraphNode<T>,GraphNode<T>>>();
			var Origin = Get_Node(origen);
			var Destination = Get_Node(destino);
			
			ListaDeCostos.Add(new Pair<GraphNode<T>, double>(Origin,0));
			ListaOrdenada.Add(new Pair<GraphNode<T>, double>(Origin,0));
			
			while(ListaOrdenada.Count != 0){
				verticeActual = ListaOrdenada.First().firstData;
				costoActual = ListaOrdenada.First().secondData;
				ListaOrdenada.RemoveAt(0);
				
				if(verticeActual.data.Equals(Destination.data)){
					hayCamino = true;
				   	var actualDestination = Destination;
				   	
				   	while(pila.Count != 0){
				   		returnList.Add(actualDestination.data);
				   		while(pila.Count != 0 && !pila.Peek().secondData.data.Equals(actualDestination.data))
				   			pila.Pop();
				   		
				   		if(pila.Count != 0){
				   			actualDestination = pila.Peek().firstData;
				   		}
				   		
				   	}
				   	
				   	break;
				}
				
				var auxiliarArista = verticeActual.adyacentEdge;
				
				while(auxiliarArista != null){
					costoActual+=auxiliarArista.weight;
					bool existe = false;
					for(int i = 0; i < ListaDeCostos.Count;i++){
						if(ListaDeCostos[i].firstData.data.Equals(auxiliarArista.adyacentNode.data)){
							
							existe = true;
							
							if(costoActual < ListaDeCostos[i].secondData){
								ListaDeCostos[i].secondData = costoActual;
								
								for(int j = 0; j < ListaOrdenada.Count;j++){
									if(ListaOrdenada[j].firstData.data.Equals(ListaDeCostos[i].firstData.data)){
										ListaOrdenada[j].secondData = costoActual;
										break;
									}
								}
								ListaOrdenada = ListaOrdenada.OrderBy(x => x.secondData).ToList();
								pila.Push(new Pair<GraphNode<T>, GraphNode<T>>(verticeActual,auxiliarArista.adyacentNode));
								costoActual -= auxiliarArista.weight;
							}

							break;
						}
					}
					
					//No existe en la lista de costos
					if(!existe){
						ListaDeCostos.Add(new Pair<GraphNode<T>, double>(auxiliarArista.adyacentNode,costoActual));
						ListaOrdenada.Add(new Pair<GraphNode<T>, double>(auxiliarArista.adyacentNode,costoActual));
						
						//ORDENAR:
						ListaOrdenada = ListaOrdenada.OrderBy(x => x.secondData).ToList();
						pila.Push(new Pair<GraphNode<T>, GraphNode<T>>(verticeActual,auxiliarArista.adyacentNode));
						
						costoActual -= auxiliarArista.weight;
					}

					auxiliarArista = auxiliarArista.nextEdge;
				}
				
				
			}
			
			if(!hayCamino)
				costoActual = graphWeight;
			
			returnList.Reverse();
			
			return new Pair<List<T>, double>(returnList,costoActual);
		}
		
		public static List<Pair<GraphNode<T>,double>> Sort(List<Pair<GraphNode<T>,double>> list){
			
			for(int i = 0; i < list.Count;i++){
				var min = i;
				for(int j = i+1;j < list.Count;j++){
					if(list[j].secondData < list[min].secondData){
						min = j;
					}
				}
				
				//intercambio
				
				var intercambio = list[i];
       			list[i] = list[min];
        		list[min] = intercambio;
				
			}
			
			return list;

		}
		
		public static Double_List<GraphNode<T>,double> Sort(Double_List<GraphNode<T>,double> list){
			
			var newList = new Double_List<GraphNode<T>,double>();
			for(int i = 0;i < list.Size();i++){
				var min = i;
				for(int j = i+1;j < list.Size();j++){
					if(list[j].secondData < list[min].secondData){
						min = j;
					}
				}
				
				newList.Push_Back(list[min]);
			}
		
			
			return newList;

		}
		
		public List<T> Dijkstra(T value1, T value2){
			var newList = new List<T>();
			var newTree = Get_Tree(value1);
			var leafsList = newTree.Get_Node_Leafs();
			var list = new List<double>();
			var Destination = Get_Node(value2);
			
			for(int i = 0; i < leafsList.Count;i++){
				var cost = 0.0;
				var getList = newTree.Get_SubList(leafsList[i],Destination.data);
				for(int j = 0; j < getList.Count;j++){
					cost+= Get_Node(getList[i].data).adyacentEdge.weight;
				}
				list.Add(cost);
			
			}
			
			
			var lista = newTree.Get_SubList(leafsList[Minumum(list)],Destination.data);
			for(int i = 0; i < lista.Count;i++){
				newList.Add(lista[i].data);
			}
			
			return newList;
		}
		
		public static int Minumum(List<double> lista){
			var num = 0;
			for(int i = 0;i < lista.Count;i++){
				for(int j = 0;j < lista.Count;j++){
					if(lista[j] < lista[i]){
						num = j;
					}
				}	
			}
			return num;
		}
		
		public List<string> IDList(){
			var returnList = new List<string>();
			var aux = this.startNode;
			while(aux != null){
				returnList.Add("{"+aux.data+"}");
				aux = aux.nextNode;
			}
			return returnList;
		}
		
		Triplet<T,double,T> CheapestEdge(double previousWeight){
			var tripleta = new Triplet<T,double,T>(startNode.data,0.0,startNode.data);
			double menor = 999999999;
			var auxiliarNodos = startNode;
			
			while(auxiliarNodos != null){
				var auxiliarAristas = auxiliarNodos.adyacentEdge;
				while(auxiliarAristas != null){
					if(auxiliarAristas.weight < menor
					  && auxiliarAristas.weight > previousWeight){
						menor = auxiliarAristas.weight;
						tripleta.firstData = auxiliarNodos.data;
						tripleta.secondData = auxiliarAristas.weight;
						tripleta.thirdData = auxiliarAristas.adyacentNode.data;
					}
					auxiliarAristas = auxiliarAristas.nextEdge;
				}
				auxiliarNodos = auxiliarNodos.nextNode;
			}
			return tripleta;
		}
		
		List<Triplet<T,double,T>> GetEdgesList(){
			var returnList = new List<Triplet<T,double,T>>();
			var auxiliarNodos = startNode;
			
			while(auxiliarNodos != null){
				var auxiliarAristas = auxiliarNodos.adyacentEdge;
				while(auxiliarAristas != null){
					returnList.Add(new Triplet<T, double, T>(auxiliarNodos.data,auxiliarAristas.weight,auxiliarAristas.adyacentNode.data));
					auxiliarAristas = auxiliarAristas.nextEdge;
				}
				auxiliarNodos = auxiliarNodos.nextNode;
			}
			
			//ordenar lista:
			
			for(int i = 0;i < returnList.Count;i++){
				var min = i;
				for(int j = i+1;j < returnList.Count;j++){
					if(returnList[j].secondData < returnList[min].secondData){
						min = j;
					}
				}
				
				//intercambio:
				var intercambio = returnList[i];
		        returnList[i] = returnList[min];
		        returnList[min] = intercambio;
				
			}

			
			return returnList;
		}
		
		bool Cycle(IList<string> myList, T value1, T value2){
			for(int i = 0; i < myList.Count;i++){
				var listaAuxiliar = GetIDs(myList[i]);
				if(listaAuxiliar.Contains(value1.ToString()) &&
				   listaAuxiliar.Contains(value2.ToString()))
				   return true;
			}
			
			return false;
		}
		

		List<string> GetIDs(string value){
			var returnList = new List<string>();
			var cadenaAuxiliar = "";
			for(int i = 1; i < value.Length-1;i++){
				if(value[i].ToString() == ","){
					returnList.Add(cadenaAuxiliar);
					cadenaAuxiliar = "";
				}else{
					cadenaAuxiliar+=value[i].ToString();
				}
			}

			returnList.Add(cadenaAuxiliar);
			
			return returnList;
		}
		
		//ruta de kruskal:
		public int NumeroDeBosques(){
			var componentesConexos = IDList();
			var listaAristas = new List<Triplet<T,double,T>>(edgesValues);
			listaAristas = listaAristas.OrderBy(z => z.secondData).ToList();
			double minimun = 0;
			foreach (var tripleta in listaAristas) {
				if (!Cycle(componentesConexos, tripleta.firstData, tripleta.thirdData)) {
					
					//buscar el valor que tenga la primera posicion:
					int primeraPosicion = GetPosicion(componentesConexos, tripleta.firstData);
					int segundaPosicion = GetPosicion(componentesConexos, tripleta.thirdData);
					var listaAuxilar = GetIDs(componentesConexos[segundaPosicion]);
					//Fusionar:
					var cadenaAuxiliar = componentesConexos[primeraPosicion];
					cadenaAuxiliar = cadenaAuxiliar.Substring(0, cadenaAuxiliar.Length - 1);
					cadenaAuxiliar += ",";
					for (int i = 0; i < listaAuxilar.Count; i++) {
						if (i == listaAuxilar.Count - 1) {
							cadenaAuxiliar += listaAuxilar[i] + "}";
						} else {
							cadenaAuxiliar += listaAuxilar[i] + ",";
						}
					}
					componentesConexos[primeraPosicion] = cadenaAuxiliar;
					componentesConexos[segundaPosicion] = "";
				}
				//end no cicla
				minimun = tripleta.secondData;
			}
			
			int numBosques = 0;
			for(int i = 0; i < componentesConexos.Count;i++){
				if(componentesConexos[i].Length > 0)
					numBosques++;
			
			}
			
			componentesConexos.Clear();
			
			return numBosques;
		}
		
		
		public Pair<List<Triplet<T,double,T>>,int> KruskalFullList(){
			var returnList = new List<Triplet<T,double,T>>();
			var componentesConexos = IDList();
			var listaAristas = new List<Triplet<T,double,T>>(edgesValues);
			listaAristas = listaAristas.OrderBy(z => z.secondData).ToList();
			double minimun = 0;
			foreach (var tripleta in listaAristas) {
				if (!Cycle(componentesConexos, tripleta.firstData, tripleta.thirdData)) {
					returnList.Add(tripleta);
					//buscar el valor que tenga la primera posicion:
					int primeraPosicion = GetPosicion(componentesConexos, tripleta.firstData);
					int segundaPosicion = GetPosicion(componentesConexos, tripleta.thirdData);
					var listaAuxilar = GetIDs(componentesConexos[segundaPosicion]);
					//Fusionar:
					var cadenaAuxiliar = componentesConexos[primeraPosicion];
					cadenaAuxiliar = cadenaAuxiliar.Substring(0, cadenaAuxiliar.Length - 1);
					cadenaAuxiliar += ",";
					for (int i = 0; i < listaAuxilar.Count; i++) {
						if (i == listaAuxilar.Count - 1) {
							cadenaAuxiliar += listaAuxilar[i] + "}";
						} else {
							cadenaAuxiliar += listaAuxilar[i] + ",";
						}
					}
					componentesConexos[primeraPosicion] = cadenaAuxiliar;
					componentesConexos[segundaPosicion] = "";
				}
				//end no cicla
				minimun = tripleta.secondData;
			}
			
			int numBosques = 0;
			for(int i = 0; i < componentesConexos.Count;i++){
				if(componentesConexos[i].Length > 0)
					numBosques++;
			
			}
			
			componentesConexos.Clear();

			return new Pair<List<Triplet<T, double, T>>, int>(returnList,numBosques);
			
		}
		
		public List<Triplet<T,double,T>> CandidatosPrim(T valueNodo, List<Triplet<T,double,T>> otherList){
			var returnList = new List<Triplet<T,double,T>>();
			
			var nodo = Get_Node(valueNodo);
			var auxiliar = nodo.adyacentEdge;
			while(auxiliar != null){
				var triplet = new Triplet<T,double,T>(nodo.data,auxiliar.weight,auxiliar.adyacentNode.data);
				var seAgrega = true;
				for(int i = 0; i < otherList.Count;i++){
					if(triplet.Is_Equal(otherList[i]) || (triplet.firstData.Equals(otherList[i].thirdData) &&
                      triplet.secondData.Equals(otherList[i].secondData) && triplet.thirdData.Equals(otherList[i].firstData))){
						seAgrega = false;
						break;
					}
				}
				
				if(seAgrega)
					returnList.Add(triplet);
				
				auxiliar = auxiliar.nextEdge;
			}
			
			return returnList;
		}	

		public List<Triplet<T,double,T>> CandidatosPrim(T valueNodo){
			var returnList = new List<Triplet<T,double,T>>();
			var nodo = Get_Node(valueNodo);
			var auxiliar = nodo.adyacentEdge;
			while(auxiliar != null){
				var triplet = new Triplet<T,double,T>(nodo.data,auxiliar.weight,auxiliar.adyacentNode.data);
				
					returnList.Add(triplet);
				
				auxiliar = auxiliar.nextEdge;
			}
			
			return returnList;
		}		

		//ruta de prim:
		public List<Triplet<T,double,T>> PrimFullList(T valueInicial){
			var returnList = new List<Triplet<T,double,T>>();
			//candidatos:
			var listaCandidatos = CandidatosPrim(valueInicial);
			var other = new List<Triplet<T, double, T>>();
//			other = other.OrderBy(x => x.secondData).ToList();
			//ordenar: 
			listaCandidatos = listaCandidatos.OrderBy(z => z.secondData).ToList();
//			
//			for(int j = 0; j < listaCandidatos.Count;j++){
//				MessageBox.Show(listaCandidatos[j].ToString(),"LISTA DE CANDIDATOS INICIAL");
//			}
			var S = new List<T>();
			S.Add(valueInicial);
			
			
			for(int i = 0; i < Size_Edges();i++){
				
				if(S.Contains(listaCandidatos.First().firstData) || S.Contains((listaCandidatos.First().thirdData))){
					var tripleta = listaCandidatos.First(); //seleccion;
					other.Add(tripleta);
					//eliminar la arista:
					listaCandidatos.RemoveAt(0);
					if(listaCandidatos.Count == 0 && i > 0){//LISTA VACIA
	//					listaCandidatos.Add(other.First());
	//					other.RemoveAt(0);
						for(int j = 0; j < edgesValues.Count;j++){
							var loContiene = false;
							for(int k = 0; k < other.Count;k++){
								if(edgesValues[j].Is_Equal(other[k])){
									loContiene = true;
									break;
								}
							}
							
							if(!loContiene){
								listaCandidatos.Add(edgesValues[j]);
								break;
							}
						}
						
					}
					//cicla:
					if(!S.Contains(tripleta.thirdData)){//no cicla
						returnList.Add(tripleta);
						//agregar la arista a S:
						S.Add(tripleta.thirdData);
						S.Add(tripleta.firstData);
						
						//agregar las aristas a los candidatos de la nueva arista que no existan
						var listaAuxiliar = CandidatosPrim(tripleta.thirdData,other);
	//					for(int j = 0; j < listaAuxiliar.Count;j++){
	//						MessageBox.Show(listaAuxiliar[j].ToString(),"listaAuxiliar de: "+tripleta.thirdData);
	//					}
						
						for(int j = 0; j < listaAuxiliar.Count;j++)
							listaCandidatos.Add(listaAuxiliar[j]);
						
						listaCandidatos = listaCandidatos.OrderBy(z => z.secondData).ToList();
						
	//					for(int j = 0; j < listaCandidatos.Count;j++){
	//						MessageBox.Show(listaCandidatos[j].ToString(),"LISTA listaCandidatos si no coneite"+tripleta.thirdData);
	//					}
						
					}
				}
				else{
					int pos = 0;
					while(true){
						if(S.Contains(listaCandidatos[pos].firstData) || S.Contains((listaCandidatos[pos].thirdData)))
							break;
						pos++;
					}
					
					
					var tripleta = listaCandidatos[pos]; //seleccion;
					other.Add(tripleta);
					//eliminar la arista:
					listaCandidatos.RemoveAt(pos);
					if(listaCandidatos.Count == 0 && i > 0){//LISTA VACIA
	//					listaCandidatos.Add(other.First());
	//					other.RemoveAt(0);
						for(int j = 0; j < edgesValues.Count;j++){
							var loContiene = false;
							for(int k = 0; k < other.Count;k++){
								if(edgesValues[j].Is_Equal(other[k])){
									loContiene = true;
									break;
								}
							}
							
							if(!loContiene){
								listaCandidatos.Add(edgesValues[j]);
								break;
							}
						}
						
					}
					//cicla:
					if(!S.Contains(tripleta.thirdData)){//no cicla
						returnList.Add(tripleta);
						//agregar la arista a S:
						S.Add(tripleta.thirdData);
						S.Add(tripleta.firstData);
						
						//agregar las aristas a los candidatos de la nueva arista que no existan
						var listaAuxiliar = CandidatosPrim(tripleta.thirdData,other);
	//					for(int j = 0; j < listaAuxiliar.Count;j++){
	//						MessageBox.Show(listaAuxiliar[j].ToString(),"listaAuxiliar de: "+tripleta.thirdData);
	//					}
						
						for(int j = 0; j < listaAuxiliar.Count;j++)
							listaCandidatos.Add(listaAuxiliar[j]);
						
						listaCandidatos = listaCandidatos.OrderBy(z => z.secondData).ToList();
						
	//					for(int j = 0; j < listaCandidatos.Count;j++){
	//						MessageBox.Show(listaCandidatos[j].ToString(),"LISTA listaCandidatos si no coneite"+tripleta.thirdData);
	//					}
						
					}
					
					
				}
				
				
				//MessageBox.Show(tripleta.ToString(),"TRIPLETA");
				//other.Remove(tripleta);
				
				
				
			}
			
			return returnList;
		}
		
		
		int GetPosicion(IList<string> lista, T value){
			
			for(int i = 0; i < lista.Count;i++){
				var listaAuxiliar = GetIDs(lista[i]);
				if(listaAuxiliar.Contains(value.ToString()))
					return i;
			}
			
			return -1;
		}
		
		public static Graph<Circulo> CreateGraph(List<Triplet<Circulo,double,Circulo>> myList){
//			var returnGraph = new Graph<Circulo>();
//		
//			for(int i = 0; i < myList.Count;i++){
//				returnGraph.Insert_Node(myList[i].firstData);
//				returnGraph.Insert_Node(myList[i].thirdData);
//				returnGraph.Insert_Edge(myList[i].secondData,myList[i].firstData,myList[i].thirdData);
//				returnGraph.Insert_Edge(myList[i].secondData,myList[i].thirdData,myList[i].firstData);
//			}
//
//			return returnGraph;
			
			var returnGraph = new Graph<Circulo>();
			
			//ordenar la lista:
			
			myList = myList.OrderBy(x => x.firstData.GetID()).ToList();
			
			//ordenar los que sean iguales en el first data:
			
			for(int i = 0;i < myList.Count;i++){
				var min = i;
				for(int j = i+1;j < myList.Count;j++){
					if(myList[j].firstData == myList[min].firstData
					   && myList[j].thirdData.GetID() < myList[min].thirdData.GetID()){
						min = j;
					}
				}
				
				//intercambio:
				var intercambio = myList[i];
		        myList[i] = myList[min];
		        myList[min] = intercambio;
				
			}
			
			var listaNodos = new List<Circulo>();
			
			for(int i = 0; i < myList.Count;i++){
				if(!listaNodos.Contains(myList[i].thirdData))
					listaNodos.Add(myList[i].thirdData);
				if(!listaNodos.Contains(myList[i].firstData))
					listaNodos.Add(myList[i].firstData);
			}
			
			listaNodos = listaNodos.OrderBy(z=>z.GetID()).ToList();
			
			//insertar nodos:
			for(int i = 0; i < listaNodos.Count;i++){
				returnGraph.Insert_Node(listaNodos[i]);
			}
						
			
			for(int i = 0; i < myList.Count;i++){
				
				returnGraph.Insert_Edge(myList[i].secondData,myList[i].firstData,myList[i].thirdData);
				returnGraph.Insert_Edge(myList[i].secondData,myList[i].thirdData,myList[i].firstData);
			}

			return returnGraph;
			
		}
		

		
	}

	public class Tree_Node<N>
	{
		public Tree_Node<N> Father;
		public List<Tree_Node<N>> Sons;
		public N data;
		
		public Tree_Node(Tree_Node<N> Padre, N Valor)
		{
			this.Father = Padre;
			this.data = Valor;
			this.Sons = new List<Tree_Node<N>>();
		}
		
		public Tree_Node(N Valor)
		{
			this.Father = null;
			this.data = Valor;
			this.Sons = new List<Tree_Node<N>>();
		}
		
		 public void Add_Son(Tree_Node<N> hijo) {
        	Sons.Add(hijo);
    	}
		
		public bool Is_Father() {
			return Sons.Count != 0;
    	}
		
		public bool Is_Leaf(){
			return Sons.Count == 0;
		}
		
		public List<Tree_Node<N>> Get_Fathers(){
			var returnList = new List<Tree_Node<N>>();
			var auxiliar = this;
			while(auxiliar != null){
				returnList.Add(auxiliar);
				auxiliar = auxiliar.Father;
			}
			
			return returnList;
		}
		
		public List<N> Get_Value_Fathers(){
			var returnList = new List<N>();
			var auxiliar = this;
			while(auxiliar != null){
				returnList.Add(auxiliar.data);
				auxiliar = auxiliar.Father;
			}
			
			return returnList;
		}
		
	}
	
	public class Tree<T>
	{

		public Tree_Node<T> Root;
		
		public Tree(Tree_Node<T> element){
			this.Root = element;
		}
		
		public bool Empty(){
			return Root == null;
		}
		
		public List<Tree_Node<T>> Get_Node_Leafs(){
			if(Empty()){
				throw new Exception("EMPTY TREE");
			}
			else{
				var aux_Queue = new Queue<Tree_Node<T>>();
				var leafs = new List<Tree_Node<T>>();
				aux_Queue.Enqueue(Root);
				
				while(aux_Queue.Count != 0){
					var auxiliar = aux_Queue.Peek();
					if(auxiliar.Is_Leaf()){
						leafs.Add(auxiliar);
					}
					else{
						for(int i = 0; i < auxiliar.Sons.Count;i++){
							aux_Queue.Enqueue(auxiliar.Sons[i]);
						}
					}
					aux_Queue.Dequeue();
				}
				
				return leafs;
			}
			
		}
		
		public List<T> Get_Value_Leafs(){
			if(Empty()){
				throw new Exception("EMPTY TREE");
			}
			else{
				var aux_Queue = new Queue<Tree_Node<T>>();
				var leafs = new List<T>();
				aux_Queue.Enqueue(Root);
				
				while(aux_Queue.Count != 0){
					var auxiliar = aux_Queue.Peek();
					if(auxiliar.Is_Leaf()){
						leafs.Add(auxiliar.data);
					}
					else{
						
						for(int i = 0; i < auxiliar.Sons.Count;i++){
							aux_Queue.Enqueue(auxiliar.Sons[i]);
						}
					}
					
					aux_Queue.Dequeue();
					
				}
				
				return leafs;
			}
			
		}
		
		public List<T> Get_All_Values(){
			if(Empty()) throw new Exception("EMPTY TREE");
			
			var returnList = new List<T>();
			var auxQueue = new Queue<Tree_Node<T>>();
			auxQueue.Enqueue(Root);
			while(auxQueue.Count != 0){
				var auxiliar = auxQueue.Peek();
				returnList.Add(auxiliar.data);
				if(!auxiliar.Is_Leaf()){
					for(int i = 0; i < auxiliar.Sons.Count;i++){
						auxQueue.Enqueue(auxiliar.Sons[i]);
					}
				}
				
				auxQueue.Dequeue();
			}
			
			return returnList;
		}

		public List<Tree_Node<T>> Get_All_Nodes(){
			if(Empty()) throw new Exception("EMPTY TREE");
			
			var returnList = new List<Tree_Node<T>>();
			var auxQueue = new Queue<Tree_Node<T>>();
			auxQueue.Enqueue(Root);
			while(auxQueue.Count != 0){
				var auxiliar = auxQueue.Peek();
				returnList.Add(auxiliar);
				if(!auxiliar.Is_Leaf()){
					for(int i = 0; i < auxiliar.Sons.Count;i++){
						auxQueue.Enqueue(auxiliar.Sons[i]);
					}
				}
				
				auxQueue.Dequeue();
			}
			
			return returnList;
		}
		
		public Tree_Node<T> Get_Node(T value){
			if(Empty()) throw new Exception("EMPTY TREE");
			
			for(int i = 0; i < Get_All_Nodes().Count;i++){
				if(Get_All_Nodes()[i].data.Equals(value)) return Get_All_Nodes()[i];
			}
			
			throw new Exception("NODE DOES NOT EXIST");
		}
		
		public bool Contains(T Value){
			return Get_All_Values().Contains(Value);
		}
		
		public List<Tree_Node<T>> Get_SubList(Tree_Node<T> Leaf){
			var returnList = new List<Tree_Node<T>>();
			var auxiliar = Leaf;
			while(auxiliar != null){
				returnList.Add(auxiliar);
				if(auxiliar.data.Equals(Root.data)) break;
				auxiliar = auxiliar.Father;
			}
			
			returnList.Reverse();
			return returnList;
			
		}
		
		public List<Tree_Node<T>> Get_SubList(Tree_Node<T> Leaf, T start){
			var returnList = new List<Tree_Node<T>>();
			var flag = false;
			var auxiliar = Leaf;
			while(auxiliar != null){
				if(auxiliar.data.Equals(start) && !flag) flag = true;

				if(flag) returnList.Add(auxiliar);
				
				if(auxiliar.data.Equals(Root.data)) break;
				
				auxiliar = auxiliar.Father;
			}
			
			returnList.Reverse();
			return returnList;
			
		}
		
		public int Size_Leafs(){
			return Get_Node_Leafs().Count;
		}
		
		public int Size_Nodes(){
			return Get_All_Nodes().Count;
		}
		
	}

	public class Matrix<T>
	{
		public class Row<N>{
			public int index;
			public Row<N> next;
			public Row<N> previous;
			public Column<N> adyacentColumn;
			
			public Row(int indice, Row<N> anterior,Row<N> siguiente,Column<N> columna){
				this.index = indice;
				this.next = siguiente;
				this.previous = anterior;
				this.adyacentColumn = columna;
			}
			
			public Row(int indice){
				this.index = indice;
				this.next = null;
				this.previous = null;
				this.adyacentColumn = null;
			}
			
			public int Size_Columns(){
				var auxiliar = this.adyacentColumn;
				if(adyacentColumn == null) return 0;
				else{
					var counter = 0;
					while(auxiliar != null){
						counter++;
						auxiliar = auxiliar.next;
					}
					return counter;
				}
			}
			
			public bool Empty_Columns(){
				return Size_Columns() == 0;
			}
		}
		
		public class Column<M>{
			public M data;
			public Column<M> next;
			public Column(M dato, Column<M> siguiente){
				this.data = dato;
				this.next = siguiente;
			}
			public Column(M dato){
				this.data = dato;
				this.next = null;
			}

		}
		
		private Row<T> start;
		private Row<T> end;
		private int numRows;
		
		public Matrix()
		{
			start = null;
			end = null;
			numRows = 0;
		}
		
		public bool Empty(){
			return start == null;
		}
		
		public int Size_Rows(){
			return numRows;
		}
		
		public void Add_Row(){
			if(Empty()){
				var newRow = new Row<T>(numRows);
				start = end = newRow;
			}
			else{
				var newRow = new Row<T>(numRows,end,null,null);
				end.next = newRow;
				end = newRow;
			}
			numRows++;
		}

		
		public Row<T> First_Row_Node(){
			if(!Empty()) return start;
			else throw new Exception("EMPTY MATRIX");
		}
		
		public Row<T> Last_Row_Node(){
			if(!Empty()) return end;
			else throw new Exception("EMPTY MATRIX");
		}
		
		public Row<T> Get_Row(int indice){
			indice = indice % Size_Rows();
			if(indice == 0) return First_Row_Node();
			else if (indice == Size_Rows() -1) return Last_Row_Node();
			else{
				var auxiliar = start;
				for(int i = 0; i < indice;i++){
					auxiliar = auxiliar.next;
				}
				return auxiliar;
			}
			
		}
		
		public T Get_Value(int Row_Index, int Column_Index){
			var row = Get_Row(Row_Index);
			if(row.adyacentColumn == null) throw new Exception("INVALID POSITION");
			else{
				var auxiliar = row.adyacentColumn;
				var num_Column = 0;
				while(auxiliar != null){
					if(num_Column == Column_Index) return auxiliar.data;
					num_Column++;
					auxiliar = auxiliar.next;
				}
				throw new Exception("INVALID POSITION");
			}
		}
		
		public Column<T> Get_Column(int Row_Index, int Column_Index){
			var row = Get_Row(Row_Index);
			if(row.adyacentColumn == null) throw new Exception("INVALID POSITION");
			else{
				var auxiliar = row.adyacentColumn;
				var num_Column = 0;
				while(auxiliar != null){
					if(num_Column == Column_Index) return auxiliar;
					num_Column++;
					auxiliar = auxiliar.next;
				}
				throw new Exception("INVALID POSITION");
			}
		}
		
		public void Add_Column(int nRow, T element){
			if(!Exist_Column(nRow,element)){
				var newColumn = new Column<T>(element);
				nRow = nRow % Size_Rows();
				var column = Get_Row(nRow).adyacentColumn;
				if(column == null){
					Get_Row(nRow).adyacentColumn = newColumn;
				}
				else{
					while(column.next != null){
						column = column.next;
					}
					column.next = newColumn;
				}
				
			}
		}
		
		public bool Exist_Column(int nRow,T element){
			nRow = nRow % Size_Rows();
			var column = Get_Row(nRow).adyacentColumn;
			while(column != null){
				if(column.data.Equals(element)) return true;
				column = column.next;
			}
			return false;
		}
		
		public bool Exist_Column(int nRow,int nColumn){
			nRow = nRow % Size_Rows();
			var column = Get_Row(nRow).adyacentColumn;
			for(int i = 0; i < Get_Row(nRow).Size_Columns();i++){
				if(nColumn == i) return true;
				column = column.next;
			}
			return false;
		}
		
		public T this[int fila,int columna]{
			get {return Get_Value(fila,columna);}
			set { Get_Column(fila,columna).data = value;}
		}
		
		public void Delete_Column(int fila, T element){
			if(!Empty()){
				fila = fila % Size_Rows();
				var auxiliar = Get_Row(fila).adyacentColumn;
				var previousColumn = Get_Row(fila).adyacentColumn;;
				if(auxiliar != null){
					for(int i = 0; i < Get_Row(fila).Size_Columns();i++){
						if(auxiliar.data.Equals(element)){
							if(i == 0){//The first One
								Get_Row(fila).adyacentColumn = auxiliar.next;
								auxiliar = null;
							}
							else if(i == Get_Row(fila).Size_Columns()-1){//The last one
								auxiliar = null;
								previousColumn.next = null;
								
							}
							else{//In the middle
								
								previousColumn.next = auxiliar.next;
								auxiliar = null;
							}
							
							break;
						}
						previousColumn = auxiliar;
						auxiliar = auxiliar.next;
					}
	
				}
			}

			
		}
		
		public void Delete_Column(int fila, int columna){
			
			if(!Empty()){
				fila = fila % Size_Rows();
				columna = columna % Get_Row(fila).Size_Columns();
				var auxiliar = Get_Row(fila).adyacentColumn;
				var previousColumn = Get_Row(fila).adyacentColumn;;
				if(auxiliar != null){
					if(columna == 0){//The first One
						Get_Row(fila).adyacentColumn = auxiliar.next;
						auxiliar = null;
					}else{
						for(int i = 0; i < columna;i++){
							previousColumn = auxiliar;
							auxiliar = auxiliar.next;
						}
						
						if(columna == Get_Row(fila).Size_Columns()-1){//The last one
								
							auxiliar = null;
								previousColumn.next =null;
								
						}
						else{//In the middle
							previousColumn.next = auxiliar.next;
							auxiliar = null;
						}
					}
					
	
				}
			}
			
			
		}
	
		public void Delete_Row(int indice){
			if(!Empty()){
				indice = indice % Size_Rows();
				var auxiliar = Get_Row(indice);
				var previousAuxiliar = Get_Row(indice);
				for(int i = 0; i < auxiliar.Size_Columns();i++){//delete its columns
					Delete_Column(indice,i);
				}
				
				//Delete ROw:
				
				if(indice == 0){
					start = auxiliar.next;
					auxiliar = null;
				}
				else{
					for(int i = 0; i < indice;i++){
						previousAuxiliar = auxiliar;
						auxiliar = auxiliar.next;
					}
					
					if(indice == Size_Rows()-1){//The last one
						auxiliar = null;
						previousAuxiliar.next = null;
					}
					else{//In the middle
						previousAuxiliar.next = auxiliar.next;
						auxiliar = null;
					}
					
				}
			}
			
			
		}
	
		public void Modify_Column(int fila, int columna, T newValue){
			Get_Column(fila,columna).data = newValue;
		}
		
	
	}

	public class Pair<A,B>
	{
		public A firstData;
		public B secondData;
		
		public Pair(A dato1,B dato2)
		{
			this.firstData = dato1;
			this.secondData = dato2;
		}
		
		public bool Same_Type(){
			return firstData.GetType().Equals(secondData.GetType());
		}
		
		public bool Is_Equal(Pair<A,B> other){
			return this.firstData.Equals(other.firstData) && 
				this.secondData.Equals(other.secondData);
		}
		
		public override string ToString()
		{
			return string.Format("[Pair FirstData={0}, SecondData={1}]", firstData, secondData);
		}

	}
	
	public class Triplet<A,B,C>{
		public A firstData;
		public B secondData;
		public C thirdData;
		
		public Triplet(A dato1,B dato2, C dato3)
		{
			this.firstData = dato1;
			this.secondData = dato2;
			this.thirdData =  dato3;
		}
		
		public bool Is_Equal(Triplet<A,B,C> other){
			return this.firstData.Equals(other.firstData) && 
				this.secondData.Equals(other.secondData) &&
				this.thirdData.Equals(other.thirdData);
		}
		
		public override string ToString()
		{
			return string.Format("{0} | {1} | {2}", firstData, secondData, thirdData);
		}
		
		

	}
	
	public class Foursome<A,B,C,D>{
		public A firstData;
		public B secondData;
		public C thirdData;
		public D fourthData;
		
		public Foursome(A dato1,B dato2, C dato3,D dato4)
		{
			this.firstData = dato1;
			this.secondData = dato2;
			this.thirdData =  dato3;
			this.fourthData = dato4;
		}
		
		
		public override string ToString()
		{
			return string.Format("{0} | {1} | {2} | {3}", firstData, secondData, thirdData,fourthData);
		}

	}
	
	public class Double_List<T,N>
	{
		//Node
		public class Double_Node<M,P>
		{
			
			public Pair<M,P> data;
			public Double_Node<M,P> previous;
			public Double_Node<M,P> next;
			
			public Double_Node(M dato1, P dato2, Double_Node<M,P> anterior, Double_Node<M,P> siguiente){
				this.data = new Pair<M,P>(dato1,dato2);
				this.previous = anterior;
				this.next = siguiente;
			}
	
			public Double_Node(M dato1, P dato2){
				this.data = new Pair<M,P>(dato1,dato2);
				this.previous = null;
				this.next = null;
			}
			
			public Double_Node(Pair<M,P> par, Double_Node<M,P> anterior, Double_Node<M,P> siguiente){
				this.data = par;
				this.previous = anterior;
				this.next = siguiente;
			}
	
			public Double_Node(Pair<M,P> par){
				this.data = par;
				this.previous = null;
				this.next = null;
			}
			
		}
		
		private Double_Node<T,N> listFront;
		private Double_Node<T,N> listBack;
		private int index;
		
		public Double_List()
		{
			listBack = listFront = null;
			index = 0;
		}
		 
		~Double_List(){
			this.Clear();
		}
		
		public bool Empty(){
			return listFront == null;
		}
		public int Size(){
			return index;
		}
		
		public T First_Data_Front(){
			if(!Empty()) return listFront.data.firstData;
			else throw new Exception("Empty Double List");
		}
		public T First_Data_Back(){
			if(!Empty()) return listBack.data.firstData;
			else throw new Exception("Empty Double List");
		}
		public N Second_Data_Front(){
			if(!Empty()) return listFront.data.secondData;
			else throw new Exception("Empty Double List");
		}
		public N Second_Data_Back(){
			if(!Empty()) return listBack.data.secondData;
			else throw new Exception("Empty Double List");
		}
		public Pair<T,N> First(){
			if(!Empty()) return listFront.data;
			else throw new Exception("Empty Double List");
		}
		public Pair<T,N> Back(){
			if(!Empty()) return listBack.data;
			else throw new Exception("Empty Double List");
		}
		
		public void Push_Back(T data1,N data2){
			if(Empty()){
				var newNode = new Double_Node<T,N>(data1,data2);
				listBack = listFront = newNode;
				index++;
			}
			else{
				var newNode = new Double_Node<T,N>(data1,data2,listBack,null);
				listBack.next = newNode;
				listBack = newNode;
				index++;
			}
		}
		
		public void Push_Front(T data1,N data2){
			if(Empty()){
				var newNode = new Double_Node<T,N>(data1,data2);
				listBack = listFront = newNode;
				index++;
			}
			else{
				var newNode = new Double_Node<T,N>(data1,data2,null,listFront);
				listFront.previous = newNode;
				listFront = newNode;
				index++;
			}
		}
		
		public void Push_Back(Pair<T,N> couple){
			if(Empty()){
				var newNode = new Double_Node<T,N>(couple);
				listBack = listFront = newNode;
				index++;
			}
			else{
				var newNode = new Double_Node<T,N>(couple,listBack,null);
				listBack.next = newNode;
				listBack = newNode;
				index++;
			}
		}
		
		public void Push_Front(Pair<T,N> couple){
			if(Empty()){
				var newNode = new Double_Node<T,N>(couple);
				listBack = listFront = newNode;
				index++;
			}
			else{
				var newNode = new Double_Node<T,N>(couple,null,listFront);
				listFront.previous = newNode;
				listFront = newNode;
				index++;
			}
		}
		
		public void Pop_Front(){
			if(!Empty()){
				
				var deleteNode = listFront;
				
				listFront = listFront.next;
				
				if(listFront != null){
					listFront.previous = null;
				}
				
				deleteNode = null;
				
				index--;
			}
		}

		public void Pop_Back(){
			if(!Empty()){
				
				var deleteNode = listBack;
				
				listBack = listBack.previous;
				
				if(listBack != null){
					listBack.next = null;
				}
				
				deleteNode = null;
				
				index--;
			}
		}
		
		public void Clear(){
			if(!Empty()){
				int i = 0;
				int size = Size();
				
				while(i < size){
					Pop_Front();
					i++;
				}
				index = 0;
				
				listFront  = listBack = null;
			}
		}
		
		public void Erase_At(int pos){
			if(!Empty()){
				pos = pos % Size();
				if(pos == 0) Pop_Front();
				else if(pos == Size()) Pop_Back();
				else{
					var temp = listFront;
			        for (int i = 0; i < pos -1; ++i) {
			            temp = temp.next;
			        }
			
			        var delete = temp.next;
			
			        temp.next = delete.next;
			
			        delete.next = delete.previous.next;

			        delete = null;
			
			        --index;
				}
				
			}
		}
		
		public bool Exist_First(T value){
			if(Empty()){
				return false;
			}
			else{
				var auxiliar = listFront;
				
				for(int i = 0; i < Size();i++){
					if(auxiliar.data.firstData.Equals(value)){
						return true;
					}
					auxiliar = auxiliar.next;
				}
				
				return false;
			}
		}
		
		public bool Exist_Second(N value){
			if(Empty()){
				return false;
			}
			else{
				var auxiliar = listFront;
				
				for(int i = 0; i < Size();i++){
					if(auxiliar.data.secondData.Equals(value)){
						return true;
					}
					auxiliar = auxiliar.next;
				}
				
				return false;
			}
		}
		
		public bool Exist(Pair<T,N> pair){
			return Exist_First(pair.firstData) && Exist_Second(pair.secondData);
		}
		
		public T Get_First_Element(int indice){
			if(!Empty()){
				indice = indice % Size();
				if(indice == 0) return First_Data_Front();
				else if(indice == Size()-1) return First_Data_Back();
				else{
					var auxiliar = listFront;
					for(int i = 0; i < indice;i++){
						auxiliar = auxiliar.next;
					}
					return auxiliar.data.firstData;
				}
			}
			else throw new Exception("EMPTY DOUBLE LIST");
		}
		public N Get_Second_Element(int indice){
			if(!Empty()){
				indice = indice % Size();
				if(indice == 0) return Second_Data_Front();
				else if(indice == Size()-1) return Second_Data_Back();
				else{
					var auxiliar = listFront;
					for(int i = 0; i < indice;i++){
						auxiliar = auxiliar.next;
					}
					return auxiliar.data.secondData;
				}
			}
			else throw new Exception("EMPTY DOUBLE LIST");
		}
		
		public Pair<T,N> Get_Pair(int indice){
			if(!Empty()){
				indice = indice % Size();
				if(indice == 0) return First();
				else if(indice == Size()-1) return Back();
				else{
					var auxiliar = listFront;
					for(int i = 0; i < indice;i++){
						auxiliar = auxiliar.next;
					}
					return auxiliar.data;
				}
			}
			else throw new Exception("EMPTY DOUBLE LIST");
		}
		
		public void Reverse(){
			
			if(!Empty()){
				var newList = new Double_List<T,N>();
				var auxiliar = listBack;
				for(int i = 0; i < Size();i++){
					newList.Push_Back(auxiliar.data);
					
					auxiliar = auxiliar.previous;
				}
				
				Clear();
				for(int i = 0; i < newList.Size();i++){
					Push_Back(newList.Get_Pair(i));
				}
				newList.Clear();
			}
			
		}
		
		public Pair<T,N> this[int indice]{
			get { return Get_Pair(indice); }
			set { Get_Pair(indice).firstData = value.firstData;
				  Get_Pair(indice).secondData = value.secondData;}
		}
		
		public  bool Is_Equal(Double_List<T,N> second){
			if(this.Size() != second.Size()) return false;
			else{
				var auxiliar = listFront;
				for(int i = 0; i < Size();i++){
					if(!auxiliar.data.firstData.Equals(second[i].firstData) && 
					   !auxiliar.data.secondData.Equals(second[i].secondData)) return false;
					auxiliar = auxiliar.next;
				}
				return true;
			}
		}
		
		public static Double_List<T,N> operator +(Double_List<T,N> original, Double_List<T,N> sumante){
			for(int i = 0; i < sumante.Size();i++){
				if(!original.Exist(sumante[i])) original.Push_Back(sumante[i]);
			}
			return original;
		}
		
		public static Double_List<T,N> operator -(Double_List<T,N> original, Double_List<T,N> restante){
			for(int i = 0; i < restante.Size();i++){
				if(original.Exist(restante[i])){
					original.Remove(restante[i]);
				}
			}
			return original;
		}
		
		public void Remove(Pair<T,N> value){
			if(!Empty()){
				Pair<T,N> dato;
			    var temp = listFront;
			    var i = 0;
			    while(temp != null){
			        dato = temp.data;
			        temp = temp.next;
			        if(dato.Is_Equal(value)){
			            Erase_At(i);
			            i--;
			        }
			        i++;
			    }
			}
		}
		
		public void Insert_At(int pos, Pair<T,N> element){
			if(Empty()){
				Push_Back(element);
			}
			else{
				pos = pos % Size();
				if(pos == 0) Push_Front(element);
				else if(pos == Size()) Push_Back(element);
				else{
					var auxiliar = listFront;
					for(int i = 0; i < pos-1;i++){
						auxiliar = auxiliar.next;
					}
					var newNode = new Double_Node<T,N>(element,auxiliar.previous,auxiliar.next);
					auxiliar.next = newNode;
					newNode.previous = auxiliar;
					index++;
				}
			}
		}
		
		public void Replace_First_Element(T elementToReplace,T replacement){
			var auxiliar = listFront;
			while(auxiliar != null){
				if(auxiliar.data.firstData.Equals(elementToReplace)) {
					auxiliar.data.firstData = replacement;
					break;
				}
				auxiliar = auxiliar.next;
			}
		}
		
		public void Replace_Second_Element(N elementToReplace,N replacement){
			var auxiliar = listFront;
			while(auxiliar != null){
				if(auxiliar.data.secondData.Equals(elementToReplace)) {
					auxiliar.data.secondData = replacement;
					break;
				}
				auxiliar = auxiliar.next;
			}
		}
		
		public void Replace_First_Element(int pos,T replacement){
			pos = pos % Size();
			var auxiliar = listFront;
			for(int i = 0; i < pos;i++){
				auxiliar = auxiliar.next;
			}
			
			auxiliar.data.firstData = replacement;
			
		}
		
		public void Replace_Second_Element(int pos,N replacement){
			pos = pos % Size();
			var auxiliar = listFront;
			for(int i = 0; i < pos;i++){
				auxiliar = auxiliar.next;
			}
			
			auxiliar.data.secondData = replacement;
			
		}
		
		
	}

	public class Double_Stack<T,N>
	{
		private Double_List<T,N> list;
		public Double_Stack()
		{
			list = new Double_List<T, N>();
		}
		
		~Double_Stack(){
			list.Clear();
		}
		
		public bool Empty(){
			return list.Empty();
		}
		
		public Pair<T,N> Peek(){
			return list.First();
		}
		
		public void Push(Pair<T,N> element){
			list.Push_Front(element);
		}
		public void Push(T element1, N element2){
			list.Push_Front(element1,element2);
		}
		
		public void Pop(){
			list.Pop_Front();
		}
		
		public int Size(){
			return list.Size();
		}
		public void Clear(){
			list.Clear();
		}
		
		public bool Contains_First_Element(T elem){
			return list.Exist_First(elem);
		}
		
		public bool Contains_Second_Element(N elem){
			return list.Exist_Second(elem);
		}
		
		public bool Contains(Pair<T,N> par){
			return list.Exist(par);
		}
		
		public bool Contains(T element1, N element2){
			return list.Exist(new Pair<T, N>(element1,element2));
		}
		
		
		public static Double_Stack<T,N> operator +(Double_Stack<T,N> first, Double_Stack<T,N> second){
			for(int i = 0; i < second.Size();i++){
				first.Push(second.Peek());
				second.Pop();
			}
			return first;
		}
		
		public static Double_Stack<T,N> operator +(Double_Stack<T,N> first, Double_Queue<T,N> second){
			for(int i = 0; i < second.Size();i++){
				first.Push(second.Peek());
				second.Dequeue();
			}
			return first;
		}
	}

	public class Double_Queue<T,N>
	{
		private Double_List<T,N> list;
		public Double_Queue()
		{
			list = new Double_List<T, N>();
		}
		
		~Double_Queue(){
			list.Clear();
		}
		
		public bool Empty(){
			return list.Empty();
		}
		
		public int Size(){
			return list.Size();
		}
		public void Dequeue(){
			list.Pop_Front();
		}
		public Pair<T,N> Peek(){
			return list.First();
		}
		public void Enqueue(Pair<T,N> elem){
			list.Push_Back(elem);
		}
		
		public void Enqueue(T element1, N element2){
			list.Push_Back(element1,element2);
		}
		
		public void Clear(){
			list.Clear();
		}
		
		public bool Contains_First_Element(T elem){
			return list.Exist_First(elem);
		}
		
		public bool Contains_Second_Element(N elem){
			return list.Exist_Second(elem);
		}
		
		public bool Contains(Pair<T,N> par){
			return list.Exist(par);
		}
		
		public bool Contains(T element1,N element2){
			return list.Exist(new Pair<T, N>(element1,element2));
		}
		
		public static Double_Queue<T,N> operator +(Double_Queue<T,N> first, Double_Queue<T,N> second){
			for(int i = 0; i < second.Size();i++){
				first.Enqueue(second.Peek());
				second.Dequeue();
			}
			return first;
		}
		
		public static Double_Queue<T,N> operator +(Double_Queue<T,N> first, Double_Stack<T,N> second){
			for(int i = 0; i < second.Size();i++){
				first.Enqueue(second.Peek());
				second.Pop();
			}
			return first;
		}
		
	}

	
	public class ABB{
		
		public class NodoABB{
		    public int dato;
		    public NodoABB izq;
		    public NodoABB der;
	
		    public NodoABB(int elem){
		    	this.dato = elem;
		    	this.izq = this.der = null;

		    }
		    public NodoABB(int elem, NodoABB i, NodoABB d){
		    	this.dato = elem;
		    	this.izq = i;
		    	this.der = d;

		    }
		}
		//private members and atributes
		
		int find(NodoABB localRoot,int elem){
			if (localRoot == null)
				return root.dato;
		    else if (elem < localRoot.dato)
		        return find(localRoot.izq, elem);
		    else if (elem > localRoot.dato)
		        return find(localRoot.der, elem);
		    else
		        return localRoot.dato;
		}
		bool insert(NodoABB localRoot,int elem){
			if (localRoot == null){
		        localRoot = new NodoABB(elem);
		        MessageBox.Show(localRoot.dato.ToString(),"INSERT");
		        return true;
		    }
		    else if (elem < localRoot.dato)
		        return insert(localRoot.izq, elem);
		    else if (elem > localRoot.dato)
		        return insert(localRoot.der, elem);
		    else
		        return false;
		}
		void inOrder(NodoABB localRoot, ref List<int> list){
			if (localRoot == null)
	        	return;
		    inOrder(localRoot.izq, ref list);
		    list.Add(localRoot.dato);
		    MessageBox.Show(localRoot.dato.ToString(),"IN ORDER");
		    inOrder(localRoot.der, ref list);
		}
		bool erase(NodoABB localRoot,int elem){
			if (localRoot == null)
		        return false;
		    else if (elem < localRoot.dato)
		        return erase(localRoot.izq, elem);
		    else if (elem > localRoot.dato)
		        return erase(localRoot.der, elem);
		    else
		    {
		        NodoABB oldRoot = localRoot;
		        if (localRoot.izq == null)
		            localRoot = localRoot.der;
		        else if (localRoot.der == null)
		            localRoot = localRoot.izq;
		        else
		            replaceParent(oldRoot, oldRoot.izq);
		        oldRoot = null;
		        return true;
		    }
		}
		void replaceParent(NodoABB oldRoot, NodoABB localRoot){
			
		    if (localRoot.der != null)
		        replaceParent(oldRoot, localRoot.der);
		    else
		    {
		        oldRoot.dato = localRoot.dato;
		        oldRoot = localRoot;
		        localRoot = localRoot.izq;
		    }
		}
	    
		NodoABB root;
	    
	    //public members:
	 	 public ABB(int value){
	    	root = new NodoABB(value);
		}
	    public ABB(int elem, ABB left,ABB right){
	    	root = new NodoABB(elem, left.root, right.root);
	    }
	
	    public bool isNull(){
	    	 return root == null;
	    }
	    public bool isLeaf(){
	    	if (!isNull())
        		return root.izq == null && root.der == null;

    		return true;
	    }
//	    public ABB<T> getLeftSubtree();
//	    public ABB<T> getRightSubtree();
	    public int getData(){
			return isNull() ? -1 : root.dato;
	    }
	    public int find(int elem){
	    	return find(root, elem);
	    }
	    public bool insert(int elem){
	    	return insert(root, elem);
	    }
	    public List<int> inOrder(){
	    	var lista = new List<int>();
	    	inOrder(root, ref lista);
	    	return lista;
	    }
	    public bool erase(int elem){
	    	return erase(root, elem);
	    }

	}


}
