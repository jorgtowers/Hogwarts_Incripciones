using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts_Incripciones.Models
{
    [Serializable]
    /// <summary>
    /// Entidad de Solucitud para ingresar a Hogwarts
    /// </summary>
    public class Solicitud
    {
        [Required(ErrorMessage = "Nombre es requerido")]
        [RegularExpression(@"^[a-zA-Z\s]{1,20}$", ErrorMessage = "Solo letras, máximo 20 carácteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es requerido")]
        [RegularExpression(@"^[a-zA-Z\s]{1,20}$", ErrorMessage = "Solo letras, máximo 20 carácteres")]
        public string Apellido { get; set; }
        
        [Required(ErrorMessage = "Identificacion es requerida")]
        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage = "Solo números, máximo 10 dígitos")]
        public int Identificacion { get; set; }
        
        [Required(ErrorMessage = "Edad es requerida")]
        [RegularExpression(@"^[0-9]{1,2}$", ErrorMessage = "Solo números, máximo 2 dígitos")]
        public int Edad { get; set; }
        
        [Required(ErrorMessage = "Casa es requerida")]
        [RegularExpression(@"^Gryffindor|Hufflepuff|Ravenclaw|Slytherin$",
         ErrorMessage = "Solo se permiten las casas Gryffindor, Hufflepuff, Ravenclaw o Slytherin")]
        public string Casa { get; set; }
    }
}
