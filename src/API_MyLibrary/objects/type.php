<?php
    /*  Projet  : API_MyLibrary
        Auteur  : Svoboda Karel Vilém
        Class   : Type
        Desc.   : Permet de répliquer les données dans la table Types
    */

    class Type
    {
        //Variables d'instances
        private $_idType, $_nomType;

        //Propriétés
        public function getIdType(){
            return $this->_idType;
        }
        public function setIdType($idType){
            $this->_idType = $idType;
        }

        public function getNomType(){
            return $this->_nomType;
        }
        public function setNomType($nomType){
            $this->_nomType = $nomType;
        }

        //Constructeur

        /** Permet de créer un Type de reference
         * 
         *  @param integer int(11) $idType
         *  @param string varchar(255) $nomType
         */
        function __construct(int $idType, string $nomType)
        {
            $this->_idType = $idType;
            $this->_nomType = $nomType;
        }

        //Fonctions

        /** Permet de retourner un array avec les informations de l'objet
         * 
         * @return array array formé pour JSON
         */
        public function returnArrayForJSON(){
            return array(
                "idType" => $this->_idType,
                "nomType" => $this->_nomType,
            );
        }
    }
?>