/* Projet   : MyLibrary - TPI 2022
 * Version  : 1.0
 * Date     : 18.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : frmConnexion.cs Form
 * Decs.    : Vue de la connexion
 * 
 * IMPORTANT : SI VOUS RENCONTREZ DU PROBLEME DU LOGIN, CHANGEZ LA VELEUR DANS LA BASE MyLibrary.Utilisateur.Connecte DE 1 à 0
 *             Si vous avez des problème à générer les solution, veuillez lancer l'application une fois afin que les design s'affichent
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
            //initialisation des composants
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            //Vérification si les champs sont remplis
            if(tbxEmail.Text != "" && tbxPassword.Text != "")
            {
                try
                {
                    //Création d'un nouvel utilisateur avec les données des champs
                    var user = new Utilisateur(tbxEmail.Text, GenererSha1(tbxPassword.Text).ToLower());
                    //Tentative de connexion à l'API
                    if (user.TestConnexion())
                    {
                        //Affichage de la nouvelle form
                        frmCollectionLivres collectionLivres = new frmCollectionLivres(user, this);
                        collectionLivres.Show();
                    }
                    //Si les données de connexion ne correspondent pas
                    else
                    {
                        //Message d'erreur
                        MessageBox.Show("Erreur lors de la connexion", "Attention Requise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                {
                    //Message d'erreur
                    MessageBox.Show("Problème interne lors de la connexion : " + Environment.NewLine + ex, "Erreur interne", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //Afficahge au clair du mot de passe lors du maintien du bouton d'affichage
        private void btnAfficherMdp_MouseDown(object sender, MouseEventArgs e)
        {
            //Affichage du mot de passe en clair
            tbxPassword.PasswordChar = '\0';
        }

        //Changement de la vue des données afin de masquer le mot de passe
        private void btnAfficherMdp_MouseUp(object sender, MouseEventArgs e)
        {
            //Cache le mot de passe
            tbxPassword.PasswordChar = '*';
        }
    }
}
