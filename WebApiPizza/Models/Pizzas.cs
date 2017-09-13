using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPizza.Models
{
    public class Pizzas
    {
        public int id_pizza { get; set; }
        public string nombre { get; set; }
        public string ingredientes { get; set; }
        public string precio { get; set; }
        public string ruta { get; set; }        
    }
}