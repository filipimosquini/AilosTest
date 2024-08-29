## Questão 3

# Enunciado

Nesta questão vamos usar o Git e um editor de texto (nano), você pode realizar uma sequência de comandos em um diretório da sua máquina local, seguindo a sequência definida no exercício. 

Nessa sequência, o nano representa a abertura de um editor de texto para criar/editar o arquivo especificado como argumento e você deve salvar no arquivo um conteúdo qualquer, que foi salvo em disco antes de prosseguir com o próximo comando:

```
git init

nano README.md

nano default.html

git add .

git commit -m "Commit 1"

git rm default.html

nano style.css

git add style.css

git commit -m "Commit 2"

git checkout -b testing

nano script.js

git add *.js

git commit -m "Commit 3"

git checkout master
```

Ao final dessa sequência de comandos, os arquivos que se encontram em seu diretório de trabalho, além do README.md, é/são:

*	[      ] script.js e style.css, apenas.
*	[      ] default.html e style.css, apenas.
*	[      ] style.css, apenas.
*	[      ] default.html e script.js, apenas.
*	[      ] default.html, script.js e style.css.


# Resposta

[  x  ] style.css, apenas.



