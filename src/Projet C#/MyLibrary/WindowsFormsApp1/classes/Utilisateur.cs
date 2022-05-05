using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrary.classes
{
    public class Utilisateur
    {
        private const int DEFAULT_IDUTILISATEUR = 0;
        private int _idUtilisateur;
        private string _email, _password;
        private ClientRest _clientRest;

        public int IdUtilisateur
        {
            get { return _idUtilisateur; }
            set { _idUtilisateur = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public Utilisateur(int idUtilisateur, string email, string password)
        {
            _clientRest = ClientRest.Instance;
            _idUtilisateur = idUtilisateur;
            _email = email;
            _password = password;
        }

        public Utilisateur(string email, string password) : this(DEFAULT_IDUTILISATEUR, email, password)
        {
            
        }

        public bool TestConnexion()
        {
            return _clientRest.AppelSimple("?session=connexion&email=" + _email + "&password=" + _password + "", "get");
        }

        public void Deconnexion()
        {
            _clientRest.AppelSimple("?session=deconnexion&email="+_email+"", "get");
        }

        public void RecuperationInfoUtiisateur()
        {
            //var result = _clientRest.ApiRequest("?session=info", "get");

            /*foreach(var item in result)
            {*/
                //MessageBox.Show(result.ToString());
            //}
        }
    }
}
