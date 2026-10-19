using System;
using System.Collections.Generic;

Conta ana = new ContaCorrente("Ana", 1000);
Conta bia = new ContaPoupanca("Bia", 2000);
Conta caio = new ContaCorrente("Caio");

ana.Depositar(200);
bia.Depositar(500, "salário");
ana.Sacar(1500);
caio.Sacar(400);
try
{
    caio.Sacar(200); // passa do limite: agora lança exceção
}
catch (SaldoInsuficienteException ex)
{
    Console.WriteLine($"Erro (Caio): {ex.Message}");
}

List<Conta> contas = new List<Conta>
    { ana, bia, caio };
foreach (Conta c in contas)
{ c.FimDoMes(); c.ExibirExtrato(); }

Console.WriteLine($"Total de contas: {Conta.GetTotalContas()}");

try
{
    ana.Sacar(1200);
    Console.WriteLine("Saque 1 ok");
    ana.Sacar(1200);
    Console.WriteLine("Saque 2 ok");
}
catch (SaldoInsuficienteException ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}
finally
{
    ana.ExibirExtrato();
}

// ===== Exceção personalizada =====
public class SaldoInsuficienteException
    : Exception
{
    public SaldoInsuficienteException(
        string mensagem) : base(mensagem)
    { }
}

// ===== Interface =====
public interface IExtrato
{
    void ExibirExtrato();
}

// ===== Classe abstrata base =====
public abstract class Conta : IExtrato
{
    private static int totalContas = 0;
    public readonly string Titular;
    protected decimal saldo;

    public Conta(string titular,
                 decimal saldoInicial)
    {
        Titular = titular;
        saldo = saldoInicial;
        totalContas++;
    }

    public Conta(string titular)
        : this(titular, 0) { }

    public decimal GetSaldo()
    { return saldo; }

    public static int GetTotalContas()
    { return totalContas; }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException(
                "Depósito deve ser positivo");
        saldo += valor;
    }

    public void Depositar(decimal valor,
                          string d)
    {
        Depositar(valor);
        Console.WriteLine($"Depósito: {d}");
    }

    public virtual void Sacar(decimal valor)
    {
        if (valor > saldo)
            throw new SaldoInsuficienteException(
                "Saldo insuficiente");
        saldo -= valor;
    }

    public abstract void FimDoMes();

    public void ExibirExtrato()
    {
        Console.WriteLine(
            $"{Titular}: R$ {saldo:F0}");
    }
}

// ===== Classes derivadas =====
public class ContaCorrente : Conta
{
    private decimal limite = 500;

    public ContaCorrente(string t, decimal s)
        : base(t, s) { }

    public ContaCorrente(string t) : base(t) { }

    public override void Sacar(decimal valor)
    {
        if (valor > saldo + limite)
            throw new SaldoInsuficienteException(
                "Limite excedido");
        saldo -= valor;
    }

    public override void FimDoMes()
    { saldo -= 10; }
}

public class ContaPoupanca : Conta
{
    public ContaPoupanca(string t, decimal s)
        : base(t, s) { }

    public override void FimDoMes()
    {
        saldo += saldo * 0.01m;
    }
}
