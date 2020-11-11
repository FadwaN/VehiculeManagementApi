# Vehicule Management API
[![Build Status](https://dev.azure.com/ffnemer/VehiculeManagementApi/_apis/build/status/FadwaN.VehiculeManagementApi?branchName=master)](https://dev.azure.com/ffnemer/VehiculeManagementApi/_build/latest?definitionId=1&branchName=master)
 
Cette repository contient le code source pour le test d’embauche dont l’énoncé est le suivant :
>Test Back 
Réaliser une API REST dans le langage de votre choix avec framework ou non. L’api doit au minimum répondre sur 4 routes : Get /vehicles (pour afficher une liste de véhicules avec id, nom, etc) Post /vehicle (pour ajouter un véhicule à la liste, la route get devra le renvoyer aussi si on l’appelle) Delete /vehicle/:id (pour supprimer un véhicule de la liste) Put /vehicle/:id (pour modifier un véhicule) Vous êtes libre d’implémenter toutes les bonnes pratiques à votre code et d’utiliser ou non une BDD pour le stockage des véhicules.

J’ai implanter un simple poc (proof of concept) api, avec une base de donnée sql server dont le model UML est le suivant: 

![alt text](https://i.imgur.com/vc71TGt.png)

## Les technologies/architecture/Patron utilisées :
-	.Net core 3.1.1, entity framework core 3.1.1, visual studio, visual studio online (pour le ci).
-	Onion architecture pour assurer le séparation de concernes entre les différentes couches (j’ai opter pour cette architecture vue qu’elle est plus adapter dans ces genre de projet, elle simplifie la testabilité du code (unit tests ou tests d’intégration, et chaque couche sera tester séparément)),elle enforce les principes SOLID pour avoir du code clean et extensible.

![alt text](https://i.imgur.com/9bJRkOa.png)
-	Repository patron pour la gestion de toutes les opération en relation avec la base de donnée, j’ai essayé de bien organier le code et le réutiliser (éviter la répétition).
-	Dependancy injection pattern, c’est le pattern d’injection des dépendances le plus adapter pour REST api surtout lorsque on parler de asp.net, il permet de découpler les implémentation les uns des autre, en injectant des interfaces dans les contrôleurs. 


## Installation et test :
-	Cloner le repo en local via : `git clone https://github.com/FadwaN/VehiculeManagementApi.git`
-	Assurer bien que vous avez .net core 3.1.1 installer dans votre machine.
-	Build la solution afin de restaurer tous les paquet nugets.
-   Création et initialisation de la base de donnée
La base de donner peux être créer et initialiser (le code contient le code de population de la bans ApplicationContext)via les étapes  suivantes :
    1. Ouvrir Package Manager Console dans visual studio, selectionner le projet repositories, et executer la commade `update-Database`:
    ![alt text](https://i.imgur.com/l4M09zw.png)
    2. Vérifier que la base a bien été créer
    ![alt text](https://i.imgur.com/w7OjE1R.png)

## API définition

| Plugin | README |
| ------ | ------ |

|API	 |Description 	|Paramètres/exemple|
| ------ | ------ | ------ |
|GET /api/Vehicules	|Retourner tous les véhicules dans la base|	/|
|GET /api/Vehicules/:id	|Retourner le véhicule dont l’id est id|	Id du véhicule à retourner|
|POST  /api/Vehicules|	Ajouter un véhicule a la base|	Le véhicule a ajouter comme une objet json, exemple : {"matricule": "2222222", "nom": "Vehicule2","description": "Description vehicule2","annee": "2017","couleur": "Vert","prix": 1200,"disponibilite": true,"model": null,"modelId": 1}|
|PUT /api/Vehicules/:id	|Mis à jour le véhicule dont l’id est id.	|Id du véhicule a mettre ajour+ un nouveau objet véhicule dans le body du requête http.|
|DELETE  /api/Vehicules/:id	|Supprimer le véhicule dont l’id est id.	|Id du véhicule a supprimer.|
|GET /api/Models	|Retourner tous les modèle de véhicules dans la base|	/|
|GET /api/Models /:id|	Retourner le modèle de vehicule dont l’id est id|	Id du modèle de véhicule à retourner|
|POST | /api/Models	Ajouter un modèle de véhicule a la base	Le modèle de véhicule a ajouter comme une objet json, exemple :{"Model": "nom model", "description": "Description model" }|
|PUT /api/Models /:id	|Mis à jour le modèle de véhicule dont l’id est id.|	Id du modèle de véhicule à mettre ajour+ un nouveau objet véhicule dans le body du requête http.|
|DELETE  /api/Models /:id	|Supprimer le modèle de véhicule dont l’id est id.	|Id du modèle de véhicule à supprimer.|

## Test via postman
-	Ajouter `Content-Type`: `application/json`. 
-	Voici quelaue screen shots:
-	![alt text](https://i.imgur.com/qUnONxO.png)
-	![alt text](https://i.imgur.com/fN6IC8U.png)
-	![alt text](https://i.imgur.com/MxzqYrv.png)

## Idées d’amélioration
-	Ajouter des tests d’intégrations.
-	Ajouter des test BDD pour bien documenter l’api implicitement.
-	Utiliser des DTO (Data transfert objets) dans chaque couche afin que le principe de séparation de couche soit respecter a 100%.
-	Ajouter swagger pour documenter l’api implicitement.
-	Mieux gérer les exception, chaque couche doit retourner ces propre exception.
-	Ajouter des unit test pour le service interface et pout le projet api.


## CI (Continious integration)
[![Build Status](https://dev.azure.com/ffnemer/VehiculeManagementApi/_apis/build/status/FadwaN.VehiculeManagementApi?branchName=master)](https://dev.azure.com/ffnemer/VehiculeManagementApi/_build/latest?definitionId=1&branchName=master)
Le statut du build est visualise en haut, cette repository GitHub est liée a un pipeline CI que j’ai définit dans visual studio online.
Le pipeline est definit ici: https://dev.azure.com/ffnemer/VehiculeManagementApi/_build


