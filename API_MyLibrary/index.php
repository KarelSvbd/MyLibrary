<?php
/*  Projet  : API_MyLibrary
    Auteur  : Svoboda Karel Vilém
    Desc.   : API qui permet de gérer la base de données MyLibrary
    Date    : 03.05.2022
    Version : 0.1
*/

//autorisation des sources externes
header('Access-Control-Allow-Origin: *');
//définition du type d'application
header('Content-Type: application/json');

//Démarage de session
session_start();

//Connexion PDO
require("models/monPDO.php");
$mydatabase = new MyLibrary();

//require("models/sqlFunctions.php");

//importation des objets
require("objects/livre.php");
require("objects/reference.php");
require("objects/type.php");
require("objects/utilisateur.php");

//si première visite de l'utilisateur
if(!isset($_SESSION['utilisateurActuel'])){
    $_SESSION['utilisateurActuel'] = null;
}

$response = null;

//Switch qui permet déterminer le type de requête de l'utilisateur
switch ($_SERVER['REQUEST_METHOD']) {
    case 'GET':
        //maipulation de la session de l'utilisateur
        switch($_GET["session"]){
            //connexion
            case "connexion":
                if($_SESSION['utilisateurActuel'] == null){
                    if(isset($_GET["email"]) && $_GET["password"]){
                        $user = new Utilisateur(0, $_GET["email"], $_GET["password"]);

                        //Si les données sont trouvées dans la base
                        if($mydatabase->testConnexion($user)){
                            http_response_code(200);
                            $response = array(
                                "200" => "La session est activée",
                            );

                            //récupération des données de l'utilisateur
                            $user = $mydatabase->recevoirUtilisateurParEmail($user->getEmail());
                            $_SESSION['connecte'] = true;
                            //Sérialisation afin d'étviter une erreur lors de la récupération de l'objet
                            $_SESSION['utilisateurActuel'] = serialize($user);
                            //Retour réponse positive et ajout des données de l'utilisateur
                            $response = array_merge($response, $mydatabase->recevoirUtilisateurParEmail($user->getEmail())->returnArrayForJSON());                    
                        }
                        else{
                            http_response_code(400);
                            $response = array(
                                "400" => "Fausses données de connexion",
                            );
                        }
                    }
                    //Si l'utilisateur a renseigné les mauvais headers
                    else{
                        http_response_code(400);
                        $response = array(
                            "400" => "Données de connexion manquantes",
                            "Headers à ajouter" => "email / password"
                        );
                    }
                    
                    
                }
                //Si l'utilisateur essaie de se connecter malgré le fait qu'une session est déjà active
                else{
                    http_response_code(401);
                        $response = array(
                            "401" => "Une session est déjà active",
                        );
                        //Affichage de l'erreur et retour des données de l'utilisateur
                        $response = array_merge($response, unserialize($_SESSION['utilisateurActuel'])->returnArrayForJSON());
                }
                
                break;
            //déconnexion de l'utilisateur
            case "deconnexion":
                if($_SESSION['utilisateurActuel'] != null){
                    //destruction de la session
                    if(session_destroy()){
                        http_response_code(201);
                        $response = array(
                            "Session détruite"
                        );
                    }
                    else{
                        http_response_code(500);
                        $response = array(
                            "Erreur serveur lors de la suppression de la session"
                        );
                    }
                }
                else{
                    http_response_code(401);
                    $response = array(
                        "Aucune session n'est active"
                    );
                }
                
                
                break;
            //information à propos de la session
            case "info":
                if($_SESSION['utilisateurActuel'] != null){
                    http_response_code(200);
                    $response = unserialize($_SESSION['utilisateurActuel'])->returnArrayForJSON();
                    break;
                }
                else{
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
        break;
}

echo json_encode($response);

?>