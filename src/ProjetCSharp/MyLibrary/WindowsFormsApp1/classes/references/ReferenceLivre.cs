/* Projet   : MyLibrary - TPI 2022
 * Version  : 1.0
 * Date     : 18.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : ReferenceLivre.cs class
 * Decs.    : Permet de créer une référence de type Livre
 */

using MyLibrary.classes;

namespace MyLibrary
{
    public class ReferenceLivre : Reference
    {
        /// <summary>
        /// Permet de créer une référence de type Livre
        /// </summary>
        /// <param name="idReference">int(11)</param>
        /// <param name="livreReference">int(11)</param>
        /// <param name="idLivre">int(11)</param>
        public ReferenceLivre(int idReference, string NomImage, int livreReference, int idLivre) : base(idReference, "", NomImage, "", 1, livreReference, idLivre, "") { }

        /// <summary>
        /// Permet d'envoyer une référence de type livre dans la table référence (clé étangères)
        /// </summary>
        /// <param name="utilisateur">Utilisateur qui envoie la référence</param>
        /// <returns>
        /// true = 201
        /// false = erreur
        /// </returns>
        public override bool PostReference(Utilisateur utilisateur)
        {
            return ClientRest.Instance.AppelSimple("?table=references&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&idLivre=" + IdLivre.ToString() + "&idType=" + IdType.ToString() + "&livreReference=" + LivreReference.ToString() + "", "POST");
        }

        /// <summary>
        /// Permet de modifier la référence
        /// </summary>
        /// <param name="utilisateur">utilisateur qui modifie la référence</param>
        /// <param name="reference">novuelles données</param>
        /// <returns>
        /// true = 201
        /// false = erreur
        /// </returns>
        public override bool PutReference(Utilisateur utilisateur, Reference reference)
        {

            return ClientRest.Instance.AppelSimple("?table=references&idReference=" + IdReference.ToString() + "&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&nomReference=" + reference.NomReference + "&auteur=" + reference.Auteur + "&nomImage=" + reference.NomImage + "&idLivre=" + reference.IdLivre + "&idType=" + reference.IdType + "", "PUT");
        }

        /// <summary>
        /// Permet à l'utilisateur de modifier le livre de la class
        /// </summary>
        /// <param name="utilisateur">utilisateur qui modifie le livre (Prop : Email, Password)</param>
        /// <param name="nouvellesDonnees">Objet livre avec les nouvelles informations</param>
        /// <returns>True = code 201, False = erreur</returns>
        public bool PutLivre(Utilisateur utilisateur, Livre nouvellesDonnees)
        {
            //Mise à jour des varaibles d'instances
            string _auteur = nouvellesDonnees.Auteur;
            string _titre = nouvellesDonnees.Titre;
            string _nomImage = nouvellesDonnees.NomImage;
            int _idLivre = nouvellesDonnees.IdLivre;


            return ClientRest.Instance.AppelSimple("?email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&titre=" + _titre + "&auteur=" + _auteur + "&nomImage=" + _nomImage + "&table=livres&idLivre=" + _idLivre + "", "PUT");
        }
    }
}
