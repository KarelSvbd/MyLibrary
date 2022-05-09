using MyLibrary.classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class ReferenceMusique
    {
        private Image _pochette;
        private string _titre;
        private string _auteur;
        private Reference _reference;

        public Image Pochette
        {
            get { return _pochette; }
            set { _pochette = value; }
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

        public ReferenceMusique(Image pochette, string titre, string auteur)
        {
            _pochette = pochette;
            _titre = titre;
            _auteur = auteur;
        }
    }
}
