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

        public Livre(int idLivre, string titre, string auteur, string nomImage, int idUtilisateur)
        {
            _clientRest = ClientRest.Instance;
            _idLivre =idLivre;
            _titre=titre;
            _auteur=auteur;
            _nomImage=nomImage;
            _idUtilisateur=idUtilisateur;
        }

        public bool PostLivre(Utilisateur utilisateur)
        {
            return _clientRest.AppelSimple("?table=livres&email="+utilisateur.Email+"&password="+utilisateur.Password+"&titre="+_titre+"&auteur="+_auteur+"&nomImage="+_nomImage+"", "POST");
            
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
            return _clientRest.AppelSimple("?email="+utilisateur.Email+"&password="+utilisateur.Password+"&table=livres&idLivre="+_idLivre+"", "DELETE");
        }
    }
}
