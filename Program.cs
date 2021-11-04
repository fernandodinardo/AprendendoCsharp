using System;

namespace DIO_Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        //To Do: Adicionar um aluno
                        Console.WriteLine("Informe o nome do Aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome_Aluno = Console.ReadLine();

                        Console.WriteLine("Informe a nota do Aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota_Aluno = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota do aluno deve ser decimal!");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;

                    case "2":
                        //To Do: Listar os alunos
                        foreach(var a in alunos)
                        {
                            //if (!a.Nome_Aluno.Equals(""))
                            if (!string.IsNullOrEmpty(a.Nome_Aluno))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome_Aluno} - NOTA: {a.Nota_Aluno}");
                            }
                        }

                        break;

                    case "3":
                        //To Do: Calcular a média geral
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome_Aluno))
                            {
                                notaTotal = notaTotal + alunos[i].Nota_Aluno;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;

                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MEDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opcao desejada:");
            Console.WriteLine();
            Console.WriteLine("1- Inserir um novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- SAIR");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
