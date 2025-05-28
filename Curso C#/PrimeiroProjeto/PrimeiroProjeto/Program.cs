namespace PrimeiroProjeto
{
    public class Program
    {
        static void Main(string[] args)
        {
            GerenciarEstoque();
            PerguntasRespostas();
            Console.ReadKey();
            Console.Clear();

            string mensagemDeBoasVinda = "Boas Vindas ao Screen Sound";
            //List<string> listaDasBandas = new List<string>() { "U2", "The Beatles", "Calypso" };

            Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
            bandasRegistradas.Add("U2", new List<int>() { 1, 10 });
            bandasRegistradas.Add("The Beatles", new List<int>() { 6 });
            bandasRegistradas.Add("Calypso", new List<int>() { 10, 10, 9 });
            ExibirOpcoesDoMenu();




            void ExibirLogo()
            {
                Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
                Console.WriteLine($"\n{mensagemDeBoasVinda}! \n");
                Console.WriteLine("***************************************");
            }

            void ExibirOpcoesDoMenu()
            {
                ExibirLogo();
                Console.WriteLine($"\nDigite 1 para registrar uma banda");
                Console.WriteLine($"\nDigite 2 para mostrar todas as banda");
                Console.WriteLine("\nDigite 3 para avaliar uma banda");
                Console.WriteLine("\nDigite 4 para exibir a média de uma banda");
                Console.WriteLine("\nDigite -1 para sair");

                Console.Write("\nDigite a sua opção: ");
                string opcaoEscolhida = Console.ReadLine()!;

                int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
                // código omitido
                switch (opcaoEscolhidaNumerica)
                {
                    case 1:
                        RegistrarBanda();
                        break;
                    case 2:
                        MostrarBandasRegistradas();
                        break;
                    case 3:
                        AvaliarUmaBanda();
                        break;
                    case 4:
                        ExibirMedia();
                        break;
                    case -1:
                        Console.WriteLine("Tchau tchau :)");

                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }

            void ExibirMedia()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Exibir média da banda");
                Console.Write("Digite o nome da banda que deseja exibir a média: ");
                string nomeDaBanda = Console.ReadLine();

                if (bandasRegistradas.ContainsKey(nomeDaBanda))
                {
                    List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
                    Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average()}.");
                }
                else
                {
                    // código para informar que a banda não foi encontrada
                    Console.WriteLine($"\n A banda {nomeDaBanda} não foi encontrada.");
                }

                Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
                Console.ReadKey();

                Console.Clear();
                ExibirOpcoesDoMenu();
            }

            void AvaliarUmaBanda()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Avaliar banda");
                Console.Write("Digite o nome da banda que deseja avaliar: ");
                string nomeDaBanda = Console.ReadLine()!;

                if (bandasRegistradas.ContainsKey(nomeDaBanda))
                {
                    Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
                    int nota = int.Parse(Console.ReadLine()!);
                    bandasRegistradas[nomeDaBanda].Add(nota);
                    Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                }

                Console.Clear();
                ExibirOpcoesDoMenu();

            }
            void MostrarBandasRegistradas()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");

                //for (int i = 0; i < listaDasBandas.Count; i++)
                //{
                //    Console.WriteLine($"Banda: {listaDasBandas[i]}");
                //}
                //foreach (var banda in listaDasBandas)
                //{
                //    Console.WriteLine($"Banda: {banda}");
                //}

                foreach (var banda in bandasRegistradas.Keys)
                {
                    Console.WriteLine($"Banda: {banda}");
                }

                Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

            void RegistrarBanda()
            {
                Console.Clear();

                ExibirTituloDaOpcao("Registro de bandas");

                Console.Write("Digite o nome da banda que deseja registrar: ");
                string nomeDaBanda = Console.ReadLine()!;

                //listaDasBandas.Add(nomeDaBanda);
                bandasRegistradas.Add(nomeDaBanda, new List<int>());


                Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso!");
                Thread.Sleep(2000);
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

            void ExibirTituloDaOpcao(string titulo)
            {
                int quantidadeDeLetras = titulo.Length;
                string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
                Console.WriteLine(asteriscos);
                Console.WriteLine(titulo);
                Console.WriteLine(asteriscos + "\n");


            }

            var notasAlunos = new Dictionary<string, Dictionary<string, List<int>>> {
                { "Ana", new Dictionary<string, List<int>> {
                    { "C#", new List<int> { 8, 7, 6 } },
                    { "Java", new List<int> { 7, 6, 5 } },
                    { "Python", new List<int> { 9, 8, 8 } }
                }},
                { "Maria", new Dictionary<string, List<int>> {
                    { "C#", new List<int> { 6, 5, 4 } },
                    { "Java", new List<int> { 8, 7, 6 } },
                    { "Python", new List<int> { 6, 10, 5 } }
                }},
                { "Luiza", new Dictionary<string, List<int>> {
                    { "C#", new List<int> { 2, 3, 10 } },
                    { "Java", new List<int> { 8, 8, 8 } },
                    { "Python", new List<int> { 7, 7, 7 } }
                }}
            };

            foreach (var aluno in notasAlunos)
            {
                Console.WriteLine($"\nAluno(a): {aluno.Key}");

                foreach (var disciplina in aluno.Value)
                {
                    double media = disciplina.Value.Average();
                    Console.WriteLine($"  {disciplina.Key}: Média = {media:F2}");
                }
            }
        }

        private static void PerguntasRespostas()
        {
            Dictionary<string, string> perguntasERespostas = new Dictionary<string, string>
                {
                    { "Qual é a capital do Brasil?", "Brasília" },
                    { "Quanto é 7 vezes 8?", "56" },
                    { "Quem escreveu 'Romeu e Julieta'?", "William Shakespeare" },
                    // Adicione mais perguntas e respostas conforme necessário
                };

            int pontuacao = 0;

            foreach (var pergunta in perguntasERespostas)
            {
                Console.WriteLine(pergunta.Key);
                Console.Write("Sua resposta: ");
                string respostaUsuario = Console.ReadLine();

                if (respostaUsuario.ToLower() == pergunta.Value.ToLower())
                {
                    Console.WriteLine("Correto!\n");
                    pontuacao++;
                }
                else
                {
                    Console.WriteLine($"Incorreto. A resposta correta é: {pergunta.Value}\n");
                }
            }

            Console.WriteLine($"Pontuação final: {pontuacao} de {perguntasERespostas.Count}");
        }

        private static void GerenciarEstoque()
        {
            Dictionary<string, int> estoque = new Dictionary<string, int>
                {
                    { "camisetas", 50 },
                    { "calças", 30 },
                    { "tênis", 20 },
                    // Adicione mais produtos conforme necessário
                };

            string produto = "camisetas";

            if (estoque.ContainsKey(produto))
            {
                Console.WriteLine($"Quantidade em estoque de {produto}: {estoque[produto]} unidades.");
            }
            else
            {
                Console.WriteLine("Produto não encontrado no estoque.");
            }

            Dictionary<string, List<int>> vendasCarros = new Dictionary<string, List<int>> {
                { "Bugatti Veyron", new List<int> { 10, 15, 12, 8, 5 } },
                { "Koenigsegg Agera RS", new List<int> { 2, 3, 5, 6, 7 } },
                { "Lamborghini Aventador", new List<int> { 20, 18, 22, 24, 16 } },
                { "Pagani Huayra", new List<int> { 4, 5, 6, 5, 4 } },
                { "Ferrari LaFerrari", new List<int> { 7, 6, 5, 8, 10 } }
            };

            double mediaVendasBugatti = vendasCarros["Bugatti Veyron"].Average();
            Console.WriteLine("\nMédia de vendas do Bugatti Veyron: " + mediaVendasBugatti);

            Console.ReadKey();
        }
    }
}
