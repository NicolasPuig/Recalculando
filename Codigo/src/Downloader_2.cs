using System;
using System.IO;
using System.Net;
using System.Collections;
using System.Collections.Generic;

namespace src
{
    /// <summary>
    /// Descarga archivos de una ubicación de la forma "http://server/directory/file" o
    /// "file:///drive:/directory/file"
    /// </summary>
    public class Downloader
    {
        private string url;

        /// <summary>
        /// La ubicación de la cual descargar
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        /// <summary>
        /// Crea una nueva instancia asignando la ubicación de la cual descargar
        /// </summary>
        /// <param name="url"></param>
        public Downloader(string url)
        {
            this.url = url;
        }

        /// <summary>
        /// Descarga contenido de la ubicación de la cual descargar
        /// </summary>
        /// <returns>Retorna el contenido descargado en una lista de lineas</returns>
        public List<string> Download()
        {
            // Creamos una nueva solicitud para el recurso especificado por la URL recibida
            WebRequest request = WebRequest.Create(url);
            // Asignamos las credenciales predeterminadas por si el servidor las pide
            request.Credentials = CredentialCache.DefaultCredentials;
            // Obtenemos la respuesta
            WebResponse response = request.GetResponse();
            // Obtenemos la stream con el contenido retornado por el servidor
            Stream stream = response.GetResponseStream();
            // Abrimos la stream con un lector para accederla más fácilmente
            StreamReader reader = new StreamReader(stream);
            // Leemos el contenido
            List<string> result = new List<string>();
            string linea = "";
            while (linea != "</html>")
            {
                linea = reader.ReadLine().Trim();
                result.Add(linea);
            }
            // Limpiamos cerrando lo que abrimos
            reader.Close();
            stream.Close();
            response.Close();
            return result;
        }
    }
}