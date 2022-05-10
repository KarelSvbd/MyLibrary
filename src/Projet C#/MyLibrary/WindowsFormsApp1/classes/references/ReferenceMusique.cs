using MyLibrary.classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class ReferenceMusique : Reference
    {
        public ReferenceMusique(int idReference, string nomImage, string titre, string auteur, int idLivre) : base(idReference, titre, nomImage, auteur, 2, 0, idLivre, ""){ }

        public override bool PostReference(Utilisateur utilisateur)
        {
            return ClientRest.Instance.AppelSimple("?table=references&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&nomReference=" + NomReference + "&auteur=" + Auteur + "&nomImage=" + NomImage + "&idLivre=" + IdLivre + "&idType=" +IdType+ "", "POST");
        }

        public override bool PutReference(Utilisateur utilisateur, Reference reference)
        {
            return ClientRest.Instance.AppelSimple("?table=references&idReference="+reference.IdReference.ToString()+"&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&nomReference=" + NomReference + "&auteur=" + Auteur + "&nomImage=" + NomImage + "&idLivre=" + IdLivre + "&idType=" + IdType + "", "PUT");
        }
    }
}
