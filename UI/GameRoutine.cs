using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryGame.Logic;

namespace MemoryGame.UI
{
    public class GameRoutine
    {
        public static void StartGame()
        {
            InputValidator inputValidator = new InputValidator();

            do
            {
                Console.WriteLine("Welcome to Memory Game!");

                string player1Name = inputValidator.GetValidPlayerName();
                int opponentType = inputValidator.GetOpponentType();
                string player2Name = "";
                bool isAgainstComputer = false;

                if (opponentType == 1)
                {
                    player2Name = inputValidator.GetValidPlayerName();
                }
                else
                {
                    isAgainstComputer = true;
                    player2Name = "Computer";
                }

                (int rows, int cols) = inputValidator.GetValidBoardSize();

                MemoryGameLogic game = new MemoryGameLogic(player1Name, player2Name, rows, cols, isAgainstComputer);
                Player player1 = game.GetPlayers().Item1;
                Player player2 = game.GetPlayers().Item2;

                while (!game.IsGameOver())
                {
                    int row1, col1, row2, col2;
                    if (game.IsPlayer1Turn || !isAgainstComputer)
                    {
                        // Player's turn
                        ConsoleUI.PrintAndClear(game.Board, player1, player2);

                        (row1, col1) = inputValidator.GetValidMove(game.Board, game.GetCurrentPlayer());
                        game.Expose(row1, col1);
                        ConsoleUI.PrintAndClear(game.Board, player1, player2);

                        (row2, col2) = inputValidator.GetValidMove(game.Board, game.GetCurrentPlayer());
                        game.Expose(row2, col2);
                        ConsoleUI.PrintAndClear(game.Board, player1, player2);

                        System.Threading.Thread.Sleep(2000);

                    }
                    else
                    {
                        // Computer's turn
                        Console.WriteLine("Computer's turn...");
                        System.Threading.Thread.Sleep(1000);

                        (row1, col1) = game.GetRandomHiddenCell();
                        game.Expose(row1, col1);
                        ConsoleUI.PrintAndClear(game.Board, player1, player2);
                        System.Threading.Thread.Sleep(1000);

                        (row2, col2) = game.GetRandomHiddenCell();
                        game.Expose(row2, col2);
                        ConsoleUI.PrintAndClear(game.Board, player1, player2);
                        System.Threading.Thread.Sleep(2000);

                    }

                    if (game.PlayTurn(row1, col1, row2, col2))
                    {
                        ConsoleUI.PrintMatchMessage();
                    }
                    else
                    {
                        ConsoleUI.PrintMissMessage();
                    }
                    System.Threading.Thread.Sleep(1000);
                    ConsoleUI.PrintAndClear(game.Board, player1, player2);


                    if (game.IsGameOver())
                    {
                        Player winner = game.GetWinner();
                        if (winner != null)
                        {
                            ConsoleUI.PrintWinMessage(winner);
                        }
                        else
                        {
                            ConsoleUI.PrintTieMessage(player1, player2);
                        }
                        break;
                    }
                }

            } while (inputValidator.DoesUserWantAnotherRound());
        }
    }
}
