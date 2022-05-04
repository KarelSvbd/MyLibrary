<?php
    /*  Projet  : API_MyLibrary
        Auteur  : Svoboda Karel Vilém
        Date    : 03.05.2022
        Version : 0.1

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
        public function setIdUtilisateur($idUtilisateur){
            $this->_idUtilisateur = $idUtilisateur;
        }

        public function getEmail(){
            return $this->_email;
        }
        public function setEmail($email){
            $this->_email = $email;
        }

        public function getPassword(){
            return $this->_password;
        }
        public function setPassword($password){
            $this->_password = $password;
        }

        public function getConnecte(){
            return $this->_connecte;
        }
        public function setConnecte($connecte){
            $this->_connecte = $connecte;
        }

        //Constructeur
        /** Permet de créer un Utilisateur
         * 
         *  @param integer int(11) $idUtilisateur
         *  @param string varchar(255) $email
         *  @param string varchar(255) $password
         */
        function __construct($idUtilisateur, $email, $password, $connecte)
        {
            $this->_idUtilisateur = $idUtilisateur;
            $this->_email = $email;
            $this->_password = $password;
            $this->_connecte = $connecte;
        }

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