using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStop.BL
{
    public class Producto
    {

        public Producto()
        {
            Activo = true;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese la descripción")]
        [MinLength(3, ErrorMessage = "Ingrese mínimo 3 carácteres")]
        [MaxLength(20, ErrorMessage = "Ingrese máximo 20 caráctres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese el precio")]
        [Range(0, 1000, ErrorMessage = "Ingrese un precio entre 0 y 1,000")]
        public double Precio { get; set; }

        public Categoria Categoria { get; set; }
        public bool Activo { get; set; }
        public object CategoriaId { get; set; }
    }
}
