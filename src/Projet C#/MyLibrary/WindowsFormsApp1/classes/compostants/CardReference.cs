using MyLibrary.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace MyLibrary
{
    public abstract class CardReference : Card
    {
        Reference _reference;
        frmCollectionReferences _frm;

        public Reference ObjReference
        {
            get { return _reference; }
            set { _reference = value; }
        }

        protected frmCollectionReferences Frm
        {
            get { return _frm; }
            set { _frm = value; }
        }
        public CardReference(Reference reference, frmCollectionReferences frm) : base()
        {
            _reference = reference;
            _frm = frm;
            Click += ClickCard;
        }
    }
}
