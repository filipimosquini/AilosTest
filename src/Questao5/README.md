## Questão 5

# Considerações

1. O código foi escrito todo em inglês, incluindo as mensagens de valiadções, erros e documentações.
2. Sobre a separação lógica de pastas do projeto, fiz algumas adições de camadas para melhor organização das classes.
3. A pasta controller foi movida de Infrastructure para a raíz da aplicação, pois, como se trata de um projeto WebApi, entendo que esta pasta pertence diretamente a esta camada.
4. Foram aplicados testes unitários somente nas regras de negócios, sendo excluídos repositórios e controladores.
5. Para a idepotência em requisições, apliquei a lógica em um middleware, para que esta solução não esteja aplicada diretamente nas camadas de negócios facilitando também a adaptação para uma solução mais completa sem gerar impactos nas funcionalidades de negócio existentes.
6. Foi realizada uma correção no script de geração da estrutura de banco de dados:

Na tabela **movimento**, a linha  ``` FOREIGN KEY(idcontacorrente) REFERENCES contacorrente(idcontacorrente) ``` está referenciando a coluna **idcontacorrente** e esta coluna na tabela **contacorrente** é do tipo ``` TEXT(37) PRIMARY KEY  ``` porém, FOREIGN KEY **idcontacorrente** presenta na tabela **movimento** é do tipo ``` INTEGER(10) NOT NULL ```, por isso, alterei o script para ``` FOREIGN KEY(idcontacorrente) REFERENCES contacorrente(numero) ``` pois também, a coluna **número** na tabela **contacorrente** está declarada também commo ``` UNIQUE ```.

# Estrutura do projeto

O projeto e estruturado com as seguintes camadas

1. Application: Ocorre a orquestração dos fluxos relacionados às regras de negócios.
2. Domain: O core da aplicação, nela o domínio do negócio e abstrações são definidas.
3. Infrastructure: São realizadas as especificações das abstrações de serviços, repositórios e algumas configurações do projeto.
5. BuildingBlocks: Contém as classes que compôem a base para o funcionamento do projeto.
6. Tests: Contém os testes de unidade.
