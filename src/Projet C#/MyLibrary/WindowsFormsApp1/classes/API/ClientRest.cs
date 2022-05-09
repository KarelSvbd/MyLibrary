using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrary.classes
{
    public sealed class ClientRest
    {
        private string _cheminApi;
        private static ClientRest instance = null;

        private ClientRest()
        {
            _cheminApi = "http://localhost/ProjetsWeb/MyLibrary/src/API_MyLibrary/";
        }

        //https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
        public static ClientRest Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientRest();
                }
                return instance;
            }
        }


        /// <summary>
        /// Permet de faire une requête à une API
        /// </summary>
        /// <param name="url">url de la demande</param>
        /// <returns>le résultat de la requête</returns>
        public string ApiRequest(string url, string method)
        {
            string strresulttest = null;
            try
            {
                url = _cheminApi + url;
                string strurltest = String.Format(url);
                WebRequest requestObject = WebRequest.Create(strurltest);
                requestObject.Method = method.ToUpper();
                HttpWebResponse responseObject = null;
                responseObject = (HttpWebResponse)requestObject.GetResponse();

                
                using (Stream steam = responseObject.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(steam);
                    strresulttest = sr.ReadToEnd();
                    var settings = new JsonSerializerSettings();
                    settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            

            return strresulttest;
        }


        public bool AppelSimple(string url, string method)
        {
            try
            {
                url = _cheminApi + url;
                string strurltest = String.Format(url);
                WebRequest requestObject = WebRequest.Create(strurltest);
                requestObject.Method = method.ToUpper();
                HttpWebResponse responseObject = null;
                responseObject = (HttpWebResponse)requestObject.GetResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }


        /// <summary>
        /// Permet de désérialiser le JSON
        /// https://www.youtube.com/watch?v=CjoAYslTKX0
        /// </summary>
        /// <param name="strJson">string en Json</param>
        public dynamic DeserialiseJSON(string strJson)
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

        public List<Livre> LivresParUtilisateur(Utilisateur utilisateur)
        {
            List<Livre> livres = new List<Livre>();
            dynamic livresDynamic = DeserialiseJSON(ApiRequest("?email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&table=livres", "GET"));
            foreach(var element in livresDynamic)
            {
                livres.Add(new Livre(Convert.ToInt32(element["idLivre"]), Convert.ToString(element["titre"]), Convert.ToString(element["auteur"]), Convert.ToString(element["nomImage"]), Convert.ToInt32(element["idUtilisateur"])));
            }
            return livres;
        }

        public List<Livre> LivresParUtilisateur(Utilisateur utilisateur, string recherche)
        {
            List<Livre> livres = new List<Livre>();
            dynamic livresDynamic = DeserialiseJSON(ApiRequest("?email="+utilisateur.Email+"&password="+utilisateur.Password+"&table=livres&recherche="+recherche+"", "GET"));
            foreach (var element in livresDynamic)
            {
                livres.Add(new Livre(Convert.ToInt32(element["idLivre"]), Convert.ToString(element["titre"]), Convert.ToString(element["auteur"]), Convert.ToString(element["nomImage"]), Convert.ToInt32(element["idUtilisateur"])));
            }
            return livres;
        }

        public List<Type> TousTypes(Utilisateur utilisateur)
        {
            List<Type> types = new List<Type>();
            dynamic typesDynamic = DeserialiseJSON(ApiRequest("?email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&table=types", "GET"));
            foreach(var element in typesDynamic)
            {
                types.Add(new Type(Convert.ToInt32(element["idType"]), Convert.ToString(element["nomType"])));
            }

            return types;
        }

        public List<Reference> ReferencesParLivre(Utilisateur utilisateur, Livre livre)
        {
            List<Reference> referencesParLivre = new List<Reference>();
            return null;
        }
    }
}
