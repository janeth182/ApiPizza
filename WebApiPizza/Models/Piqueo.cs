using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPizza.Models
{
    public class Piqueo
    {
        public int id_piqueo { get; set; }
        public string nombre_piqueo { get; set; }
        public string ingredientes_piqueo { get; set; }
        public string precio_piqueo { get; set; }
        public string ruta_piqueo { get; set; }
    }
}