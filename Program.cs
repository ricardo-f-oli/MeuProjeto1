namespace MeuProjeto1
{
    // Exemplo didático procedural: dados simples e funções estáticas, sem classes de domínio.
    class Program
    {
        enum Opcao
        {
            Sair = 0,
            Somar = 1,
            Subtrair = 2,
            Multiplicar = 3,
            Dividir = 4,
            Potencia = 5
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== Calculadora didática em C# ===");
            Console.WriteLine("Procedural: as operações são funções separadas e os dados são variáveis locais.");
            Console.WriteLine("Isso permite estudar lógica e funções sem introduzir objetos, propriedades ou herança.\n");

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n1-Somar  2-Subtrair  3-Multiplicar  4-Dividir  5-Potência  0-Sair");
                Console.Write("Escolha: ");
                string entrada = Console.ReadLine() ?? "";
                if (!int.TryParse(entrada, out int valorOpcao) || !Enum.IsDefined(typeof(Opcao), valorOpcao))
                {
                    Console.WriteLine("Opção inválida.");
                    continue;
                }

                Opcao opcao = (Opcao)valorOpcao;
                if(opcao == Opcao.Sair)
                {
                    continuar = false;
                    break;
                }
                
                    
            
                    double a = LerNumero("Primeiro número: ");
                    double b = LerNumero("Segundo número: ");
                    double resultado = 0;
                    bool valido = true;

                    // switch-case seleciona a operação; operadores matemáticos executam o cálculo.
                    switch (opcao)
                    {
                        case Opcao.Somar: resultado = Somar(a, b); break;
                        case Opcao.Subtrair: resultado = Subtrair(a, b); break;
                        case Opcao.Multiplicar: resultado = Multiplicar(a, b); break;
                        case Opcao.Dividir:
                            if (b == 0)
                            {
                                Console.WriteLine("Não é possível dividir por zero.");
                                valido = false;
                            }
                            else resultado = Dividir(a, b);
                            break;
                        case Opcao.Potencia: resultado = Math.Pow(a, b); break;
                        case Opcao.RaizQuadrada: resultado = Math.Sqrt(a); break;
                        default:
                        Console.WriteLine("Opção inválida.");
                        break;
                    }

                    if (valido)
                    {
                        Console.WriteLine($"Resultado: {resultado}");
                    }
                
                    
                }

                // Operador ternário: expressão condicional compacta.
                string status = continuar ? "Calculadora ativa" : "Encerrando";
                Console.WriteLine(status);

            Console.WriteLine("Até a próxima!");
        }

        static double LerNumero(string mensagem)
        {
            while (true) // while repete até que a entrada seja válida.
            {
                Console.Write(mensagem);
                string texto = Console.ReadLine() ?? "";
                if (double.TryParse(texto, out double numero))
                    return numero;
                Console.WriteLine("Valor inválido; tente novamente.");
            }
        }

        static double Somar(double a, double b) => a + b;
        static double Subtrair(double a, double b) => a - b;
        static double Multiplicar(double a, double b) => a * b;
        static double Dividir(double a, double b) => a / b;
    }
}

