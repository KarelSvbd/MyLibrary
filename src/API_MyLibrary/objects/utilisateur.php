<?php
    /*  Projet  : API_MyLibrary
        Auteur  : Svoboda Karel Vilém
        Class   : Type
        Desc.   : Permet de répliquer les données dans la table Utilisateurs
    */

    class Utilisateur
    {
        //Variables d'instances
        private $_idUtilisateur, $_email, $_password, $_connecte;

        //Propriétés
        public function getIdUtilisateur(){
            return $this->_idUtilisateur;
        }
        public function setIdUtilisateur(int $idUtilisateur){
            $this->_idUtilisateur = $idUtilisateur;
        }

        public function getEmail(){
            return $this->_email;
        }
        public function setEmail(string $email){
            $this->_email = $email;
        }

        public function getPassword(){
            return $this->_password;
        }
        public function setPassword(string $password){
            $this->_password = $password;
        }

        public function getConnecte(){
            return $this->_connecte;
        }
        public function setConnecte(bool $connecte){
            $this->_connecte = $connecte;
        }

        //Constructeur

        /** Permet de créer un Utilisateur
         * 
         *  @param integer int(11) $idUtilisateur
         *  @param string varchar(255) $email
         *  @param string varchar(255) $password
         */
        function __construct(int $idUtilisateur, string $email, string $password, bool $connecte)
        {
            $this->_idUtilisateur = $idUtilisateur;
            $this->_email = $email;
            $this->_password = $password;
            $this->_connecte = $connecte;
        }

        //Fonctions

        /** Permet de retourner un array avec les informations de l'objet
         * 
         * @return array array formé pour JSON
         */
        public function returnArrayForJSON(){
            return array(
                "idUtilisateur" => $this->_idUtilisateur,
                "email" => $this->_email,
                "password" => $this->_password,
                "connecte" => $this->_connecte
            );
        }
    }
?>