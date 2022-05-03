<?php
/**
*	Classe d'acces aux donnees Utilise les services de la classe PDO
*	Les attributs sont tous statiques, les 4 premiers pour la connexion
*	$monPdo qui contiendra l'unique instance de la classe
*/
class MyLibrary
{
    private $_serveur = 'mysql:host=localhost';
    private $_bdd = 'dbname=MyLibrary';
    private $_user = 'MyLibraryAPI';
    private $_mdp = 'r6.4>NRM`tC~y*gN';

    private $monPdo;
    private $_unPdo = null;

    private $_retourUtilisateurParEmailPassword = null;
    private $_retourUtilisateurParEmail = null;

    //	Constructeur privé, crée l'instance de PDO qui sera sollicitée
    //	pour toutes les méthodes de la classe
    public function __construct()
    {
        try{
            $this->_unPdo = new PDO($this->_serveur.';'.$this->_bdd, $this->_user, $this->_mdp,array(
                PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8",
                PDO::ATTR_PERSISTENT => true
            ));

            $sql = "SELECT * FROM Utilisateurs WHERE email=:email AND password=:password";
            $this->_retourUtilisateurParEmailPassword = $this->_unPdo->prepare($sql);
            $this->_retourUtilisateurParEmailPassword->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "SELECT * FROM Utilisateurs WHERE email=:email";
            $this->_retourUtilisateurParEmail = $this->_unPdo->prepare($sql);
            $this->_retourUtilisateurParEmail->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');
        }
        catch (PDOException $e) {
            print "Erreur !: " . $e->getMessage() . "<br>";
            die();
        }
    }

    public function testConnexion(Utilisateur $utilisateur){
        $this->_retourUtilisateurParEmailPassword->execute(array(':email' => $utilisateur->getEmail(), ':password' => $utilisateur->getPassword()));
        return isset($this->_retourUtilisateurParEmailPassword->fetchAll()[0][0]);
    }

    public function recevoirUtilisateurParEmail(string $email){
        $this->_retourUtilisateurParEmail->execute(array(':email' => $email));
        $resultat = $this->_retourUtilisateurParEmail->fetchAll();
        return new Utilisateur($resultat[0][0], $resultat[0][1], $resultat[0][2]);
    }

    public function __destruct()
    { 
        $this->_unPdo  = null;
    }


    /*
    *	Fonction statique qui cree l'unique instance de la classe
    *   Appel : $instanceMonPdo = MonPdo::getMonPdo();
    *	@return l'unique objet de la classe MonPdo
    *
    public static function getInstance()
    {
        if(self::$unPdo == null)
        {
            self::$monPdo= new MonPdo();
        }
        return self::$unPdo;
    }
    */
}
?>