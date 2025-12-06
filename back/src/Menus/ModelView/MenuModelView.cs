using System.ComponentModel.DataAnnotations;

namespace Menus.ModelView
{
    public class MenuModelView
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = string.Empty;
        public int Precio { get; set; }
        public string? Imagen { get; set; }

        public MenuModelView()
        {
        }

        public MenuModelView(int id, string nombre, string descripcion, int precio, string? imagen)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Imagen = imagen;
        }
        public MenuModelView(string nombre, string descripcion, int precio, string? imagen)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Imagen = imagen;
        }
    }
}
