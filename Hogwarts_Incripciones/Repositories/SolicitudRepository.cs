using Hogwarts_Incripciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hogwarts_Incripciones.Repositories
{
    public class SolicitudRepository
    {
        
         public static List<Solicitud> _Solicitudes = new List<Solicitud>();

        public SolicitudRepository()
        {
            _Solicitudes.Add(new Solicitud()
            {
                Nombre = "Harry",
                Apellido = "Potter",
                Casa = "Gryffindor",
                Edad = 8,
                Identificacion = 1
            });
            _Solicitudes.Add(new Solicitud()
            {
                Nombre = "Hermione",
                Apellido = "Granger",
                Casa = "Gryffindor",
                Edad = 8,
                Identificacion = 2
            });
            _Solicitudes.Add(new Solicitud()
            {
                Nombre = "Ron",
                Apellido = "Weasley",
                Casa = "Gryffindor",
                Edad = 8,
                Identificacion = 3
            });
            _Solicitudes.Add(new Solicitud()
            {
                Nombre = "Draco",
                Apellido = "Malfoy",
                Casa = "Slytherin",
                Edad = 8,
                Identificacion = 4
            });
        }
        public void Agregar(Solicitud item){
            _Solicitudes.Add(item);
        }
        public void Eliminar(Solicitud item) {
            _Solicitudes.Remove(item);
        }
        public void Modificar(int identificacion, Solicitud item) {
            int index = _Solicitudes.FindIndex(sol => sol.Identificacion == identificacion);
            if (index > -1) {
                Solicitud toUpdate= _Solicitudes.ElementAt(index) ;
                foreach (PropertyInfo prop in toUpdate.GetType().GetProperties())                
                    prop.SetValue(toUpdate, item.GetType().GetProperty(prop.Name).GetValue(item));
            }
        }
        public IQueryable<Solicitud> Listado() {
            return _Solicitudes.AsQueryable();
        }
        public Solicitud Obtener(int identificacion) {
            return _Solicitudes.Where(s => s.Identificacion == identificacion).FirstOrDefault();
        }
    }
}
