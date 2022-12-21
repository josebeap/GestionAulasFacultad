using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GestionAulasFacultad.Helpers
{
    public class Mensajes
    {
        public static String mensajeErrorEliminar = ConfigurationManager.AppSettings["MensajeErrorAlEliminar"];
        public static String mensajeEdicionCorrecta = ConfigurationManager.AppSettings["MensajeEdicionCorrecta"];
        public static String ExceptionMessage = "Ha ocurrido un error ejecutando la acción.";
        public static String alreadyExistMessage = "Ya existe un registro con esta información";
    }
}