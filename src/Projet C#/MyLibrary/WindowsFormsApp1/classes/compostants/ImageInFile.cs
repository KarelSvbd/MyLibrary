using System;
using System.Drawing;
using System.Linq;

namespace MyLibrary
{
    public class ImageInFile
    {
        private string _nom;
        private string _extension;
        private Bitmap _data;

        const string DEFAULT_EXTENSION = ".png";

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

        private ImageInFile(string nom, string extension, Bitmap data)
        {
            _nom = nom;
            _extension = extension;
            _data = data;
        }

        public ImageInFile(string extension, Bitmap data) : this(nomAleatoire(), extension, data) { }

        public ImageInFile(Bitmap data) : this(DEFAULT_EXTENSION, data) { }

        ///https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        private static string nomAleatoire()
        {
             Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void SaveBmp()
        {
            _data.Save(_nom + _extension);
        }
    }
}
