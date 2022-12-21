using System;
using System.Threading;
namespace Jogo_do_Galo
{
    internal class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int jogador = 1;
        static int turno;
        static int flag = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n");
                if (jogador % 2 == 0)//Indicação do turno atual
                {
                    Console.WriteLine("Turno do Jogador 'X'");
                }
                else
                {
                    Console.WriteLine("Turno do Jogador 'O'");
                }
                Console.WriteLine("\n");
                //Desenhar o tabuleiro
                Tab();
                turno = int.Parse(Console.ReadLine());
                if (arr[turno] != 'X' && arr[turno] != 0) //Avançar o turno e reconhecer se o turno é do 'X' ou do 'O'
                {
                    if (jogador % 2 == 0)
                    {
                        arr[turno] = 'O';
                        jogador++;
                    }
                    else
                    {
                        arr[turno] = 'X';
                        jogador++;
                    }
                }
                else
                {
                    Console.WriteLine("A casa {0} já está ocupada com {1}", turno, arr[turno]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Loading.....");
                    Thread.Sleep(2000);
                }
                flag = VerificarFim();
            }
            while (flag != 1 && flag != -1);
            Console.Clear();
            Tab();
            if (flag == 1)
            {
                Console.WriteLine("Jogador {0} ganhou", (jogador % 2));
            }
            else
            {
                Console.WriteLine("Empate");
            }
            Console.ReadLine();
        }

        //Método de desenhar o tabuleiro
        private static void Tab()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        private static int VerificarFim()
        {
            #region Horzontal Winning Condtion
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion
            #region vertical Winning Condtion
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion
            #region Checking For Draw
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }
    }
}