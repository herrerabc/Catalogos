using System;

namespace Entidades
{ 
    public class EColonias
    {
        public int Id { get; set; } //(int 4)  not null
        public int IdEstado { get; set; } //(int 4)  not null
        public int IdMunicipio { get; set; } //(int 4)  not null
        public long cp { get; set; } //(bigint 8)  not null
        public string Descripcion { get; set; } //(varchar 120)  null
    }
}