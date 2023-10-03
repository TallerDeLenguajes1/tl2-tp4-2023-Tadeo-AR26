namespace EspacioCadeteria{
    public class Cadete{
        private int id;
        private string nombre;
        private string direccion;
        private long telefono;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public long Telefono { get => telefono; set => telefono = value; }

        public Cadete(){}

        public Cadete(int id, string nombre, string direccion, long telefono){
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public string mostrarDatosCadete(){
            string infoCadete = $"ID: {id}\n";
            infoCadete += $"Nombre: {nombre}\n";
            infoCadete += $"Dirección: {direccion}\n";
            infoCadete += $"Teléfono: {telefono}\n";
            return infoCadete;
        }

    }
}