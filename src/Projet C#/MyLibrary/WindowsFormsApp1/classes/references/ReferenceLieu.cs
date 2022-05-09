using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class ReferenceLieu
    {
        string _titre, _description;
        private const string DEFAULT_DESCRIPTION = "";

        public string Titre
        {
            get { return _titre; }
            set { _titre = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public ReferenceLieu(string titre, string description)
        {
            _titre = titre;
            _description = description;
        }

        public ReferenceLieu(string titre) : this(titre, DEFAULT_DESCRIPTION) { }

    }
}
