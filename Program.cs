using System;
using System.Globalization;

namespace SeuProjeto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== MENU DE EXERCÍCIOS ===");
            Console.WriteLine("1 - Detalhar Data");
            Console.WriteLine("2 - Calcular Desconto INSS");
            Console.WriteLine("3 - Verificar Aula ETEC");
            Console.WriteLine("4 - Calcular Tabuada");
            Console.WriteLine("5 - Calcular Média");
            Console.WriteLine("6 - Concatenar Palavras");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();
            Console.WriteLine("---------------------------");

            switch (opcao)
            {
                case "1":
                    DetalharData();
                    break;
                case "2":
                    CalcularDescontoINSS();
                    break;
                case "3":
                    VerificarAulaEtec();
                    break;
                case "4":
                    CalcularTabuada();
                    break;
                case "5":
                    CalcularMedia();
                    break;
                case "6":
                    ConcatenarPalavras();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        // Tarefa 1 da Aula: Detalhar Data
        public static void DetalharData()
        {
            CultureInfo culturaPtBr = new CultureInfo("pt-BR");

            Console.Write("Digite uma data (dd/MM/yyyy): ");
            string entrada = Console.ReadLine();

            if (DateTime.TryParse(entrada, culturaPtBr, DateTimeStyles.None, out DateTime dataInformada))
            {
                string diaSemana = dataInformada.ToString("dddd", culturaPtBr);
                diaSemana = culturaPtBr.TextInfo.ToTitleCase(diaSemana);

                string mesExtenso = dataInformada.ToString("MMMM", culturaPtBr);
                mesExtenso = culturaPtBr.TextInfo.ToTitleCase(mesExtenso);

                Console.WriteLine($"\nDia da Semana: {diaSemana}");
                Console.WriteLine($"Mês: {mesExtenso}");

                if (dataInformada.DayOfWeek == DayOfWeek.Sunday)
                {
                    string horaAtual = DateTime.Now.ToString("HH:mm");
                    Console.WriteLine($"Hora atual: {horaAtual}");
                }
            }
            else
            {
                Console.WriteLine("Data inválida! Por favor, digite no formato correto (ex: 15/03/2026).");
            }
        }

        // Tarefa 2 da Aula: Calcular Desconto INSS 2026
        public static void CalcularDescontoINSS()
        {
            Console.Write("Digite o valor do salário bruto: R$ ");
            if (decimal.TryParse(Console.ReadLine(), out decimal salario))
            {
                decimal aliquota = 0m;

                if (salario <= 1621.00m)
                {
                    aliquota = 0.075m; 
                }
                else if (salario <= 2902.84m)
                {
                    aliquota = 0.09m;  
                }
                else if (salario <= 4354.27m)
                {
                    aliquota = 0.12m;  
                }
                else if (salario <= 8475.55m)
                {
                    aliquota = 0.14m;  
                }
                else
                {
                    aliquota = 0.14m;  
                }

                decimal valorInss = salario * aliquota;
                decimal salarioDescontado = salario - valorInss;

                Console.WriteLine($"\n--- Resultado do Cálculo ---");
                Console.WriteLine($"Alíquota aplicada: {aliquota * 100}%");
                Console.WriteLine($"Valor do INSS a pagar: {valorInss:C2}");
                Console.WriteLine($"Salário com desconto do INSS: {salarioDescontado:C2}");
            }
            else
            {
                Console.WriteLine("Valor de salário inválido!");
            }
        }

        public static void VerificarAulaEtec()
        {
            Console.WriteLine("Digite a data:");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime data))
            {
                if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
                {
                    Console.WriteLine("Final de semana! Hoje não tem aula! Revisarei exercícios!");
                }
                else
                {
                    Console.WriteLine("Dia de semana! Bora pra ETEC!");
                }
            }
            else
            {
                Console.WriteLine("Data em formato inválido!");
            }
        }

        public static void CalcularTabuada()
        {
            Console.WriteLine("Digite a tabuada que deseja calcular:");
            if (int.TryParse(Console.ReadLine(), out int tabuada))
            {
                int contador = 0;
                while (contador <= 10)
                {
                    string mensagem = string.Format("{0} X {1} = {2}", tabuada, contador, tabuada * contador);
                    Console.WriteLine(mensagem);
                    contador++;
                }
            }
            else
            {
                Console.WriteLine("Número inválido!");
            }
        }

        public static void CalcularMedia()
        {
            Console.WriteLine("Digite a primeira nota:");
            decimal.TryParse(Console.ReadLine(), out decimal nota1);

            Console.WriteLine("Digite a segunda nota:");
            decimal.TryParse(Console.ReadLine(), out decimal nota2);

            decimal media = (nota1 + nota2) / 2;
            Console.WriteLine($"A média é {media}");

            if (media >= 7)
                Console.WriteLine("Aprovado");
            else if (media >= 4)
                Console.WriteLine("Recuperação");
            else
                Console.WriteLine("Reprovado");
        }

        public static void ConcatenarPalavras()
        {
            Console.WriteLine("Digite seu nome: ");
            string nome = Console.ReadLine();

            string frase1 = $"Olá {nome}, hoje é {DateTime.Now}";
            Console.WriteLine(frase1);

            Console.WriteLine("===========================");

            Console.WriteLine("Quanto custa um dólar em reais?");
            if (decimal.TryParse(Console.ReadLine(), out decimal ValorDolarReais))
            {
                string frase2 = string.Format("Hoje é {0:dd/MM/yyyy}, o dólar está custando {1:c2}", DateTime.Now, ValorDolarReais);
                Console.WriteLine(frase2);
            }

            Console.WriteLine("===========================");

            string cabecalho = string.Format("{0:dddd}, {0:dd} de {0:MMMM} de {0:yy} - {0:HH:mm:ss}", DateTime.Now);
            Console.WriteLine(cabecalho);
        }
    }
}