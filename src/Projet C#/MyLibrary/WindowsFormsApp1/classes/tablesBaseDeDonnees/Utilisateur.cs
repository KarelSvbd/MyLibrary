/* Projet   : MyLibrary - TPI 2022
 * Version  : 0.8.1
 * Date     : 16.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : Type.cs class
 * Decs.    : Permet d'encapsuler la table Utilisateurs de la base de données
 */

namespace MyLibrary.classes
{
    public class Utilisateur
    {
        #region Variables d'instances
        private int _idUtilisateur;
        private string _email, _password;
        private ClientRest _clientRest;
        #endregion

        #region Constantes
        private const int DEFAULT_IDUTILISATEUR = 0;
        #endregion

        #region Propriétées
        public int IdUtilisateur
        {
            get { return _idUtilisateur; }
            set { _idUtilisateur = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Permet d'encapsuler la table Utilisateurs de la base de données
        /// </summary>
        /// <param name="idUtilisateur">int(11)</param>
        /// <param name="email">varchar(255)</param>
        /// <param name="password">varchar(255)</param>
        public Utilisateur(int idUtilisateur, string email, string password)
        {
            _clientRest = ClientRest.Instance;
            _idUtilisateur = idUtilisateur;
            _email = email;
            _password = password;
        }

        /// <summary>
        /// Permet d'encapsuler la table Utilisateurs de la base de données sans idUTilisateur
        /// </summary>
        /// <param name="email">varchar(255)</param>
        /// <param name="password">varchar(255)</param>
        public Utilisateur(string email, string password) : this(DEFAULT_IDUTILISATEUR, email, password){ }
        #endregion

        #region Methodes
        /// <summary>
        /// Permet de faire une tentative de connexion avec les données de la classe
        /// </summary>
        /// <returns>
        /// true = code 200 (connexion ok et l'utilisateur est connecté dans la base)
        /// false = erreur ou mauvaise données de connexion erronées
        /// </returns>
        public bool TestConnexion()
        {
            return _clientRest.AppelSimple("?session=connexion&email=" + _email + "&password=" + _password + "", "get");
        }
        
        /// <summary>
        /// Permet à l'utilisateur de se déconnecter 
        /// L'UTILISATEUR DOIT SE RECONNECTER S'IL VEUT REFAIRE DES REQUÊTES à L'API
        /// </summary>
        /// <returns>
        /// true = code 200 (déconnexion ok)
        /// false = erreur
        /// </returns>
        public bool Deconnexion()
        {
            return _clientRest.AppelSimple("?session=deconnexion&email=" + _email + "&password=" + _password + "", "get");
        }

        #endregion
    }
}
