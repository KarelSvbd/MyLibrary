namespace MyLibrary.classes
{
    public class Livre
    {
        #region Variables d'instances
        private int _idLivre, _idUtilisateur;
        private string _titre, _auteur, _nomImage;
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
            _idLivre=idLivre;
            _titre=titre;
            _auteur=auteur;
            _nomImage=nomImage;
            _idUtilisateur=idUtilisateur;
        }
    }
}
