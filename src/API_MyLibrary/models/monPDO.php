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
    private $_connexionUtilisateur = null;
    private $_deconnexionUtilisateur = null;
    private $_statusConnexionUtilisateur = null;

    private $_afficherLivreParIdUtilisateur = null;
    private $_ajouterLivre = null;
    private $_rechercheLivreParAuteurOuTitre = null;

    //	Constructeur privé, crée l'instance de PDO qui sera sollicitée
    //	pour toutes les méthodes de la classe
    public function __construct()
    {
        try{
            $this->_unPdo = new PDO($this->_serveur.';'.$this->_bdd, $this->_user, $this->_mdp,array(
                PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8",
                PDO::ATTR_PERSISTENT => true
            ));

            //Prepare statements
            $sql = "SELECT * FROM Utilisateurs WHERE email=:email AND password=:password";
            $this->_retourUtilisateurParEmailPassword = $this->_unPdo->prepare($sql);
            $this->_retourUtilisateurParEmailPassword->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "SELECT * FROM Utilisateurs WHERE email=:email";
            $this->_retourUtilisateurParEmail = $this->_unPdo->prepare($sql);
            $this->_retourUtilisateurParEmail->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "UPDATE Utilisateurs SET connecte=1 WHERE idUtilisateur=:idUtilisateur;";
            $this->_connexionUtilisateur = $this->_unPdo->prepare($sql);
            $this->_connexionUtilisateur->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "UPDATE Utilisateurs SET connecte=0 WHERE idUtilisateur=:idUtilisateur;";
            $this->_deconnexionUtilisateur = $this->_unPdo->prepare($sql);
            $this->_deconnexionUtilisateur->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "SELECT connecte FROM Utilisateurs WHERE email=:email";
            $this->_statusConnexionUtilisateur = $this->_unPdo->prepare($sql);
            $this->_statusConnexionUtilisateur->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "INSERT INTO Livres (titre, auteur, nomImage, idUtilisateur) VALUES(:titre, :auteur, :nomImage, :idUtilisateur);";
            $this->_ajouterLivre = $this->_unPdo->prepare($sql);
            $this->_ajouterLivre->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "UPDATE Livres SET titre=:titre, auteur=:auteur, nomImage=:nomImage WHERE idLivre=:idLivre;";
            $this->_modifierLivre = $this->_unPdo->prepare($sql);
            $this->_modifierLivre->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "DELETE FROM Livres WHERE idLivre=:idLivre;";
            $this->_supprimerLivre = $this->_unPdo->prepare($sql);
            $this->_supprimerLivre->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "SELECT * FROM Livres WHERE idUtilisateur=:idUtilisateur";
            $this->_afficherLivreParIdUtilisateur = $this->_unPdo->prepare($sql);
            $this->_afficherLivreParIdUtilisateur->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "SELECT * FROM Livres WHERE auteur LIKE :auteur OR titre LIKE :titre AND idUtilisateur=:idUtilisateur";
            $this->_rechercheLivreParAuteurOuTitre = $this->_unPdo->prepare($sql);
            $this->_rechercheLivreParAuteurOuTitre->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

        }
        catch (PDOException $e) {
            print "Erreur !: " . $e->getMessage() . "<br>";
            die();
        }
    }

    public function connexionUtilisateur(Utilisateur $utilisateur){
        $this->_connexionUtilisateur->execute(array(':idUtilisateur' => $utilisateur->getIdUtilisateur()));
    }

    public function deconnexionUtilisateur(Utilisateur $utilisateur){
        $this->_deconnexionUtilisateur->execute(array(':idUtilisateur' => $utilisateur->getIdUtilisateur()));
    }

    public function testConnexion(Utilisateur $utilisateur){
        $this->_retourUtilisateurParEmailPassword->execute(array(':email' => $utilisateur->getEmail(), ':password' => $utilisateur->getPassword()));
        return isset($this->_retourUtilisateurParEmailPassword->fetchAll()[0][0]);
    }

    public function recevoirUtilisateurParEmail(string $email){
        $this->_retourUtilisateurParEmail->execute(array(':email' => $email));
        $resultat = $this->_retourUtilisateurParEmail->fetchAll();
        return new Utilisateur($resultat[0][0], $resultat[0][1], $resultat[0][2], $resultat[0][3]);
    }

    public function statusConnexionUtilisateur(string $email){
        $this->_statusConnexionUtilisateur->execute(array(':email' => $email));
        $resultat = $this->_statusConnexionUtilisateur->fetchAll();
        return $resultat[0][0];
    }

    public function ajouterLivre(Livre $livre){
        $this->_ajouterLivre->execute(array(':titre' => $livre->getTitre(), ':auteur' => $livre->getAuteur(), ':nomImage' => $livre->getNomImage(), ':idUtilisateur' => $livre->getIdUtilisateur()));
    }

    public function modifierLivre(Livre $livre){
        $this->_modifierLivre->execute(array(':idLivre'=>$livre->getIdLivre(),':titre' => $livre->getTitre(), ':auteur' => $livre->getAuteur(), ':nomImage' => $livre->getNomImage()));
    }

    public function supprimerLivre(Livre $livre){
        $this->_supprimerLivre->execute(array(':idLivre'=>$livre->getIdLivre()));
    }

    public function livresParUtilisateur(Utilisateur $utilisateur){
        $this->_afficherLivreParIdUtilisateur->execute(array(':idUtilisateur' => $utilisateur->getIdUtilisateur()));
        $resultat = $this->_afficherLivreParIdUtilisateur->fetchAll();
        $arrayLivre = array();
        foreach($resultat as $unLivre){
            array_push($arrayLivre, new Livre($unLivre[0], $unLivre[1], $unLivre[2], $unLivre[3], $unLivre[4]));
        }
        return $arrayLivre;
    }

    public function rechercheLivreParAuteurOuTitre(Utilisateur $utilisateur, string $recherche){
        $this->_rechercheLivreParAuteurOuTitre->execute(array(':idUtilisateur' => $utilisateur->getIdUtilisateur(), ':auteur' => "%".$recherche."%", ':titre' => "%".$recherche."%"));
        $resultat = $this->_rechercheLivreParAuteurOuTitre->fetchAll();
        $arrayLivre = array();
        foreach($resultat as $unLivre){
            array_push($arrayLivre, new Livre($unLivre[0], $unLivre[1], $unLivre[2], $unLivre[3], $unLivre[4]));
        }
        return $arrayLivre;
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