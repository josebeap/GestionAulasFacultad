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
    }
}