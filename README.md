# SitemaDeElevador

Ao longo do dessenvolvimento, foi contruido uma classe ElevadorService com vários métodos para analisar os dados de utilização de elevadores. Esses métodos foram implementados a partir de 
uma interface 'IElevadorServices', que define os métodos que a classe 'ElevadorService' deve implementar

Os métodos que foram construídos são:

- 'andarMenosUtilizado' : retorna uma lista de inteiros com os andares menos utilizados.
- 'elevadorMaisFrequentadoPeriodoMaiorFluxo': retorna uma lista de char com os elevadores mais frequentados e o período em que se encontram em maior fluxo.
- 'elevadorMenosFrequentadoPeriodoMenosFluxo': retorna uma lista de char com os elevadores menos frequentados e o período em que se encontram em menor fluxo.
- 'periodoMaiorUtilizacaoConjuntoElevadores': retorna uma string com o período de maior utilização do conjunto de elevadores.
- 'percentualDeUsoElevador: retorna um float com o percentual de uso de um elevador específico (A, B, C ou D).

Além disso, criei métodos para imprimir os resultados desses métodos na tela, de acordo com o formato desejado.

- 'imprimeResultadoNaTelaAndarUtilizado': imprime na tela o andar menos utilizado pelos usuários.
- 'imprimeElevadorMaisFrequentadoPeriodoMaiorFluxo': imprime na tela o elevador mais frequentado e o período que se encontra em maior fluxo.
- 'imprimeElevadorMenosFrequentadoPeriodoMenosFluxo': imprime na tela o elevador menos frequentado e o período que se encontra em menor fluxo.
- 'imprimePeriodoMaiorUtilizacaoConjuntoElevadores': imprime na tela o período de maior utilização do conjunto de elevadores.
- 'imprimePercentualDeUsoElevadores': imprime na tela o percentual de uso de cada elevador com relação a todos os serviços prestados.

Esses métodos foram construídos para ajudar a responder perguntas sobre os dados de utilização dos elevadores, como : 
"Qual é o andar menos utilizado pelos usuários?", 
"Qual é o elevador mais frequentado e o período que se encontra maior fluxo?", 

entre outras.
