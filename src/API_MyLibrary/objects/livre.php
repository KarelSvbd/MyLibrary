<?php
    /*  Projet  : API_MyLibrary
        Auteur  : Svoboda Karel Vilém
        Class   : Livre
        Desc.   : Permet de répliquer les données dans la table Livres
    */

    class Livre
    {
        //Variables d'instances
        private $_idLivre, $_titre, $_auteur, $_nomImage, $_idUtilisateur;

        //Propriétés
        public function getIdLivre(){
            return $this->_idLivre;
        }
        public function setIdLivre(int $idLivre){
            $this->_idLivre = $idLivre;
        }

        public function getTitre(){
            return $this->_titre;
        }
        public function setTitre(string $titre){
            $this->_titre = $titre;
        }

        public function getAuteur(){
            return $this->_auteur;
        }
        public function setAuteur(string $auteur){
            $this->_auteur = $auteur;
        }

        public function getNomImage(){
            return $this->_nomImage;
        }
        public function setNomImage(string $nomImage){
            $this->_nomImage = $nomImage;
        }

        public function getIdUtilisateur(){
            return $this->_idUtilisateur;
        }
        public function setIdUtilisateur(int $idUtilisateur){
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
        function __construct(int $idLivre, string $titre, string $auteur, string $nomImage, int $idUtilisateur)
        {
            $this->_idLivre = $idLivre;
            $this->_titre = $titre;
            $this->_auteur = $auteur;
            $this->_nomImage = $nomImage;
            $this->_idUtilisateur = $idUtilisateur;
        }

        //Fonctions

        /** Permet de retourner un array avec les informations de l'objet
         * 
         * @return array array formé pour JSON
         */
        public function returnArrayForJSON(){
            return array(
                "idLivre" => $this->_idLivre,
                "titre" => $this->_titre,
                "auteur" => $this->_auteur,
                "nomImage" => $this->_nomImage,
                "idUtilisateur" => $this->_idUtilisateur
            );
        }

        public function ReferenceDeLivre(Livre $livre){
            return new Reference(0, "", "", "", 1, $this->_idLivre, $livre->getIdLivre(), "");
        }
    }
?>