/* Projet   : MyLibrary - TPI 2022
 * Version  : 0.6
 * Date     : 10.05.2022
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
        public frmCollectionReferences(Livre livre, Utilisateur utilisateur)
        {
            _livre = livre;
            _utilisateur = utilisateur;
            _references = new List<Reference>();
            _cardsReferences = new List<Card>();

            InitializeComponent();
            //Changement dynamique du nom de la form
            Text += " " + _livre.Titre;
            lblTitreLivre.Text = _livre.Titre;
            _clientRest = ClientRest.Instance;
            _types = _clientRest.TousTypes(_utilisateur);
            _livres = _clientRest.LivresParUtilisateur(_utilisateur);
            majCbxTypes(_types);
            
            UpdateFormView();
            btnAjouter.Enabled = true;
            btnModifier.Enabled = true;
            btnSupprimer.Enabled = true;

            

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            //Ajout test de la combobox
            switch (cbxType.SelectedIndex)
            {
                case 0:
                    if(cbxLivre.SelectedIndex == 0)
                    {
                        //new ReferenceLivre(0)
                        
                    }
                    else
                    {
                        if (new ReferenceLivre(0, _livres[cbxLivre.SelectedIndex - 1].IdLivre, _livre.IdLivre).PostReference(_utilisateur))
                        {
                            Console.WriteLine(_livres[cbxLivre.SelectedIndex - 1].IdLivre + " " +_livre.IdLivre);
                            MessageBox.Show("La référence à été ajoutée", "Référence Ajoutée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UpdateFormView();
                        }
                        else
                        {
                            MessageBox.Show("Un problème s'est produit lors de l'envoie de la donnée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case 1:
                    if (new ReferenceMusique(0, "à ajouter", tbxTitre.Text, tbxAuteur.Text, ObjLivre.IdLivre).PostReference(_utilisateur))
                    {
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

        private void lblTxtReference_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnAjouterLivre_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Mise à jour des éléments de la vue
        /// </summary>
        private void UpdateFormView()
        {
            //Mise à 0 des List
            _references.Clear();
            _cardsReferences.Clear();
            flpReferences.Controls.Clear();

            //récupération des éléments
            _references = _clientRest.ReferencesParLivre(_utilisateur, _livre);

            cbxLivre.Items.Add("-- NOUVEAU LIVRE --");
            foreach (Livre lvr in _livres)
            {
                cbxLivre.Items.Add(lvr.Titre);
            }
            cbxLivre.SelectedIndex = 0;

            

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

        private void MajDonneesBase()
        {

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
                    cbxType.SelectedIndex = 0;
                    break;
                //Musique
                case 2:
                    tbxTitre.Text = card.ObjReference.NomReference;
                    tbxAuteur.Text = card.ObjReference.Auteur;
                    tbxDescription.Text = card.ObjReference.DescriptionLieu;
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
            //new ReferenceMusique(0, "à ajouter", tbxTitre.Text, tbxAuteur.Text, ObjLivre.IdLivre).PutReference(_utilisateur, new ReferenceMusique(_cardSelectionne.ObjReference.IdReference,  "A Ajouter", tbxTitre.Text, tbxAuteur.Text,  _livre.IdLivre))
            switch (_cardSelectionne.ObjReference.IdType)
            {
                case 1:

                    break;
                //Musique
                case 2:
                    if (_cardSelectionne.ObjReference.PutReference(_utilisateur, new ReferenceMusique(0, "à ajouter", tbxTitre.Text, tbxAuteur.Text, ObjLivre.IdLivre)))
                    {
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
    }
}
