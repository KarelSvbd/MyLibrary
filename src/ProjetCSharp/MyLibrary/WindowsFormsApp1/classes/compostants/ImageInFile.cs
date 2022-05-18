/* Projet   : MyLibrary - TPI 2022
 * Version  : 1.0
 * Date     : 18.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : ImageInFile.cs class
 * Decs.    : Permet de stoquer une image avec ses informations
 */

using System;
using System.Drawing;
using System.Linq;

namespace MyLibrary
{
    public class ImageInFile
    {
        #region variables d'instances
        private string _nom;
        private string _extension;
        private Bitmap _data;
        #endregion


        #region constantes
        const string DEFAULT_EXTENSION = ".png";
        #endregion

        #region propriétes
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        public Bitmap Data
        {
            get { return _data; }
            set { _data = value; }
        }
        #endregion

        #region constructeurs
        /// <summary>
        /// Permet de stoquer une image avec ses informations
        /// </summary>
        /// <param name="nom">nom de l'image</param>
        /// <param name="extension">type</param>
        /// <param name="data">Bitmap de l'image</param>
        private ImageInFile(string nom, string extension, Bitmap data)
        {
            _nom = nom;
            _extension = extension;
            _data = data;
        }

        /// <summary>
        /// Image avec nom aléatoire
        /// </summary>
        /// <param name="extension">type</param>
        /// <param name="data">Bitmap de l'image</param>
        public ImageInFile(string extension, Bitmap data) : this(nomAleatoire(), extension, data) { }

        /// <summary>
        /// Image avec nom aléatoire et sans type (type par défault png)
        /// </summary>
        /// <param name="data">Bitmap de l'image</param>
        public ImageInFile(Bitmap data) : this(DEFAULT_EXTENSION, data) { }
        #endregion




        #region methodes
        /// <summary>
        /// Image avec nom aléatoire et sans type (type par défault png)
        /// Source du code :
        /// https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        /// </summary>
        private static string nomAleatoire()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Permet d'enregistrer l'image en local
        /// </summary>
        public void SaveBmp()
        {
            _data.Save(_nom + _extension);
        }
        #endregion
    }
}
