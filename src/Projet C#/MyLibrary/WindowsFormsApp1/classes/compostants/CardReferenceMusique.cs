using MyLibrary.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class CardReferenceMusique : Card
    {
        private ReferenceMusique _reference;
        public CardReferenceMusique(ReferenceMusique reference) : base()
        {
            _reference = reference;
        }
        protected override void ClickCard(object o, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
