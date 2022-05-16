/* Projet   : MyLibrary - TPI 2022
 * Version  : 0.8.1
 * Date     : 16.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : CardReferenceLivre.cs cardReference
 * Decs.    : Permet de créer une card de référence de type livre
 */

using MyLibrary.classes;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace MyLibrary
{
    public class CardReferenceLivre : CardReference
    {
        #region variables d'instances
        private Livre _livre;
        private PictureBox _image;
        #endregion

        public Livre ObjLivre
        {
            get { return _livre; }
            set { _livre = value; }
        }

        #region constructeurs
        /// <summary>
        /// Permet de créer une card de référence de type livre avec les données d'un livre
        /// </summary>
        /// <param name="livre">données du livre</param>
        /// <param name="reference">données de référence du livre</param>
        /// <param name="frm">form où la card est affichée</param>
        public CardReferenceLivre(Livre livre, Reference reference, frmCollectionReferences frm) : base(reference, frm)
        {
            
                _livre = livre;
                _image = new PictureBox();
                _image.Size = new Size(150, 70);
                _image.BackColor = Color.LightBlue;
                
                try
                {
                _image.Image = Image.FromFile(_livre.NomImage);
                _image.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Label lbltxtAuteur = new Label();
                lbltxtAuteur.Text = "Auteur : ";
                lbltxtAuteur.Location = new Point(Location.X + 2, Location.Y + 80);
                Label lblAuteur = new Label();
                lblAuteur.Text = _livre.Auteur;
                lblAuteur.Location = new Point(Location.X + 2, Location.Y + 95);

                Label lbltxtTitre = new Label();
                lbltxtTitre.Text = "Titre : ";
                lbltxtTitre.Location = new Point(190, 5);
                lbltxtTitre.Location = new Point(Location.X + 2, Location.Y + 120);
                Label lblTitre = new Label();
                lblTitre.Text = _livre.Titre;
            lblTitre.Location = new Point(Location.X + 2, Location.Y + 135);

            _image.Click += ClickCard;
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

        public CardReferenceLivre(Utilisateur utilisateur, Reference referenceLivre, frmCollectionReferences frm) : this(ClientRest.Instance.LivreParIdLivre(utilisateur, referenceLivre.LivreReference), referenceLivre, frm) { }
        #endregion

        #region methodes
        /// <summary>
        /// Appelle la fonction SelectionCard de la form collection références 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        protected override void ClickCard(object o, EventArgs e)
        {
            Frm.SelectionCard(this);
        }
        #endregion
    }
}
