using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.classes
{
    public class ClientRest
    {
        private string _cheminApi;
        public ClientRest(string cheminApi)
        {
            _cheminApi = cheminApi;
        }
        /// <summary>
        /// Permet de faire une requête à une API
        /// </summary>
        /// <param name="url">url de la demande</param>
        /// <returns>le résultat de la requête</returns>
        public string ApiRequest(string url, string method)
        {
            url = _cheminApi + url;
            string strurltest = String.Format(url);
            WebRequest requestObject = WebRequest.Create(strurltest);
            requestObject.Method = method.ToUpper();
            HttpWebResponse responseObject = null;
            responseObject = (HttpWebResponse)requestObject.GetResponse();

            string strresulttest = null;
            using (Stream steam = responseObject.GetResponseStream())
            {
                StreamReader sr = new StreamReader(steam);
                strresulttest = sr.ReadToEnd();
                var settings = new JsonSerializerSettings();
                settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                sr.Close();
            }

            return DeserialiseJSON(strresulttest);
        }

        /// <summary>
        /// Permet de désérialiser le JSON
        /// https://www.youtube.com/watch?v=CjoAYslTKX0
        /// </summary>
        /// <param name="strJson">string en Json</param>
        private dynamic DeserialiseJSON(string strJson)
        {
            try
            {
                var jPerson = JsonConvert.DeserializeObject<dynamic>(strJson);

                return jPerson;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex);
                return null;
            }
        }
    }
}
