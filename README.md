# Guide pour l'installation de l'application MyLibrary v1.0

## Setup de la base de données
1. Importez le code SQL qui se trouve dans ./src/BaseDeDonnees
2. Créez un utilisateur qui a les droits de modification sur la base

## Setup de L'API
1. Allez dans le dossier ./src/API_MyLibrary/models/myLibraryPDO.PHP
2. Modifiez les données suivantes
- private $_serveur = 'mysql:host=**HOST**';
- private $_bdd = 'dbname=**NOMBASEDEDONNES'**;
- private $_user = '**UTILISATEURDELABASE**';
- private $_mdp = '**MOTDEPASSEDELUTILISATEUR**';

## Setup de l'application C#
1. Allez dans la class ClientRest
2. Modifiez le chemin de l'API pour qu'il corresponde