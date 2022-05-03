using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.classes
{
    public class Type
    {
        private int _idType;
        private string _nomType, _nomImage, _auteur, _description;
        
        public int IdType
        {
            get { return _idType; }
            set { _idType = value; }
        }

        public string NomType
        {
            get { return _nomType; }
            set { _nomImage = value; }
        }

        public string NomImage
        {
            get { return _nomImage; }
            set { _nomImage=value; }
        }

        public string Auteur
        {
            get { return _auteur; }
            set { _auteur = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Type(int idType, string nomType, string nomImage, string auteur, string description)
        {
            _idType = idType;
            _nomType = nomType;
            _nomImage = nomImage;
            _auteur = auteur;
            _description = description;
        }
    }
}
