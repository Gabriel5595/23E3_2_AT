# Desenvolvimento do Callback

Temos que ter dois métodos: Um principal e um Callback.

*O método princial é executado e depois o Callback é executado no final do método principal.*

O método principal irá realizar os cálculos com base na lista de clientes.
* Utilizar um foreach para passar por todos os elementos da listaClientes.
* Calcular valor total em contas, realizando o câmbio quando necessário.
* Calcular valor total das tarifas.
* Receberá:
  * listaClientes (com as informações de todos os clientes extraídas do arquivo.)
  * listaSaldosETarifas (lista vazia para utilização do callback);

O callback irá adicionar as informações a lista.
* Inserção das informações já calculadas em uma lista.
* Receberá:
  * listaSaldosETarifas (vazia);
  * CPF
  * SaldoTotalContas
  * TarifasTotais