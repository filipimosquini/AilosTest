## Questão 5

# Considerações

1. Foi realizada uma correção no script de geração da estrutura de banco de dados:

Na tabela **movimento**, a linha  ``` FOREIGN KEY(idcontacorrente) REFERENCES contacorrente(idcontacorrente) ``` está referenciando a coluna **idcontacorrente** e esta coluna na tabela **contacorrente** é do tipo ``` TEXT(37) PRIMARY KEY  ``` porém, FOREIGN KEY **idcontacorrente** presenta na tabela **movimento** é do tipo ``` INTEGER(10) NOT NULL ```, por isso, alterei o script para ``` FOREIGN KEY(idcontacorrente) REFERENCES contacorrente(numero) ``` pois também, a coluna **número** na tabela **contacorrente** está declarada também commo ``` UNIQUE ```.

2. 
