using MyLibrary.classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace MyLibrary
{
    public class CardReferenceLieu : CardReference
    {
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
            
            lbltxtTitre.Click += ClickCard;
            lblTitre.Click += ClickCard;
            lblTxtDescription.Click += ClickCard;
            lblDescription.Click += ClickCard;

            Controls.Add(lblTitre);
            Controls.Add(lbltxtTitre);
            Controls.Add(lblDescription);
            Controls.Add(lblTxtDescription);
        }

        protected override void ClickCard(object o, EventArgs e)
        {
            Frm.SelectionCard(this);
        }
    }
}
