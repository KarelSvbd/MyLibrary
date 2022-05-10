/* Projet   : MyLibrary - TPI 2022
 * Version  : 0.6
 * Date     : 10.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : ReferenceLieu.cs
 * Decs.    : Vue de la collection des références d'un livre
 */

using MyLibrary.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class ReferenceLieu : Reference
    {
        private const string DEFAULT_DESCRIPTION = "";

        public ReferenceLieu(int idReference, string titre, string description, int idLivre) : base(idReference, titre, "", "", 3, 0, idLivre, description) { }

        public ReferenceLieu(int idReference, string titre, int idLivre) : this(idReference, titre, DEFAULT_DESCRIPTION, idLivre) { }

        public override bool PostReference(Utilisateur utilisateur)
        {
            return false;
        }

        /*
         *  public bool PostLivre(Utilisateur utilisateur)
        {
            return _clientRest.AppelSimple("?email="+utilisateur.Email+"&password="+utilisateur.Password+"&titre="+_titre+"&auteur="+_auteur+"&nomImage="+_nomImage+"", "POST");
            
            //Messagebox _clientRest.ApiRequest("", "POST");
        }

        public bool PutLivre(Utilisateur utilisateur, Livre nouvellesDonnees)
        {
            _auteur = nouvellesDonnees.Auteur;
            _titre = nouvellesDonnees.Titre;
            _nomImage = nouvellesDonnees.NomImage;

            return _clientRest.AppelSimple("?email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&titre=" + _titre + "&auteur=" + _auteur + "&nomImage=" + _nomImage + "&table=livres&idLivre=" + _idLivre + "", "PUT");        
        }

        public bool DeleteLivre(Utilisateur utilisateur)
        {
            return _clientRest.AppelSimple("?email="+utilisateur.Email+"&password="+utilisateur.Email+"&table=livres&idLivre="+_idLivre+"", "DELETE");
        }
        */

    }
}
