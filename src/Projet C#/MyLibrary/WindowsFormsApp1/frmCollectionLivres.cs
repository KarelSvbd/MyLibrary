using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary.classes;

namespace MyLibrary
{
    public partial class frmCollectionLivres : Form
    {
        Utilisateur _utlisateur;
        
        public frmCollectionLivres(Utilisateur utilisateur, frmConnexion frmPrecedente)
        {
            InitializeComponent();
            _utlisateur = utilisateur;
            frmPrecedente.Close();
            
        }

        private void frmCollectionLivres_Load(object sender, EventArgs e)
        {

        }

        private void card1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            //new Livre(0, tbxTitre.Text, tbxAuteur.Text, pbxImageAjouter.Tag.ToString(), 0).PostLivre(_utlisateur);
            //https://www.codeproject.com/Questions/546631/howplustoplussavepluspictureboxplusimageplusinplus
            try
            {
                pbxImageAjouter.Image.Save(@"C:/Users/karel.svbd/Pictures/MyLibraryData");
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

        private void VerifBtnAjouter()
        {
            if (tbxAuteur.Text != "" && tbxTitre.Text != "" && pbxImageAjouter.Image != null)
            {
                btnAjouter.Enabled = true;
            }
            else
            {
                // <!> Changer plus tard
                btnAjouter.Enabled = true;
            }
        }

        private void tbxAuteur_TextChanged(object sender, EventArgs e)
        {
            VerifBtnAjouter();
        }

        private void tbxTitre_TextChanged(object sender, EventArgs e)
        {
            VerifBtnAjouter();
        }

        private void card1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void frmCollectionLivres_FormClosed(object sender, FormClosedEventArgs e)
        {
            _utlisateur.Deconnexion();
        }
    }
}
