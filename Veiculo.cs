public abstract class Veiculo
{
    public string Marca {get; set;}

    public string Modelo{get; set;}

    public bool EstaLigado {get; set;}

    public Veiculo(string marca, string modelo)
    {
        Marca = marca;
        Modelo = modelo;
    }

    public void Ligar()
    {
        EstaLigado = true;
    }

    public void Desligar() => EstaLigado = false;

    public abstract void Acelerar(int incremeto);

    public abstract void Frear(int decremento);
}