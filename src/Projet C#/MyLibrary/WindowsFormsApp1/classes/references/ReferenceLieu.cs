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
        private const string DEFAULT_RESUME = "";

        public ReferenceLieu(int idReference, string titre, string descriptionLieu, int idLivre) : base(idReference, titre, "", "", 3, 0, idLivre, descriptionLieu) { }

        public ReferenceLieu(int idReference, string titre, int idLivre) : this(idReference, titre, DEFAULT_RESUME, idLivre) { }

        public override bool PostReference(Utilisateur utilisateur)
        {
            Console.WriteLine("?table=references&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&nomReference=" + NomReference + "&descriptionLieu=" + DescriptionLieu + "&idLivre=" + IdLivre.ToString() + "&idType=" + IdType.ToString() + "");
            return ClientRest.Instance.AppelSimple("?table=references&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&nomReference=" + NomReference + "&descriptionLieu=" + DescriptionLieu + "&idLivre=" + IdLivre.ToString() + "&idType=" + IdType.ToString() + "", "POST");
        }

        public override bool PutReference(Utilisateur utilisateur, Reference reference)
        {
            Console.WriteLine(reference.IdType);
            return ClientRest.Instance.AppelSimple("?table=references&idReference=" + IdReference.ToString() + "&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&nomReference=" + reference.NomReference + "&descriptionLieu=" + reference.DescriptionLieu + "&idLivre=" + reference.IdLivre + "&idType=" + reference.IdType + "", "PUT");
        }
    }
}
