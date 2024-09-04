using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Logic
{
    public class Board
    {
        private BoardCell[,] m_Board;
        public int Rows { get; }
        public int Columns { get; }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            m_Board = new BoardCell[rows, columns];
            InitializeBoard();
        }

        public List<char> GenerateCards() // makes a list of the cards values to put in the board
        {
            char initialSeedCharacter = 'Z';
            int numberOfCellPairs = (Rows * Columns) / 2;
            List<char> cardsList = new List<char>();

            for (int i = 0; i < numberOfCellPairs; i++)
            {
                cardsList.Add(initialSeedCharacter);
                cardsList.Add(initialSeedCharacter);
                initialSeedCharacter--;
            }

            return cardsList;
        }

        public void InitializeBoard()
        {
            List<char> cardsList = GenerateCards();
            Random rand = new Random();
            int randomIndex = -1;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    randomIndex = rand.Next(cardsList.Count());
                    this.m_Board[i, j] = new BoardCell(cardsList[randomIndex]);
                    cardsList.RemoveAt(randomIndex);
                }
            }
        }
        public (int,int) GetSize()
        {
            return (Rows, Columns);
        }

        public BoardCell[,] GetBoardCells()
        {
            return m_Board;
        }

        public BoardCell GetCell(int row, int col)
        {
            return m_Board[row, col];
        }

        public void ExposeCell(int row, int col)
        {
            m_Board[row, col].IsExposed = true;
        }

        public void HideCell(int row, int col)
        {
            m_Board[row, col].IsExposed = false;
        }

        public bool AreAllCellsExposed()
        {
            foreach (var cell in m_Board)
            {
                if (!cell.IsExposed)
                {
                    return false;
                }
            }
            return true;
        }
    }

}
