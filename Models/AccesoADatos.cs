using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Text.Json;
using EspacioCadeteria;

namespace EspacioCadeteria{
    public class AccesoADatos{
        private List<Cadete>? listaCadetes;
        public List<Cadete>? ListaCadetes { get => listaCadetes; set => listaCadetes = value; }

        public virtual List<Cadete> cargarCadetes(string archivo){
            return ListaCadetes;
        }
    }

    public class AccesoCSV : AccesoADatos{
        public override List<Cadete> cargarCadetes(string archivo){
            List<Cadete> cadetes  = new List<Cadete>();
            var cadetesCargados = File.ReadAllLines(archivo + ".csv")
            .Skip(1).                           //Saltea el encabezado
            Select(line => line.Split(',')).
            Select(parts => new Cadete(int.Parse(parts[0]), parts[1], parts[2], long.Parse(parts[3])));
            cadetes.AddRange(cadetesCargados);
            ListaCadetes = cadetes;
            return ListaCadetes;
        }
    }

    public class AccesoJSON: AccesoADatos{
        public override List<Cadete> cargarCadetes(string archivo){
            List<Cadete>? cadetes = new List<Cadete>();
            try{
                string jsonText = File.ReadAllText(archivo + ".json");
                cadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonText);
                ListaCadetes = cadetes;
            }
            catch (Exception ex){
            }
            return ListaCadetes;
        }
    }
}