/* Projet   : MyLibrary - TPI 2022
 * Version  : 1.0
 * Date     : 18.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : CardLivre.cs CardLivre
 * Decs.    : Permet de créer une card de type livre
 */

using MyLibrary.classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyLibrary
{
    public class CardLivre : Card
    {
        #region variables d'instances
        PictureBox _image;
        private Livre _livre;
        private frmCollectionLivres _lvres;
        #endregion

        #region propriétés
        public Livre ObjLivre
        {
            get { return _livre; }
            set { _livre = value; }
        }
        #endregion

        #region constructeurs

        public CardLivre() : this(new Livre(0, "Notre Dame de paris", "Victor Hugo", "frmConnexion.png", 0),  null)
        {

        } 
        public CardLivre(Livre livre, frmCollectionLivres lvres) : base()
        {
            _livre = livre;
            _lvres = lvres;

            _image = new PictureBox();
            _image.Size = new Size(150, 70);
            _image.BackColor = Color.LightBlue;
            try
            {
                _image.Image = Image.FromFile(livre.NomImage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
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
            lbltxtAuteur.Click += ClickCard;
            lblAuteur.Click += ClickCard;
            lbltxtTitre.Click += ClickCard;
            lblTitre.Click += ClickCard;
            _image.Click += ClickCard;
            btnReference.Click += ClickReference;


            Controls.Add(_image);
            Controls.Add(lblAuteur);
            Controls.Add(lbltxtAuteur);
            Controls.Add(lblTitre);
            Controls.Add(lbltxtTitre);
            Controls.Add(btnReference);
        }
        #endregion

        #region methodes
        protected override void ClickCard(object o, EventArgs e)
        {
            _lvres.SelectionnerCard(this);
        }

        private void ClickReference(object o, EventArgs e)
        {
            _lvres.AfficherReference(_livre);

        }
        #endregion
    }
}
