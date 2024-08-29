## Questão 2

# Observações

1. Os valores retornados pela API estão diferentes dos valores esperados.
2. Para este exercício, foram utilizados as bibliotecas SimpleInjector, RestSharp e Newtonsoft.Json
3. A arquitetura do projeto foi pensada com base na arquitetura três camadas.

# Enunciado

Necessitamos que você desenvolva uma aplicação que calcule a quantidade de gols marcados por time em um ano.

Os dados de todas as partidas são disponibilizados por uma API e podem ser filtrados passando parâmetros com os próprios campos que são retornados:

Método: GET
URL API: https://jsonmock.hackerrank.com/api/football_matches

Parâmetros opcionais que podem ser utilizados:
year – int – Filtra o ano de pesquisa
team1 – string – Filtra o nome do time 1 da partida
team2 – string – Filtra o nome do time 2 da partida
page – int – Filtra o número da página de resultados

Exemplo de requisição:
https://jsonmock.hackerrank.com/api/football_matches?year=2015&team1=Galatasaray

O programa deve retornar 2 resultados:

Resultado 1:
Time: Paris Saint-Germain
Ano: 2013

Resultado 2:
Time: Chelsea
Ano: 2014

Resultado esperado:
Team Paris Saint - Germain scored 109 goals in 2013
Team Chelsea scored 92 goals in 2014


# Resposta

**Exemplo 1 e 2:**
![image](https://github.com/user-attachments/assets/d907a758-a524-4de3-af00-c566d42ead10)


