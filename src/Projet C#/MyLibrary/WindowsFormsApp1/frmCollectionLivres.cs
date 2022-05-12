/* Projet   : MyLibrary - TPI 2022
 * Version  : 0.6
 * Date     : 10.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : frmCollectionLivres.cs Form
 * Decs.    : Vue de la collection de Livres d'un utilisateur
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using MyLibrary.classes;
using WindowsFormsApp1;

namespace MyLibrary
{
    public partial class frmCollectionLivres : Form
    {
        Utilisateur _utilisateur;
        ClientRest _clientRest;
        List<Livre> _listLivresUtilisateur;
        List<Card> _listCard;
        CardLivre _cardSelectionne;
        
        public frmCollectionLivres(Utilisateur utilisateur, frmConnexion frmPrecedente)
        {
            InitializeComponent();
            _utilisateur = utilisateur;
            _clientRest = ClientRest.Instance;
            _listLivresUtilisateur = new List<Livre>();
            _listCard = new List<Card>();
            frmPrecedente.Close();
            RefreshView();
            
        }

        private void frmCollectionLivres_Load(object sender, EventArgs e)
        {

        }

        private void card1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            
            //https://www.codeproject.com/Questions/546631/howplustoplussavepluspictureboxplusimageplusinplus
            try
            {
                ImageInFile imageEnregistrer = new ImageInFile((Bitmap)pbxImageAjouter.Image);
                //
                //Ajout du livre
                if (new Livre(0, tbxTitre.Text, tbxAuteur.Text, imageEnregistrer.Nom+imageEnregistrer.Extension, 0).PostLivre(_utilisateur))
                {
                    imageEnregistrer.SaveBmp();
                    MessageBox.Show("La donnée a été ajoutée", "Livre ajouté", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshView();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void btnImporterImage_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/6122984/load-a-bitmap-image-into-windows-forms-using-open-file-dialog
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    pbxImageAjouter.Image = new Bitmap(dlg.FileName);
                }
            }
        }

        private void tbxAuteur_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxTitre_TextChanged(object sender, EventArgs e)
        {

        }

        private void card1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void frmCollectionLivres_FormClosed(object sender, FormClosedEventArgs e)
        {
            _utilisateur.Deconnexion();
        }

        private void RefreshView()
        {
            flpListCard.Controls.Clear();
            _listLivresUtilisateur.Clear();
            _listLivresUtilisateur = _clientRest.LivresParUtilisateur(_utilisateur);
            _listCard.Clear();

            foreach (Livre livresPourCard in _listLivresUtilisateur)
            {
                Card nouvelleCard = new CardLivre(livresPourCard, this);
                _listCard.Add(nouvelleCard);
                flpListCard.Controls.Add(nouvelleCard);
            }
        }

        private void RefreshView(string recherche)
        {
            flpListCard.Controls.Clear();
            _listLivresUtilisateur.Clear();
            _listLivresUtilisateur = _clientRest.LivresParUtilisateur(_utilisateur, recherche);
            _listCard.Clear();

            foreach (Livre livresPourCard in _listLivresUtilisateur)
            {
                CardLivre nouvelleCard = new CardLivre(livresPourCard, this);
                _listCard.Add(nouvelleCard);
                flpListCard.Controls.Add(nouvelleCard);
            }
        }


        private void flpListCard_Click(object sender, EventArgs e)
        {
            VueParDefault();
        }

        private void VueParDefault()
        {
            foreach (CardLivre uneCard in _listCard)
            {
                uneCard.BackColor = Color.White;
                uneCard.ForeColor = Color.Black;
            }
            _cardSelectionne = null;
            
            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            tbxAuteur.Text = null;
            tbxTitre.Text = null;
            pbxImageAjouter.Image = null;
        }

        public void SelectionnerCard(CardLivre card)
        {
            _cardSelectionne = card;
            btnModifier.Enabled = true;
            btnSupprimer.Enabled = true;
            btnAjouter.Enabled = false;
            foreach(CardLivre uneCard in _listCard)
            {
                uneCard.BackColor = Color.White;
                uneCard.ForeColor = Color.Black;
            }
            card.BackColor = Color.Gray;
            card.ForeColor = Color.White;
            tbxAuteur.Text = card.ObjLivre.Auteur;
            tbxTitre.Text = card.ObjLivre.Titre;
            pbxImageAjouter.Image = Image.FromFile(card.ObjLivre.NomImage);

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            ImageInFile imageEnregistrer = new ImageInFile((Bitmap)pbxImageAjouter.Image);
            if (_cardSelectionne.ObjLivre.PutLivre(_utilisateur, new Livre(0, tbxTitre.Text, tbxAuteur.Text, imageEnregistrer.Nom + imageEnregistrer.Extension, 0)))
            {
                File.Delete(_cardSelectionne.ObjLivre.NomImage);
                imageEnregistrer.SaveBmp();
                MessageBox.Show("Le livre a été modifié", "Livre modifié", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshView();
            }
            //new Livre()
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/15036329/confirmation-message
            DialogResult dr = MessageBox.Show("Voulez-vous vraiment supprimer ce livre", "Suppression de livre", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (_cardSelectionne.ObjLivre.DeleteLivre(_utilisateur))
                {
                    RefreshView();
                    VueParDefault();
                    MessageBox.Show("Le livre a été supprimé", "Livre supprimé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void tbxRecherche_TextChanged(object sender, EventArgs e)
        {
            if (tbxRecherche.Text != "")
            {
                RefreshView(tbxRecherche.Text);
            }
            else
            {
                RefreshView();
            }
        }

        public void AfficherReference(Livre livre)
        {
            frmCollectionReferences collectionReferences = new frmCollectionReferences(livre, _utilisateur);
            collectionReferences.Show();
        }

        private void pbxImageAjouter_Click(object sender, EventArgs e)
        {

        }

        private void lblTitre_Click(object sender, EventArgs e)
        {

        }

        private void frmCollectionLivres_Click(object sender, EventArgs e)
        {
            VueParDefault();
        }
    }
}
