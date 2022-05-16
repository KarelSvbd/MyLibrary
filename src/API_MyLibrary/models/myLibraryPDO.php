<?php
/*  Projet  : API_MyLibrary
    Auteur  : Svoboda Karel Vilém
    Class   : Livre
    Desc.   : Permet de répliquer les données dans la table Livres
*/

class MyLibrary
{
    // <!> À modifier lors de la mise en production <!>
    //Données de connexion à la base
    private $_serveur = 'mysql:host=localhost';
    private $_bdd = 'dbname=MyLibrary';
    private $_user = 'MyLibraryAPI';
    private $_mdp = 'r6.4>NRM`tC~y*gN';

    private $_connexionPDO = null;

    //Utilisateurs
    private $_retourUtilisateurParEmailPassword = null;
    private $_retourUtilisateurParEmail = null;
    private $_connexionUtilisateur = null;
    private $_deconnexionUtilisateur = null;
    private $_statusConnexionUtilisateur = null;

    //Livres
    private $_afficherLivreParIdUtilisateur = null;
    private $_rechercheLivreParIdLivre = null;
    private $_ajouterLivre = null;
    private $_rechercheLivreParAuteurOuTitre = null;
    private $_dernierLivreUtilisateur = null;

    //Références
    private $_referencesParLivre = null;
    private $_ajouterReference = null;

    
    private $_ajouterReferenceMusique;
    private $_modifierReferenceMusique;

    private $_ajouterReferenceLivre;

    private $_ajouterReferenceLieu;
    private $_modifierReferenceLieu;

    //Types
    private $_tousTypes = null;

