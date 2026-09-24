
using System.ComponentModel;
using MeuProjeto1;
using Microsoft.Win32.SafeHandles;

public class Program
{
	public static void Main()
	{
		Carro carro = new Carro("VM", "Carro"); // Carro: [id = 0, marca = null, ano = 0, cor = null, velocidade = 0, estaLigado = false]
		Console.WriteLine($"Carro: [id = {carro.Id}, marca = {carro.Marca}, ano = {carro.Ano}, cor = {carro.Cor}, velocidade = {carro.Velocidade}, estaLigado = {carro.EstaLigado}]");
		Moto moto = new Moto("Yamaha", "Moto");
		Console.WriteLine($"Moto: [id = {moto.Id}, marca = {moto.Marca}, ano = {moto.Ano}, cor = {moto.Cor}, velocidade = {moto.Velocidade}, estaLigado = {moto.EstaLigado}]");
		carro.Id = 12;
		carro.Cor = "Vermelho";
		carro.Velocidade = 50;	
		carro.Ano = 2020;
		carro.Buzinar();
		carro.EstaLigado = true;
		carro.Buzinar();
		moto.Id = 12;
		moto.Cor = "Vermelho";
		moto.Velocidade = 50;	
		moto.Ano = 2020;
		moto.Buzinar();
		moto.EstaLigado = true;
		moto.Buzinar();
		// carro.Acelerar(20);
		// Console.WriteLine($"Carro: [velocidade = {carro.Velocidade}]");
		// carro.Frear(70);
		// Console.WriteLine($"Carro: [velocidade = {carro.Velocidade}]");
		// carro.Buzinar();

	}

	// Funções independentes: qualquer código pode alterar a velocidade diretamente.
	static int Acelerar(int velocidadeAtual, int valor)
	{
		return velocidadeAtual + valor;
	}

	static int Frear(int velocidadeAtual, int valor)
	{
		return Math.Max(0, velocidadeAtual - valor);
	}

	static byte Somar(byte a, byte b)
	{
		return (byte)(a + b);
	}
}
