/* Projet   : MyLibrary - TPI 2022
 * Version  : 0.6
 * Date     : 10.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : ClientRest.cs Class
 * Decs.    : Sert à faire des appels à l'API
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace MyLibrary.classes
{
    public sealed class ClientRest
    {
        #region variables d'instances
        private string _cheminApi;
        private static ClientRest instance = null;
        #endregion

        #region constructeurs
        private ClientRest()
        {
            _cheminApi = "http://localhost/ProjetsWeb/MyLibrary/src/API_MyLibrary/";
        }
        #endregion

        #region propriétés
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
        #endregion


        #region Methodes
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

        /// <summary>
        /// Fait un appel avec une réponse en booléen en fonction du code de l'API
        /// </summary>
        /// <param name="url">url relatif</param>
        /// <param name="method">GET, POST, DELETE, PUT</param>
        /// <returns></returns>
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

        /// <summary>
        /// Permet de récupérer les livres par leur utilisateur
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <returns></returns>
        public List<Livre> LivresParUtilisateur(Utilisateur utilisateur)
        {
            List<Livre> livres = new List<Livre>();
            try
            {
                dynamic livresDynamic = DeserialiseJSON(ApiRequest("?email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&table=livres", "GET"));
                foreach (var element in livresDynamic)
                {
                    livres.Add(new Livre(Convert.ToInt32(element["idLivre"]), Convert.ToString(element["titre"]), Convert.ToString(element["auteur"]), Convert.ToString(element["nomImage"]), Convert.ToInt32(element["idUtilisateur"])));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            return livres;
        }

        /// <summary>
        /// Permet de récupérer les livres par leur utilisateur et une recherche personnalisée
        /// </summary>
        /// <param name="utilisateur">utilisateur</param>
        /// <param name="recherche">chaine personnalisée</param>
        /// <returns></returns>
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

        /// <summary>
        /// Récupère tous les types
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Récupère tous toutes les références d'un livre et les classe en fonction du type
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <param name="livre"></param>
        /// <returns></returns>
        public List<Reference> ReferencesParLivre(Utilisateur utilisateur, Livre livre)
        {
            List<Reference> referencesParLivre = new List<Reference>();
            dynamic referencesDynamic = DeserialiseJSON(ApiRequest("?email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&table=references&idLivre=" +livre.IdLivre.ToString() +"", "GET"));
            foreach (var element in referencesDynamic)
            {
                switch (Convert.ToInt32(element["idType"]))
                {
                    case 1:
                        referencesParLivre.Add(new ReferenceLivre(Convert.ToInt32(element["idReference"]), Convert.ToString(element["nomImage"]), Convert.ToInt32(element["livreReference"]), Convert.ToInt32(element["idLivre"])));
                        break;
                    case 2:
                        referencesParLivre.Add(new ReferenceMusique(Convert.ToInt32(element["idReference"]), Convert.ToString(element["nomImage"]), Convert.ToString(element["nomReference"]), Convert.ToString(element["auteur"]), Convert.ToInt32(element["idLivre"])));
                        break;
                    case 3:
                        if(element["descriptionLieu"] == null)
                        {
                            referencesParLivre.Add(new ReferenceLieu(Convert.ToInt32(element["idReference"]), Convert.ToString(element["nomReference"]), Convert.ToInt32(element["idLivre"])));
                        }
                        else
                        {
                            referencesParLivre.Add(new ReferenceLieu(Convert.ToInt32(element["idReference"]), Convert.ToString(element["nomReference"]), Convert.ToString(element["descriptionLieu"]), Convert.ToInt32(element["idLivre"])));
                        }
                        
                        break;
                }
            }

            return referencesParLivre;
        }

        /// <summary>
        /// Recupère un livre par son id
        /// </summary>
        /// <param name="utilisateur">utilisateur propriétaire du livre</param>
        /// <param name="idLivre">id du livre à rechercher</param>
        /// <returns></returns>
        public Livre LivreParIdLivre(Utilisateur utilisateur, int idLivre)
        {
            dynamic LivreDynamic = DeserialiseJSON(ApiRequest("?email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&table=livres&idLivre="+idLivre.ToString()+"", "GET"));
            return new Livre(Convert.ToInt32(LivreDynamic["idLivre"]), Convert.ToString(LivreDynamic["titre"]), Convert.ToString(LivreDynamic["auteur"]), Convert.ToString(LivreDynamic["nomImage"]), Convert.ToInt32(LivreDynamic["idUtilisateur"]));
            
        }

        /// <summary>
        /// Récupère le dernier livre de l'utlisateur
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <returns></returns>
        public int DernierLivreUtilisateur(Utilisateur utilisateur)
        {
            return Convert.ToInt32(DeserialiseJSON(ApiRequest("?email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&table=livres&tri=dernier", "GET")));
        }

        #endregion
    }
}
