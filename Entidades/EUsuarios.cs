using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class EUsuarios
    {
        [Display(Name= "Id")]
        public int Id { get; set; } //(int 4)  not null
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [Display(Name = "Nombre: ")]
        public string Nombre { get; set; } //(varchar 50)  not null
        [Required(ErrorMessage = "El apellido paterno es obligatorio.")]
        [Display(Name = "Apellido paterno: ")]
        public string ApellidoP { get; set; } //(varchar 50)  not null
        [Required(ErrorMessage = "El apellido materno es obligatorio.")]
        [Display(Name = "Apellido materno: ")]
        public string ApellidoM { get; set; } //(varchar 50)  not null
        public decimal? Telefono { get; set; } //(numeric 9)  null
        public string Direccion { get; set; } //(varchar 120)  null
        public string Email { get; set; } //(varchar 50)  null
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [Display(Name = "Nombre de usuario: ")]
        public string Loggin { get; set; } //(varchar 50)  null
        [Display(Name = "Contraseña: ")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Password { get; set; } //(varchar 50)  null
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [Display(Name = "Estatus: ")]
        public bool Estado { get; set; } //(bit 1)  not null
    }
}