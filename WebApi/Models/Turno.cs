using System;

namespace WebApi.Models
{
    public class Turno
    {
        public int Id {get;set;}
        public Sector Sector {get;set;}

        public DateTime Fecha {get;set;}

        public Usuario Usuario {get;set;}

        public bool isConfirmado {get;set;}

        public bool isAsistio {get;set;}

    }
}