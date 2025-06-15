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


## Questions 9 à 20

### 9. Donnez un automate reconnaissant les mots commençant par "Http://".

L'automate possède une chaîne d'états lisant successivement `H`, `t`, `t`, `p`, `:`, `/`, `/` avant d'atteindre un état terminal qui boucle sur lui‑même pour accepter le reste du mot.

### 10. Implémentez dans le projet un algorithme `AlgorithmeCommenceParHttp` créant cet automate et testez‑le.

Un nouvel algorithme a été ajouté dans `AlgorithmeCommenceParHttp` et enregistré dans la fabrique. Il valide correctement les mots tels que `"Http://site"` et rejette ceux qui ne commencent pas par cette séquence.

### 11. Donnez la regex associée à cet automate.

`^Http://.*$`

### 12. Donnez un automate reconnaissant les mots commençant par "Http://" ou par "www".

Depuis l'état initial deux chemins sont possibles : l'un lit la séquence `Http://`, l'autre lit `www`. Les deux convergent vers un même état terminal qui boucle sur tout caractère.

### 13. Implémentez dans le projet un algorithme `AlgorithmeCommenceParHTTPouWWW` créant cet automate et testez‑le.

Cet algorithme a été implémenté et enregistré dans la fabrique. Il accepte par exemple `"Http://exemple"` ou `"wwwsite"` mais rejette `"ftp://"`.

### 14. Donnez la regex associée à cet automate.

`^(Http://|www).*$`

### 15. Donnez un automate reconnaissant les mots finissant par ".fr".

L'automate garde les deux derniers caractères lus. L'état terminal correspond à la lecture de la séquence finale `.fr`.

### 16. Implémentez dans le projet un algorithme `AlgorithmeFinissantParFR` créant cet automate et testez‑le.

Un algorithme dédié a été ajouté. Il reconnaît par exemple `"site.fr"` mais pas `"site.fra"`.

### 17. Donnez la regex associée à cet automate.

`.*\.fr$`

### 18. Donnez un automate reconnaissant les mots finissant par ".fr" ou ".com".

L'automate précédent est complété par un second chemin mémorisant la séquence finale `.com`. Les états terminaux correspondent respectivement aux suffixes `.fr` et `.com`.

### 19. Implémentez dans le projet un algorithme `AlgorithmeFinissantParFRouCOM` créant cet automate et testez‑le.

L'algorithme a été ajouté et enregistré. Il reconnaît `"exemple.com"` et `"exemple.fr"` mais pas `"exemple.net"`.

### 20. Donnez la regex associée à cet automate.

`.*\.(fr|com)$`

### 21. Donnez un automate reconnaissant les mots ne contenant pas de `;`.

L'automate se compose d'un état initial et terminal qui boucle sur tout caractère
sauf `;`. Une transition sur `;` mène vers un état d'erreur non terminal qui
boucle sur lui‑même.

### 22. Implémentez dans le projet un algorithme `AlgorithmeSansPointVirgule` créant cet automate et testez‑le.

L'automate a été ajouté dans le dossier `Realisation` et enregistré dans la fabrique.
Il accepte par exemple `"bonjour"` mais rejette `"bad;word"`.

### 23. Donnez la regex associée à cet automate.

`^[^;]*$`

### 24. Donnez un automate reconnaissant les mots contenant au moins une lettre minuscule, une lettre majuscule et un chiffre.

On modélise les différentes combinaisons rencontrées (aucune, minuscule seule,
majuscule seule, chiffre seul, etc.) via huit états. Une fois les trois types de
caractères lus, on atteint un état terminal qui boucle sur lui‑même.

### 25. Implémentez dans le projet un algorithme `AlgorithmeMDP` créant cet automate et testez‑le.

L'algorithme a été codé et enregistré. Il valide par exemple `"Abc1"` et rejette
`"abc"` ou `"ABC1"` car ils ne contiennent pas les trois catégories requises.
