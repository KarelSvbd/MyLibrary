using MyLibrary.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class ReferenceLivre : Reference
    {
        public ReferenceLivre(int idReference, int idLivreReference, int idLivre) : base(idReference, "", "", "", 1, idLivreReference, idLivre, "") { }
    }
}
