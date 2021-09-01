using System;
using System.Linq;
namespace ConnectFourWinApp
{
    public enum eGameState
    {
        Off,
        Player1,
        Player2,
        Computer,
        Win,
    }
    public delegate void GameOverEventHandler(object i_Sender, EventArgs i_EventArgs);
    class BoardManger
    {
        private char?[,] m_BoardMatrix = null;
        private eGameState m_GameState;
        private bool m_GameIsOn;
        private eGameState m_Opponent;
        private int m_Player1ScoreCount;
        private int m_Player2OrComputerScoreCount;
        public event GameOverEventHandler PlayerWon;
        public event GameOverEventHandler Tie;
        public BoardManger(int i_BoardRows,int i_BoardColumns, eGameState i_Opponent)
        {
            m_BoardMatrix = new char?[i_BoardRows,i_BoardColumns];
            m_GameState = eGameState.Off;
            m_GameIsOn = false;
            m_Opponent = i_Opponent;
            m_Player1ScoreCount = 0;
            m_Player2OrComputerScoreCount = 0;

        }
        public char?[,] Board
        {
            get
            {
                return m_BoardMatrix;
            }
        }
        public eGameState GameState
        {
            get
            {
                return m_GameState;
            }
            set
            {
                m_GameState = value;
            }
        }
        public bool GameIsOn
        {
            get
            {
                return m_GameIsOn;
            }
            set
            {
                m_GameIsOn = value;
            }
        }
        public int Player1ScoreCount
        {
            get
            {
                return m_Player1ScoreCount;
            }
        }
        public int Player2OrComputerScoreCount
        {
            get
            {
                return m_Player2OrComputerScoreCount;
            }
        }
        public eGameState Opponent
        {
            get
            {
                return m_Opponent;
            }
        }
        public void ChangeTurn()
        {

                if(m_GameState == eGameState.Player2 || m_GameState == eGameState.Computer)
                {
                    m_GameState = eGameState.Player1;
                }
                else if(m_GameState == eGameState.Player1 && m_Opponent == eGameState.Player2)
                {
                    m_GameState = eGameState.Player2;
                }
                else if(m_GameState == eGameState.Player1 && m_Opponent == eGameState.Computer)
                    m_GameState = eGameState.Computer;
            

        }
        public bool CheckIfValidMove(int i_ColumnNumber)
        {
            if(i_ColumnNumber <= m_BoardMatrix.GetLength(1) && i_ColumnNumber >=1)
            {
                int lastRow = m_BoardMatrix.GetLength(0) - 1;
                for (int i = lastRow; i >= 0; i--)
                {

                    if (!m_BoardMatrix[i, i_ColumnNumber - 1].HasValue)
                    {
                        return true;
                    }
                }
                return false;
            }

            return false;
        }
        public void FillCellWithValidMoveAndIfWinGameIsOff(int i_ColumnNumber)
        {
            int lastRow = m_BoardMatrix.GetLength(0) - 1;
            for (int i = lastRow; i >= 0; i--)
            {
                if(!m_BoardMatrix[i, i_ColumnNumber-1].HasValue)
                {

                    if(m_GameState == eGameState.Player1)
                    {
                        m_BoardMatrix[i, i_ColumnNumber-1] = 'X';
                        WinCheck(i, i_ColumnNumber-1);
                        break;
                    }
                    if (m_GameState == eGameState.Player2 || m_GameState == eGameState.Computer)
                    {
                        m_BoardMatrix[i, i_ColumnNumber-1] = 'O';
                        WinCheck(i, i_ColumnNumber-1 );
                        break;
                    }
                }
            }
        }
        public void WinCheck(int i_CellRow, int i_CellColumn)
        {
            int matrixNumberOfRows = m_BoardMatrix.GetLength(0);
            int matrixNumberOfColumn = m_BoardMatrix.GetLength(1);
            char lastInsertedCell = m_BoardMatrix[i_CellRow, i_CellColumn] ?? '0';
            // Row check
            if(winRightToLeftObliqueLineCheck(lastInsertedCell, i_CellRow, i_CellColumn) ||
               winRowCheck(lastInsertedCell, i_CellRow, i_CellColumn) ||
               winColumnCheck(lastInsertedCell, i_CellRow, i_CellColumn) || 
               winLeftToRightObliqueLineCheck(lastInsertedCell, i_CellRow, i_CellColumn)
               )
            {
                m_GameIsOn = false;

                if(m_GameState == eGameState.Player1)
                {
                    m_Player1ScoreCount += 1;
                }
                else if(m_GameState == eGameState.Player2 || m_GameState == eGameState.Computer)
                {
                    m_Player2OrComputerScoreCount += 1;
                }
                OnPlayerWon();
            }
            else
            {
                if(BoardIsFull() == true)
                {
                    TieUpdateScores();
                    OnTie();
                }
            }
        }
        private bool winRowCheck(char i_LastInsertedCell,int i_CellRow, int i_CellColumn)

