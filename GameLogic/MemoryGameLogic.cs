using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Logic
{
    public class MemoryGameLogic
    {
        private Board m_Board;
        private Player m_Player1;
        private Player m_Player2;
        public bool IsPlayer1Turn { get; private set; } = true;


        public MemoryGameLogic(string player1Name, string player2Name, int rows, int columns, bool isAgainstComputer)
        {
            m_Player1 = new Player(player1Name, false);
            m_Player2 = new Player(player2Name, isAgainstComputer);
            m_Board = new Board(rows, columns);
        }

        public Board Board => m_Board;

        public void Expose(int row,int column)
        {
         m_Board.ExposeCell(row, column);
        }
        public bool PlayTurn(int row1, int col1, int row2, int col2)
        {
            if (m_Board.GetCell(row1, col1).Value == m_Board.GetCell(row2, col2).Value)
            {
                GetCurrentPlayer().IncreaseScore();
                return true;
            }
            else
            {
                m_Board.HideCell(row1, col1);
                m_Board.HideCell(row2, col2);
                SwitchTurn();
                return false;
            }
        }

        private void SwitchTurn()
        {
            IsPlayer1Turn = !IsPlayer1Turn;
        }
        public (int, int) GetRandomHiddenCell()
        {
            Random rand = new Random();
            var hiddenCells = new List<(int, int)>();

            for (int i = 0; i < Board.GetSize().Item1; i++)
            {
                for (int j = 0; j < Board.GetSize().Item2; j++)
                {
                    if (!Board.GetBoardCells()[i, j].IsExposed)
                    {
                        hiddenCells.Add((i, j));
                    }
                }
            }

            int index = rand.Next(hiddenCells.Count);
            return hiddenCells[index];
        }

        public Player GetCurrentPlayer()
        {
            return IsPlayer1Turn ? m_Player1 : m_Player2;
        }

        public bool IsGameOver()
        {
            return m_Board.AreAllCellsExposed();
        }
        
        public (Player,Player) GetPlayers()
        {
            return (m_Player1, m_Player2);
        }

        public Player GetWinner()
        {
            if (m_Player1.Score > m_Player2.Score)
            {
                return m_Player1;
            }
            else if (m_Player2.Score > m_Player1.Score)
            {
                return m_Player2;
            }
            else
            {
                return null; // It's a tie
            }
        }
    }
}
