using System;
using System.Collections.Generic;
using System.Text.Json;
using UtilityLibraries;

namespace EspacioCadeteria{
    public class AccesoADatosCadeteria{
        public AccesoADatosCadeteria(){}
        public Cadeteria obtenerCadeteria(){
            try{
                string archivo = "Cadeteria.json";
                string jsonText = File.ReadAllText(archivo);
                Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(jsonText);
                Console.WriteLine("ASD");
                return cadeteria;
            }
            catch(Exception ex){

            }
            return null;
        }
    }

    public class AccesoADatosCadetes{
        public AccesoADatosCadetes(){}
        public List<Cadete> ObtenerCadetes(){
            List<Cadete> cadetes;
            string archivo = "Cadetes.json";
            try{
                string jsonText = File.ReadAllText(archivo);
                cadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonText);
                return cadetes;
            }
            catch(Exception ex){

            }
            return null;
        }

        public void GuardarCadetes(List<Cadete> Cadetes){
            string DataPath = "Cadetes.json";
            string jsonText = JsonSerializer.Serialize(Cadetes);
            using (var nuevoarchivo = new FileStream(DataPath, FileMode.OpenOrCreate)){
                using(var strWriter = new StreamWriter(nuevoarchivo)){
                    strWriter.WriteLine("{0}", jsonText);
                    strWriter.Close();
                }
            }
        }
    }

    public class AccesoADatosPedidos{
        public AccesoADatosPedidos(){}
        public List<Pedido> ObtenerPedidos(){
            List<Pedido> pedidos = new List<Pedido>();
            string archivo = "Pedidos.json";
            try{
                string jsonText = File.ReadAllText(archivo);
                pedidos = JsonSerializer.Deserialize<List<Pedido>>(jsonText);
            }
            catch(Exception ex){

            }
            return pedidos;
        }

        public void GuardarPedidos(List<Pedido> Pedidos){
            string DataPath = "Pedidos.json";
            string jsonText = JsonSerializer.Serialize(Pedidos);
            using (var nuevoarchivo = new FileStream(DataPath, FileMode.OpenOrCreate)){
                using(var strWriter = new StreamWriter(nuevoarchivo)){
                    strWriter.WriteLine("{0}", jsonText);
                    strWriter.Close();
                }
            }
        }
    }
}