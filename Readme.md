# Vehicule Management API
[![Build Status](https://dev.azure.com/ffnemer/VehiculeManagementApi/_apis/build/status/FadwaN.VehiculeManagementApi?branchName=master)](https://dev.azure.com/ffnemer/VehiculeManagementApi/_build/latest?definitionId=1&branchName=master)
 
Ce repository contient le code source du test d’embauche suivant :
>Test Back 
Réaliser une API REST dans le langage de votre choix avec framework ou non. L’api doit au minimum répondre sur 4 routes : Get /vehicles (pour afficher une liste de véhicules avec id, nom, etc) Post /vehicle (pour ajouter un véhicule à la liste, la route get devra le renvoyer aussi si on l’appelle) Delete /vehicle/:id (pour supprimer un véhicule de la liste) Put /vehicle/:id (pour modifier un véhicule) Vous êtes libre d’implémenter toutes les bonnes pratiques à votre code et d’utiliser ou non une BDD pour le stockage des véhicules.

J’ai implémenté un simple poc (proof of concept) api, avec une base de donnée sql server dont le model UML est le suivant: 

![alt text](https://i.imgur.com/vc71TGt.png)

## Les technologies/architectures/patrons utilisés :
-	.Net core 3.1.1, entity framework core 3.1.1, visual studio, visual studio online (pour le ci).
-	Onion architecture pour assurer la séparation des préoccupations (SoC) entre les différentes couches (j’ai opté pour cette architecture car elle est plus adaptée aux api REST, elle simplifie la testabilité du code (unit tests ou tests d’intégration, et chaque couche sera testée séparément)),elle enforce les principes SOLID pour avoir un code propre et extensible).

![alt text](https://i.imgur.com/9bJRkOa.png)
-	Repository patron pour la gestion de toutes les opérations en relation avec la base de données, j’ai essayé de bien organier le code et le réutiliser (éviter la répétition).
-	Dependancy injection pattern, c’est le pattern d’injection des dépendances le plus adapté aux API REST surtout quand il s'agit de asp.net, il permet de découpler les implémentations les unes des autre, en injectant des interfaces dans les contrôleurs. 


## Installation et test :
-	Cloner le repo en local via : `git clone https://github.com/FadwaN/VehiculeManagementApi.git`
-	Vous assurer que vous avez .net core 3.1.1 installé sur votre machine.
-	Builder la solution afin de restaurer tous les paquets nugets.
-   Création et initialisation de la base de données
La base de données peut être crée et initialisée (le code contient le code de population de la bans ApplicationContext) en suivant les étapes suivantes:
    1. Ouvrir Package Manager Console dans visual studio, selectionner le projet repositories, et executer la commande `update-Database`:
    
    ![alt text](https://i.imgur.com/l4M09zw.png)
    
    2. Vérifier que la base a bien été crée
    
    ![alt text](https://i.imgur.com/w7OjE1R.png)

## API définition

| Plugin | README |
| ------ | ------ |

|API	 |Description 	|Paramètres/exemple|
| ------ | ------ | ------ |
|GET /api/Vehicules	|Retourner tous les véhicules dans la base|	/|
|GET /api/Vehicules/:id	|Retourner le véhicule dont l’id est id|	Id du véhicule à retourner|
|POST  /api/Vehicules|	Ajouter un véhicule à la base|	Le véhicule à ajouter comme un objet json, exemple : {"matricule": "2222222", "nom": "Vehicule2","description": "Description vehicule2","annee": "2017","couleur": "Vert","prix": 1200,"disponibilite": true,"model": null,"modelId": 1}|
|PUT /api/Vehicules/:id	|Mis à jour du véhicule dont l’id est id.	|Id du véhicule à mettre à jour+ un nouvel objet véhicule dans le body de la requête http.|
|DELETE  /api/Vehicules/:id	|Supprimer le véhicule dont l’id est id.	|Id du véhicule à supprimer.|
|GET /api/Models	|Retourner tous les modèles de véhicules dans la base|	/|
|GET /api/Models/:id|	Retourner le modèle de vehicule dont l’id est id|	Id du modèle de véhicule à retourner|
|POST /api/Models|	Ajouter un modèle de véhicule à la base	|Le modèle de véhicule à ajouter comme objet json, exemple :{"Model": "nom model", "description": "Description model" }|
|PUT /api/Models /:id	|Mis à jour du modèle de véhicule dont l’id est id.|	Id du modèle de véhicule à mettre à jour+ un nouvel objet véhicule dans le body de la requête http.|
|DELETE  /api/Models /:id	|Supprimer le modèle de véhicule dont l’id est id.	|Id du modèle de véhicule à supprimer.|

## Test via postman
-	Ajouter `Content-Type`: `application/json`. 
-	Voici quelaue screen shots:
-	![alt text](https://i.imgur.com/qUnONxO.png)
-	![alt text](https://i.imgur.com/fN6IC8U.png)
-	![alt text](https://i.imgur.com/MxzqYrv.png)

## Idées d’amélioration
-	Ajouter des tests d’intégrations.
-	Ajouter des tests BDD pour bien documenter l’api implicitement.
-	Utiliser des DTO (Data transfert objets) dans chaque couche afin que le principe de séparation de couches soit respecté a 100%.
-	Ajouter swagger pour documenter l’api implicitement.
-	Mieux gérer les exceptions, chaque couche doit retourner ses propres exceptions.
-	Ajouter des unit test pour le service interface et pour le projet api.


## CI (Continious integration)
[![Build Status](https://dev.azure.com/ffnemer/VehiculeManagementApi/_apis/build/status/FadwaN.VehiculeManagementApi?branchName=master)](https://dev.azure.com/ffnemer/VehiculeManagementApi/_build/latest?definitionId=1&branchName=master)
Le statut du build est visualisé en haut, ce repository GitHub est liée à un pipeline CI que j’ai défini dans visual studio online.
Le pipeline est definit ici: https://dev.azure.com/ffnemer/VehiculeManagementApi/_build


