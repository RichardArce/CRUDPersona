using System;
using System.Collections.Generic;

namespace CRUDPersonaObjetos.Modelos;

public partial class Provincia
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Persona> Persona { get; set; } = new List<Persona>();
}
