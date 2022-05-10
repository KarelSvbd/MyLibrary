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
    public class CardReferenceMusique : CardReference
    {
        private PictureBox _image;
        public CardReferenceMusique(Reference reference, frmCollectionReferences frm) : base(reference, frm)
        {
            _image = new PictureBox();
            _image.Size = new Size(150, 70);
            _image.BackColor = Color.Orange;
            //_image.Image = Image.FromFile(imageLocation + livre.NomImage);
            _image.SizeMode = PictureBoxSizeMode.StretchImage;

            Label lbltxtAuteur = new Label();
            lbltxtAuteur.Text = "Auteur : ";
            lbltxtAuteur.Location = new Point(Location.X + 2, Location.Y + 80);
            Label lblAuteur = new Label();
            lblAuteur.Text = ObjReference.Auteur;
            lblAuteur.Location = new Point(Location.X + 2, Location.Y + 95);

            Label lbltxtTitre = new Label();
            lbltxtTitre.Text = "Titre : ";
            lbltxtTitre.Location = new Point(190, 5);
            lbltxtTitre.Location = new Point(Location.X + 2, Location.Y + 120);
            Label lblTitre = new Label();
            lblTitre.Text = ObjReference.NomReference;
            lblTitre.Location = new Point(Location.X + 2, Location.Y + 135);

            lbltxtAuteur.Click += ClickCard;
            lblAuteur.Click += ClickCard;
            lbltxtTitre.Click += ClickCard;
            lblTitre.Click += ClickCard;

            Controls.Add(_image);
            Controls.Add(lblAuteur);
            Controls.Add(lbltxtAuteur);
            Controls.Add(lblTitre);
            Controls.Add(lbltxtTitre);
        }
        protected override void ClickCard(object o, EventArgs e)
        {

            Frm.SelectionCard(this);
        }
    }
}
