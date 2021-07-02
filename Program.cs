using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            
            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListaSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluiSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;          
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = obterOpcaoUsuario();
            }

            Console.WriteLine("Obriagdo por utilizar nossos serviços.");
            Console.ReadLine();
        }
        private static void VisualizarSeries()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluiSeries()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);

        }


        private static void AtualizarSeries()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o gênero entre as opções a cima: ");
            int entrdaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série: ");
            string entrdaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da série: ");
            int entrdaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrção da série: ");
            string entrdadescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entrdaGenero,
                                        titulo: entrdaTitulo,
                                        ano: entrdaAno,
                                        descricao: entrdadescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ListaSeries()
        {
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if(!excluido)
                {
                    Console.WriteLine($"#ID {serie.retornaId()} - {serie.retornatitulo()}");
                }
                else if(excluido)
                {
                    Console.WriteLine($"#ID {serie.retornaId()} - {serie.retornatitulo()} - Excluído");
                }
            }
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o gênero entre as opções a cima: ");
            int entrdaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série: ");
            string entrdaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da série: ");
            int entrdaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrção da série: ");
            string entrdadescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoID(),
                                        genero: (Genero)entrdaGenero,
                                        titulo: entrdaTitulo,
                                        ano: entrdaAno,
                                        descricao: entrdadescricao);

            repositorio.Insere(novaSerie);
        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
