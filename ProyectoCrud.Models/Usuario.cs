using System;
using System.Collections.Generic;

namespace ProyectoCrud.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public string? Direccion { get; set; }

    public string? EstadoCivil { get; set; }

    public string? Dpi { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
