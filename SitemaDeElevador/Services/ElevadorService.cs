namespace SitemaDeElevador.Services
{
    public class ElevadorService : IElevadorServices
    {
        private Predios _predios;
        public ElevadorService()
        {
            DeserializedJson deserialized = new DeserializedJson();
            _predios = deserialized.DeserializeJson("input.json");

        }

        public List<int> andarMenosUtilizado()
        {
            Dictionary<int, int> andares = new Dictionary<int, int>();
            foreach (Predio predio in _predios.Predio)
            {
                if (!andares.ContainsKey(predio.Andar))
                {
                    andares.Add(predio.Andar, predio.Andar);
                }
                else
                {
                    andares[predio.Andar]++;
                }
            }

            int menorUtilizacao = andares.Values.Min();

            return andares.Where(x => x.Value == menorUtilizacao).Select(x => x.Value).ToList();
        }

        public List<char> elevadorMaisFrequentado()
        {
            Dictionary<char, int> elevadores = new Dictionary<char, int>();
            foreach (Predio predio in _predios.Predio)
            {
                if (!elevadores.ContainsKey(predio.Elevador[0]))
                {
                    elevadores.Add(predio.Elevador[0], 1);
                }
                else
                {
                    elevadores[predio.Elevador[0]]++;
                }
            }

            int maiorUtilizacao = elevadores.Values.Max();

            return elevadores.Where(x => x.Value == maiorUtilizacao).Select(x => x.Key).ToList();
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            List<char> elevadorMaisFrequentado = elevadorMenosFrequentado();

            Dictionary<char, int> turnos = new Dictionary<char, int>();
            foreach(Predio predio in _predios.Predio)
            {
                if (predio.Elevador[0] == elevadorMaisFrequentado[0])
                {
                    if (!turnos.ContainsKey(predio.Turno[0]))
                    {
                        turnos.Add(predio.Turno[0], 1);
                    }
                    else
                    {
                        turnos[predio.Turno[0]]++;
                    }
                }
            }

            int maiorUtilizacao = turnos.Values.Max();

            return turnos.Where(x => x.Value == maiorUtilizacao).Select(x => x.Key).ToList();
        }

        public List<char> elevadorMenosFrequentado()
        {
            Dictionary<char, int> elevadores = new Dictionary<char, int>();
            foreach (Predio predio in _predios.Predio)
            {
                if (!elevadores.ContainsKey(predio.Elevador[0]))
                {
                    elevadores.Add(predio.Elevador[0], 1);
                }
                else
                {
                    elevadores[predio.Elevador[0]]++;
                }
            }

            int menorUtilizacao = elevadores.Values.Min();

            return elevadores.Where(x => x.Value == menorUtilizacao).Select(x => x.Key).ToList();
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            List<char> elevadorMenosFrequentado = elevadorMaisFrequentado();

            Dictionary<char, int> turnos = new Dictionary<char, int>();
            foreach (Predio predio in _predios.Predio)
            {
                if (predio.Elevador[0] == elevadorMenosFrequentado[0])
                {
                    if (!turnos.ContainsKey(predio.Turno[0]))
                    {
                        turnos.Add(predio.Turno[0], 1);
                    }
                    else
                    {
                        turnos[predio.Turno[0]]++;
                    }
                }
            }

            int menorUtilizacao = turnos.Values.Min();

            return turnos.Where(x => x.Value == menorUtilizacao).Select(x => x.Key).ToList();
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            Dictionary<char, int> turnos = new Dictionary<char, int>();

            foreach(Predio predio in _predios.Predio)
            {
                if (!turnos.ContainsKey(predio.Turno[0]))
                {
                    turnos.Add(predio.Turno[0], 1);
                }
                else
                {
                    turnos[predio.Turno[0]]++;
                }
            }

            int maiorUtilizacao = turnos.Values.Max();

            return turnos.Where(x => x.Value == maiorUtilizacao).Select(x => x.Key).ToList();
        }

        public float percentualDeUsoElevadorA()
        {
            return CalcularPercentualElevadores('A');
        }

        public float percentualDeUsoElevadorB()
        {
            return CalcularPercentualElevadores('B');
        }

        public float percentualDeUsoElevadorC()
        {
            return CalcularPercentualElevadores('C');
        }

        public float percentualDeUsoElevadorD()
        {
            return CalcularPercentualElevadores('D');
        }

        public float percentualDeUsoElevadorE()
        {
            return CalcularPercentualElevadores('E');
        }
        private float CalcularPercentualElevadores(char nome)
        {
            int utilizacoesElevador = _predios.Predio.Count(x => x.Elevador[0] == nome);

            return (float)utilizacoesElevador / _predios.Predio.Length * 100;
        }

        public void imprimeResultadoNaTelaAndarUtilizado()
        {
            Console.WriteLine("What is the floor less used by users?");
            List<int> andaresUtilizados = andarMenosUtilizado();
            if (andaresUtilizados.Count > 1)
            {
                Console.WriteLine($"The least used floor is: {andaresUtilizados[0]}");
            }
            else
            {
                Console.Write("The least used floors are: ");
                for (int i = 0; i < andaresUtilizados.Count; i++)
                {
                    if (i == andaresUtilizados.Count - 1)
                    {
                        Console.WriteLine(andaresUtilizados[i]);
                    }
                    else
                    {
                        Console.Write(andaresUtilizados[i] + ". ");
                    }
                }
            }
        }
        public void imprimeElevadorMaisFrequentadoPerioMaiorFluxo()
        {
            Console.WriteLine("What is the most frequented elevator and the period that is the largest flow? ");
            List<char> elevadorFrequentado = elevadorMaisFrequentado();
            if(elevadorFrequentado.Count > 1)
            {
                Console.WriteLine($"The most frequented elevators are: {elevadorFrequentado}");
            }
            else
            {
                Console.WriteLine($"The most frequented elevator is: {elevadorFrequentado[0]}");
            }
            
            List<char> fluxoElevadorFrequentado = periodoMaiorFluxoElevadorMaisFrequentado();
            if(fluxoElevadorFrequentado.Count > 1)
            {
                Console.WriteLine($"The periods of lower flow are: {fluxoElevadorFrequentado}");
            }
            else
            {
                Console.WriteLine($"The period of least flow is: {fluxoElevadorFrequentado[0]}");
            }
        }
        public void imprimeElevadorMenosFrequentadoPeriodoMenosFluxo()
        {
            //Console.WriteLine("Qual é o elevador menos frequentado e o período que se encontra menor fluxo?");
            //List<char> elevadoresFrequentados = periodoMenorFluxoElevadorMenosFrequentado();
            //foreach (char elevador in elevadoresFrequentados)
            //{
            //    Console.WriteLine("O elevador " + elevador + " foi menos frequentado e se encontra em período de menor fluxo.");
            //}
            Console.WriteLine("Which is the least frequented elevator and the least flow period? ");
            List<char> elevadorfrequentado = periodoMenorFluxoElevadorMenosFrequentado();
            if (elevadorfrequentado.Count > 1)
            {
                Console.WriteLine($"The least frequented elevators are: {elevadorfrequentado}");
            }
            else
            {
                Console.WriteLine($"The least frequented elevator is: {elevadorfrequentado[0]}");
            }

            List<char> fluxoElevadorfrequentado = periodoMenorFluxoElevadorMenosFrequentado();
            if (fluxoElevadorfrequentado.Count > 1)
            {
                Console.WriteLine($"The periods of lower flow are: {fluxoElevadorfrequentado}");
            }
            else
            {
                Console.WriteLine($"The period of least flow is: {fluxoElevadorfrequentado[0]}");
            }
        }
        public void imprimePeriodoMaiorUtilizacaoConjuntoElevadores()
        {
            Console.WriteLine("What is the period of greatest use of the set of elevators? ");
            List<char> periodoConjuntoElevador = periodoMaiorUtilizacaoConjuntoElevadores();
            if(periodoConjuntoElevador.Count > 1)
            {
                Console.WriteLine($"The periods of greatest use of the set of elevators are: {periodoConjuntoElevador}");
            }
            else
            {
                Console.WriteLine($"The period of greatest use of the lift assembly is: {periodoConjuntoElevador[0]}");
            }
        }
        public Dictionary<char, float> percentualDeUsoElevadores()
        {
            int totalServicos = _predios.Predio.SelectMany(p => p.Elevador).Count();

            Dictionary<char, int> contagemUsoElevadores = new Dictionary<char, int>();
            foreach (var predio in _predios.Predio)
            {
                foreach (var p in predio.Elevador)
                {
                    if (contagemUsoElevadores.ContainsKey(p))
                    {
                        contagemUsoElevadores[p]++;
                    }
                    else
                    {
                        contagemUsoElevadores[p] = 1;
                    }
                }
            }

            Dictionary<char, float> percentualDeUsoElevadores = new Dictionary<char, float>();
            foreach (var elevador in contagemUsoElevadores)
            {
                percentualDeUsoElevadores[elevador.Key] = (float)elevador.Value / totalServicos * 100;
            }

            return percentualDeUsoElevadores;
        }
        public void imprimePercentualDeUsoElevadores()
        {
            Console.WriteLine("What is the percentage of use of each elevator in relation to all services provided?");
            Dictionary<char, float> percentualDeUso = percentualDeUsoElevadores();
            foreach (var elevador in percentualDeUso)
            {
                Console.WriteLine("The elevator " + elevador.Key + " was used in " + elevador.Value + "% of the services provided.");
            }
        }
    }
}