    //Constructeur
    public function __construct()
    {
        try{
            $this->_connexionPDO = new PDO($this->_serveur.';'.$this->_bdd, $this->_user, $this->_mdp,array(
                PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8",
                PDO::ATTR_PERSISTENT => true
            ));

            //Prepare statements

            //Utilisateurs
            $sql = "SELECT * FROM Utilisateurs WHERE email=:email AND password=:password";
            $this->_retourUtilisateurParEmailPassword = $this->_connexionPDO->prepare($sql);
            $this->_retourUtilisateurParEmailPassword->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "SELECT * FROM Utilisateurs WHERE email=:email";
            $this->_retourUtilisateurParEmail = $this->_connexionPDO->prepare($sql);
            $this->_retourUtilisateurParEmail->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "UPDATE Utilisateurs SET connecte=1 WHERE idUtilisateur=:idUtilisateur;";
            $this->_connexionUtilisateur = $this->_connexionPDO->prepare($sql);
            $this->_connexionUtilisateur->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "UPDATE Utilisateurs SET connecte=0 WHERE idUtilisateur=:idUtilisateur;";
            $this->_deconnexionUtilisateur = $this->_connexionPDO->prepare($sql);
            $this->_deconnexionUtilisateur->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "SELECT connecte FROM Utilisateurs WHERE email=:email";
            $this->_statusConnexionUtilisateur = $this->_connexionPDO->prepare($sql);
            $this->_statusConnexionUtilisateur->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            //Livres
            $sql = "INSERT INTO Livres (titre, auteur, nomImage, idUtilisateur) VALUES(:titre, :auteur, :nomImage, :idUtilisateur);";
            $this->_ajouterLivre = $this->_connexionPDO->prepare($sql);
            $this->_ajouterLivre->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "SELECT * FROM Livres WHERE idLivre=:idLivre";
            $this->_rechercheLivreParIdLivre = $this->_connexionPDO->prepare($sql);
            $this->_rechercheLivreParIdLivre->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "UPDATE Livres SET titre=:titre, auteur=:auteur, nomImage=:nomImage WHERE idLivre=:idLivre;";
            $this->_modifierLivre = $this->_connexionPDO->prepare($sql);
            $this->_modifierLivre->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "DELETE FROM Livres WHERE idLivre=:idLivre;";
            $this->_supprimerLivre = $this->_connexionPDO->prepare($sql);
            $this->_supprimerLivre->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "SELECT * FROM Livres WHERE idUtilisateur=:idUtilisateur";
            $this->_afficherLivreParIdUtilisateur = $this->_connexionPDO->prepare($sql);
            $this->_afficherLivreParIdUtilisateur->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "SELECT * FROM Livres WHERE auteur LIKE :auteur OR titre LIKE :titre AND idUtilisateur=:idUtilisateur";
            $this->_rechercheLivreParAuteurOuTitre = $this->_connexionPDO->prepare($sql);
            $this->_rechercheLivreParAuteurOuTitre->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');
            //dernierIdLivre
            $sql = "SELECT * FROM Livres WHERE idUtilisateur=:idUtilisateur ORDER BY idLivre DESC LIMIT 1";
            $this->_dernierLivreUtilisateur = $this->_connexionPDO->prepare($sql);
            $this->_dernierLivreUtilisateur->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            //Références
            $sql = "SELECT * FROM MyLibrary.References WHERE idLivre=:idLivre";
            $this->_referencesParLivre = $this->_connexionPDO->prepare($sql);
            $this->_referencesParLivre->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "DELETE FROM MyLibrary.References WHERE idReference=:idReference;";
            $this->_supprimerReference = $this->_connexionPDO->prepare($sql);
            $this->_supprimerReference->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

                // Référence type musique
            $sql = "INSERT INTO MyLibrary.References (nomReference, nomImage, idType, auteur, idLivre) VALUES(:nomReference, :nomImage, :idType, :auteur, :idLivre);";
            $this->_ajouterReferenceMusique = $this->_connexionPDO->prepare($sql);
            $this->_ajouterReferenceMusique->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            $sql = "UPDATE MyLibrary.References SET nomReference=:nomReference, nomImage=:nomImage, idType=:idType, auteur=:auteur, idLivre=:idLivre WHERE idReference=:idReference;";
            $this->_modifierReferenceMusique = $this->_connexionPDO->prepare($sql);
            $this->_modifierReferenceMusique->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

                // Référence type Livre
            $sql = "INSERT INTO MyLibrary.References (livreReference, idType, idLivre) VALUES(:livreReference, :idType, :idLivre);";
            $this->_ajouterReferenceLivre = $this->_connexionPDO->prepare($sql);
            $this->_ajouterReferenceLivre->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

                // Référence type Lieu
            $sql = "INSERT INTO MyLibrary.References (nomReference, idType, idLivre, descriptionLieu) VALUES(:nomReference, :idType, :idLivre, :descriptionLieu);";
                $this->_ajouterReferenceLieu = $this->_connexionPDO->prepare($sql);
                $this->_ajouterReferenceLieu->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');
            
                $sql = "UPDATE MyLibrary.References SET nomReference=:nomReference, idType=:idType, idLivre=:idLivre, descriptionLieu=:descriptionLieu WHERE idReference=:idReference;";
            $this->_modifierReferenceLieu = $this->_connexionPDO->prepare($sql);
            $this->_modifierReferenceLieu->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

            //Types
            $sql = "SELECT * FROM Types";
            $this->_tousTypes = $this->_connexionPDO->prepare($sql);
            $this->_tousTypes->setFetchMode(PDO::FETCH_ASSOC, 'MyLibrary');

        }
        catch (PDOException $e) {
            //Affichage de l'erreur dans les logis
            error_log("Erreur PDO ! : " . $e->getMessage());
            die();
        }
    }

    /** Permet de connecter un utilisateur 
     *  <!> Methode vulnérable à utiliser strictement après une connexion correcte de l'utilisateur (testConnexion) <!> 
     * 
     *  @Utilisateur $utilisateur utilisateur à connecter
     * 
     *  @return null
     */
    public function connexionUtilisateur(Utilisateur $utilisateur){
        $this->_connexionUtilisateur->execute(array(':idUtilisateur' => $utilisateur->getIdUtilisateur()));
    }

    /** Permet de déconnecter un utilisateur
     * 
     *  @Utilisateur $utilisateur utilisateur à déconnecter
     * 
     *  @return null
     */
    public function deconnexionUtilisateur(Utilisateur $utilisateur){
        $this->_deconnexionUtilisateur->execute(array(':idUtilisateur' => $utilisateur->getIdUtilisateur()));
    }

    /** Permet de faire une tentative de connexion
     * 
     * @Utilisateur $utilisateur utilisateur à connecter
     * 
     * @return bool connexion correcte = true, connexion fausse = false
     */
    public function testConnexion(Utilisateur $utilisateur){
        $this->_retourUtilisateurParEmailPassword->execute(array(':email' => $utilisateur->getEmail(), ':password' => $utilisateur->getPassword()));
        return isset($this->_retourUtilisateurParEmailPassword->fetchAll()[0][0]);
    }

