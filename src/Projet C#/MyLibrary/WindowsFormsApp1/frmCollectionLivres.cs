/* Projet   : MyLibrary - TPI 2022
 * Version  : 0.8.1
 * Date     : 16.05.2022
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
using System.IO;
using System.Windows.Forms;
using MyLibrary.classes;
using WindowsFormsApp1;

namespace MyLibrary
{
    public partial class frmCollectionLivres : Form
    {
        //Variables d'instances
        Utilisateur _utilisateur;
        ClientRest _clientRest;
        List<Livre> _listLivresUtilisateur;
        List<Card> _listCard;
        CardLivre _cardSelectionne;
        
        /// <summary>
        /// Form de collection de livres
        /// Affiche les livres de l'utilisateur dans une liste d'objets.
        /// Permet de faire un CRUD sur les livres via un formulaire
        /// </summary>
        /// <param name="utilisateur">Données de l'tutilisateur</param>
        /// <param name="frmPrecedente">Form de connexion</param>
        public frmCollectionLivres(Utilisateur utilisateur, frmConnexion frmPrecedente)
        {
            //Initialisation des composants
            InitializeComponent();
            //Stockage des données dans les variables d'instances
            _utilisateur = utilisateur;
            _clientRest = ClientRest.Instance;
            //Instanciations des lists
            _listLivresUtilisateur = new List<Livre>();
            _listCard = new List<Card>();
            //Fermeture de la form de connexion
            frmPrecedente.Close();
            //Affichage des données
            RefreshView();
        }

