/* Projet   : MyLibrary - TPI 2022
 * Version  : 0.8.1
 * Date     : 16.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : ReferenceMusique.cs class
 * Decs.    : Permet de créer une référence de type musique
 */

using MyLibrary.classes;

namespace MyLibrary
{
    public class ReferenceMusique : Reference
    {
        /// <summary>
        /// Permet de créer une référence de type musique
        /// </summary>
        /// <param name="idReference">int(11)</param>
        /// <param name="nomImage">varchar(255)</param>
        /// <param name="titre">varchar(255)</param>
        /// <param name="auteur">varchar(100)</param>
        /// <param name="idLivre">int(11)</param>
        public ReferenceMusique(int idReference, string nomImage, string titre, string auteur, int idLivre) : base(idReference, titre, nomImage, auteur, 2, 0, idLivre, ""){ }

        /// <summary>
        /// Permet d'envoyer la référence à l'API
        /// </summary>
        /// <param name="utilisateur">Utilisateur qui envoie la référence</param>
        /// <returns>
        /// true = code 201
        /// false = erreur
        /// </returns>
        public override bool PostReference(Utilisateur utilisateur)
        {
            return ClientRest.Instance.AppelSimple("?table=references&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&nomReference=" + NomReference + "&auteur=" + Auteur + "&nomImage=" + NomImage + "&idLivre=" + IdLivre + "&idType=" +IdType+ "", "POST");
        }

        /// <summary>
        /// Permet de modifier une référence par l'API
        /// </summary>
        /// <param name="utilisateur">Utilisateur qui modifie la référence</param>
        /// <param name="reference">Nouvelles données de la référence</param>
        /// <returns>
        /// true = code 201
        /// false = erreur
        /// </returns>
        public override bool PutReference(Utilisateur utilisateur, Reference reference)
        {
            return ClientRest.Instance.AppelSimple("?table=references&idReference="+ IdReference.ToString() +"&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&nomReference=" + reference.NomReference + "&auteur=" + reference.Auteur + "&nomImage=" + reference.NomImage + "&idLivre=" + reference.IdLivre + "&idType=" + reference.IdType + "", "PUT");
        }
    }
}
