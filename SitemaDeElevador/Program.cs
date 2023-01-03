
using SitemaDeElevador.Services;

var dados = SerializedJson.Ler<Predio>("input.json");

Console.WriteLine(dados.Andar);
