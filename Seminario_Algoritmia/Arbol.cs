using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seminario_Algoritmia
{
    public class ArbolBinarioOrdenado {
        class Nodo{
            public int info;
            public Nodo izq, der;
        }
        Nodo raiz;
        public List<int> Nodos;

        public ArbolBinarioOrdenado(){
            raiz=null;
            Orden = new List<int>();
            Nodos = new List<int>();
        }
        
        public List<int> Orden;
     
        public void Insertar (int info)
        {
        	if(Nodos.Contains(info))
        		return;
            Nodo nuevo;
            nuevo = new Nodo ();
            nuevo.info = info;
            Nodos.Add(info);
            nuevo.izq = null;
            nuevo.der = null;
            if (raiz == null)
                raiz = nuevo;
            else
            {
                Nodo anterior = null, reco;
                reco = raiz;
                while (reco != null)
                {
                    anterior = reco;
					reco = info < reco.info ? reco.izq : reco.der;
                }
                if (info < anterior.info)
                    anterior.izq = nuevo;
                else
                    anterior.der = nuevo;
            }
        }


        private void ImprimirPre (Nodo reco)
        {
            if (reco != null)
            {
                Orden.Add(reco.info);
                ImprimirPre (reco.izq);
                ImprimirPre (reco.der);
            }
        }

        public void ImprimirPre ()
        {
            ImprimirPre (raiz);
            Console.WriteLine();
        }

        private void ImprimirEntre (Nodo reco)
        {
            if (reco != null)
            {   
                ImprimirEntre (reco.izq);
                Console.Write(reco.info + " ");
                ImprimirEntre (reco.der);
            }
        }

        public void ImprimirEntre ()
        {
            ImprimirEntre (raiz);
            Console.WriteLine();
        }


        private void ImprimirPost (Nodo reco)
        {
            if (reco != null)
            {
                ImprimirPost (reco.izq);
                ImprimirPost (reco.der);
                Console.Write(reco.info + " ");
            }
        }


        public void ImprimirPost ()
        {
            ImprimirPost (raiz);
            Console.WriteLine();
        }

    }
}