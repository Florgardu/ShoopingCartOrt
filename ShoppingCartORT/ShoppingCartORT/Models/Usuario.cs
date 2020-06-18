using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartORT.Models
{
    public class Usuario
    {
        public int usuarioID { get; set; }

        [Required(ErrorMessage = "Un nombre es requerido")]
        [StringLength(20)]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Un apellido es requerido")]
        [StringLength(20)]
        public string apellido { get; set; }

        public int dni { get; set; }


        [Required(ErrorMessage = "Password es requerida")]
        [StringLength(15, ErrorMessage = "La contraseña debe tener como minimo 5 caracteres", MinimumLength = 5)]
        public string password { get; set; }

        [Required(ErrorMessage = "Email es requerido")]
        [StringLength(30, ErrorMessage = "Debe ingresar un mail entre 5 y 30 caracteres", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Ingrese un imail valido")]
        public string mail { get; set; }

        [StringLength(30, MinimumLength = 1)]
        public string rol { get; set; }
    }
}

