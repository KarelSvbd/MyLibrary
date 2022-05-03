using MyLibrary.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
            if(tbxEmail.Text != "" && tbxPassword.Text != "")
            {
                new Utilisateur(tbxEmail.Text, ConvertToSha1(tbxPassword.Text));
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Attention Requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string ConvertToSha1(string text)
        {
            using (SHA1 sha1Hash = SHA1.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                return BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            }
        }
    }
}
