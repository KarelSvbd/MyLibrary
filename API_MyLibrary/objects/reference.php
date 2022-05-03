<?php
    /*  Projet  : API_MyLibrary
        Auteur  : Svoboda Karel Vilém
        Date    : 03.05.2022
        Version : 0.1

        Class   : Reference
        Desc.   : Permet de répliquer les données dans la table References
    */

    class Reference
    {
        //Variables d'instances
        private $_idReference, $_nomReference, $_nomImage, $_auteur, $_idType, $_livreReference, $_idUtilisateur;

        //Propriétés
        public function getIdReference(){
            return $this->_idReference;
        }
        public function setIdReference($idReference){
            $this->_idReference = $idReference;
        }

        public function getNomReference(){
            return $this->_nomReference;
        }
        public function setNomReference($nomReference){
            $this->_nomReference = $nomReference;
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

        public function getIdType(){
            return $this->_idType;
        }
        public function setIdType($idType){
            $this->_idType = $idType;
        }

        public function getLivresReference(){
            return $this->_livreReference;
        }
        public function setLivresReference($LivreReference){
            $this->_livreReference = $LivreReference;
        }

        public function getIdUtilisateur(){
            return $this->_idUtilisateur;
        }
        public function setIdUtilisateur($idUtilisateur){
            $this->_idUtilisateur = $idUtilisateur;
        }

        //Constructeur
        /** Permet de créer une Reference
         * 
         *  @param integer int(11) $idReference
         *  @param string varchar(100) $nomReference
         *  @param string varchar(255) $nomImage
         *  @param string varchar(100) $auteur
         *  @param integer int(11) $idType
         *  @param integer int(11) $livreReference
         *  @param integer int(11) $idUtilisateur
         */
        function __construct($idLivre, $titre, $auteur, $nomImage, $idUtilisateur)
        {
            $this->_idLivre = $idLivre;
            $this->_titre = $titre;
            $this->_auteur = $auteur;
            $this->_nomImage = $nomImage;
            $this->_idUtilisateur = $idUtilisateur;
        }
    }
?>