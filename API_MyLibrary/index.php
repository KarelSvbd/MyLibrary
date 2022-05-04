<?php
/*  Projet  : API_MyLibrary
    Auteur  : Svoboda Karel Vilém
    Desc.   : API qui permet de gérer la base de données MyLibrary
    Date    : 03.05.2022
    Version : 0.2
*/

//autorisation des sources externes
header('Access-Control-Allow-Origin: *');
//définition du type d'application
header('Content-Type: application/json');

//Connexion PDO
require("models/monPDO.php");
$mydatabase = new MyLibrary();

//require("models/sqlFunctions.php");

//importation des objets
require("objects/livre.php");
require("objects/reference.php");
require("objects/type.php");
require("objects/utilisateur.php");

$response = null;

//Switch qui permet déterminer le type de requête de l'utilisateur
switch ($_SERVER['REQUEST_METHOD']) {
    case 'GET':
        //maipulation de la session de l'utilisateur
        switch($_GET["session"]){
            //connexion
            case "connexion":
                if($mydatabase->statusConnexionUtilisateur($_GET["email"]) == 0){
                    if(isset($_GET["email"]) && $_GET["password"]){
                        $user = new Utilisateur(0, $_GET["email"], $_GET["password"], 0);

                        //Si les données sont trouvées dans la base
                        if($mydatabase->testConnexion($user)){
                            http_response_code(200);
                            $response = array(
                                "200" => "La session est activée",
                            );

                            //récupération des données de l'utilisateur
                            $user = $mydatabase->recevoirUtilisateurParEmail($user->getEmail());

                            $mydatabase->connexionUtilisateur($user);
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
                            "401" => "La session de cet utilisateur est déjà active",
                        );
                }
                
                break;
            //déconnexion de l'utilisateur
            case "deconnexion":
                // <!> ajout de sécurité
                if($mydatabase->statusConnexionUtilisateur($_GET["email"]) == 1){
                    $user = $mydatabase->recevoirUtilisateurParEmail($_GET["email"]);
                    $mydatabase->deconnexionUtilisateur($user);

                    // <!> ajout de réponse
                }
                
                
                break;
            //information à propos de la session
            //<!> A CORRIGER APRèS LA SUPPRESSION GéNéRALE DES SESSIONS
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
    case "POST":
        if(isset($_GET["email"]) && isset($_GET["password"]) && isset($_GET["titre"]) && isset($_GET["auteur"]) && isset($_GET["nomImage"])){
            //Création d'un objet Livre à partir des données dans le get
            $livre = new Livre(0, $_GET["titre"], $_GET["auteur"], $_GET["nomImage"], $mydatabase->recevoirUtilisateurParEmail($_GET["email"])->getIdUtilisateur());
            $response = $livre->returnArrayForJSON();

        }
        //Ajout d'un livre
        //if($mydatabase->testConnexion(new Utilisateur()))
        if($mydatabase->statusConnexionUtilisateur($_GET["email"]) == 1){
            
        }
        break;
}

echo json_encode($response);

?>