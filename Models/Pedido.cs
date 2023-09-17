namespace EspacioCadeteria{
    public class Pedido{
        private int numero;
        private string? observacion;
        private Cliente cliente;

        private string? estado;

        private Cadete? cadete;

        public int Numero { get => numero; set => numero = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public string? Observacion { get => observacion; set => observacion = value; }
        public string? Estado { get => estado; set => estado = value; }
        public Cadete? Cadete { get => cadete; set => cadete = value; }

        public Pedido(int numero, string observacion, string nombreCliente, string direccion, long telefono, string referencia_direccion)
        {
            cliente = new Cliente( nombreCliente,  direccion,  telefono,  referencia_direccion);
            this.numero = numero;
            this.observacion = observacion;
            estado = "Pendiente";
        }
        public string? VerDireccionCliente(){
            Console.WriteLine(cliente.Direccion);
            string? direccionCliente = cliente.Direccion;
            return direccionCliente;
        }
        public string? VerDatosCliente(){
            string? infoCliente = $"Nombre: {cliente.Nombre}\n";
            infoCliente += $"Teléfono: {cliente.Telefono}\n";
            infoCliente += $"Dirección: {cliente.Direccion}\n";
            return infoCliente;
        }
    }
}