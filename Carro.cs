public class Carro : Veiculo
{	
	public Carro(string marca, string modelo) : base(marca, modelo) { }

	public long Id { get; set; }
	public string Marca { get; set; }
	public int Ano { get; set; }
	public string Modelo {get; set;}
	public string Cor { get; set; }
	public int Velocidade { get; set; }
	
	override public void Acelerar(int incremento)
	{
		if (EstaLigado)
			Velocidade = Velocidade + incremento;
	}

	override public void Frear(int decremento)
	{
		if (EstaLigado)
		{
			Velocidade = Velocidade - decremento; 
			if (Velocidade < 0)
				Velocidade = 0;
		}
	}

	public void Buzinar()
	{
		if (EstaLigado)
			Console.WriteLine("Buzinando!");
		else
			Console.WriteLine("O carro está desligado.");
	}
}