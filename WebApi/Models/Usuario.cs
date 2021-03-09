using System.Collections;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class Usuario
    {
        public int Id{get;set;}
        public string Nombre {get;set;}
        public string DNI {get;set;}
        public List<Turno> Turnos {get;set;}
    }
}