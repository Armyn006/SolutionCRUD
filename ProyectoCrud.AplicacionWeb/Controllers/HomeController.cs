using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.AplicacionWeb.Models;
using ProyectoCrud.AplicacionWeb.Models.ViewModels;
using ProyectoCrud.BLL.Service;
using ProyectoCrud.Models;
using System.Diagnostics;
using System.Globalization;

namespace ProyectoCrud.AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioService _UsuarioService;

        public HomeController(IUsuarioService usuarioServ)
        {
            _UsuarioService = usuarioServ;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public async Task <IActionResult> Lista()
        {
            IQueryable<Usuario> queryContactoSQL = await _UsuarioService.ObtenerTodos();

            List<VMUsuario> lista = queryContactoSQL 
                .Select(c => new VMUsuario(){
                IdUsuario = c.IdUsuario,
                Nombres = c.Nombres,
                Apellidos = c.Apellidos,
                FechaNacimiento = c.FechaNacimiento.Value.ToString("dd/MM/yyyy"),
                Genero = c.Genero,
                Direccion = c.Direccion,
                EstadoCivil = c.EstadoCivil,
                Dpi =  c.Dpi}).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);
        }



        [HttpPost]

        public async Task<IActionResult> Insertar([FromBody] VMUsuario modelo)
        {
            Usuario NuevoModelo = new Usuario()
            {
                Nombres = modelo.Nombres,
                Apellidos = modelo.Apellidos,
                FechaNacimiento = DateTime.ParseExact(modelo.FechaNacimiento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-GT")),
                Genero = modelo.Genero,
                Direccion= modelo.Direccion,    
                EstadoCivil= modelo.EstadoCivil,
                Dpi = modelo.Dpi
            };

            bool respuesta = await _UsuarioService.Insertar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new {Valor = respuesta});
        }




        [HttpPut]

        public async Task<IActionResult> Actualizar([FromBody] VMUsuario modelo)
        {
            Usuario NuevoModelo = new Usuario()
            {   IdUsuario = modelo.IdUsuario,
                Nombres = modelo.Nombres,
                Apellidos = modelo.Apellidos,
                FechaNacimiento = DateTime.ParseExact(modelo.FechaNacimiento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-GT")),
                Genero = modelo.Genero,
                Direccion = modelo.Direccion,
                EstadoCivil = modelo.EstadoCivil,
                Dpi = modelo.Dpi
            };

            bool respuesta = await _UsuarioService.Actualizar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { Valor = respuesta });
        }





        [HttpDelete]

        public async Task<IActionResult> Eliminar(int id)
        {


            bool respuesta = await _UsuarioService.Eliminar(id);

            return StatusCode(StatusCodes.Status200OK, new { Valor = respuesta });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}