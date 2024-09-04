using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MemoryGame.Logic;

namespace MemoryGame.UI
{
    public class ConsoleUI
    {
        public static void PrintAndClear(Board i_Board, Player player1, Player player2)
        {
            Console.Clear();
            PrintBoard(i_Board);
            PrintScoreBoard(player1, player2);
        }
        public static void PrintBoard(Board i_Board)
        {
            int initialLetter = 65;
            string dividerLine = new string('=', 4 * i_Board.GetSize().Item2 + 1);
            StringBuilder boardTableOutput = new StringBuilder("  ");

            // Adding the columns line
            for (int i = 0; i < i_Board.GetSize().Item2; i++)
            {
                boardTableOutput.AppendFormat("  {0} ", (char)initialLetter++);
            }

            boardTableOutput.AppendLine();
            boardTableOutput.Append("  ").AppendLine(dividerLine);

            // Adding the rows
            for (int i = 0; i < i_Board.GetSize().Item1; i++)
            {
                boardTableOutput.AppendFormat("{0} |", i + 1);
                for (int j = 0; j < i_Board.GetSize().Item2; j++)
                {
                    if (i_Board.GetBoardCells()[i, j].IsExposed)
                    {
                        boardTableOutput.AppendFormat(" {0} |", i_Board.GetCell(i,j).Value);
                    }
                    else
                    {
                        boardTableOutput.Append("   |");
                    }
                }
                boardTableOutput.AppendLine().Append("  ").AppendLine(dividerLine);
            }

            Console.WriteLine(boardTableOutput.ToString());

        }
        public static void PrintScoreBoard(Player i_Player1, Player i_Player2)
        {
            string scoreBoardOutput = string.Format("Scoreboard: {0} - {1} points | {2} - {3} points", i_Player1.Name, i_Player1.Score, i_Player2.Name, i_Player2.Score);
            Console.WriteLine(scoreBoardOutput);
        }

        public static void PrintTieMessage(Player i_Player1, Player i_Player2)
        {
            Console.WriteLine(string.Format("Its a tie, both {0} and {1} finished the game with {2} points!", i_Player1.Name, i_Player2.Name, i_Player1.Score));
        }

        public static void PrintWinMessage(Player i_Winner)
        {
            Console.WriteLine(string.Format("Congratulations {0}, You won the game with {1} points!", i_Winner.Name, i_Winner.Score));
        }

        public static void PrintMatchMessage()
        {
            Console.WriteLine(string.Format("Nice match! Keep it going..."));
        }
        public static void PrintMissMessage()
        {
            Console.WriteLine("Miss!");
        }

    }

}
