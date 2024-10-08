﻿using ProyectoAgua.EN;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.EN
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Rol")]
        [Required(ErrorMessage = "Rol es Obligatorio")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "Nombre es Obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 Caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido es Obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 Caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Login es Obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 Caracteres")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password es Oblgatorio")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "El Password debe tener entre 5 y 32 Caracteres")]
        public string Password { get; set; }
        public byte Estatus { get; set; }
        [Display(Name = "Fecha de Registro")]
        [Required(ErrorMessage = "FechaRegistro es Obligatorio")]
        //[StringLength(100, ErrorMessage = "Maximo 100 Caracteres")]
        public DateTime FechaRegistro { get; set; }
        public Rol Rol { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Confirmar Password")]
        [StringLength(32, ErrorMessage = "La Password debe tener entre 5 a 32 Caracteres")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password y confirmar Password deben ser iguales")]
        [Display(Name = "Confirmar Password")]
        public string ConfirmPassword_Aux { get; set; }
    }

    public enum Estatus_Usuario
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}
