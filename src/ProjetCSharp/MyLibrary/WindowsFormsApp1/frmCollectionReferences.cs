/* Projet   : MyLibrary - TPI 2022
 * Version  : 1.0
 * Date     : 18.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : frmCollectionReferences.cs Form
 * Decs.    : Vue de la collection des références d'un livre
 */

using MyLibrary;
using MyLibrary.classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmCollectionReferences : Form
    {
        //Variables d'instances
        private Livre _livre;
        private Utilisateur _utilisateur;
        private ClientRest _clientRest;
        private List<Reference> _references;
        private List<Card> _cardsReferences;
        private List<Livre> _livres;
        private CardReference _cardSelectionne;
        private frmCollectionLivres _frmCollectionLivres;

        //Référence ambigu 
        private List<MyLibrary.classes.Type> _types;

        //Propriétés
        public Livre ObjLivre
        {
            get { return _livre; }
            set { _livre = value; }
        }
        /// <summary>
        /// Vue 
        /// </summary>
        /// <param name="livre"></param>
        /// <param name="utilisateur"></param>
        public frmCollectionReferences(Livre livre, Utilisateur utilisateur, frmCollectionLivres frmCollectionLivres)
        {
            _livre = livre;
            _utilisateur = utilisateur;
            _references = new List<Reference>();
            _cardsReferences = new List<Card>();
            _frmCollectionLivres = frmCollectionLivres;

            InitializeComponent();
            //Changement dynamique du nom de la form
            Text += " : " + _livre.Titre.ToLower();
            lblTitreLivre.Text = _livre.Titre;
            _clientRest = ClientRest.Instance;
            _types = _clientRest.TousTypes(_utilisateur);
            _livres = _clientRest.LivresParUtilisateur(_utilisateur);

            majCbxTypes(_types);

            cbxFiltreType.Items.Add("Tous");
            cbxFiltreType.Items.Add("Livres");
            cbxFiltreType.Items.Add("Musiques");
            cbxFiltreType.Items.Add("Lieux");
            cbxFiltreType.SelectedIndex = 0;

            UpdateFormView();
            btnAjouter.Enabled = true;
            btnModifier.Enabled = true;
            btnSupprimer.Enabled = true;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ImageInFile imageEnregistrer = null;
            //Ajout test de la combobox
            switch (cbxType.SelectedIndex)
            {
                case 0:
                    imageEnregistrer = new ImageInFile((Bitmap)pbxImage.Image);
                    if (cbxLivre.SelectedIndex == 0)
                    {
                        //new ReferenceLivre(0)
                        Livre nouveauLivre = new Livre(0, tbxTitre.Text, tbxAuteur.Text, imageEnregistrer.Nom + imageEnregistrer.Extension, _utilisateur.IdUtilisateur);
                        if (nouveauLivre.PostLivre(_utilisateur))
                        {
                            
                            imageEnregistrer.SaveBmp();
                            new ReferenceLivre(0, nouveauLivre.NomImage, _clientRest.DernierLivreUtilisateur(_utilisateur), _livre.IdLivre).PostReference(_utilisateur);
                            _frmCollectionLivres.RefreshView();
                            UpdateFormView();
                        }
                    }
                    else
                    {
                        imageEnregistrer = new ImageInFile((Bitmap)pbxImage.Image);
                        if (new ReferenceLivre(0, imageEnregistrer.Nom, _livres[cbxLivre.SelectedIndex - 1].IdLivre, _livre.IdLivre).PostReference(_utilisateur))
                        {
                            _frmCollectionLivres.RefreshView();
                            MessageBox.Show("La référence et le livre ont été ajoutées", "Référence Ajoutée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UpdateFormView();
                        }
                        else
                        {
                            MessageBox.Show("Un problème s'est produit lors de l'envoie de la donnée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case 1:
                    imageEnregistrer = new ImageInFile((Bitmap)pbxImage.Image);
                    if (new ReferenceMusique(0, imageEnregistrer.Nom + imageEnregistrer.Extension, tbxTitre.Text, tbxAuteur.Text, ObjLivre.IdLivre).PostReference(_utilisateur))
                    {
                        imageEnregistrer.SaveBmp();
                        MessageBox.Show("La référence à été ajoutée", "Référence Ajoutée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateFormView();
                    } else{
                        MessageBox.Show("Un problème s'est produit lors de l'envoie de la donnée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 2:
                    if (new ReferenceLieu(0, tbxTitre.Text, tbxDescription.Text, ObjLivre.IdLivre).PostReference(_utilisateur))
                    {
                        MessageBox.Show("La référence à été ajoutée", "Référence Ajoutée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateFormView();
                    }
                    else
                    {
                        MessageBox.Show("Un problème s'est produit lors de l'envoie de la donnée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
            
        }

        /// <summary>
        /// Mise à jour des éléments de la vue
        /// </summary>
        private void UpdateFormView()
        {
            //Mise à 0 des List
            _references.Clear();
            _cardsReferences.Clear();
            cbxLivre.Items.Clear();
            flpReferences.Controls.Clear();
            //cbxFiltreType.SelectedIndex = 0;

            //récupération des éléments
            _references = _clientRest.ReferencesParLivre(_utilisateur, _livre);

            cbxLivre.Items.Add("-- NOUVEAU LIVRE --");
            foreach (Livre lvr in _livres)
            {
                cbxLivre.Items.Add(lvr.Titre);
            }
            cbxLivre.SelectedIndex = 0;

            
            if(cbxFiltreType.SelectedIndex == 0 && tbxRecherche.Text == "")
            {
                foreach (Reference reference in _references)
                {
                    Card nouvelleCard;
                    switch (reference.IdType)
                    {
                        //Livre
                        case 1:
                            nouvelleCard = new CardReferenceLivre(_utilisateur, reference, this);
                            flpReferences.Controls.Add(nouvelleCard);
                            _cardsReferences.Add(nouvelleCard);
                            break;
                        //Musique
                        case 2:
                            nouvelleCard = new CardReferenceMusique(reference, this);
                            flpReferences.Controls.Add(nouvelleCard);
                            _cardsReferences.Add(nouvelleCard);
                            break;
                        //Lieu
                        case 3:
                            nouvelleCard = new CardReferenceLieu(reference, this);
                            flpReferences.Controls.Add(nouvelleCard);
                            _cardsReferences.Add(nouvelleCard);
                            break;
                    }

                }
            }
            else
            {
                List<CardReference> cards = new List<CardReference>();
                if(cbxFiltreType.SelectedIndex != 0 && tbxRecherche.Text == "")
                {
                    cards.AddRange(RechercheReferenceParFiltre(cbxFiltreType.SelectedIndex));
                }
                else if(cbxFiltreType.SelectedIndex == 0 && tbxRecherche.Text != "")
                {
                    cards.AddRange(RechercheReferenceParFiltre(tbxRecherche.Text));
                }
                else
                {
                    cards.AddRange(RechercheReferenceParFiltre(tbxRecherche.Text, cbxFiltreType.SelectedIndex));
                }


                foreach(CardReference card in cards)
                {
                    flpReferences.Controls.Add(card);
                    _cardsReferences.Add(card);
                }
                
            }
            
            //ActiverTousElements();
        }

        /// <summary>
        /// Mise à jour de l'états des inputs
        /// </summary>
        /// <param name="etat">True = activation, false = désactivation</param>
        private void EtatTousElements(bool etat)
        {
            btnImporterImage.Enabled = etat;
            tbxTitre.Enabled = etat;
            tbxAuteur.Enabled = etat;
            tbxDescription.Enabled = etat;
            cbxLivre.Enabled = etat;
        }


        /// <summary>
        /// Essaie de supprimer une référence affiche des popups en conséquence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Voulez-vous vraiment supprimer cette référence", "Suppression de Référence", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                //Essai de suppression de la référence
                if (_cardSelectionne.ObjReference.DeleteReference(_utilisateur))
                {
                    MessageBox.Show("La référence à été supprimée", "Référence Supprimée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateFormView();
                }
                else
                {
                    MessageBox.Show("Un problème s'est produit lors de l'envoie de la donnée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            
        }

        /// <summary>
        /// Mets à jour les types
        /// </summary>
        /// <param name="_types">List des types</param>
        private void majCbxTypes(List<MyLibrary.classes.Type> _types)
        {
            cbxType.Items.Clear();
            foreach(var type in _types)
            {
                cbxType.Items.Add(type.NomType);
            }
            //Séléction par défault
            cbxType.SelectedIndex = 0;
        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Désactivation de tous les inputs
            EtatTousElements(false);

            //Activation des inputs en fonction du type de référence
            switch (cbxType.SelectedIndex)
            {
                //Livre
                case 0:
                    tbxTitre.Enabled = true;
                    btnImporterImage.Enabled = true;
                    tbxAuteur.Enabled = true;
                    cbxLivre.Enabled = true;
                    break;
                //Musique
                case 1:
                    tbxTitre.Enabled = true;
                    btnImporterImage.Enabled = true;
                    tbxAuteur.Enabled = true;
                    break;
                //Lieu
                case 2:
                    tbxTitre.Enabled= true;
                    tbxDescription.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// Se déclache lorsqu'une carte est séléctionnée
        /// Sert à récupérer les données de la carte
        /// </summary>
        /// <param name="card">Card séléctionnée</param>
        public void SelectionCard(CardReference card)
        {
            cbxType.Enabled = false;
            _cardSelectionne = card;
            btnAjouter.Enabled = false;
            btnModifier.Enabled = true;
            btnSupprimer.Enabled = true;
            //Changement de style pour les card et mise en évidence de la card séléctionnée 
            foreach (var uneCard in _cardsReferences)
            {
                if (uneCard == card)
                {
                    card.BackColor = Color.Gray;
                    card.ForeColor = Color.White;
                }
                else
                {
                    uneCard.BackColor = Color.White;
                    uneCard.ForeColor = Color.Black;
                }

            }

            //Mise en place des données dans les inputs
            switch (card.ObjReference.IdType)
            {
                //Livre
                case 1:
                    tbxTitre.Text = card.ObjReference.NomReference;
                    tbxAuteur.Text = card.ObjReference.Auteur;
                    tbxDescription.Text = card.ObjReference.DescriptionLieu;
                    pbxImage.Image = Image.FromFile(card.ObjReference.NomImage);
                    cbxType.SelectedIndex = 0;
                    break;
                //Musique
                case 2:
                    tbxTitre.Text = card.ObjReference.NomReference;
                    tbxAuteur.Text = card.ObjReference.Auteur;
                    tbxDescription.Text = card.ObjReference.DescriptionLieu;
                    pbxImage.Image = Image.FromFile(card.ObjReference.NomImage);
                    cbxType.SelectedIndex = 1;
                    break;
                //Lieu
                case 3:
                    tbxTitre.Text = card.ObjReference.NomReference;
                    tbxAuteur.Text = card.ObjReference.Auteur;
                    tbxDescription.Text = card.ObjReference.DescriptionLieu;
                    cbxType.SelectedIndex = 2;
                    break;
            }
        }

        /// <summary>
        /// S'active quand une card est séléctionnée
        /// </summary>
        public void SelectionCard()
        {
            foreach (var uneCard in _cardsReferences)
            {
               uneCard.BackColor = Color.White;
               uneCard.ForeColor = Color.Black;
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            

            switch (_cardSelectionne.ObjReference.IdType)
            {
                case 1:
                    ImageInFile imageEnregistrer = new ImageInFile((Bitmap)pbxImage.Image);
                    imageEnregistrer.SaveBmp();
                    new ReferenceLivre(_cardSelectionne.ObjReference.IdReference, imageEnregistrer.Nom + imageEnregistrer.Extension, _cardSelectionne.ObjReference.LivreReference, _cardSelectionne.ObjReference.IdLivre).PutLivre(_utilisateur, new Livre(_cardSelectionne.ObjReference.LivreReference, tbxTitre.Text, tbxAuteur.Text, imageEnregistrer.Nom + imageEnregistrer.Extension, 0));
                    UpdateFormView();
                    break;
                //Musique
                case 2:
                    imageEnregistrer = new ImageInFile((Bitmap)pbxImage.Image);
                    if (_cardSelectionne.ObjReference.PutReference(_utilisateur, new ReferenceMusique(0, imageEnregistrer.Nom + imageEnregistrer.Extension, tbxTitre.Text, tbxAuteur.Text, ObjLivre.IdLivre)))
                    {
                        imageEnregistrer.SaveBmp();
                        MessageBox.Show("La référence à été modifiée", "Référence modifiée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateFormView();
                    }
                    else
                    {
                        MessageBox.Show("Un problème s'est produit lors de l'envoie de la donnée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                //Lieu
                case 3:
                    if (_cardSelectionne.ObjReference.PutReference(_utilisateur, new ReferenceLieu(0,  tbxTitre.Text, tbxDescription.Text, ObjLivre.IdLivre)))
                    {
                        MessageBox.Show("La référence à été modifiée", "Référence modifiée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateFormView();
                    }
                    else
                    {
                        MessageBox.Show("Un problème s'est produit lors de l'envoie de la donnée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
            
            
        }

        private void flpReferences_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flpReferences_Click(object sender, EventArgs e)
        {
            InputParDefault();
        }

        private void InputParDefault()
        {
            cbxType.Enabled = true;
            cbxType.SelectedIndex = 0;
            _cardSelectionne = null;
            SelectionCard();
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnAjouter.Enabled = true;
            tbxAuteur.Text = "";
            tbxTitre.Text = "";
            tbxDescription.Text = "";
            pbxImage.Image = null;
        }

        private void frmCollectionReferences_Click(object sender, EventArgs e)
        {
            InputParDefault();
        }

        private void cbxLivre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLivre.SelectedIndex != 0)
            {
                EtatTousElements(false);
                cbxLivre.Enabled = true;
            }
            else
            {
                InputParDefault();
                tbxAuteur.Enabled = true;
                tbxTitre.Enabled = true;
                btnImporterImage.Enabled = true;
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
                    pbxImage.Image = new Bitmap(dlg.FileName);
                }
            }
        }

        private void cbxFiltreType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFormView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxRecherche_TextChanged(object sender, EventArgs e)
        {
            UpdateFormView();
        }

        private List<CardReference> RechercheReferenceParFiltre(string recherche)
        {
            List<CardReference> listCard = new List<CardReference>();
            CardReference nouvelleCard;
            foreach (Reference reference in _references)
            {
                if(reference.DescriptionLieu.ToLower().Contains(recherche.ToLower()) || reference.Auteur.ToLower().Contains(recherche.ToLower()) || reference.NomReference.ToLower().Contains(recherche.ToLower()))
                {
                    switch (reference.IdType)
                    {
                        //Livre
                        case 1:
                                nouvelleCard = new CardReferenceLivre(_utilisateur, reference, this);
                                listCard.Add(nouvelleCard);
                            break;
                        //Musique
                        case 2:
                                nouvelleCard = new CardReferenceMusique(reference, this);
                                listCard.Add(nouvelleCard);

                            break;
                        //Lieu
                        case 3:
                                nouvelleCard = new CardReferenceLieu(reference, this);
                                listCard.Add(nouvelleCard);
                            break;
                    }
                }
            }
            return listCard;
        }

        private List<CardReference> RechercheReferenceParFiltre(int idType)
        {
            List<CardReference> listCard = new List<CardReference>();
            foreach (Reference reference in _references)
            {
                CardReference nouvelleCard;
                switch (reference.IdType)
                {
                    //Livre
                    case 1:
                        if (idType == 1)
                        {
                            nouvelleCard = new CardReferenceLivre(_utilisateur, reference, this);
                            listCard.Add(nouvelleCard);
                        }
                        break;
                    //Musique
                    case 2:
                        if (idType == 2)
                        {
                            nouvelleCard = new CardReferenceMusique(reference, this);
                            listCard.Add(nouvelleCard);
                        }

                        break;
                    //Lieu
                    case 3:
                        if (idType == 3)
                        {
                            nouvelleCard = new CardReferenceLieu(reference, this);
                            listCard.Add(nouvelleCard);
                        }
                        break;
                }
            }
            return listCard;
        }

        private List<CardReference> RechercheReferenceParFiltre(string recherche, int idType)
        {
            List<CardReference> listCard = new List<CardReference>();
            CardReference nouvelleCard;
            foreach (Reference reference in _references)
            {
                if (reference.DescriptionLieu.ToLower().Contains(recherche.ToLower()) || reference.Auteur.ToLower().Contains(recherche.ToLower()) || reference.NomReference.ToLower().Contains(recherche.ToLower()))
                {
                    switch (reference.IdType)
                    {
                        //Livre
                        case 1:
                            if (idType == 1)
                            {
                                nouvelleCard = new CardReferenceLivre(_utilisateur, reference, this);
                                listCard.Add(nouvelleCard);
                            }
                            break;
                           
                        //Musique
                        case 2:
                            if(idType == 2)
                            {
                                nouvelleCard = new CardReferenceMusique(reference, this);
                                listCard.Add(nouvelleCard);
                            }
                            

                            break;
                        //Lieu
                        case 3:
                            if(idType == 3)
                            {
                                nouvelleCard = new CardReferenceLieu(reference, this);
                                listCard.Add(nouvelleCard);
                            }
                            break;
                    }
                }
            }
            return listCard;
        }
    }
}
