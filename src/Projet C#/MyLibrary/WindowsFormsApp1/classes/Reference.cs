namespace MyLibrary.classes
{
    public class Reference
    {
        #region Variables d'instances
        private int _idReference, _idType, _livreReference, _idUtilisateur;
        private string _nomReference, _nomImage, _auteur;
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

        public int IdUtilisateur
        {
            get { return _idUtilisateur; }
            set { _idUtilisateur = value; }
        }
        #endregion

        #region Constructeurs
        public Reference(int idReference, string nomReference, string nomImage, string auteur, int idType, int livreReference, int idUtilisateur)
        {
            _idReference = idReference;
            _nomReference = nomReference;
            _nomImage = nomImage;
            _auteur = auteur;
            _idType = idType;
            _livreReference = livreReference;
            _idUtilisateur = idUtilisateur;
        }

        //public Reference
        #endregion
    }
}
