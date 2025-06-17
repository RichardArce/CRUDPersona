using System;
using System.Collections.Generic;

namespace CRUDPersonaObjetos.Modelos;

public partial class Persona
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Edad { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
