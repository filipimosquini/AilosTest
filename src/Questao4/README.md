## Questão 4

# Enunciado

Uma empresa registra os atendimentos por assunto e por ano em uma tabela.

Você precisa escrever um comando select que retorne o assunto, o ano e a quantidade de ocorrências, filtrando apenas assuntos que tenham mais de 3 ocorrências no mesmo ano.

O comando deve ordenar os registros por ANO e por QUANTIDADE de ocorrências de forma DECRESCENTE.

![image](https://github.com/user-attachments/assets/b8f5579c-c4b7-4d3f-8d8c-b085224f029b)

**Resultado esperado:**

![image](https://github.com/user-attachments/assets/866596d4-dfe7-4937-acc7-ef116918246e)

**Comandos para criação da tabela e inserção dos registros:**

```
-- ORACLE
CREATE TABLE atendimentos (
 id  RAW(16) DEFAULT SYS_GUID() NOT NULL,
 assunto VARCHAR2(100) NOT NULL,
 ano NUMBER(4)
);

INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento','2021');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto','2021');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto','2021');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro','2021');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento','2021');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto','2021');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto','2021');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto','2021');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto','2021');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento','2021');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento','2021');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto','2022');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto','2022');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento','2022');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento','2022');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento','2022');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro','2022');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro','2022');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro','2022');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro','2022');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro','2022');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro','2022');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro','2022');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao cadastro','2022');
COMMIT;

```

# Resposta

```
SELECT A.ASSUNTO, A.ANO, COUNT(1) AS "QUANTIDADE"
FROM ATENDIMENTOS A
GROUP BY A.ANO, A.ASSUNTO
HAVING COUNT(1) > 3
ORDER BY A.ANO DESC, COUNT(1) DESC;

```

![image](https://github.com/user-attachments/assets/a2a25624-d05f-4a57-920d-69ed04826c49)


