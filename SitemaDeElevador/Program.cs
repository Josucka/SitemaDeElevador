using SitemaDeElevador.Services;

ElevadorService fluxo = new ElevadorService();
fluxo.imprimeResultadoNaTelaAndarUtilizado();
Console.WriteLine("-------");
fluxo.imprimeElevadorMaisFrequentadoPerioMaiorFluxo();
Console.WriteLine("-------");
fluxo.imprimeElevadorMenosFrequentadoPeriodoMenosFluxo();
Console.WriteLine("-------");
fluxo.imprimePeriodoMaiorUtilizacaoConjuntoElevadores();
Console.WriteLine("-------");
fluxo.imprimePercentualDeUsoElevadores();
Console.WriteLine("-------");
