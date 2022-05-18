/* Projet   : MyLibrary - TPI 2022
 * Version  : 1.0
 * Date     : 18.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : CardLivre.cs CardLivre
 * Decs.    : Sert de modèles aux card
 */
using System;
using System.Windows.Forms;
using System.Drawing;

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
