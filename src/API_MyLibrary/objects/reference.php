<?php
    /*  Projet  : API_MyLibrary
        Auteur  : Svoboda Karel Vilém
        Class   : Reference
        Desc.   : Permet de répliquer les données dans la table References
    */

    class Reference
    {
        //Variables d'instances
        private $_idReference, $_nomReference, $_nomImage, $_auteur, $_idType, $_livreReference, $_idLivre, $_description;

        //Propriétés
        public function getIdReference(){
            return $this->_idReference;
        }
        public function setIdReference(int $idReference){
            $this->_idReference = $idReference;
        }

        public function getNomReference(){
            return $this->_nomReference;
        }
        public function setNomReference(string $nomReference){
            $this->_nomReference = $nomReference;
        }

        public function getNomImage(){
            return $this->_nomImage;
        }
        public function setNomImage(string $nomImage){
            $this->_nomImage = $nomImage;
        }

        public function getAuteur(){
            return $this->_auteur;
        }
        public function setAuteur(string $auteur){
            $this->_auteur = $auteur;
        }

        public function getIdType(){
            return $this->_idType;
        }
        public function setIdType($idType){
            $this->_idType = $idType;
        }

        public function getLivresReference(){
            return $this->_livreReference;
        }
        public function setLivresReference(string $LivreReference){
            $this->_livreReference = $LivreReference;
        }

        public function getIdLivre(){
            return $this->_idLivre;
        }
        public function setIdLivre(int $idLivre){
            $this->_idLivre = $idLivre;
        }

        public function getDescription(){
            return $this->_description;
        }
        public function setDescription($description){
           $this->_description =  $description;
        }

        //Constructeur
        
        /** Permet de créer une Reference
         * 
         *  @param integer int(11) $idReference
         *  @param string varchar(100) $nomReference
         *  @param string varchar(255) $nomImage
         *  @param string varchar(100) $auteur
         *  @param  int(11) $idType
         *  @param integer int(11) $livreReference
         *  @param integer int(11) $idUtilisateur
         */
        function __construct(int $idReference, string $nomReference, string $nomImage, string $auteur, int $idType, int $livreReference, int $idLivre, int $description)
        {
            $this->_idReference = $idReference;
            $this->_nomReference = $nomReference;
            $this->_nomImage = $nomImage;
            $this->_auteur = $auteur;
            $this->_idType = $idType;
            $this->_livreReference = $livreReference;
            $this->_idLivre = $idLivre;
            $this->_description = $description;
        }

        //Fonctions

        /** Permet de retourner un array avec les informations de l'objet
         * 
         * @return array array formé pour JSON
         */
        public function returnArrayForJSON(){
            return array(
                "idReference" => $this->_idReference,
                "nomReference" => $this->_nomReference,
                "nomImage" => $this->_nomImage,
                "auteur" => $this->_auteur,
                "idType" => $this->_idType,
                "livreReference" => $this->_livreReference,
                "idLivre" => $this->_idLivre,
                "description" => $this->_description
            );
        }
    }
?>