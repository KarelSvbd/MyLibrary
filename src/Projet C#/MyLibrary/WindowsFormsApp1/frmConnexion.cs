/* Projet   : MyLibrary - TPI 2022
 * Version  : 0.6
 * Date     : 10.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : frmConnexion.cs Form
 * Decs.    : Vue de la connexion
 */

using MyLibrary.classes;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MyLibrary
{
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            //Vérification si les champs sont remplis
            if(tbxEmail.Text != "" && tbxPassword.Text != "")
            {
                //Création d'un nouvel utilisateur avec les données des champs
                var user = new Utilisateur(tbxEmail.Text, GenererSha1(tbxPassword.Text).ToLower());
                //Tentative de connexion à l'API
                if (user.TestConnexion())
                {
                    user.RecuperationInfoUtiisateur();
                    //Affichage de la nouvelle form
                    frmCollectionLivres collectionLivres = new frmCollectionLivres(user, this);
                    collectionLivres.Show();
                }
                //Si les données de connexion ne correspondent pas
                else
                {
                    //Message d'erreur
                    MessageBox.Show("Email ou Mot de passe erroné", "Attention Requise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //Message d'erreur
                MessageBox.Show("Veuillez remplir tous les champs", "Attention Requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Permet de créer un sha1 à partir d'un string
        /// </summary>
        /// <param name="text">Text à générer</param>
        /// <returns>Sha1 du texte</returns>
        private string GenererSha1(string text)
        {
            using (SHA1 sha1Hash = SHA1.Create())
            {
                //Conversion en Bytes
                byte[] sourceBytes = Encoding.UTF8.GetBytes(text);
                //Création du Sha1
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                //Convertis le tableau de byte en string
                return BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            }
        }

        private void btnAfficherMdp_MouseDown(object sender, MouseEventArgs e)
        {
            //Affichage du mot de passe en clair
            tbxPassword.PasswordChar = '\0';
        }

        private void btnAfficherMdp_MouseUp(object sender, MouseEventArgs e)
        {
            //Cache le mot de passe
            tbxPassword.PasswordChar = '*';
        }

        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {
            
        }

        
    }
}
