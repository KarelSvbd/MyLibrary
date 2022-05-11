using MyLibrary.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class ReferenceLivre : Reference
    {
        public ReferenceLivre(int idReference, int livreReference, int idLivre) : base(idReference, "", "", "", 1, livreReference, idLivre, "") { }

        public override bool PostReference(Utilisateur utilisateur)
        {
            return ClientRest.Instance.AppelSimple("?table=references&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&idLivre=" + IdLivre.ToString() + "&idType=" + IdType.ToString() + "&livreReference=" + LivreReference.ToString() + "", "POST");
        }

        public bool PostLivreReference(Utilisateur utilisateur)
        {

            return ClientRest.Instance.AppelSimple("?table=references&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&titre=" + NomReference + "&auteur=" + Auteur + "&nomImage=" + NomImage + "&idLivre=" + IdLivre + "&idType=" + IdType + "", "POST");
        }

        public override bool PutReference(Utilisateur utilisateur, Reference reference)
        {
            return ClientRest.Instance.AppelSimple("?table=references&idReference=" + IdReference.ToString() + "&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&nomReference=" + reference.NomReference + "&auteur=" + reference.Auteur + "&nomImage=" + reference.NomImage + "&idLivre=" + reference.IdLivre + "&idType=" + reference.IdType + "", "PUT");
        }
    }
}
