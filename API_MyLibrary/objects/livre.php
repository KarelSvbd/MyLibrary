<?php
    /*  Projet  : API_MyLibrary
        Auteur  : Svoboda Karel Vilém
        Date    : 03.05.2022
        Version : 0.1

        Class   : Livre
        Desc.   : Permet de répliquer les données dans la table Livres
    */

    class Livres
    {
        //Variables d'instances
        private $_idLivre, $_titre, $_auteur, $_nomImage, $_idUtilisateur;

        //Propriétés
        public function getIdLivre(){
            return $this->_idLivre;
        }
        public function setIdLivre($idLivre){
            $this->_idLivre = $idLivre;
        }

        public function getTitre(){
            return $this->_titre;
        }
        public function setTitre($titre){
            $this->_titre = $titre;
        }

        public function getAuteur(){
            return $this->_auteur;
        }
        public function setAuteur($auteur){
            $this->_auteur = $auteur;
        }

        public function getNomImage(){
            return $this->_nomImage;
        }
        public function setNomImage($nomImage){
            $this->_nomImage = $nomImage;
        }

        public function getIdUtilisateur(){
            return $this->_idUtilisateur;
        }
        public function setIdUtilisateur($idUtilisateur){
            $this->_idUtilisateur = $idUtilisateur;
        }

        //Constructeur
        /** Permet de créer un livre
         * 
         *  @param integer int(11) $idLivre
         *  @param string varchar(100) $titre
         *  @param string varchar(255) $auteur
         *  @param string varchar(255) $nomImage
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