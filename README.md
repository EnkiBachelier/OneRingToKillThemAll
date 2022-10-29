# OneRingToKillThemAll
Jeu de combat réalisé dans l'UE USRS45 (C# de base, sans POO) au CNAM-ENJMIN avec Diane AVEILLAN et Thibault VINCENT (Groupe F)

-----------------------------ONE RING TO KILL THEM ALL---------------------------------------------

Projet en C# développé par Diane AVEILLAN, Thibault VINCENT et Enki BACHELIER.


-----------LANCER LE JEU--------------------

Ouvrir la solution (ProjectOneRingToKillThemALL.sln) dans Visual Studio 2019 et lancer le jeu. 
Il est possible que NAudio ne fonctionne pas, il faut donc l'installer via la console de packages
et écrire cette commande : NuGet\Install-Package NAudio -Version 2.1.0

----------PRINCIPE DU JEU-------------------

C'est un jeu de combat en tour par tour avec une inspiration du Seigneur des Anneaux.
Le joueur a le choix entre 6 classes uniques, avec chacune des statistiques équilibrées
et une attaque spéciale. 
Le jeu se déroule en trois manches avec une histoire pour les relier.
Le but du jeu est de gagner ces trois manches afin d'arriver à l'écran de victoire.
Afin de jouer, le joueur n'a qu'à rentrer, soit des chiffres (1,2,3...), soit des mots (comme son prénom).

-----------ETAT ACTUEL DU JEU--------------

Le jeu possède pour le moment :
- Six classes, dont 3 inventées par les créateurs, toutes équilibrées 
- Une interface en console travaillée
- Un système de son et d'effets sonores (retiré pour cette version)
- Trois modes de difficultés, croissantes entre chaque manche
- Un système de potions lors de la 2nde manche
- Une histoire sur le Seigneur des Anneaux

-----------INTELLIGENCE ARTIFICIELLE--------

Difficulté 1 : L'IA prend des décisions aléatoires pendant les trois manches

Difficulté 2 :
- A la manche 1, l'IA prend des décisions aléatoires mais compte les actions que réalise le joueur (combien de fois il se défend,
attaque, ou réalise son attaque spéciale)
- A la manche 2, l'IA adapte son rôle en fonction des données récoltées et favorise l'un des actions (3/5 de la réaliser) 
(si le joueur se défend tout au long de la manche 1, l'IA va devenir un Gimlit et favoriser son attaque spéciale, 
capable d'outrepasser la défense)
- A la manche 3, l'IA adapte son rôle et son action favorisée selon le rôle du joueur. Elle choisit le rôle qui contre
le mieux (en seconde position) le joueur (selon le tableau d'équilibrage)

Difficulté 3 :
- A la manche 1, l'IA prend des décisions aléatoires mais compte les actions que réalise le joueur (combien de fois il se défend,
attaque, ou réalise son attaque spéciale)
- A la manche 2, l'IA adapte son rôle en fonction des données récoltées et favorise l'un des actions (3/5 de la réaliser) 
(si le joueur se défend tout au long de la manche 1, l'IA va devenir un Gimlit et favoriser son attaque spéciale, 
capable d'outrepasser la défense)
- A la manche 3, l'IA adapte son rôle et son action favorisée selon le rôle du joueur. Elle choisit le rôle qui contre
le mieux (en première position) le joueur (selon le tableau d'équilibrage). Elle peut également choisir l'action qui contre
le mieux l'action du joueur (3/4)

-------------DOSSIER ZIP-----------------

Dans le dossier ZIP, vous pouvez retrouver le tableau d'équilibrage et le PDF de présentation du jeu.

------------AMELIORATIONS FUTURES-------

- Le système de sons doit être réimplanté 
- Soigner davantage le visuel du jeu
- Continuer à équilibrer les difficultés
- Compléter l'histoire



