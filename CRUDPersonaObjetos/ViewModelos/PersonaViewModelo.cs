namespace CRUDPersonaObjetos.ViewModelos
{
    public partial class PersonaViewModelo
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public int? Edad { get; set; }

        public int? ProvinciaIdfk { get; set; } // Foreign Key

        public string? ProvinciaNombre { get; set; } // Nombre de la provincia asociada para mostrar

        //No debería tener objetos --solo debe mostrar la info, o funcionar como estructura de datos
    }
}
