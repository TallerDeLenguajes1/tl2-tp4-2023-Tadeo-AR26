﻿namespace UtilityLibraries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using EspacioCadeteria;

public class Cadeteria
{
    private string? nombre;
        private long telefono;
        private List<Cadete> listaCadetes;
        private List<Pedido> listaPedidos = new List<Pedido>();

        public string? Nombre { get => nombre; set => nombre = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

        public Cadeteria(string nombre, long telefono){
            this.nombre = nombre;
            this.telefono = telefono;
        }
        public void AgregarCadete(int id, string nombre, string direccion, long telefono){
            Cadete NuevoCadete;
            NuevoCadete = new Cadete(id, nombre, direccion, telefono);
            listaCadetes.Add(NuevoCadete);
        }
        
        public void AgregarPedido(int numero, string observacion, string nombreCliente, string direccion, long telefono, string referencia_direccion){
            Pedido NuevoPedido;
            NuevoPedido = new Pedido(numero, observacion, nombreCliente, direccion, telefono, referencia_direccion);
            listaPedidos.Add(NuevoPedido);
        }

        public void cambiarEstadoPedido(int numeroPedido){  
            Pedido pedidoEncontrado = ListaPedidos.Find(pedido => pedido.Numero == numeroPedido);
                if(pedidoEncontrado != null){
                    if(pedidoEncontrado.Estado == "Pendiente"){
                        pedidoEncontrado.Estado = "Entregado";
                    }
                    else{
                    }
            }
        }

        public void cargarCadetes(int opcion){
            // 1 cargar desde CSV - 2 cargar desde JSON
            AccesoADatos acceso = new AccesoADatos();
            string archivo = "Cadetes";
            switch(opcion){
                case 1:
                    acceso = new AccesoCSV();
                    break;
                case 2:
                    acceso = new AccesoJSON();
                    break;
            }
            listaCadetes = acceso.cargarCadetes(archivo);
        }

        public void mostrarDatosCadete(){
            foreach(Cadete cadete in listaCadetes){
                string infoCadete = cadete.mostrarDatosCadete();
            }
        }

        public int jornalACobrar(int idCadete){
            int jornal = 0;
            int montoPorPedido = 500;
            jornal = listaPedidos
            .Where(pedido => pedido.Cadete != null && pedido.Cadete.Id == idCadete && pedido.Estado == "Entregado")
            .Sum(pedido => montoPorPedido);
            return jornal;
        }

        public void asignarCadeteAPedido(int idCadete, int idPedido){
            Pedido pedidoEncontrado = listaPedidos.Find(pedido => pedido.Numero == idPedido);
            Cadete cadeteEncontrado = listaCadetes.Find(cadete => cadete.Id == idCadete);
            pedidoEncontrado.Cadete = cadeteEncontrado;
        }

        public void reasignarCadete(int idCadete, int numero){
            Pedido pedidoEncontrado = listaPedidos.Find(pedido => pedido.Numero == numero);
            Cadete cadeteEncontrado = listaCadetes.Find(cadete => cadete.Id == idCadete);
            pedidoEncontrado.Cadete = cadeteEncontrado;
        }
}