/* Projet   : MyLibrary - TPI 2022
 * Version  : 1.0
 * Date     : 18.05.2022
 * 
 * Auteur   : Karel V. Svoboda
 * Classe   : I.DA-P4A
 * 
 * Class    : CardReference.cs Card
 * Decs.    : Sert de modèles pour les card des références
 */

using MyLibrary.classes;
using WindowsFormsApp1;

namespace MyLibrary
{
    public abstract class CardReference : Card
    {
        #region varaibles d'instance
        Reference _reference;
        frmCollectionReferences _frm;
        #endregion

        #region propriétés
        public Reference ObjReference
        {
            get { return _reference; }
            set { _reference = value; }
        }

        protected frmCollectionReferences Frm
        {
            get { return _frm; }
            set { _frm = value; }
        }
        #endregion

        #region constructeurs
        public CardReference(Reference reference, frmCollectionReferences frm) : base()
        {
            _reference = reference;
            _frm = frm;
            Click += ClickCard;
        }
        #endregion
    }
}
