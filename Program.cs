using System;

namespace Dio.SerieFilme
{
    class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuarioPrincipal = ObterOpcaoUsuarioPrincipal();
            
            while(opcaoUsuarioPrincipal.ToUpper() !="X")
            {
                if (opcaoUsuarioPrincipal == "1")
                {
                    string opcaoUsuarioSerie = ObterOpcaoUsuarioSerie();
                    while(opcaoUsuarioSerie.ToUpper() !="X")
                    {
                        switch (opcaoUsuarioSerie)
                        {
                            case "1" :
                                ListarSerie();
                                break;
                            case "2" :
                                InserirSerie();
                                break;
                            case "3":
                                AtualizarSerie();
                                break;
                            case "4":
                                ExcluirSerie();
                                break;
                            case "5":
                                VisualizarSerie();
                                break;
                            case "C":
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Opção invalida!");
                                Console.WriteLine("Entre novamente com uma opção");
                                opcaoUsuarioPrincipal = ObterOpcaoUsuarioPrincipal();
                                //trow new ArgumentOutofRangeException("");
                                break;
                        }
                        opcaoUsuarioSerie = ObterOpcaoUsuarioSerie();
                    }
                }
                else if (opcaoUsuarioPrincipal == "2")
                {
                    string opcaoUsuarioFilme = ObterOpcaoUsuarioFilme();
                    while(opcaoUsuarioFilme.ToUpper() !="X")
                    {
                        switch (opcaoUsuarioFilme)
                        {
                            case "1" :
                                ListarFilme();
                                break;
                            case "2" :
                                InserirFilme();
                                break;
                            case "3":
                                AtualizarFilme();
                                break;
                            case "4":
                                ExcluirFilme();
                                break;
                            case "5":
                                VisualizarFilme();
                                break;
                            case "C":
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Opção invalida!");
                                Console.WriteLine("Entre novamente com uma opção");
                                opcaoUsuarioPrincipal = ObterOpcaoUsuarioPrincipal();
                                //trow new ArgumentOutofRangeException("");
                                break;
                        }
                        opcaoUsuarioFilme = ObterOpcaoUsuarioFilme();
                    }
                }
                else
                {
                    Console.WriteLine("Opção invalida!");
                    Console.WriteLine("Entre novamente com uma opção");
                    opcaoUsuarioPrincipal = ObterOpcaoUsuarioPrincipal();
                    //retone para menu principal
                }
            }

        static void ListarSerie()
        {
            Console.WriteLine("Listar Série.");
            
            var lista = repositorioSerie.Lista();

            if ( lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("ID {0}: {1} - {2}",serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
                //Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        static void ListarFilme()
        {
            Console.WriteLine("Listar Filme.");
            
            var lista = repositorioFilme.Lista();

            if ( lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Filme cadastrada.");
                return;
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("ID {0}: {1} - {2}",filme.retornaId(), filme.retornaTitulo(), (excluido ? "Excluido" : ""));
                //Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        static void InserirSerie()
        {
            Console.WriteLine("Inserir nova Série.");

            foreach( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} -{1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Emissora da Série: ");
            string entradaEmisora = Console.ReadLine();

            Console.WriteLine("Digite quantidade de Episodio da Série: ");
            int entradaEpisodio = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorioSerie.Proximo(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        episodio : entradaEpisodio,
                                        emisora : entradaEmisora,
                                        descricao: entradaDescricao);
            repositorioSerie.Insere(novaSerie);                           
        }

        static void InserirFilme()
        {
            Console.WriteLine("Inserir nova Filme.");

            foreach( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} -{1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a gravadora do Filme: ");
            string entradaGravadora = Console.ReadLine();


            Console.WriteLine("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorioFilme.Proximo(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        gravadora: entradaGravadora,
                                        descricao: entradaDescricao);
            repositorioFilme.Insere(novoFilme);                           
        }

        static void AtualizarSerie()
        {
            Console.WriteLine("Digete o id da Série.");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} -{1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Emissora da Série: ");
            string entradaEmisora = Console.ReadLine();

            Console.WriteLine("Digite quantidade de Episodio da Série: ");
            int entradaEpisodio = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        episodio : entradaEpisodio,
                                        emisora : entradaEmisora,
                                        descricao: entradaDescricao);
            repositorioSerie.Atualiza(indiceSerie, atualizaSerie);
        }
        
        static void AtualizarFilme()
        {
            Console.WriteLine("Digete o id da Série.");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} -{1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a gravadora do Filme: ");
            string entradaGravadora = Console.ReadLine();

            Console.WriteLine("Digite a descrição da Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        gravadora: entradaGravadora,
                                        descricao: entradaDescricao);
            repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
        }

        static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorioSerie.Exclui(indiceSerie);
        }

        static void ExcluirFilme()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorioFilme.Exclui(indiceFilme);
        }

        static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie =  int.Parse(Console.ReadLine());

            var serie = repositorioSerie.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        static void VisualizarFilme()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceFilme =  int.Parse(Console.ReadLine());

            var filme = repositorioFilme.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }

        static string ObterOpcaoUsuarioPrincipal()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Serie & Filme a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine();
            Console.WriteLine("1 - Série.");
            Console.WriteLine("2 - Filme.");
            Console.WriteLine();

            string opcapUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcapUsuario;
        }

        static string ObterOpcaoUsuarioSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Série ao seu Dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Série");
            Console.WriteLine("2 - Inserir nova Série.");
            Console.WriteLine("3 - Atualizar Série.");
            Console.WriteLine("4 - Excluir Série.");
            Console.WriteLine("5 - Visualizar Série.");
            Console.WriteLine("C - limpar tela.");
            Console.WriteLine("X - Sair.");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        } 

        static string ObterOpcaoUsuarioFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Série & Filme ao seu Dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Filme");
            Console.WriteLine("2 - Inserir nova Filme.");
            Console.WriteLine("3 - Atualizar Filme.");
            Console.WriteLine("4 - Excluir Filme.");
            Console.WriteLine("5 - Visualizar Filme.");
            Console.WriteLine("C - limpar tela.");
            Console.WriteLine("X - Sair.");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
        }
    }
}
