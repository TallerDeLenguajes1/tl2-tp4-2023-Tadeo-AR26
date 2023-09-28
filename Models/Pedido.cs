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

        public Pedido(){} //Si le saco este constructor, los metodos para agregar cadetes mueren
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

        public string? GetDatosPedido(){
            string? ped = $"Numero: {numero}\n";
            ped += $"Observacion: {observacion}\n";
            ped += $"Cliente: {cliente.Nombre}\n";
            ped += $"Direccion: {cliente.Direccion}\n";
            ped += $"Teléfono: {cliente.Telefono}\n";
            ped += $"Referencia: {cliente.Referencia_direccion}\n";
            ped += $"Estado: {estado}\n";
            return ped;
        }
    }
}