/* Projet   : MyLibrary - TPI 2022
 * Version  : 0.8.1
 * Date     : 16.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : CardReferenceMusique.cs cardReference
 * Decs.    : Permet de créer une card de référence de type musique
 */

using MyLibrary.classes;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace MyLibrary
{
    public class CardReferenceMusique : CardReference
    {
        #region Variables d'instances
        private PictureBox _image;
        #endregion

        #region Constructeurs

        /// <summary>
        /// Permet de créer une card de type référence de musique
        /// </summary>
        /// <param name="reference">Données de la card</param>
        /// <param name="frm">form dans laquelle la card s'affiche</param>
        public CardReferenceMusique(Reference reference, frmCollectionReferences frm) : base(reference, frm)
        {
            _image = new PictureBox();
            _image.Size = new Size(150, 70);
            _image.BackColor = Color.Orange;
            try
            {
                _image.Image = Image.FromFile(reference.NomImage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            //Définition de la mise en page de l'image
            _image.SizeMode = PictureBoxSizeMode.StretchImage;

            //Création des éléments visuels
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

            //Ajout des événements de click pour séléctionner la card
            lbltxtAuteur.Click += ClickCard;
            lblAuteur.Click += ClickCard;
            lbltxtTitre.Click += ClickCard;
            lblTitre.Click += ClickCard;

            //Ajout dans les controls de la card
            Controls.Add(_image);
            Controls.Add(lblAuteur);
            Controls.Add(lbltxtAuteur);
            Controls.Add(lblTitre);
            Controls.Add(lbltxtTitre);
        }
        #endregion
        /// <summary>
        /// Appel la fonction Selection de la form frmSelectionReferences avec les données de l'objet
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        protected override void ClickCard(object o, EventArgs e)
        {
            Frm.SelectionCard(this);
        }
    }
}