    /** Retourne un utilisateur par email
     * 
     * @string email de l'utilisateur à rechercher
     * 
     * @return Utilisateur utilisateur avec par email
     */
    public function recevoirUtilisateurParEmail(string $email){
        $this->_retourUtilisateurParEmail->execute(array(':email' => $email));
        $resultat = $this->_retourUtilisateurParEmail->fetchAll();
        return new Utilisateur($resultat[0][0], $resultat[0][1], $resultat[0][2], $resultat[0][3]);
    }

    /** retourne si un utilisateur est connecté en fonction de son email
     * 
     * @string email utilisateur
     * 
     * @return bool true = connecté, flase = pas connecté
    */
    public function statusConnexionUtilisateur(string $email){
        $this->_statusConnexionUtilisateur->execute(array(':email' => $email));
        $resultat = $this->_statusConnexionUtilisateur->fetchAll();
        return $resultat[0][0];
    }

    /** Permet d'ajouter un livre
     * 
     * @Livre livre à ajouter
     * @return null
     */
    public function ajouterLivre(Livre $livre){
        $this->_ajouterLivre->execute(array(':titre' => $livre->getTitre(), ':auteur' => $livre->getAuteur(), ':nomImage' => $livre->getNomImage(), ':idUtilisateur' => $livre->getIdUtilisateur()));
    }

    /** Permet de modifier un livre
     * 
     * @Livre livre AVEC les données modifiées sauf les IDs
     * @return null
     */
    public function modifierLivre(Livre $livre){
        $this->_modifierLivre->execute(array(':idLivre'=>$livre->getIdLivre(),':titre' => $livre->getTitre(), ':auteur' => $livre->getAuteur(), ':nomImage' => $livre->getNomImage()));
    }

    
    /** Permet de supprimer un livre
     * 
     * @Livre livre à supprimer
     * @return null
     */
    public function supprimerLivre(Livre $livre){
        $this->_supprimerLivre->execute(array(':idLivre'=>$livre->getIdLivre()));
    }

    /** Permet de retourener tous les livres d'utilisateur
     * 
     * @Utilisateur utilisateur en question
     * @return array(Livres) retourne la liste des Livres
    */
    public function livresParUtilisateur(Utilisateur $utilisateur){
        $this->_afficherLivreParIdUtilisateur->execute(array(':idUtilisateur' => $utilisateur->getIdUtilisateur()));
        $resultat = $this->_afficherLivreParIdUtilisateur->fetchAll();
        $arrayLivre = array();
        foreach($resultat as $unLivre){
            array_push($arrayLivre, new Livre($unLivre[0], $unLivre[1], $unLivre[2], $unLivre[3], $unLivre[4]));
        }
        return $arrayLivre;
    }

    public function dernierLivreUtilisateur(Utilisateur $utilisateur){
        $this->_dernierLivreUtilisateur->execute(array(':idUtilisateur' => $utilisateur->getIdUtilisateur()));
        $resultat = $this->_dernierLivreUtilisateur->fetchAll();
        $arrayLivre = array();
        foreach($resultat as $unLivre){
            array_push($arrayLivre, new Livre($unLivre[0], $unLivre[1], $unLivre[2], $unLivre[3], $unLivre[4]));
        }
        return $arrayLivre[0];
    }

    /** Permet de faire une recherche grâce à un filtre personnalisé. Le programme va chercher dans la base les éléments de l'utilisateur avec les filtres en quesiton sous les tables Auteur et Titre
     * 
     * @Utilisateur $utilisateur utilisateur qui fait la requête
     * @string chaîne de caractères à rechercher
     */
    public function rechercheLivreParAuteurOuTitre(Utilisateur $utilisateur, string $recherche){
        $this->_rechercheLivreParAuteurOuTitre->execute(array(':idUtilisateur' => $utilisateur->getIdUtilisateur(), ':auteur' => "%".$recherche."%", ':titre' => "%".$recherche."%"));
        $resultat = $this->_rechercheLivreParAuteurOuTitre->fetchAll();
        //Création d'une instance de Livre pour chaque donnée trouvée et retour du résultat dans un array
        $arrayLivre = array();
        foreach($resultat as $unLivre){
            array_push($arrayLivre, new Livre($unLivre[0], $unLivre[1], $unLivre[2], $unLivre[3], $unLivre[4]));
        }
        return $arrayLivre;
    }

