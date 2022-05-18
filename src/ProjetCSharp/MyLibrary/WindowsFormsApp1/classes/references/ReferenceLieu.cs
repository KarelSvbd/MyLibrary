/* Projet   : MyLibrary - TPI 2022
 * Version  : 1.0
 * Date     : 18.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : ReferenceLieu.cs class
 * Decs.    : Permet de créer une référence de type Lieu
 */


using MyLibrary.classes;

namespace MyLibrary
{
    public class ReferenceLieu : Reference
    {
        #region constantes
        private const string DEFAULT_DESCRIPTIONLIEU = "";
        #endregion

        /// <summary>
        /// Permet de créer une référence de type Lieu avec la description
        /// </summary>
        /// <param name="idReference">int(11)</param>
        /// <param name="titre">varchar(255)</param>
        /// <param name="descriptionLieu">madiumtext</param>
        /// <param name="idLivre">int(11)</param>
        public ReferenceLieu(int idReference, string titre, string descriptionLieu, int idLivre) : base(idReference, titre, "", "", 3, 0, idLivre, descriptionLieu) { }

        /// <summary>
        /// Permet de créer une référence de type Lieu sans description
        /// </summary>
        /// <param name="idReference">int(11)</param>
        /// <param name="titre">varchar(255)</param>
        /// <param name="idLivre">int(11)</param>
        public ReferenceLieu(int idReference, string titre, int idLivre) : this(idReference, titre, DEFAULT_DESCRIPTIONLIEU, idLivre) { }

        /// <summary>
        /// Permet d'ajouter la référence dans la base par l'API
        /// </summary>
        /// <param name="utilisateur">Utilisateur qui ajoute la référence</param>
        /// <returns>
        /// true = 201
        /// false = erreur
        /// </returns>
        public override bool PostReference(Utilisateur utilisateur)
        {
            return ClientRest.Instance.AppelSimple("?table=references&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&nomReference=" + NomReference + "&descriptionLieu=" + DescriptionLieu + "&idLivre=" + IdLivre.ToString() + "&idType=" + IdType.ToString() + "", "POST");
        }

        /// <summary>
        /// Permet de modifier une référence dans la base par l'API
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <param name="reference"></param>
        /// <returns>
        /// true = 201
        /// false = erreur
        /// </returns>
        public override bool PutReference(Utilisateur utilisateur, Reference reference)
        {
            return ClientRest.Instance.AppelSimple("?table=references&idReference=" + IdReference.ToString() + "&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&nomReference=" + reference.NomReference + "&descriptionLieu=" + reference.DescriptionLieu + "&idLivre=" + reference.IdLivre + "&idType=" + reference.IdType + "", "PUT");
        }
    }
}
