using System;

namespace Entidades
{
    public class EMunicipios
    {
        public int Id { get; set; } //(int 4)  not null
        public int IdEstado { get; set; } //(int 4)  not null
        public string descripcion { get; set; } //(varchar 70)  null
    }
}