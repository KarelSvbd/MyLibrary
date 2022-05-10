using MyLibrary;
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
    public class CardLivre : Card
    {
        PictureBox _image;
        private Livre _livre;
        private frmCollectionLivres _lvres;
        public Livre ObjLivre
        {
            get { return _livre; }
            set { _livre = value; }
        }

        public CardLivre() : this(new Livre(0, "Notre Dame de paris", "Victor Hugo", "frmConnexion.png", 0), "C:/Users/karel.svbd/Desktop/Pour TPI/src/Projet C#/MyLibrary/WindowsFormsApp1/ressources/images/", null)
        {

        } 
        public CardLivre(Livre livre, string imageLocation, frmCollectionLivres lvres) : base()
        {
            _livre = livre;
            _lvres = lvres;

            _image = new PictureBox();
            _image.Size = new Size(150, 70);
            _image.BackColor = Color.LightBlue;
            //_image.Image = Image.FromFile(imageLocation + livre.NomImage);
            _image.SizeMode = PictureBoxSizeMode.StretchImage;

            Label lbltxtAuteur = new Label();
            lbltxtAuteur.Text = "Auteur : ";
            lbltxtAuteur.Location = new Point(Location.X + 2, Location.Y + 80);
            Label lblAuteur = new Label();
            lblAuteur.Text = livre.Auteur;
            lblAuteur.Location = new Point(Location.X + 45, Location.Y + 80);

            Label lbltxtTitre = new Label();
            lbltxtTitre.Text = "Titre : ";
            lbltxtTitre.Location = new Point(190, 5);
            lbltxtTitre.Location = new Point(Location.X + 2, Location.Y + 120);
            Label lblTitre = new Label();
            lblTitre.Text = livre.Titre;
            lblTitre.Location = new Point(Location.X + 45, Location.Y + 120);

            Button btnReference = new Button();
            btnReference.Text = "Référence";
            btnReference.Location = new Point(Location.X + 35, Location.Y + 160);
            btnReference.Width = 80;
            Click += ClickCard;
            btnReference.Click += ClickReference;


            Controls.Add(_image);
            Controls.Add(lblAuteur);
            Controls.Add(lbltxtAuteur);
            Controls.Add(lblTitre);
            Controls.Add(lbltxtTitre);
            Controls.Add(btnReference);
        }

        protected override void ClickCard(object o, EventArgs e)
        {
            _lvres.SelectionnerCard(this);
        }

        private void ClickReference(object o, EventArgs e)
        {
            _lvres.AfficherReference(_livre);

        }
    }
}
