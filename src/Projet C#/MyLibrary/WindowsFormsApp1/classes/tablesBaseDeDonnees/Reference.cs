namespace MyLibrary.classes
{
    public class Reference
    {
        #region Variables d'instances
        private int _idReference, _idType, _livreReference, _idLivre;
        private string _nomReference, _nomImage, _auteur, _description;
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
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        
        
        #endregion

        #region Constructeurs
        public Reference(int idReference, string nomReference, string nomImage, string auteur, int idType, int livreReference, int idLivre, string description)
        {
            _idReference = idReference;
            _nomReference = nomReference;
            _nomImage = nomImage;
            _auteur = auteur;
            _idType = idType;
            _livreReference = livreReference;
            _idLivre = idLivre;
            _description = description;
        }

        public virtual bool PostReference(Utilisateur utilisateur)
        {
            return false;
        }

        public virtual bool PutReference(Utilisateur utilisateur, Reference reference)
        {
            return false;
        }

        public virtual bool DeleteReference(Utilisateur utilisateur)
        {
            return ClientRest.Instance.AppelSimple("?table=references&email=" + utilisateur.Email + "&password=" + utilisateur.Password + "&idReference=" + _idReference + "", "DELETE");
        }

        //public Reference
        #endregion
    }
}
