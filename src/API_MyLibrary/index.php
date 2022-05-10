<?php
/*  Projet  : API_MyLibrary
    Auteur  : Svoboda Karel Vilém
    Desc.   : API qui permet de gérer la base de données MyLibrary
    Date    : 10.05.2022
    Version : 0.6
*/

//autorisation des sources externes
header('Access-Control-Allow-Origin: *');
//définition du type d'application
header('Content-Type: application/json');

//Connexion PDO
require("models/myLibraryPDO.php");
$mydatabase = new MyLibrary();

//require("models/sqlFunctions.php");

//importation des objets
require("objects/livre.php");
require("objects/reference.php");
require("objects/type.php");
require("objects/utilisateur.php");

$response = null;

//vérification si l'utilisateur a transmit ses données 
if (isset($_GET["email"]) && $_GET["password"]) {

    //Switch qui permet déterminer le type de requête de l'utilisateur
    switch ($_SERVER['REQUEST_METHOD']) {
        case 'GET':
            //maipulation de la session de l'utilisateur
            if (isset($_GET["session"])) {
                switch ($_GET["session"]) {
                        //connexion
                    case "connexion":
                        if ($mydatabase->statusConnexionUtilisateur($_GET["email"]) == 0) {

                            $user = new Utilisateur(0, $_GET["email"], $_GET["password"], 0);

                            //Si les données sont trouvées dans la base
                            if ($mydatabase->testConnexion($user)) {
                                http_response_code(200);
                                $response = array(
                                    "200" => "La session est activée",
                                );

                                //récupération des données de l'utilisateur
                                $user = $mydatabase->recevoirUtilisateurParEmail($user->getEmail());

                                $mydatabase->connexionUtilisateur($user);
                                //Retour réponse positive et ajout des données de l'utilisateur
                                $response = array_merge($response, $mydatabase->recevoirUtilisateurParEmail($user->getEmail())->returnArrayForJSON());
                            } else {
                                http_response_code(400);
                                $response = array(
                                    "400" => "Fausses données de connexion",
                                );
                            }

                            //Si l'utilisateur a renseigné les mauvais headers

                        }
                        //Si l'utilisateur essaie de se connecter malgré le fait qu'une session est déjà active
                        else {
                            http_response_code(401);
                            $response = array(
                                "401" => "La session de cet utilisateur est déjà active",
                            );
                        }

                        break;
                        //déconnexion de l'utilisateur
                    case "deconnexion":
                        // <!> ajout de sécurité
                        if ($mydatabase->statusConnexionUtilisateur($_GET["email"]) == 1) {
                            $user = $mydatabase->recevoirUtilisateurParEmail($_GET["email"]);
                            $mydatabase->deconnexionUtilisateur($user);

                            // <!> ajout de réponse
                            http_response_code(201);
                            $response = array(
                                "201" => "l'utilisateur est déconnectée",
                            );
                        }


                        break;
                        //information à propos de la session
                        //<!> A CORRIGER APRèS LA SUPPRESSION GéNéRALE DES SESSIONS
                    case "info":
                        if ($_SESSION['utilisateurActuel'] != null) {
                            http_response_code(200);
                            $response = unserialize($_SESSION['utilisateurActuel'])->returnArrayForJSON();
                            break;
                        } else {
                            http_response_code(401);
                            $response = array(
                                "Aucune session n'est active"
                            );
                        }
                        //Si le point d'entré est non traité
                    default:
                        $response = array(
                            "400" => "Point d'entrée inconnu",
                        );
                        break;
                }
            }

            //manipulation de la table livres
            if (isset($_GET["table"])) {
                $user = new Utilisateur(0, $_GET["email"], $_GET["password"], 0);
                //if ($mydatabase->testConnexion($user)) {
                if ($mydatabase->statusConnexionUtilisateur($_GET["email"]) == 1) {
                    switch ($_GET["table"]) {
                        case "livres":
                            if (isset($_GET["recherche"])) {
                                $user->setIdUtilisateur($mydatabase->recevoirUtilisateurParEmail($_GET["email"])->getIdUtilisateur());
                                //var_dump($mydatabase->livresParUtilisateur($user));
                                //récupération des livres en fonction de l'idUtilisateur
                                http_response_code(200);
                                $response = array();
                                foreach ($mydatabase->rechercheLivreParAuteurOuTitre($user, $_GET["recherche"]) as $unLivre) {
                                    array_push($response, $unLivre->returnArrayForJSON());
                                }
                            }else if(isset($_GET["idLivre"])){
                                http_response_code(200);
                                $response = array();
                                 
                                array_push($response, $mydatabase->rechercheLivreParIdLivre($_GET["idLivre"])->returnArrayForJSON());
                            } 
                            else {
                                $user->setIdUtilisateur($mydatabase->recevoirUtilisateurParEmail($_GET["email"])->getIdUtilisateur());
                                //var_dump($mydatabase->livresParUtilisateur($user));
                                //récupération des livres en fonction de l'idUtilisateur
                                http_response_code(200);
                                $response = array();
                                foreach ($mydatabase->livresParUtilisateur($user) as $unLivre) {
                                    array_push($response, $unLivre->returnArrayForJSON());
                                }
                            }

                            break;
                        case "utilisateurs":
                            break;
                        case "references":
                            if ($mydatabase->statusConnexionUtilisateur($_GET["email"]) == 1) {
                                if (isset($_GET["idLivre"])) {
                                    // <!> Ajout de la vérification si le livre appartient à l'utilisateur
                                   
                                    http_response_code(200);
                                    $response = array();
                                    foreach($mydatabase->referencesParLivre(new Livre($_GET["idLivre"], "", "", "", 0)) as $reference){
                                        array_push($response, $reference->returnArrayForJSON());
                                    }
                                }
                            }
                            break;
                        case "types":
                            if ($mydatabase->statusConnexionUtilisateur($_GET["email"]) == 1) {
                                http_response_code(200);
                                $response = array();
                                foreach ($mydatabase->tousTypes() as $unType) {
                                    array_push($response, $unType->returnArrayForJSON());
                                }
                            }
                            break;
                        default:
                            break;
                    }
                } else {
                    http_response_code(403);
                    $response = array(
                        "Veuillez vous connecter pour poursuivre"
                    );
                }
                /*}
                    http_response_code(403);
                    $response = array(
                        "les données de connexion sont fausses"
                    );*/
            }

            break;
        case "POST":

            //if($mydatabase->testConnexion(new Utilisateur()))
            if ($mydatabase->statusConnexionUtilisateur($_GET["email"]) == 1) {
                switch($_GET["table"]){
                    case 'livres':
                        if (isset($_GET["titre"]) && isset($_GET["auteur"]) && isset($_GET["nomImage"])) {
                            //Création d'un objet Livre à partir des données dans le get
                            $livre = new Livre(0, $_GET["titre"], $_GET["auteur"], $_GET["nomImage"], $mydatabase->recevoirUtilisateurParEmail($_GET["email"])->getIdUtilisateur());
                            $mydatabase->ajouterLivre($livre);
                            http_response_code(201);
                            $response = $livre->returnArrayForJSON();
                        }
                        break;
                    case 'references':
                        var_dump("test");
                        if(isset($_GET["idType"])){
                            switch($_GET["idType"]){
                                //livre
                                case "1":
                                    http_response_code(404);
                                    break;
                                //musique
                                case "2":
                                    if(isset($_GET["nomImage"]) && isset($_GET["nomReference"]) && isset($_GET["auteur"]) && isset($_GET["idLivre"])){
                                        $reference = new Reference(0, $_GET["nomReference"], $_GET["nomImage"], $_GET["auteur"], $_GET["idType"], 0, $_GET["idLivre"], "");
                                        $mydatabase->ajouterReferenceMusique($reference);
                                        http_response_code(201);
                                        $response = $reference->returnArrayForJSON();
                                    }
                                    else{
                                        http_response_code(401);
                                    }
                                    break;
                                //lieu
                                case '3':
                                    http_response_code(404);
                                    break;
                                default:
                            }
                            
                        }
                        // < ! > ajouter sécurité de isset

                        break;
                }

                
            } else {
                http_response_code(403);
                $response = array(
                    "Veuillez vous connecter pour poursuivre"
                );
            }
            break;
        case "PUT":
            if ($mydatabase->statusConnexionUtilisateur($_GET["email"]) == 1) {
                switch($_GET["table"]){
                    case 'livres': 
                        if (isset($_GET["idLivre"]) && isset($_GET["titre"]) && isset($_GET["auteur"]) && isset($_GET["nomImage"])) {
                        //Création d'un objet Livre à partir des données dans le get
                        $livre = new Livre($_GET["idLivre"], $_GET["titre"], $_GET["auteur"], $_GET["nomImage"], $mydatabase->recevoirUtilisateurParEmail($_GET["email"])->getIdUtilisateur());
                        $mydatabase->modifierLivre($livre);
                        http_response_code(201);
                        $response = $livre->returnArrayForJSON();
                    }
                    break;
                    case 'references':
                        if(isset($_GET["idReference"])){
                            if(isset($_GET["idType"])){
                                switch($_GET["idType"]){
                                    //livre
                                    case "1":
                                        http_response_code(404);
                                        break;
                                    //musique
                                    case "2":
                                        var_dump("test");
                                        if(isset($_GET["idReference"]) && isset($_GET["nomImage"]) && isset($_GET["nomReference"]) && isset($_GET["auteur"]) && isset($_GET["idLivre"])){
                                            $reference = new Reference($_GET["idReference"], $_GET["nomReference"], $_GET["nomImage"], $_GET["auteur"], $_GET["idType"], 0, $_GET["idLivre"], "");
                                            $mydatabase->modifierReferenceMusique($reference);
                                            http_response_code(201);
                                            $response = $reference->returnArrayForJSON();
                                        }
                                        else{
                                            http_response_code(401);
                                        }
                                        break;
                                    //lieu
                                    case '3':
                                        http_response_code(404);
                                        break;
                                    default:
                                }
                                
                            }
                        }
                        break;
                } 
            }else {
                http_response_code(403);
                $response = array(
                    "Veuillez vous connecter pour poursuivre"
                );
            }
        
            
            break;
        case "DELETE":
            if (isset($_GET["table"])) {
                switch($_GET["table"]){
                    case "livres":
                        $livre = new Livre($_GET["idLivre"], "", "", "", 0);
                        $mydatabase->supprimerLivre($livre);
                        break;
                    case "references":
                        if(isset($_GET["idReference"])){
                            $reference = new Reference($_GET["idReference"], null, null, null, null, null, null, null, null);
                            $mydatabase->supprimerReference($reference);
                            http_response_code(201);
                            
                        }
                        break;
                }
                
            }
            break;
    }
} else {
    http_response_code(400);
    $response = array(
        "400" => "Données de connexion manquantes",
        "Headers à ajouter" => "email / password"
    );
}

echo json_encode($response);
