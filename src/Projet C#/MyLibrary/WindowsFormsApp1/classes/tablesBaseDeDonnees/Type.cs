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
        private string _nomType;
        
        public int IdType
        {
            get { return _idType; }
            set { _idType = value; }
        }

        public string NomType
        {
            get { return _nomType; }
            set { _nomType = value; }
        }


        public Type(int idType, string nomType)
        {
            _idType = idType;
            _nomType = nomType;
        }
    }
}
