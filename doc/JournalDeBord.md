# Journal de bord / TPI 2022 / MyLibrary
##Karel Vilém Svoboda

### 02.05.2022
####Objectifs
Pour le premier jour mon objectif sera l'analyse et la planification. En fin de journée et dois rendre mon planning Gantt et pour ce faire, je dois commencer la synthétisation du cahier des charges afin de déterminer les différentes tâches.
####Déroulement
- 07h30 : Journal de bord
- 07h40 : Lecture de l'énoncé du TPI
- 07h45 : Mise en place du GitHub
- 07h55 : Mise en place du diagramme de Gantt
- 08h10 : Résumé du rapport de TPI
- 08h55 : Travail sur le diagramme de gantt
- 11h40 : planning prévisionnel terminée, pause de midi
- 12h40 : Reprise du travail et début du diagramme de la base de données
- 13h00 : Consultation avec Madame Travnjak à propos de mon avancement. J'ai été aidé pour le diagramme de la base de données et à clarifier le cahier des charges.
- 13h10 : Envoie du planning prévisonnel aux experts et à Mme Travnjak
- 13h15 : Suite du travail sur la base de données
- 14h00 : Documentation de la base de données
- 15h30 : Travil sur les maquettes
- 16h40 : Fin des maquettes rédaction de la conclusion et backups
####Conclusion
J'ai effectués mes tâches pour la journée, le fait de tenir un planning m'a aidé dans mon organisation et j'ai bien pu me répartir les tâches.

###03.05.2022
####Objectifs
Aujourd'hui Je vais commencer par mettre mon serveur web local puis je vais commencer le développement de l'API PHP.
####Déroulement
- 7h30 : Journal de bord
- 7h40 : Création de l'utilisateur dans la base de données
- 7h50 : Génération d'un mot de passe aléatoire pour le user API
- 7h55 : Ajout de deux entrées dans la table utilisateurs de la base de données
|   Email               |   Password (non sha1)    |  
|-----------------------|--------------------------|
|   karel.svbd@eduge.ch |   Super   |
|   amir.yns@eduge.ch   |   random  |
- 8h00 : Début de travail sur l'API PHP
  1. Création de l'environnement
  2. Création des objets PHP représentant les trables de la base de données
- 9h10 : Début du travail sur le point d'entrée de connexion
  1. Création des points d'entrée
  2. Débug avec postman
  3. création du crud sur la table user
- Demdande d'aide à Mr Bonvin pour les requêtes php
  1. Explication des requêtes sql à l'intérieur d'un singlethon
- 13h30 Problème lors du passage de l'objet php en session
  1. Le problème a été résolu en sérialisant l'objet en le passant dans la session, la réponse a été trouvé sur https://stackoverflow.com/questions/1442177/storing-objects-in-php-session
- 13h45 : Fin du travail sur les points d'entrées de connexion, début de la rédaction de la documentation technique
- 14h10 : Début de la rédaction du manuel d'utilisateur
- 14h45 : Début du développement de l'application C#
  1. Création des objets représentant les tables de la base de données
  2. Création de la form de connexion

####Conclusion
J'ai effectué les tâches que je me suis attribué. Cependant je me suis rendu compte qu'il serait plus pratique de travailler sur l'application et l'API en même temps afin de pouvoir créer les points d'entré donc j'ai besoin et pas en faire trop innutilement

### 04.05.2022
#### Objectifs
Je vais commencer cettre journée en implémentant la connexion dans mon application c#. Ensuite je vais commencer le système de card.
#### Déroulement
07h30 : Implémentation de la connexion dans l'application c#
  1. Problème rencontré lors de la récupération des valeurs du JSON Solution : Utiliser un bolléen qui retourne si l'API a envoyé une erreur 


09h50 : Consultation avec Mme Travjak à propos de l'avancement
10h00 : Début du travail sur les card
1. Création de l'objet card hérité du composant panel


11h15 : Création du point d'entrée d'ajout de livres
13h00 : Je me suis rendu compte que utiliser des session dans une API n'est pas compatible avec le package NuGet. Par conséquent, je dois repenser mon API et ma base de données.
1. ajout de la colonne "connecte" dans la table utilisateur
2. Changement du code de l'api (explication du nouveau système de sécurité dans le rapport de projet)


#### Conclusion
Malgrès le fait qu'il y a eu un gros imprévu au niveau des sessions de l'API, les tâches de la journée ont été accomplies.

#### Conclusion

### 05.05.2022
#### Objectifs
L'objectif de la jour est de terminer la partie CRUD de la collection de livre. Pour ce faire il faut que j'achève les points d'entrées dans l'API et la génération dynamique des card dans l'application C#
#### Déroulement
07h30 : Travail sur les points d'entrées de la table Livres
08h00 : implémentation d'ajout d'image à partir du formulaire
  - Note : Ajouter les données fonctionne mais on ne peut pas encore envoyer le nom des image, j'y consacrerai plus de temps plus tard
08h30 : Récupération des Livres de l'utilisateur
10h15 : récupération des données dans l'application c# et création dynamique des card
10h50 : Recherche des livres avec les filtres
14h00 : Permière version fonctionnel du crud des Livres
14h00 : documentation
15h00 : Visioconférence avec Mme Travnjak 
15h30 : Début sur le système de recherche dans les livres
#### Conclusion
J'ai terminé plus de tâches que prévu, en plus du crud. J'ai implémenté la recherche personnalisé dans les auteurs et les titres

### 09.05.2022
#### Objectifs
Aujourd'hui je vais commencer à travailler sur la partie références. Ensuite, je vais refaire les card afin de les rendre plus jolies visuelement. 
#### Déroulement
07h40 : Début du travail sur la form references (ajout des composants)
08h50 : Je vois à présent rendre la class card absrtaite afin de pouvoir l'utiliser pour afficher les références
11h20 : Création des points d'entrées d'ajout de références
12h40 : Visite de Mme Travnjak
1. Consultation à propos de la form référence. Sinthétisation des 3 formulaires en un seul et ajouter le possibilité de séléctionner un livre existant ou d'en ajouter un.
2. Fixation d'une défense à projet à blanc pour le 26 mai
12h50 : Début du travail sur les points de la consultation
14h00 : Erreur bloquante, impossible de faire un crud sur la table Reference
15h00 : Mise à jour de la base de données pour les exigences du cahier des charges
#### Conclusion
Le bug bloquant n'a pas été corrigé, après avoir passé une heure sur le problème, j'ai redirigé mon attention vers des tâches moins complexes pour la journée.