using System;
using System.Collections.Generic;
using System.Linq;

namespace MeuProjeto1;

public static class Aulas
{
	private enum DiaSemana
	{
		Segunda = 1,
		Terca = 2,
		Quarta = 3,
		Quinta = 4,
		Sexta = 5
	}

	public static void Executar()
	{
		ManipularArrays();
		ManipularEnum();
		ManipularListas();

		Console.WriteLine($"Soma: {Somar(2, 3)}");
		Console.WriteLine($"Maior valor: {Maior(4, 9)}");
		Console.WriteLine($"Dobro: {Dobrar(5)}");
	}

	private static void ManipularArrays()
	{
        
		// Array: coleção de tamanho fixo, com índices iniciados em zero.
		int[] numeros = new int[6];
		numeros[0] = 5;
		numeros[1] = 2;
		numeros[2] = 8;
		numeros[3] = 1;
		numeros[4] = 4;
		numeros[5] = 10;

		// Métodos e propriedades úteis de array.
		Array.Sort(numeros);
		Array.Reverse(numeros);
		int posicao = Array.IndexOf(numeros, 8);
		int[] copia = new int[numeros.Length];
		String [] nomes = new string[3] { "Bruno", "Ana", "Carla" };
        Array.Sort(nomes);
        Console.WriteLine(nomes);

        Array.Copy(numeros, copia, numeros.Length);

		Console.WriteLine($"Tamanho: {numeros.Length}");
		Console.WriteLine($"Posição do 8: {posicao}");
		Console.WriteLine($"Maior: {numeros.Max()}");
		Console.WriteLine($"Soma: {numeros.Sum()}");
		Console.WriteLine(string.Join(", ", copia));

	}

	private static void ManipularEnum()
	{
		DiaSemana[] dias = Enum.GetValues<DiaSemana>();

		// É possível iterar um enum com for usando o array retornado por GetValues.
		for (int i = 0; i < dias.Length; i++)
			Console.WriteLine($"Dia {(int)dias[i]}: {dias[i]}");
	}

	private static void ManipularListas()
	{
		// List<T> possui tamanho dinâmico.
		List<string> nomes = new() { "Ana", "Bruno", "Carla" };
		nomes.Add("Daniel");
		nomes.AddRange(new[] { "Eva", "Fabio" });
		nomes.Insert(0, "Alice");
		nomes.Remove("Bruno");
		nomes.RemoveAt(nomes.Count - 1);

		foreach (string nome in nomes)
			Console.WriteLine(nome);

		bool existe = nomes.Contains("Carla");
		int quantidade = nomes.Count;
		List<string> filtrados = nomes.Where(nome => nome.Length > 4).ToList();
		nomes.Sort();

		Console.WriteLine($"Contém Carla: {existe}");
		Console.WriteLine($"Quantidade: {quantidade}");
		Console.WriteLine(string.Join(", ", filtrados));
	}

	// Funções: métodos reutilizáveis que recebem parâmetros e retornam valores.
	private static int Somar(int primeiro, int segundo) => primeiro + segundo;

	private static int Maior(int primeiro, int segundo) =>
		primeiro > segundo ? primeiro : segundo;

	private static int Dobrar(int valor) => valor * 2;
}



// Classe Carro
// Requisito nao funcional: id, marca, ano, cor, velocidade, estaLigado.
// Requisito funcional: acelerar, frear, buzinar, getId, setId, getMarca, setMarca, getAno, setAno, getCor, setCor, getVelocidade, setVelocidade.

