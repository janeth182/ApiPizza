using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPizza.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;

namespace WebApiPizza.Controllers
{
    public class HomeController : ApiController
    {        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnPizzas"].ConnectionString);
        [HttpGet]
        public IHttpActionResult Pizzas()
        {
            List<Pizzas> lPizzas = lstPizzas();
            return Ok(lPizzas); 
        }

        [HttpGet]
        public IHttpActionResult Piqueo()
        {
            List<Piqueo> lPiqueo = lstPiqueos();
            return Ok(lPiqueo);
        }
        #region DA
        public List<Pizzas> lstPizzas()
        {
            
            List<Pizzas> lstPizzas = null;
            con.Open();
            SqlCommand cmd = new SqlCommand("lstPizzas", con);
            cmd.CommandType = CommandType.StoredProcedure;            
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                lstPizzas = new List<Pizzas>();
                Pizzas oPizzas;
                while (drd.Read())
                {
                    if (drd.HasRows && !drd.IsDBNull(drd.GetOrdinal("id_pizza")))
                    {
                        oPizzas = new Pizzas();
                        oPizzas.id_pizza = drd.GetInt32(drd.GetOrdinal("id_pizza"));
                        oPizzas.nombre = drd.GetString(drd.GetOrdinal("nombre"));
                        oPizzas.ingredientes = drd.GetString(drd.GetOrdinal("ingredientes"));
                        oPizzas.precio = drd.GetString(drd.GetOrdinal("precio"));
                        oPizzas.ruta = drd.GetString(drd.GetOrdinal("ruta"));                        
                        lstPizzas.Add(oPizzas);
                    }
                }
                drd.Close();
            }
            return lstPizzas;
        }
        public List<Piqueo> lstPiqueos()
        {

            List<Piqueo> lstPiqueos = null;
            con.Open();
            SqlCommand cmd = new SqlCommand("lstPiqueo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                lstPiqueos = new List<Piqueo>();
                Piqueo oPiqueo;
                while (drd.Read())
                {
                    if (drd.HasRows && !drd.IsDBNull(drd.GetOrdinal("id_piqueo")))
                    {
                        oPiqueo = new Piqueo();
                        oPiqueo.id_piqueo = drd.GetInt32(drd.GetOrdinal("id_piqueo"));
                        oPiqueo.nombre_piqueo = drd.GetString(drd.GetOrdinal("nombre_piqueo"));
                        oPiqueo.ingredientes_piqueo = drd.GetString(drd.GetOrdinal("ingredientes_piqueo"));
                        oPiqueo.precio_piqueo = drd.GetString(drd.GetOrdinal("precio_piqueo"));
                        oPiqueo.ruta_piqueo = drd.GetString(drd.GetOrdinal("ruta_piqueo"));
                        lstPiqueos.Add(oPiqueo);
                    }
                }
                drd.Close();
            }
            return lstPiqueos;
        }

        #endregion
    }
}
