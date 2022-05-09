using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MyLibrary;
using WindowsFormsApp1;

namespace MyLibrary.classes
{
    abstract public class Card : Panel
    {
        public Size taille = new Size(150, 200);

        public Card() : base()
        {
            Size = taille;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
        }

        protected abstract void ClickCard(object o, EventArgs e);
    }
}
