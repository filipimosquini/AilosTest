## Questão 5

# Considerações

1. O código foi escrito todo em inglês, incluindo as mensagens de valiadções, erros e documentações.
2. Sobre a separação lógica de pastas do projeto, fiz algumas adições de camadas para melhor organização das classes.
3. Foram aplicados testes unitários somente nas regras de negócios, sendo excluídos repositórios e controladores.
4. Para a idepotência em requisições, apliquei a lógica em um middleware, para que esta solução não esteja aplicada diretamente nas camadas de negócios facilitando também a adaptação para uma solução mais completa sem gerar impactos nas funcionalidades de negócio existentes.
5. Foi realizada uma correção no script de geração da estrutura de banco de dados:

Na tabela **movimento**, a linha  ``` FOREIGN KEY(idcontacorrente) REFERENCES contacorrente(idcontacorrente) ``` está referenciando a coluna **idcontacorrente** e esta coluna na tabela **contacorrente** é do tipo ``` TEXT(37) PRIMARY KEY  ``` porém, FOREIGN KEY **idcontacorrente** presenta na tabela **movimento** é do tipo ``` INTEGER(10) NOT NULL ```, por isso, alterei o script para ``` FOREIGN KEY(idcontacorrente) REFERENCES contacorrente(numero) ``` pois também, a coluna **número** na tabela **contacorrente** está declarada também commo ``` UNIQUE ```.
