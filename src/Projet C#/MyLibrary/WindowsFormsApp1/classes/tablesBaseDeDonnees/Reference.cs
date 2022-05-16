/* Projet   : MyLibrary - TPI 2022
 * Version  : 0.8.1
 * Date     : 16.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : References.cs class
 * Decs.    : Permet d'encapsuler la table References de la base de données
 *            Sert également de class mère aux références livre, musique et lieu
 */

namespace MyLibrary.classes
{
    public class Reference
    {
        #region Variables d'instances
        private int _idReference, _idType, _livreReference, _idLivre;
        private string _nomReference, _nomImage, _auteur, _descriptionLieu;
        #endregion

        #region Propriétés
        public int IdReference
        {
            get { return _idReference; }
            set { _idReference = value; }
        }

        public string NomReference
        {
            get { return _nomReference; }
            set { _nomReference = value; }
        }

        public string NomImage
        {
            get { return _nomImage; }
            set { _nomImage = value; }
        }

        public string Auteur
        {
            get { return _auteur; }
            set { _auteur = value; }
        }

        public int IdType
        {
            get { return _idType; }
            set { _idType = value; }
        }

        public int LivreReference
        {
            get { return _livreReference; }
            set { _livreReference = value; }
        }

        public int IdLivre
        {
            get { return _idLivre; }
            set { _idLivre = value; }
        }
        public string DescriptionLieu
        {
            get { return _descriptionLieu; }
            set { _descriptionLieu = value; }
        }



        #endregion

        #region Constructeurs
        /// <summary>
        /// Permet d'encapsuler la table References de la base de données
        /// Sert également de class mère aux références livre, musique et lieu
        /// </summary>
        /// <param name="idReference">int(11)</param>
        /// <param name="nomReference">varchar(255)</param>
        /// <param name="nomImage">varchar(255)</param>
        /// <param name="auteur">varchar(100)</param>
        /// <param name="idType">int(11)</param>
        /// <param name="livreReference">int(11) livres, idLivres</param>
        /// <param name="idLivre">int(11) livres, IdLivres </param>
        /// <param name="descriptionLieu">mediumtext</param>
        public Reference(int idReference, string nomReference, string nomImage, string auteur, int idType, int livreReference, int idLivre, string descriptionLieu)
        {
            _idReference = idReference;
            _nomReference = nomReference;
            _nomImage = nomImage;
            _auteur = auteur;
            _idType = idType;
            _livreReference = livreReference;
            _idLivre = idLivre;
            _descriptionLieu = descriptionLieu;
        }

        /// <summary>
        /// Sert de modèles aux class enfants
        /// Permet d'envoyer la référence à l'API
        /// </summary>
        /// <param name="utilisateur">Utilisateur qui envoie la référence</param>
        /// <returns>Retourne forcément false si elle n'est pas override</returns>
        public virtual bool PostReference(Utilisateur utilisateur)
        {
            return false;
        }

        /// <summary>
        /// Sert de modèles aux class enfants
        /// Permet de modifier la référence à l'API
        /// </summary>
        /// <param name="utilisateur">Utilisateur qui envoie la référence</param>
        /// <param name="reference">nouvelles données de la référence</param>
        /// <returns>Retourne forcément false si elle n'est pas override</returns>
        public virtual bool PutReference(Utilisateur utilisateur, Reference reference)
        {
            return false;
        }

        /// <summary>
        /// Sert de modèles aux class enfants
        /// Permet de supprimer la référence à l'API
        /// </summary>
        /// <param name="utilisateur">Utilisateur qui supprime la référence</param>
        /// <returns>Retourne forcément false si elle n'est pas override</returns>
        public virtual bool DeleteReference(Utilisateur utilisateur)
        {
            return ClientRest.Instance.AppelSimple("?table=references&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&idReference=" + _idReference + "", "DELETE");
        }

        //public Reference
        #endregion
    }
}
