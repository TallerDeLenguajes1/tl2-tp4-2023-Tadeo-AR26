using Microsoft.AspNetCore.Mvc;
using EspacioCadeteria;
using UtilityLibraries;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase{
    private readonly ILogger<CadeteriaController > _logger;
    Cadeteria cadeteria;
    public CadeteriaController(ILogger<CadeteriaController > logger){
        int opcion = 0;
        Console.WriteLine("Cargar Datos");
        Console.WriteLine("1-CSV");
        Console.WriteLine("2-JSON");
        bool successfullyParsed = int.TryParse(Console.ReadLine(), out opcion);

        cadeteria = new Cadeteria("Nombre de la Cadeteria", 3876642382);
        cadeteria.cargarCadetes(opcion);

        _logger = logger;

    }

    [HttpGet(Name = "CadeteriaController")] //El primer metodo toma el nombre de la clase aunque no se ponga el nombre
    public ActionResult<string> GetNombreCadeteria(){
        return cadeteria.Nombre;
    }
}