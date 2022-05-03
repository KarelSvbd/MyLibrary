using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.classes
{
    public class Utilisateur
    {
        private const int DEFAULT_IDUTILISATEUR = 0;
        private int _idUtilisateur;
        private string _email, _password;
        private ClientRest clientRest;

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
            clientRest = new ClientRest("http://localhost/ProjetsWeb/MyLibrary/src/API_MyLibrary/");
            _idUtilisateur = idUtilisateur;
            _email = email;
            _password = password;
        }

        public Utilisateur(string email, string password) : this(DEFAULT_IDUTILISATEUR, email, password)
        {

        }

        /*public bool testConnexion()
        {

        }*/
    }
}
