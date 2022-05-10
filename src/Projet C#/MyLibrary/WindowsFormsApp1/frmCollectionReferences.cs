using MyLibrary;
using MyLibrary.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmCollectionReferences : Form
    {
        private Livre _livre;
        private Utilisateur _utilisateur;
        private ClientRest _clientRest;
        private List<Reference> _references;
        private List<Card> _cardsReferences;
        private CardReference _cardSelectionne;
        //Référence ambigu 
        private List<MyLibrary.classes.Type> _types;

        public Livre ObjLivre
        {
            get { return _livre; }
            set { _livre = value; }
        }
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
            majCbxTypes(_types);
            
            UpdateFormView();
            btnAjouter.Enabled = true;
            btnModifier.Enabled = true;
            btnSupprimer.Enabled = true;

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            //Ajout test de la combobox
            if(new ReferenceMusique(0, "à ajouter", tbxTitre.Text, tbxAuteur.Text, ObjLivre.IdLivre).PostReference(_utilisateur))
            {
                MessageBox.Show("La référence à été ajoutée", "Référence Ajoutée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateFormView();
            }
            else
            {
                MessageBox.Show("Un problème s'est produit lors de l'envoie de la donnée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void UpdateFormView()
        {
            _references.Clear();
            _cardsReferences.Clear();
            flpReferences.Controls.Clear();

            _references = _clientRest.ReferencesParLivre(_utilisateur, _livre);

            foreach (Reference reference in _references)
            {
                Card nouvelleCard;
                switch (reference.IdType)
                {
                    case 1:
                        nouvelleCard = new CardReferenceLivre(_utilisateur, reference, this);
                        flpReferences.Controls.Add(nouvelleCard);
                        _cardsReferences.Add(nouvelleCard);
                        break;
                    case 2:
                        nouvelleCard = new CardReferenceMusique(reference, this);
                        flpReferences.Controls.Add(nouvelleCard);
                        _cardsReferences.Add(nouvelleCard);
                        break;
                    case 3:
                        nouvelleCard = new CardReferenceLieu(reference, this);
                        flpReferences.Controls.Add(nouvelleCard);
                        _cardsReferences.Add(nouvelleCard);
                        break;
                }
                
            }
            //ActiverTousElements();
        }

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

        private void tbxAuteurMusique_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbxTitreMusique_TextChanged(object sender, EventArgs e)
        {
        }

        private void pbxImageMusique_Click(object sender, EventArgs e)
        {

        }

        private void tbxAuteurLivre_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbxTitreLivre_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbxLivreExistant_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tbxTitreLieu_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbxDescriptionLieu_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnImporterImage_Click(object sender, EventArgs e)
        {

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Voulez-vous vraiment supprimer cette référence", "Suppression de Référence", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
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
            EtatTousElements(false);
            switch (cbxType.SelectedIndex)
            {
                case 0:
                    tbxTitre.Enabled = true;
                    btnImporterImage.Enabled = true;
                    tbxAuteur.Enabled = true;
                    cbxLivre.Enabled = true;
                    break;
                case 1:
                    tbxTitre.Enabled = true;
                    btnImporterImage.Enabled = true;
                    tbxAuteur.Enabled = true;
                    break;
                case 2:
                    tbxTitre.Enabled= true;
                    tbxDescription.Enabled = true;
                    break;
            }
        }

        public void SelectionCard(CardReference card)
        {
            _cardSelectionne = card;
            foreach(var uneCard in _cardsReferences)
            {
                if(uneCard == card)
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

            switch (card.ObjReference.IdType){
                case 1:
                    cbxType.SelectedIndex = 0;
                    break;
                case 2:
                    
                    tbxTitre.Text = card.ObjReference.NomReference;
                    tbxAuteur.Text = card.ObjReference.Auteur;
                    tbxDescription.Text = card.ObjReference.Description;
                    cbxType.SelectedIndex = 1;
                    break;
                case 3:
                    tbxTitre.Text = card.ObjReference.NomReference;
                    tbxAuteur.Text=card.ObjReference.Auteur;
                    tbxDescription.Text = card.ObjReference.Description;
                    cbxType.SelectedIndex = 2;
                    break;
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (new ReferenceMusique(0, "à ajouter", tbxTitre.Text, tbxAuteur.Text, ObjLivre.IdLivre).PutReference(_utilisateur, new ReferenceMusique(_cardSelectionne.ObjReference.IdReference,  "A Ajouter", tbxTitre.Text, tbxAuteur.Text,  _livre.IdLivre)))
            {
                MessageBox.Show("La référence à été modifiée", "Référence modifiée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateFormView();
            }
            else
            {
                MessageBox.Show("Un problème s'est produit lors de l'envoie de la donnée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
