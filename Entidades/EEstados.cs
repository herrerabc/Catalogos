using System;

namespace Entidades
{
    public class EEstados
    {
        public int Id { get; set; } //(int 4)  not null
        public int IdPais { get; set; } //(int 4)  not null
        public string descripcion { get; set; } //(varchar 70)  null
    }
}