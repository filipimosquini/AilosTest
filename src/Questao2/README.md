## Questão 1

# Enunciado

Uma instituição financeira solicita que para cadastrar uma conta bancária, é necessário informar:

* o número da conta 
*	o nome do titular da conta 
*	e o valor de depósito inicial que o titular depositou ao abrir a conta.

O valor de depósito inicial, é opcional, ou seja: 
*	se o titular não tiver dinheiro a depositar no momento de abrir sua conta, o depósito inicial não será feito e o saldo inicial da conta será, naturalmente, zero.

Importante: Após a conta ser aberta, o número da conta nunca poderá ser alterado. Já o nome do titular pode ser alterado (pois uma pessoa pode mudar de nome quando contrai matrimônio por exemplo).

O saldo da conta não pode ser alterado livremente. É preciso haver um mecanismo para proteger isso. 

O saldo só aumenta por meio de depósitos, e só diminui por meio de saques. 

Para cada saque realizado, a instituição cobra uma taxa de $ 3.50. 

Observação: a conta pode ficar com saldo negativo se o saldo não for suficiente para realizar o saque e/ou pagar a taxa.

Disponibilizamos um programa que solicita os dados de cadastro da conta, dando opção para que seja ou não
informado o valor de depósito inicial. Em seguida, realizar um depósito e depois um saque, sempre
mostrando os dados da conta após cada operação.

Você deve implementar a classe “ContaBancaria” para que o programa funcione conforme dois cenários de teste abaixo:

**Exemplo 1:**

1. Entre o número da conta: 5447
2. Entre o titular da conta: Milton Gonçalves
3. Haverá depósito inicial (s/n)? s
4. Entre o valor de depósito inicial: 350.00

* Dados da conta:
Conta 5447, Titular: Milton Gonçalves, Saldo: $ 350.00

5. Entre um valor para depósito: 200
* Dados da conta atualizados:
Conta 5447, Titular: Milton Gonçalves, Saldo: $ 550.00

6. Entre um valor para saque: 199
* Dados da conta atualizados:
Conta 5447, Titular: Milton Gonçalves, Saldo: $ 347.50

**Exemplo 2:**

1. Entre o número da conta: 5139
2. Entre o titular da conta: Elza Soares
3. Haverá depósito inicial (s/n)? n

* Dados da conta:
Conta 5139, Titular: Elza Soares, Saldo: $ 0.00

4. Entre um valor para depósito: 300.00
* Dados da conta atualizados:
Conta 5139, Titular: Elza Soares, Saldo: $ 300.00

5. Entre um valor para saque: 298.00
* Dados da conta atualizados:
Conta 5139, Titular: Elza Soares, Saldo: $ -1.50


# Resposta

**Exemplo 1:**
![image](https://github.com/user-attachments/assets/984a1b53-8aef-48f2-9855-2b256ce1bfa9)

**Exemplo 2:**
![image](https://github.com/user-attachments/assets/78815ee2-5048-4e33-83f7-ddabd91d4bf3)


