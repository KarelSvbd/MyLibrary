using MyLibrary.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class ReferenceLivre : Livre
    {
        public ReferenceLivre(int idLivre, string titre, string auteur, string nomImage, int idUtilisateur) : base(idLivre, titre, auteur, nomImage, idUtilisateur) { }
    }
}
