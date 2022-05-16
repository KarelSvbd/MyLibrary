/* Projet   : MyLibrary - TPI 2022
 * Version  : 0.8.1
 * Date     : 16.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : Type.cs class
 * Decs.    : Permet d'encapsuler la table Types de la base de données
 */

namespace MyLibrary.classes
{
    public class Type
    {
        #region Variables d'instances
        private int _idType;
        private string _nomType;
        #endregion

        #region Propriétés
        public int IdType
        {
            get { return _idType; }
            set { _idType = value; }
        }

        public string NomType
        {
            get { return _nomType; }
            set { _nomType = value; }
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Permet d'encapsuler la table Types de la base de données
        /// </summary>
        /// <param name="idType">int(11)</param>
        /// <param name="nomType">varchar(255)</param>
        public Type(int idType, string nomType)
        {
            _idType = idType;
            _nomType = nomType;
        }
        #endregion
    }
}
