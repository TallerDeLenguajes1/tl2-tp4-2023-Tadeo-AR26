using Microsoft.AspNetCore.Mvc;
using EspacioCadeteria;
using UtilityLibraries;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase{
    private readonly ILogger<CadeteriaController > _logger;
    private Cadeteria cadeteria;
    public CadeteriaController(ILogger<CadeteriaController > logger){

        cadeteria = Cadeteria.GetInstance();

        cadeteria.AgregarPedido(0, "Observacion", "Tadeo", "Direccion", 3876642382, "Referencia");
        cadeteria.AgregarPedido(1, "Observacion2", "Alonso", "Direccion2", 3876642382, "Referencia2");

        _logger = logger;

    }

    [HttpGet(Name = "CadeteriaController")] //El primer metodo toma el nombre de la clase aunque no se ponga el nombre
    public ActionResult<string> GetNombreCadeteria(){
        return Ok(cadeteria.Nombre);
    }

    [HttpGet]
    [Route("Pedidos")]
    public ActionResult<List<Pedido>> GetPedidos(){
        return Ok(cadeteria.getPedidos());
    }
    
    [HttpGet]
    [Route("Cadetes")]
    public ActionResult<List<Cadete>> GetCadetes(){
        return Ok(cadeteria.getCadetes());
    }

    [HttpPost]
    [Route("AddPedido")]
    public ActionResult<Pedido> agregarPedido(Pedido pedido){
        var nuevoPedido = cadeteria.AddPedido(pedido);
        return Ok(nuevoPedido);
    }

    [HttpGet]
    [Route("Informe")]
    public ActionResult<string> GetInforme(){
        Informe nuevoInforme;
        nuevoInforme = new Informe();
        string informeJSON = nuevoInforme.GenerarInformeJson(cadeteria);
        return Ok(informeJSON);
    }

    [HttpPut]
    [Route("AsignarPedido")]
    public ActionResult<Pedido> asignarPedido(int idPedido, int idCadete){
        Pedido nuevoPedido = cadeteria.asignarCadeteAPedido(idCadete, idPedido);
        return nuevoPedido;
    }

    [HttpPut]
    [Route("CambiarCadete")]
    public ActionResult<Pedido> cambiarCadetePedido(int idPedido, int idCadete){
        Pedido pedido = cadeteria.reasignarCadete(idCadete, idPedido);
        return pedido;
    }

    [HttpPut]
    [Route("ActualizarEstadoPedido")]
    public ActionResult<Pedido> actualizarEstadoPedido(int idPedido, int nuevoEstado){
        Pedido pedido = cadeteria.cambiarEstadoPedido(idPedido);
        return pedido;
    }
}