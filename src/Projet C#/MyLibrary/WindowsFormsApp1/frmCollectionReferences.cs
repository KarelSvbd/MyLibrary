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
            
            InitializeComponent();
            //Changement dynamique du nom de la form
            Name += " " + _livre.Titre;
            lblTitreLivre.Text = _livre.Titre;
            _clientRest = ClientRest.Instance;
            _types = _clientRest.TousTypes(_utilisateur);
            majCbxTypes(_types);
            

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            new ReferenceMusique(pbxImage.Image, tbxTitre.Text, tbxAuteur.Text);
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

            ActiverTousElements();

            switch (cbxType.SelectedIndex)
            {
                case 0:
                    btnImporterImage.Enabled = true;
                    tbxTitre.Enabled = true;
                    tbxAuteur.Enabled = true;

                    //tbxDescription.Enabled = false;
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }

        private void ActiverTousElements()
        {
            btnImporterImage.Enabled = true;
            tbxTitre.Enabled = true;
            tbxAuteur.Enabled = true;
            tbxDescription.Enabled = true;
            cbxLivre.Enabled = true;
            btnAjouter.Enabled = true;
            btnModifier.Enabled = true;
            btnSupprimer.Enabled = true;
        }

        private void MajDonneesBase()
        {

        }

        private void tbxAuteurMusique_TextChanged(object sender, EventArgs e)
        {
            UpdateFormView();
        }

        private void tbxTitreMusique_TextChanged(object sender, EventArgs e)
        {
            UpdateFormView();
        }

        private void pbxImageMusique_Click(object sender, EventArgs e)
        {

        }

        private void tbxAuteurLivre_TextChanged(object sender, EventArgs e)
        {
            UpdateFormView();
        }

        private void tbxTitreLivre_TextChanged(object sender, EventArgs e)
        {
            UpdateFormView();
        }

        private void cbxLivreExistant_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFormView();
        }

        private void tbxTitreLieu_TextChanged(object sender, EventArgs e)
        {
            UpdateFormView();
        }

        private void tbxDescriptionLieu_TextChanged(object sender, EventArgs e)
        {
            UpdateFormView();
        }

        private void btnImporterImage_Click(object sender, EventArgs e)
        {

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {

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
            UpdateFormView();
        }
    }
}
