public class Moto: Veiculo
{
    public Moto(string marca, string modelo) : base(marca, modelo) { }

	public long Id { get; set; }
	public string Marca { get; set; }
	public int Ano { get; set; }
    public string Modelo {get; set;}
	public string Cor { get; set; }
	public int Velocidade { get; set; }
	
	override public void Acelerar(int incremento)
	{
		if (EstaLigado)
			Velocidade = Velocidade + 2*incremento;
	}

	override public void Frear(int decremento)
	{
		if (EstaLigado)
		{
			Velocidade = Velocidade - decremento/10; 
			if (Velocidade < 0)
				Velocidade = 0;
		}
	}

	public void Buzinar()
	{
		if (EstaLigado)
			Console.WriteLine("To na moto buzinando!");
		else
			Console.WriteLine("A moto está desligada.");
	}
}