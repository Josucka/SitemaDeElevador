namespace SitemaDeElevador.Services
{
    public class ElevadorService : IElevadorServices
    {
        private List<Predio> _predio;
        private SerializedJson _serialized;
        public ElevadorService(List<Predio> predio, SerializedJson serialized)
        {
            _predio = predio;
            _serialized = serialized;
        }

        public List<int> andarMenosUtilizado()
        {
            
            var contagemAndares = new Dictionary<int, int>();
            for (int i = 0; i <= 15; i++)
            {
                contagemAndares[i] = 0;
            }

            //contabiliza o uso de cada andar
            foreach (var elevador in _predio)
            {
                foreach (var uso in elevador.Elevador)
                {
                    contagemAndares[uso]++;
                }
            }

            int menorContagem = contagemAndares.Values.Min();
            var andaresMenosUtilizados = new List<int>();
            foreach (var kvp in contagemAndares)
            {
                if (kvp.Value == menorContagem)
                {
                    andaresMenosUtilizados.Add(kvp.Key);
                }
            }
            return andaresMenosUtilizados;
        }

        public List<char> elevadorMaisFrequentado()
        {
            var contagemElevadores = new Dictionary<char, int>();
            contagemElevadores['A'] = 0;
            contagemElevadores['B'] = 0;
            contagemElevadores['C'] = 0;
            contagemElevadores['D'] = 0;
            contagemElevadores['E'] = 0;

            //contabiliza o uso de cada elevadores
            foreach (var elevador in _predio)
            {
                contagemElevadores[elevador.Elevador[0]] += elevador.Andar;
            }

            int maiorContagem = contagemElevadores.Values.Max();
            var elevadoresMaisFrequentados = new List<char>();
            foreach (var kvp in contagemElevadores)
            {
                if (kvp.Value == maiorContagem)
                {
                    elevadoresMaisFrequentados.Add(kvp.Key);
                }
            }
            return elevadoresMaisFrequentados;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            var elevadoresMaisFrequentados = elevadorMaisFrequentado();

            var periodosMaiorFluxo = new List<char>();

            foreach (var elevador in _predio)
            {
                // Pula os elevadores que não estão na lista de elevadores mais frequentados
                if (!elevadoresMaisFrequentados.Contains(elevador.Elevador[0]))
                {
                    continue;
                }

                // Cria um dicionário para armazenar a contagem de uso de cada período
                var contagemPeriodos = new Dictionary<char, int>();
                contagemPeriodos['M'] = 0;
                contagemPeriodos['V'] = 0;
                contagemPeriodos['N'] = 0;

                foreach (var uso in elevador.Elevador)
                {
                    contagemPeriodos[uso]++;
                }

                // Encontra o período com o maior número de usos
                char periodoMaisFrequentado = ' ';
                int maiorContagem = 0;
                foreach (var kvp in contagemPeriodos)
                {
                    if (kvp.Value > maiorContagem)
                    {
                        periodoMaisFrequentado = kvp.Key;
                        maiorContagem = kvp.Value;
                    }
                }

                // Adiciona o período mais frequentado à lista
                periodosMaiorFluxo.Add(periodoMaisFrequentado);
            }

            return periodosMaiorFluxo;
        }

        public List<char> elevadorMenosFrequentado()
        {
            var contagemElevadores = new Dictionary<char, int>();
            contagemElevadores['A'] = 0;
            contagemElevadores['B'] = 0;
            contagemElevadores['C'] = 0;
            contagemElevadores['D'] = 0;
            contagemElevadores['E'] = 0;

            // Itera pelos elevadores e contabiliza o uso de cada um
            foreach (var elevador in _predio)
            {
                contagemElevadores[elevador.Elevador[0]] += elevador.Andar;
            }

            // Encontra o menor número de uso
            int menorContagem = contagemElevadores.Values.Min();
            var elevadoresMenosFrequentados = new List<char>();
            foreach (var kvp in contagemElevadores)
            {
                if (kvp.Value == menorContagem)
                {
                    elevadoresMenosFrequentados.Add(kvp.Key);
                }
            }

            return elevadoresMenosFrequentados;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            var elevadoresMenosFrequentados = elevadorMenosFrequentado();
            var periodosMenorFluxo = new List<char>();

            foreach (var elevador in _predio)
            {
                // Pula os elevadores que não estão na lista de elevadores menos frequentados
                if (!elevadoresMenosFrequentados.Contains(elevador.Elevador[0]))
                {
                    continue;
                }

                // Cria um dicionário para armazenar a contagem de uso de cada período
                var contagemPeriodos = new Dictionary<char, int>();
                contagemPeriodos['M'] = 0;
                contagemPeriodos['V'] = 0;
                contagemPeriodos['N'] = 0;

                // Itera pelos usos do elevador e contabiliza o número de vezes que cada período foi utilizado
                foreach (var uso in elevador.Turno)
                {
                    contagemPeriodos[uso]++;
                }

                char periodoMenosFrequentado = ' ';
                int menorContagem = int.MaxValue;
                foreach (var kvp in contagemPeriodos)
                {
                    if (kvp.Value < menorContagem)
                    {
                        periodoMenosFrequentado = kvp.Key;
                        menorContagem = kvp.Value;
                    }
                }

                periodosMenorFluxo.Add(periodoMenosFrequentado);
            }

            return periodosMenorFluxo;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            var contagemPeriodos = new Dictionary<char, int>();
            contagemPeriodos['M'] = 0;
            contagemPeriodos['V'] = 0;
            contagemPeriodos['N'] = 0;

            // Itera pelos elevadores
            foreach (var elevador in _predio)
            {
                // Itera pelos usos do elevador e contabiliza o número de vezes que cada período foi utilizado
                foreach (var uso in elevador.Turno)
                {
                    contagemPeriodos[uso]++;
                }
            }

            // Encontra o período com o maior número de usos
            char periodoMaisFrequentado = ' ';
            int maiorContagem = 0;

            foreach (var kvp in contagemPeriodos)
            {
                if (kvp.Value > maiorContagem)
                {
                    maiorContagem = kvp.Value;
                }
            }

            var periodosMaiorUtilizacao = new List<char>();
            foreach (var kvp in contagemPeriodos)
            {
                if (kvp.Value == maiorContagem)
                {
                    periodosMaiorUtilizacao.Add(kvp.Key);
                }
            }

            return periodosMaiorUtilizacao;
        }

        public float percentualDeUsoElevadorA()
        {
            // Obtém o número total de usos de todos os elevadores
            int totalUsos = _predio.Sum(e => e.Andar);

            // Obtém o número de usos do elevador A
            int usosElevadorA = _predio.First(e => e.Elevador[0] == 'A').Andar;

            // Calcula o percentual de uso do elevador A
            float percentualDeUso = (float)usosElevadorA / totalUsos;

            // Retorna o percentual de uso com duas casas decimais
            return (float)Math.Round(percentualDeUso, 2);
        }

        public float percentualDeUsoElevadorB()
        {
            // Obtém o número total de usos de todos os elevadores
            int totalUsos = _predio.Sum(e => e.Andar);

            // Obtém o número de usos do elevador A
            int usosElevadorA = _predio.First(e => e.Elevador[0] == 'B').Andar;

            // Calcula o percentual de uso do elevador A
            float percentualDeUso = (float)usosElevadorA / totalUsos;

            // Retorna o percentual de uso com duas casas decimais
            return (float)Math.Round(percentualDeUso, 2);
        }

        public float percentualDeUsoElevadorC()
        {
            // Obtém o número total de usos de todos os elevadores
            int totalUsos = _predio.Sum(e => e.Andar);

            // Obtém o número de usos do elevador A
            int usosElevadorA = _predio.First(e => e.Elevador[0] == 'C').Andar;

            // Calcula o percentual de uso do elevador A
            float percentualDeUso = (float)usosElevadorA / totalUsos;

            // Retorna o percentual de uso com duas casas decimais
            return (float)Math.Round(percentualDeUso, 2);
        }

        public float percentualDeUsoElevadorD()
        {
            // Obtém o número total de usos de todos os elevadores
            int totalUsos = _predio.Sum(e => e.Andar);

            // Obtém o número de usos do elevador A
            int usosElevadorA = _predio.First(e => e.Elevador[0] == 'D').Andar;

            // Calcula o percentual de uso do elevador A
            float percentualDeUso = (float)usosElevadorA / totalUsos;

            // Retorna o percentual de uso com duas casas decimais
            return (float)Math.Round(percentualDeUso, 2);
        }

        public float percentualDeUsoElevadorE()
        {
            // Obtém o número total de usos de todos os elevadores
            int totalUsos = _predio.Sum(e => e.Andar);

            // Obtém o número de usos do elevador A
            int usosElevadorA = _predio.First(e => e.Elevador[0] == 'E').Andar;

            // Calcula o percentual de uso do elevador A
            float percentualDeUso = (float)usosElevadorA / totalUsos;

            // Retorna o percentual de uso com duas casas decimais
            return (float)Math.Round(percentualDeUso, 2);
        }
    }
}