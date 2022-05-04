using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MyLibrary;

namespace MyLibrary.classes
{
    public class Card : Panel
    {
        public Size taille = new Size(150, 200);
        PictureBox _image;
        private Livre _livre;

        public Livre ObjLivre
        {
            get { return _livre; }
            set { _livre = value; }
        }

        public Card(): this(new Livre(0, "Notre Dame de paris", "Victor Hugo", "frmConnexion.png", 0), "C:/Users/karel.svbd/Desktop/Pour TPI/src/Projet C#/MyLibrary/WindowsFormsApp1/ressources/images/")
        {
            
        }

        public Card(Livre livre, string imageLocation) : base()
        {
            _livre = livre;
            Size = taille;
            BackColor = Color.LightGray;
            BorderStyle = BorderStyle.FixedSingle;
            _image = new PictureBox();
            _image.Size = new Size(150, 70);
            _image.Image = Image.FromFile(imageLocation + livre.NomImage);
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


            Controls.Add(_image);
            Controls.Add(lblAuteur);
            Controls.Add(lbltxtAuteur);
            Controls.Add(lblTitre);
            Controls.Add(lbltxtTitre);
            Controls.Add(btnReference);

        }

        public void ClickCard(object o, EventArgs e)
        {
            
        }
    }
}
