/* Projet   : MyLibrary - TPI 2022
 * Version  : 1.0
 * Date     : 18.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : CardReferenceLieu.cs cardReference
 * Decs.    : Permet de créer une card de référence de type lieu
 */

using MyLibrary.classes;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace MyLibrary
{
    public class CardReferenceLieu : CardReference
    {
        /// <summary>
        /// Permet de créer card de référence lieu
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="frm"></param>
        public CardReferenceLieu(Reference reference, frmCollectionReferences frm) : base(reference, frm)
        {

            Label lbltxtTitre = new Label();
            lbltxtTitre.Text = "Titre : ";
            lbltxtTitre.Location = new Point(Location.X + 2, Location.Y + 20);
            Label lblTitre = new Label();
            lblTitre.Text = ObjReference.NomReference;
            lblTitre.Location = new Point(Location.X + 2, Location.Y + 35);

            Label lblTxtDescription = new Label();
            lblTxtDescription.Text = "Description : ";
            lblTxtDescription.Location = new Point(190, 5);
            lblTxtDescription.Location = new Point(Location.X + 2, Location.Y + 80);
            Label lblDescription = new Label();
            lblDescription.Text = ObjReference.DescriptionLieu;
            lblDescription.Location = new Point(Location.X + 2, Location.Y + 95);
            lblDescription.Size = new Size(Size.Width - 2, Size.Height - 80);
            
            //Ajout des événements de click
            lbltxtTitre.Click += ClickCard;
            lblTitre.Click += ClickCard;
            lblTxtDescription.Click += ClickCard;
            lblDescription.Click += ClickCard;

            //ajout des éléments dans les controls de la card
            Controls.Add(lblTitre);
            Controls.Add(lbltxtTitre);
            Controls.Add(lblDescription);
            Controls.Add(lblTxtDescription);
        }

        public Reference Reference
        {
            get => default;
            set
            {
            }
        }

        public Livre Livre
        {
            get => default;
            set
            {
            }
        }

        protected override void ClickCard(object o, EventArgs e)
        {
            Frm.SelectionCard(this);
        }
    }
}
