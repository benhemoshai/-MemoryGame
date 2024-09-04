using MemoryGame.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.UI
{
    public class InputValidator
    {
        public string GetValidPlayerName()
        {
            bool isValidName = false;
            string playerName = "";
            while (!isValidName)
            {
                Console.WriteLine("Enter your name: ");
                playerName = Console.ReadLine();
                if (playerName.Length < 1)
                {
                    Console.WriteLine("Invalid name! Please enter a valid name.");
                    continue;
                }
                else
                {
                    isValidName = true;
                }
            }

            return playerName;
        }
        public int GetOpponentType()
        {
            int choice = -1;
            bool isValidChoice = false;

            while (!isValidChoice)
            {
                Console.WriteLine("Press 1 and enter for two players game");
                Console.WriteLine("Press 2 and enter for playing against the computer");
                isValidChoice = int.TryParse(Console.ReadLine(), out choice);

                if (choice > 2 || choice < 1)
                {
                    Console.WriteLine("Invalid choice! Please enter 1 or 2.");
                    isValidChoice = false;
                    continue;
                }
                else
                {
                    isValidChoice = true;
                }
            }

            return choice;
        }

        public (int, int) GetValidBoardSize()
        {
            int numOfRows = askForBoardDimensions("rows");
            int numOfColums = askForBoardDimensions("columns");
            return (numOfRows,numOfColums);
        }
        private static int askForBoardDimensions(string i_DimensionType)
        {
            string userAnswer;
            int userAnswerInt = -1;
            bool isValidDimension = false;

            while (!isValidDimension)
            {
                Console.WriteLine(string.Format("Enter a valid number of {0} (between 4 to 6): ", i_DimensionType));
                userAnswer = Console.ReadLine();
                bool isValidInteger = int.TryParse(userAnswer, out userAnswerInt);

                if (!isValidInteger)
                {
                    Console.WriteLine("You should enter an integer number!");
                    continue;
                }

                if (userAnswerInt < 4 || userAnswerInt > 6)
                {
                    Console.WriteLine(string.Format("{0} is not in range!", userAnswerInt));
                    continue;
                }

                isValidDimension = true;
            }

            return userAnswerInt;
        }

        public (int,int) GetValidMove(Board i_Board, Player i_CurrentPlayer)
        {
            bool isValidMove = false;
            int currentBoardRows = i_Board.GetSize().Item1;
            int currentBoardColumns = i_Board.GetSize().Item2;
            string moveIndexes = "";
            int chosenRowIndex = 0;
            int chosenColumnIndex = 0;

            while (!isValidMove)
            {
                Console.WriteLine(string.Format("({0}) Enter a valid move: ", i_CurrentPlayer.Name));
                moveIndexes = Console.ReadLine();

                if (moveIndexes.Length != 2)
                {
                    if (moveIndexes.Equals("Q"))
                    {
                        Environment.Exit(0);
                    }

                    Console.WriteLine("A valid move contains only 2 letters!");
                    continue;
                }
                else if (moveIndexes[0] - 65 < 0 || moveIndexes[0] - 65 > currentBoardColumns - 1)
                {
                    Console.WriteLine("Invalid column index!");
                    continue;
                }
                else if (moveIndexes[1] - 48 < 1 || moveIndexes[1] - 48 > currentBoardRows) // decrease by 48 to parse it to int. changed the condition < 1
                {
                    Console.WriteLine("Invalid row index!");
                    continue;
                }

                chosenRowIndex = int.Parse(moveIndexes.Substring(1)) - 1; // or moveIndexes[1] - 48 - 1;
                chosenColumnIndex = moveIndexes[0] - 65;

                if (i_Board.GetBoardCells()[chosenRowIndex, chosenColumnIndex].IsExposed)
                {
                    Console.WriteLine("This is cell is already taken!");
                    continue;
                }
                else
                {
                    isValidMove = true;
                    continue;
                }
            }

            return (chosenRowIndex,chosenColumnIndex);
        }

        public bool DoesUserWantAnotherRound()
        {
            bool isValidChoice = false;
            bool isPlayingAnotherGame = false;

            while (!isValidChoice)
            {
                Console.WriteLine("Do you want to play again? (press Y or N)");
                string userChoice = Console.ReadLine();

                if (userChoice.Equals("Y"))
                {
                    isValidChoice = true;
                    isPlayingAnotherGame = true;

                }
                else if (userChoice.Equals("N") || userChoice.Equals("Q"))
                {
                    isValidChoice = true;
                }
                else
                {
                    Console.WriteLine("Enter only Y or N/Q to continue!");
                    continue;
                }
                Console.Clear();
            }

            return isPlayingAnotherGame;
        }
    }

}
