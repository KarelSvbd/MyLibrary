<?php
    /*  Projet  : API_MyLibrary
        Auteur  : Svoboda Karel Vilém
        Date    : 03.05.2022
        Version : 0.1

        Class   : Type
        Desc.   : Permet de répliquer les données dans la table Types
    */

    class Type
    {
        //Variables d'instances
        private $_idType, $_nomType, $_nomImage, $_auteur, $_description;

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

        public function getNomImage(){
            return $this->_nomImage;
        }
        public function setNomImage($nomImage){
            $this->_nomImage = $nomImage;
        }

        public function getAuteur(){
            return $this->_auteur;
        }
        public function setAuteur($auteur){
            $this->_auteur = $auteur;
        }

        public function getDescription(){
            return $this->_description;
        }
        public function setDescription($description){
            $this->_description = $description;
        }

        

        //Constructeur
        /** Permet de créer un Type de reference
         * 
         *  @param integer int(11) $idType
         *  @param string varchar(255) $nomType
         *  @param string varchar(255) $nomImage
         *  @param string varchar(100) $auteur
         *  @param string mediumtext $description
         */
        function __construct($idType, $nomType, $nomImage, $auteur, $description)
        {
            $this->_idType = $idType;
            $this->_nomType = $nomType;
            $this->_auteur = $auteur;
            $this->_nomImage = $nomImage;
            $this->_description = $description;
        }
    }
?>