    public function tousTypes(){
        $this->_tousTypes->execute();
        $resultat = $this->_tousTypes->fetchAll();

        $arrayTitre = array();
        foreach($resultat as $unType){
            array_push($arrayTitre, new Type($unType[0], $unType[1]));
        }
        return $arrayTitre;
    }

    public function referencesParLivre(Livre $livre){
        $this->_referencesParLivre->execute(array(':idLivre' => $livre->getIdLivre()));
        $resultat = $this->_referencesParLivre->fetchAll();
        $arrayReference = array();
        foreach($resultat as $uneReference){
            array_push($arrayReference, new Reference($uneReference[0], $uneReference[1], $uneReference[2], $uneReference[3], $uneReference[4], $uneReference[5], $uneReference[6], $uneReference[7]));
        }
        return $arrayReference;
    }

    public function rechercheLivreParIdLivre(int $idLivre){
        $this->_rechercheLivreParIdLivre->execute(array(':idLivre' => $idLivre));
        $resultat = $this->_rechercheLivreParIdLivre->fetchAll();
        return new Livre($resultat[0][0], $resultat[0][1], $resultat[0][2], $resultat[0][3], $resultat[0][4]);
    }

    public function ajouterReference(Reference $reference){
        //:nomReference, :nomImage, :auteur, :idType, :livreReference, :idUtilisateur
        error_log($this->_ajouterReference->execute(array(':nomReference' => $reference->getNomReference(), ':nomImage' => $reference->getNomImage(), ':auteur' => $reference->getAuteur(), ':idType' => $reference->getIdType(), ':livreReference' => $reference->getLivreReference(), ':resume' => $reference->getDescriptionLieu())));
    }

    //:nomReference, :nomImage, :auteur, :idLivre, :idType
    public function ajouterReferenceMusique(Reference $reference){
        $this->_ajouterReferenceMusique->execute(array(':nomReference' => $reference->getNomReference(), ':nomImage' => $reference->getNomImage(), ':auteur' => $reference->getAuteur(), ':idLivre' => $reference->getIdLivre(),  ':idType' => $reference->getIdType()));
    }

    //private $_modifierReferenceMusique; private $_supprimerReferenceMusique;
    public function modifierReferenceMusique(Reference $reference){
        $this->_modifierReferenceMusique->execute(array(':idReference' => $reference->getIdReference(), ':nomReference' => $reference->getNomReference(), ':nomImage' => $reference->getNomImage(), ':auteur' => $reference->getAuteur(), ':idLivre' => $reference->getIdLivre(),  ':idType' => $reference->getIdType()));
    }

    public function supprimerReference(Reference $reference){
        $this->_supprimerReference->execute(array(':idReference' => $reference->getIdReference()));
    }

    public function ajouterReferenceLivre(Reference $reference){
        //$this->_ajouterReferenceLivre->execute(array(':livreReference' => $reference->getLivreReference(), ':idLivre' => $reference->getIdLivre(),  ':idType' => $reference->getIdType()));
        $this->_ajouterReferenceLivre->execute(array(':livreReference' => $reference->getLivreReference(), ':idLivre' => $reference->getIdLivre(),  ':idType' => $reference->getIdType()));
    }

    //:nomReference, :descriptionLieu :idType, :idLivre
    public function ajouterReferenceLieu(Reference $reference){
        $this->_ajouterReferenceLieu->execute(array(':nomReference' => $reference->getNomReference(), ':descriptionLieu' => $reference->getDescriptionLieu(), ':idType' => $reference->getIdType(), ':idLivre' => $reference->getIdLivre()));
        //$this->_ajouterReferenceLieu->execute(array(':nomReference' => "nom", ':descriptionLieu' => "description", ':idType' => 3, ':idLivre' => 1));
    }

    public function modifierReferenceLieu(Reference $reference){
        $this->_modifierReferenceLieu->execute(array(':idReference' => $reference->getIdReference(), ':nomReference' => $reference->getNomReference(),   ':idLivre' => $reference->getIdLivre(),  ':idType' => $reference->getIdType(), ':descriptionLieu' => $reference->getDescriptionLieu()));
    }
}
?>