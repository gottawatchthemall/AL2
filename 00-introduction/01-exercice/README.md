# Exercice : Hello Kebab

## Objectifs

- Ouvrir une discussion

**Temps indicatif** : 60 minutes

## Etape 1

Je viens d'ouvrir un restaurant de Kebabs et afin de gérer mon système de prise de commande, j'ai besoin que vous me livriez un objet Kebab capable d'être créé avec différents ingrédients (salade, tomate, oignons, viande, etc). J'ai déjà conçu une interface graphique, vous devez juste créer l'objet Kebab qui doit seulement avoir une seule méthode qui ne prend pas d'argument et qui renvoie un booleen afin de savoir si un Kebab est végétarien ou non.

## Etape 2

Ajouter une méthode à l'objet Kebab afin de savoir s'il est pescétarien.

> Le pescétarisme, ou pesco-végétarisme, est un néologisme désignant le régime alimentaire d'une personne omnivore qui s'abstient de consommer de la chair animale à l'exception de celle issue des poissons, des crustacés et mollusques aquatiques.

## Etape 3

Ajouter les possibilités suivantes :
- Un système de doublage du fromage (double cheese)
- Un système pour enlever les oignons

Dans tout les cas, l'ordre des couches ne doit pas être modifié (ordre constant).

Pour le double cheese :
- si le kebab n'a pas de fromage, ne rien faire
- s'il y a du fromage alors le doubler au même endroit de le fromage existant.

ex :

```
S|T|C -> S|T|C|C
C|S|C|T -> C|C|S|C|C|T
```

- C : Cheese
- S : Salade
- T : Tomate