/* Projet   : MyLibrary - TPI 2022
 * Version  : 0.8.1
 * Date     : 16.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : Livre.cs class
 * Decs.    : Permet d'encapsuler la table Livres de la base de données
 */

namespace MyLibrary.classes
{
    public class Livre
    {
        #region Variables d'instances
        private int _idLivre, _idUtilisateur;
        private string _titre, _auteur, _nomImage;
        private ClientRest _clientRest;
        #endregion

        #region Propriétés
        public int IdLivre
        {
            get { return _idLivre; }
            set { _idLivre = value; }
        }

        public int IdUtilisateur
        {
            get { return _idUtilisateur; }
            set { _idUtilisateur = value; }
        }

        public string Titre
        {
            get { return _titre; }
            set { _titre = value; }
        }

        public string Auteur
        {
            get { return _auteur; }
            set { _auteur = value; }
        }

        public string NomImage
        {
            get { return _nomImage; }
            set { _nomImage = value; }
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Permet d'encapsuler la table Livres de la base de données
        /// </summary>
        /// <param name="idLivre">int(11)</param>
        /// <param name="titre">varchar(255)</param>
        /// <param name="auteur">varchar(100)</param>
        /// <param name="nomImage">varchar(255)</param>
        /// <param name="idUtilisateur">int(11)</param>
        public Livre(int idLivre, string titre, string auteur, string nomImage, int idUtilisateur)
        {
            _clientRest = ClientRest.Instance;
            _idLivre =idLivre;
            _titre=titre;
            _auteur=auteur;
            _nomImage=nomImage;
            _idUtilisateur=idUtilisateur;
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Permet à un utilisateur d'envoyer le livre de la class
        /// </summary>
        /// <param name="utilisateur">utilisateur qui envoie le livre (Prop : Email, Password) </param>
        /// <returns>True = code 201, False = erreur</returns>
        public bool PostLivre(Utilisateur utilisateur)
        {
            return _clientRest.AppelSimple("?table=livres&email="+utilisateur.Email+"&password="+utilisateur.Password+"&titre="+_titre+"&auteur="+_auteur+"&nomImage="+_nomImage+"", "POST");
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
            _auteur = nouvellesDonnees.Auteur;
            _titre = nouvellesDonnees.Titre;
            _nomImage = nouvellesDonnees.NomImage;


            return _clientRest.AppelSimple("?email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&titre=" + _titre + "&auteur=" + _auteur + "&nomImage=" + _nomImage + "&table=livres&idLivre=" + _idLivre + "", "PUT");        
        }

        /// <summary>
        /// Permet de supprimer le livre de la class
        /// </summary>
        /// <param name="utilisateur">utilisateur qui souhaite supprimer le livre</param>
        /// <returns>True = code 201, False = erreur</returns>
        public bool DeleteLivre(Utilisateur utilisateur)
        {
            return _clientRest.AppelSimple("?email="+utilisateur.Email+"&password="+utilisateur.Password+"&table=livres&idLivre="+_idLivre+"", "DELETE");
        }
        #endregion
    }
}
