# Rapport R4.12 - Automates

## Questions 1 à 8

### 1. Donnez quelques exemples de langages.

- L'ensemble des mots sur l'alphabet \{a,b\} contenant au moins un `a`.
- L'ensemble des entiers naturels écrits en décimal (c'est-à-dire les chaînes composées de chiffres `0` à `9`).
- L'ensemble des identifiants valides en C# (une lettre ou un `_` suivi de lettres, chiffres ou `_`).

### 2. Donnez des exemples de mots reconnus et non‑reconnus par l'automate donné.

L'automate comporte trois états (1 initial, 2 terminal, 3 intermédiaire) avec des transitions :

- de 1 vers 3 sur `b`,
- de 1 vers 2 sur `a`,
- de 3 vers 2 sur `b`,
- de 3 vers 3 sur `a` ou `c`,
- de 2 vers 2 sur `a`, `b` ou `c`.

Exemples de mots **reconnus** : `"a"`, `"bb"`, `"bac"`.
Exemples de mots **non reconnus** : `"b"`, `"ca"`, `"cb"`.

### 3. Cherchez rapidement sur internet à quoi ressemble une expression régulière.

Une expression régulière (regex) est une chaîne permettant de décrire un motif : par exemple `^ab*c$` reconnaît toutes les chaînes commençant par `a`, suivies de zéro ou plusieurs `b`, et se terminant par `c`.

### 4. Donnez quelques cas d'utilisation des regex en informatique.

- Vérification de la forme d'une adresse e‑mail dans un formulaire.
- Recherche et remplacement de motifs de texte dans un éditeur ou un script.
- Extraction d'informations (dates, numéros, etc.) dans un fichier log.

### 5. Observez le fonctionnement de l'application.

L'application fournit une interface permettant de sélectionner un algorithme issu de `FarbiqueAlgorithme`. Chaque algorithme construit un automate (classe `Algorithme`) et permet de tester plusieurs mots. `AlgorithmeExemple` est enregistré par `MakerAlgorithmeExemple` dans la méthode `Initialisation` de la fabrique.

### 6. Dessinez l'automate associé à l'exemple présent dans le projet.

L'automate d'`AlgorithmeExemple` comporte deux états :

```
 (Initial) --A--> [LuA]*
```

`[LuA]` est terminal et boucle sur lui‑même sur tout caractère. Toute transition non définie depuis l'état initial mène à l'état d'erreur (non terminal).

### 7. Déterminez ce que vérifie cet automate.

Il accepte exactement les mots qui **commencent par la lettre `A`**. Après avoir lu `A`, tous les caractères suivants sont acceptés.

### 8. Donnez la regex associée à cet automate.

La regex équivalente est : `^A.*$`

