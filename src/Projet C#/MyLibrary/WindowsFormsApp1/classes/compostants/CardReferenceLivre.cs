using MyLibrary.classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrary
{
    public class CardReferenceLivre : Card
    {
        private ReferenceLivre _reference;
        private PictureBox _image;
        public CardReferenceLivre(ReferenceLivre reference) : base()
        {
            _reference = reference;

            _image = new PictureBox();
            _image.Size = new Size(150, 70);
            _image.BackColor = Color.LightBlue;
            //_image.Image = Image.FromFile(imageLocation + livre.NomImage);
            _image.SizeMode = PictureBoxSizeMode.StretchImage;

            Label lbltxtAuteur = new Label();
            lbltxtAuteur.Text = "Auteur : ";
            lbltxtAuteur.Location = new Point(Location.X + 2, Location.Y + 80);
            Label lblAuteur = new Label();
            lblAuteur.Text = _reference.Auteur;
            lblAuteur.Location = new Point(Location.X + 45, Location.Y + 80);

            Label lbltxtTitre = new Label();
            lbltxtTitre.Text = "Titre : ";
            lbltxtTitre.Location = new Point(190, 5);
            lbltxtTitre.Location = new Point(Location.X + 2, Location.Y + 120);
            Label lblTitre = new Label();
            lblTitre.Text = _reference.Titre;
            lblTitre.Location = new Point(Location.X + 45, Location.Y + 120);

            Controls.Add(_image);
            Controls.Add(lblAuteur);
            Controls.Add(lbltxtAuteur);
            Controls.Add(lblTitre);
            Controls.Add(lbltxtTitre);
        }
        protected override void ClickCard(object o, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