        {
            int matrixNumberOfColumn = m_BoardMatrix.GetLength(1);
           
            int count = 1;
            // Right check
            for(int i = i_CellColumn + 1; i < matrixNumberOfColumn; i++)
            {
                if(m_BoardMatrix[i_CellRow, i] == i_LastInsertedCell)
                {
                    count += 1;
                }
                else
                {
                    break;
                }
            }
            //Left check
            for (int i = i_CellColumn - 1; i >= 0; i--)
            {
                if (m_BoardMatrix[i_CellRow, i] == i_LastInsertedCell)
                {
                    count += 1;
                    
                }
                else
                {
                    break;
                }
            }
            return count >= 4 ? true : false;
        }
        private bool winColumnCheck(char i_LastInsertedCell, int i_CellRow, int i_CellColumn)
        {
            int matrixNumberOfRows = m_BoardMatrix.GetLength(0);
            int count = 1;
            // Right check
            for (int i = i_CellRow + 1; i < matrixNumberOfRows; i++)
            {
                if (m_BoardMatrix[i, i_CellColumn] == i_LastInsertedCell)
                {
                    count += 1;
                }
                else
                {
                    break;
                }
            }
            //Left check
            for (int i = i_CellRow - 1; i >= 0; i--)
            {
                if (m_BoardMatrix[i, i_CellColumn] == i_LastInsertedCell)
                {
                    count += 1;
                    
                }
                else
                {
                    break;
                }
            }
            return count >= 4 ? true : false;
        }
        private bool winLeftToRightObliqueLineCheck(char i_LastInsertedCell, int i_CellRow, int i_CellColumn)
        {
            int matrixNumberOfRows = m_BoardMatrix.GetLength(0);
            int matrixNumberOfColumn = m_BoardMatrix.GetLength(1) ;
            int count = 1;
            //check top right
            for(int i = i_CellRow -1 ; i >= 0 ; i--)
            {
                
                for(int j = i_CellColumn+1; j < matrixNumberOfColumn; j++)
                {
                    if(i_CellRow - i == j - i_CellColumn)
                    {
                        if(m_BoardMatrix[i, j] == i_LastInsertedCell)
                        {
                            count += 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            //check bottom left
            for (int i = i_CellRow + 1; i < matrixNumberOfRows; i++)
            {

                for (int j = i_CellColumn - 1; j>=0 ; j--)
                {
                    if (i - i_CellRow  == i_CellColumn - j)
                    {
                        if (m_BoardMatrix[i, j] == i_LastInsertedCell)
                        {
                            count += 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return count >= 4 ? true : false;
        }
        private bool winRightToLeftObliqueLineCheck(char i_LastInsertedCell, int i_CellRow, int i_CellColumn)
        {
            int matrixNumberOfRows = m_BoardMatrix.GetLength(0);
            int matrixNumberOfColumn = m_BoardMatrix.GetLength(1);
            int count = 1;
            //check top left
            for (int i = i_CellRow - 1; i >= 0; i--)
            {

                for (int j = i_CellColumn - 1; j >= 0 ; j--)
                {
                    if (i_CellRow - i == i_CellColumn - j)
                    {
                        if (m_BoardMatrix[i, j] == i_LastInsertedCell)
                        {
                            count += 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            //check bottom right
            for (int i = i_CellRow + 1; i < matrixNumberOfRows; i++)
            {

                for (int j = i_CellColumn - 1; j< matrixNumberOfColumn; j++)
                {
                    if (i - i_CellRow == j - i_CellColumn)
                    {
                        if (m_BoardMatrix[i, j] == i_LastInsertedCell)
                        {
                            count += 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return count >= 4 ? true : false;
        }
        public bool BoardIsFull()
        {
            int numOfColumns = m_BoardMatrix.GetLength(1);
            
            for(int i = 0; i < numOfColumns; i++)
            {
                if(m_BoardMatrix[0, i] == null)
                {
                    return false;
                }
            }
            return true;
        }
        public eGameState GetRandomPlayerStartTheGame()
        {
            Random rand = new Random();
            int randomNum = rand.Next(1, 3); // random number between 1-2
            if (randomNum == 1)
            {
                return eGameState.Player1;
            }
            else
            {
                return eGameState.Player2;
            }

        }
        public void ResetBoardData()
        {
            int numberOfRows = m_BoardMatrix.GetLength(0);
            int numberOfColumns = m_BoardMatrix.GetLength(1);
            m_BoardMatrix = new char?[numberOfRows, numberOfColumns];
            m_GameState = GetRandomPlayerStartTheGame();
            if(m_Opponent == eGameState.Computer)
            {
                m_GameState = eGameState.Player1;
            }
            else if(m_Opponent == eGameState.Player2)
            {
                m_GameState = GetRandomPlayerStartTheGame();
            }
            
        }
        public int GetRandomValidColumnNumberWithFreeCell()
        {
            int numOfColumns = m_BoardMatrix.GetLength(0);
            bool v_IsValidColumnNumber = true;
            Random random = new Random();
            int randomColumn = -1;
            while (!v_IsValidColumnNumber != true)
            { 
                randomColumn = random.Next(1, numOfColumns + 1);
                v_IsValidColumnNumber = CheckIfValidMove(randomColumn);
                if(v_IsValidColumnNumber == true)
                {
                    v_IsValidColumnNumber = false;
                    break;

                }
                else
                {
                    v_IsValidColumnNumber = true;
                }
            }
            return randomColumn;
        }
        public void PlayerRetireFromGame(eGameState i_Player)
        {
            if (i_Player == eGameState.Player1)
            {
                    m_Player2OrComputerScoreCount += 1;
                    m_GameState = m_Opponent;// player 2 or computer
                    

            }
            else if (i_Player == eGameState.Player2 || i_Player == eGameState.Computer)
            {
                m_GameState = eGameState.Player1;
                m_Player1ScoreCount += 1;
            }
            m_GameIsOn = false;
        }
        public void TieUpdateScores()
        {
            m_Player1ScoreCount += 1;
            m_Player2OrComputerScoreCount += 1;
            m_GameIsOn = false;
        }
        protected virtual void OnPlayerWon()
        {
            if(PlayerWon != null)
            {
                PlayerWon.Invoke(this, EventArgs.Empty);
            }
        }
        protected virtual void OnTie()
        {
            if (Tie != null)
            {
                Tie.Invoke(this, EventArgs.Empty);
            }
        }
        public bool BoardIsEmpty
        {
            get
            {
                int counter = 0;
                foreach(char? matrixCell in m_BoardMatrix)
                {
                    if(matrixCell != null )
                    {
                        counter += 1;
                    }
                }

                return counter == 0 ? true : false;
            }
        }
    }
}
