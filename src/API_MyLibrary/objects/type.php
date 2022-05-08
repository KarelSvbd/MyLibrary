<?php
    /*  Projet  : API_MyLibrary
        Auteur  : Svoboda Karel Vilém
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
        function __construct(int $idType, string $nomType, string $nomImage, string $auteur, string $description)
        {
            $this->_idType = $idType;
            $this->_nomType = $nomType;
            $this->_auteur = $auteur;
            $this->_nomImage = $nomImage;
            $this->_description = $description;
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
                "auteur" => $this->_auteur,
                "nomImage" => $this->_nomImage,
                "description" => $this->_description
            );
        }
    }
?>