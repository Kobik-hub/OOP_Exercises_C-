using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_four
{
    class ConsoleManger
    {
        public static void PrintBoard(char?[,] i_BoardMatrix)
        {
            StringBuilder sbDividerLine = new StringBuilder();
            StringBuilder sbNumberOfColumnsTitle = new StringBuilder();
            for (int column = 0; column < i_BoardMatrix.GetLength(1); column++)
            {
                sbNumberOfColumnsTitle.AppendFormat("  {0}  ", column + 1);
            }
            for (int column = 0; column < i_BoardMatrix.GetLength(1); column++)
            {
                sbDividerLine.Append("=====");
            }
            Console.WriteLine(sbNumberOfColumnsTitle.ToString());
            Console.WriteLine(Environment.NewLine);
            for (int row = 0; row < i_BoardMatrix.GetLength(0); row++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("|");
                for (int column = 0; column < i_BoardMatrix.GetLength(1); column++)
                {
                    if (i_BoardMatrix[row, column] == 'X' || i_BoardMatrix[row, column] == 'O')
                    {
                        sb.AppendFormat(" {0}  |", i_BoardMatrix[row, column].ToString());
                    }
                    else
                    {
                        sb.AppendFormat("    |", i_BoardMatrix[row, column].ToString());
                    }
                }
                Console.WriteLine(sb.ToString());
                Console.WriteLine(sbDividerLine.ToString());

            }
        }
        public static void ClearScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }
        public static void ChooseNumberOfRowsMsg()
        {
            Console.WriteLine("Enter number of row between 4 - 8");
        }
        public static void ChooseNumberOfRowsMsgError()
        {
            Console.WriteLine("Your input is invalid, number of rows must be between 4-8");
        }
        public static void ChooseNumberOfColumnsMsg()
        {
            Console.WriteLine("Enter number of columns between 4 - 8");
        }
        public static void ChooseNumberOfColumnsMsgError()
        {
            Console.WriteLine("Your input is invalid, number of columns must be between 4-8");
        }
        public static void WelcomeMsg()
        {
            Console.WriteLine("Welcome to  4 In A Line game!");
            
        }
        public static void PlayerTurnMsg(eGameState i_State)
        {
            string msg;
            switch(i_State)
            {
                case eGameState.Player1:
                    msg = "Player 1 turn";
                    break;
                case eGameState.Player2:
                    msg = "Player 2 turn";
                    break;
                case eGameState.Computer:
                    msg = "Computer turn";
                    break;
                default:
                    msg = "";
                    break;
            }
            Console.WriteLine(msg);
        }
        public static void ChooseYourMoveMsg(int i_NumberOfColumns)
        {
            string msg = String.Format("Enter a number in rage 1 - {0}", i_NumberOfColumns);
            Console.WriteLine(msg);
        }
        public static void ChooseYourMoveMsgError(int i_NumberOfColumns)
        {
            string msg = String.Format("Invalid input, Enter a number in rage 1 - {0}", i_NumberOfColumns);
            Console.WriteLine(msg);
        }
        public static void WinnerMsg(eGameState i_WinnerPlayer)
        {
            string msg;
            switch (i_WinnerPlayer)
            {
                case eGameState.Player1:
                    msg = string.Format("Player 1 win");
                    break;
                case eGameState.Player2:
                    msg = string.Format("Player 2 win");
                    break;
                case eGameState.Computer:
                    msg = string.Format("Computer win");
                    break;
                default:
                    msg = "";
                    break;
            }
            Console.WriteLine(msg);
        }
        public static void ScoreResults(int i_Player1Score, int i_Player2Score, eGameState i_Opponent)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Scores:{0}=================={0}", Environment.NewLine);
            sb.AppendFormat("Player1: {1}{0}", Environment.NewLine,i_Player1Score);
            if(i_Opponent == eGameState.Player2)
            {
                sb.AppendFormat("Player2: {1}{0}", Environment.NewLine, i_Player2Score);
            }
            else if(i_Opponent == eGameState.Computer)
            {
                sb.AppendFormat("Computer: {1}{0}", Environment.NewLine, i_Player2Score);
            }
            Console.WriteLine(sb.ToString());
        }
        public static void ChooseOpponent()
        {
            string msg = string.Format("Choose your opponent:{0}enter 1 for playing against other player{0}enter 2 for playing against your computer",Environment.NewLine);
            Console.WriteLine(msg);
        }
        public static void ChooseOpponentEror()
        {
            string msg = string.Format("Invalid Input{0}Choose your opponent:{0}enter 1 for playing against other player{0}enter 2 for playing against your computer", Environment.NewLine);
            ConsoleManger.ClearScreen();
            Console.WriteLine(msg);
        }
        public static void PlayAgain()
        {
            Console.WriteLine("Are you want to play again? y for yes and q for quit the game");
        }
        public static void DrawMsg()
        {
            Console.WriteLine("Its a draw!");
        }
    }
}