        /// <summary>
        /// Ajout d'un livre
        /// Source du code de l'importation de l'image : 
        /// https://www.codeproject.com/Questions/546631/howplustoplussavepluspictureboxplusimageplusinplus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            //Vérification des champs
            if (VerificationInputs())
            {
                //tentative d'ajout de livre
                try
                {
                    ImageInFile imageEnregistrer = new ImageInFile((Bitmap)pbxImageAjouter.Image);
                    //Création du livre et appel de la methode d'ajout
                    if (new Livre(0, tbxTitre.Text, tbxAuteur.Text, imageEnregistrer.Nom + imageEnregistrer.Extension, 0).PostLivre(_utilisateur))
                    {
                        //enregistrement de l'image
                        imageEnregistrer.SaveBmp();
                        //Afficahge du message de confirmation
                        MessageBox.Show("La donnée a été ajoutée", "Livre ajouté", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //mise à jour de la vue
                        RefreshView();
                    }
                }
                catch (Exception ex)
                {
                    //Afficahge du message d'erreur
                    MessageBox.Show("Une erreur s'est produite lors de l'ajout du livre", "Erreur interne", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                //Afficahge du message d'erreur
                MessageBox.Show("Veuillez ajouter remplir tous les champs", "Inputs non valides", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Pression du bouton d'importation d'image
        /// Source du code d'importation et transformation en Bitmap des images
        /// https://stackoverflow.com/questions/6122984/load-a-bitmap-image-into-windows-forms-using-open-file-dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImporterImage_Click(object sender, EventArgs e)
        {
            //Ouverture du dialogue d'importation
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

        /// <summary>
        /// S'active lors de la fermeture de la form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCollectionLivres_FormClosed(object sender, FormClosedEventArgs e)
        {
            //déconnecte l'utilisateur
            _utilisateur.Deconnexion();
        }

        /// <summary>
        /// Permet de mettre à jour les données de l'application sans filtre
        /// </summary>
        public  void RefreshView()
        {
            //remise à zéro des listes
            flpListCard.Controls.Clear();
            _listLivresUtilisateur.Clear();
            _listLivresUtilisateur = _clientRest.LivresParUtilisateur(_utilisateur);
            _listCard.Clear();

            //Création de card pour chaque livre de l'utilisateur
            foreach (Livre livresPourCard in _listLivresUtilisateur)
            {
                Card nouvelleCard = new CardLivre(livresPourCard, this);
                _listCard.Add(nouvelleCard);
                flpListCard.Controls.Add(nouvelleCard);
            }
        }

        /// <summary>
        /// Permet de mettre à jour les données de l'application avec un filtre
        /// </summary>
        /// <param name="recherche">Chaîne de caractères à rechercher dans l'auteur et le titre</param>
        public void RefreshView(string recherche)
        {
            //remise à zéro des listes
            flpListCard.Controls.Clear();
            _listLivresUtilisateur.Clear();
            _listLivresUtilisateur = _clientRest.LivresParUtilisateur(_utilisateur, recherche);
            _listCard.Clear();

            //Création de card pour chaque livre de l'utilisateur après le filtrage
            foreach (Livre livresPourCard in _listLivresUtilisateur)
            {
                CardLivre nouvelleCard = new CardLivre(livresPourCard, this);
                _listCard.Add(nouvelleCard);
                flpListCard.Controls.Add(nouvelleCard);
            }
        }

        /// <summary>
        /// Mise à zéro de la vue si l'utilisateur clique sur flpListCard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flpListCard_Click(object sender, EventArgs e)
        {
            VueParDefault();
        }

        /// <summary>
        /// Permet de vider la carte séléctionnée et de remettre à zéro la vue de l'application
        /// </summary>
        private void VueParDefault()
        {
            //Mise à zéro du style de toutes les cards
            foreach (CardLivre uneCard in _listCard)
            {
                uneCard.BackColor = Color.White;
                uneCard.ForeColor = Color.Black;
            }
            //Mise à zéro de la card séléctionnée
            _cardSelectionne = null;
            //Activation du bouton d'ajout et désactivation des boutons de suppression et modifications
            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            //Mise à zéro des inputs
            tbxAuteur.Text = null;
            tbxTitre.Text = null;
            pbxImageAjouter.Image = null;
        }

        /// <summary>
        /// Permet de séléctionner une card et de stocker ses données
        /// </summary>
        /// <param name="card"></param>
        public void SelectionnerCard(CardLivre card)
        {
            //stockage de la card dans une variable d'instance
            _cardSelectionne = card;
            //Activation des bouton de modification et de suppression et désactivation du bouton d'ajout
            btnModifier.Enabled = true;
            btnSupprimer.Enabled = true;
            btnAjouter.Enabled = false;
            //Mise à zéro du style des card
            foreach(CardLivre uneCard in _listCard)
            {
                uneCard.BackColor = Color.White;
                uneCard.ForeColor = Color.Black;
            }
            //Mise en évidence de la card séléctionnée
            card.BackColor = Color.Gray;
            card.ForeColor = Color.White;
            //Affichage des données dans les inputs
            tbxAuteur.Text = card.ObjLivre.Auteur;
            tbxTitre.Text = card.ObjLivre.Titre;
            //Recherche de l'image par son nom
            pbxImageAjouter.Image = Image.FromFile(card.ObjLivre.NomImage);
        }

        /// <summary>
        /// Modification d'image suite à la pression du bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            //Vérification des inputs
            if (VerificationInputs())
            {
                try
                {
                    ImageInFile imageEnregistrer = new ImageInFile((Bitmap)pbxImageAjouter.Image);
                    //Essai de modification du livre
                    if (_cardSelectionne.ObjLivre.PutLivre(_utilisateur, new Livre(0, tbxTitre.Text, tbxAuteur.Text, imageEnregistrer.Nom + imageEnregistrer.Extension, 0)))
                    {
                        //Suppression de l'image précédente
                        File.Delete(_cardSelectionne.ObjLivre.NomImage);
                        //Sauvegarde de la nouvelle image
                        imageEnregistrer.SaveBmp();
                        //Afficahge du message en cas de succès
                        MessageBox.Show("Le livre a été modifié", "Livre modifié", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Mise à jour de la vue
                        RefreshView();
                    }
                    else
                    {
                        //Afficahge du message d'erreur
                        MessageBox.Show("Une erreur s'est produite lors de la modification du livre", "Erreur interne", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    //Afficahge du message d'erreur
                    MessageBox.Show("Une erreur s'est produite lors de la modification du livre", "Erreur interne", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                //Afficahge du message d'erreur
                MessageBox.Show("Veuillez ajouter remplir tous les champs", "Inputs non valides", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Pression du bouton de suppression
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            //affichage du message de confirmation
            DialogResult dr = MessageBox.Show("Voulez-vous vraiment supprimer ce livre", "Suppression de livre", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            //Si l'utilisateur confirme la suppression
            if (dr == DialogResult.Yes)
            {
                try
                {
                    //Tentative de suppression de livre
                    if (_cardSelectionne.ObjLivre.DeleteLivre(_utilisateur))
                    {
                        //Mise à zéro de la vue
                        RefreshView();
                        VueParDefault();
                        //Afficahge du message de confirmation
                        MessageBox.Show("Le livre a été supprimé", "Livre supprimé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Problème lors de la suppression du livre", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
                
            }
            
        }

        /// <summary>
        /// Vérification si les inputs sont remplis
        /// </summary>
        /// <returns>True = inputs remplis, False = un ou plusieurs input(s) est ou sont vide(s)</returns>
        private bool VerificationInputs()
        {
            //Vérification des inputs
            if(tbxAuteur.Text == "" && tbxRecherche.Text == "")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// S'enclanche lors d'un changement de texte de la tbxRecherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxRecherche_TextChanged(object sender, EventArgs e)
        {
            //Si le champs n'est pas vide, on appelle la fonction qui affiche les livres en fonction du filtre
            //Sinon afficahge de tous les livres de l'utilisateur
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
            frmCollectionReferences collectionReferences = new frmCollectionReferences(livre, _utilisateur, this);
            collectionReferences.Show();
        }

        /// <summary>
        /// S'enclanche si l'utilisateur click sur la form
        /// Mise à zéro des données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCollectionLivres_Click(object sender, EventArgs e)
        {
            VueParDefault();
        }
    }
}
