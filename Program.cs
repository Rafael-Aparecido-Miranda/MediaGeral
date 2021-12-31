 using System;

 namespace Estudo2
 {
     class Program
     {
         static void Main(string[]args)
        {
            int indice = 0;
            int quantidade;
            
            Console.WriteLine("Quantos alunos irão ser cadastrados?");
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                // Verifica se consegue fazer o Parse se conseguir preenche a quantidade vinda do  modificador out inteiro valor             
                 quantidade= valor;
            }
            else
            {
                throw new ArgumentException("O valor da nota deve ser inteiro."+"\r\n");
            }
            
            var alunos = new Aluno[quantidade];            
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X") //COMPARA MAIÚSCULA E MINÚSCULA COM O toUpeer()
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        //TODO: Adicionar aluno
                        
                        Console.WriteLine("\r\n"+"Informe o nome do aluno: ");
                        Aluno aluno = new Aluno(); //Cria o objeto aluno
                        aluno.Nome = Console.ReadLine(); // Seta o nome do aluno

                        Console.WriteLine("Informe a nota do aluno:");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            // Verifica se consegue fazer o Parse se conseguir preenche a nota vinda do  modificador out decimal nota 
                            
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal."+"\r\n");
                        }
                        alunos[indice] = aluno;
                        indice++;
                        break;

                    case "2":
                        //TODO: listar aluno
                        foreach(var a in alunos)
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota} \r\n");
                        
                        break;

                    case "3":
                        //TODO: calcular média geral
                        decimal notaTotal = 0;
                        var nrAlunos =0;
                        for (int i=0; i < alunos.Length; i++)
                        {
                            
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos = nrAlunos+1;
                            
                        }
                        decimal mediaGeral = notaTotal / nrAlunos;
                        EConceito conceitoGeral;

                        if (mediaGeral <= 2)
                        {
                            conceitoGeral = EConceito.E;
                        }
                        else if (mediaGeral <= 4)
                        {
                            conceitoGeral = EConceito.D;
                        }
                        else if (mediaGeral <= 6)
                        {
                            conceitoGeral = EConceito.C;
                        }
                        else if (mediaGeral <= 8)
                        {
                            conceitoGeral = EConceito.B;
                        }
                        else
                        {
                            conceitoGeral = EConceito.A;
                        }
                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO {conceitoGeral}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(); //EXCEPTION QUE DIZ QUE O PARÂMETRO ESTÁ FORA DO RANGE ESPECIFICADO   
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("3- X- Sair" + " \r\n");

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
 }