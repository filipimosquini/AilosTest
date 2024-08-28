## Quest�o 1

# Enunciado

Uma institui��o financeira solicita que para cadastrar uma conta banc�ria, � necess�rio informar:
�	o n�mero da conta, 
�	o nome do titular da conta, 
�	e o valor de dep�sito inicial que o titular depositou ao abrir a conta.

O valor de dep�sito inicial, � opcional, ou seja: 
�	se o titular n�o tiver dinheiro a depositar no momento de abrir sua conta, o dep�sito inicial n�o ser� feito e o saldo inicial da conta ser�, naturalmente, zero.

Importante: Ap�s a conta ser aberta, o n�mero da conta nunca poder� ser alterado. J� o nome do titular pode ser alterado (pois uma pessoa pode mudar de nome quando contrai matrim�nio por exemplo).

O saldo da conta n�o pode ser alterado livremente. � preciso haver um mecanismo para proteger isso. 

O saldo s� aumenta por meio de dep�sitos, e s� diminui por meio de saques. 

Para cada saque realizado, a institui��o cobra uma taxa de $ 3.50. 

Observa��o: a conta pode ficar com saldo negativo se o saldo n�o for suficiente para realizar o saque e/ou pagar a taxa.

Disponibilizamos um programa que solicita os dados de cadastro da conta, dando op��o para que seja ou n�o
informado o valor de dep�sito inicial. Em seguida, realizar um dep�sito e depois um saque, sempre
mostrando os dados da conta ap�s cada opera��o.

Voc� deve implementar a classe �ContaBancaria� para que o programa funcione conforme dois cen�rios de teste abaixo:

Exemplo 1:

Entre o n�mero da conta: 5447
Entre o titular da conta: Milton Gon�alves
Haver� dep�sito inicial (s/n)? s
Entre o valor de dep�sito inicial: 350.00

Dados da conta:
Conta 5447, Titular: Milton Gon�alves, Saldo: $ 350.00

Entre um valor para dep�sito: 200
Dados da conta atualizados:
Conta 5447, Titular: Milton Gon�alves, Saldo: $ 550.00

Entre um valor para saque: 199
Dados da conta atualizados:
Conta 5447, Titular: Milton Gon�alves, Saldo: $ 347.50

Exemplo 2:
Entre o n�mero da conta: 5139
Entre o titular da conta: Elza Soares
Haver� dep�sito inicial (s/n)? n

Dados da conta:
Conta 5139, Titular: Elza Soares, Saldo: $ 0.00

Entre um valor para dep�sito: 300.00
Dados da conta atualizados:
Conta 5139, Titular: Elza Soares, Saldo: $ 300.00

Entre um valor para saque: 298.00
Dados da conta atualizados:
Conta 5139, Titular: Elza Soares, Saldo: $ -1.50


# Resposta