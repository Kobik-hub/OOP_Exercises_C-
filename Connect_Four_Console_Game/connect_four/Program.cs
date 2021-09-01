using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_four
{
    class Program
    {
        public static void Delay()  
        {
            DateTime end = DateTime.Now.AddSeconds(1);

            while (DateTime.Now <= end)
            {
                
            }
        } // 1 second delay to imitate 
        public static int GetNumberOfRowsOrColumnsFromUser(string i_Type)
        {
            switch(i_Type)
            {
                case "rows":
                    ConsoleManger.ChooseNumberOfRowsMsg();
                    break;
                case "columns":
                    ConsoleManger.ChooseNumberOfColumnsMsg();
                    break;
                default:
                    break;
            }
            bool v_IsValid = true;
            int number= -1;//Default value for out variable.
            while (!v_IsValid != true)
            {
                bool v_IsNumber = int.TryParse(Console.ReadLine(), out number);
                if(v_IsNumber == true)
                {
                    if(number >= 4 && number <= 8)
                    {

                        return number;
                    }
                    else
                    {
                        switch (i_Type)
                        {
                            case "rows":
                                ConsoleManger.ChooseNumberOfRowsMsgError();
                                break;
                            case "columns":
                                ConsoleManger.ChooseNumberOfColumnsMsgError();
                                break;
                            default:
                                break;
                        }

                        v_IsValid = true;
                    }

                }
                if (v_IsNumber == false)
                {
                    switch(i_Type)
                    {
                        case "rows":
                            ConsoleManger.ChooseNumberOfRowsMsgError();
                            break;
                        case "columns":
                            ConsoleManger.ChooseNumberOfColumnsMsgError();
                            break;
                        default:
                            break;
                    }
                }
            }

            return number;
        }
        public static eGameState GetOpponent()
        {
            
            bool v_IsValidInput = true;
            int opponentCode = -1;
            ConsoleManger.ChooseOpponent();
            while (!v_IsValidInput != true)
            {
                
                bool v_IsNumber = int.TryParse(Console.ReadLine(), out opponentCode);
                if(v_IsNumber == true)
                {
                    if(opponentCode == 1 || opponentCode == 2)
                    {
                        break;
                    }
                    else
                    {
                        ConsoleManger.ChooseOpponentEror();
                    }
                }
                else
                {
                    ConsoleManger.ChooseOpponentEror();
                }
            }
            return opponentCode == 1 ? eGameState.Player2 : eGameState.Computer;
        }
        public static bool PlayAgain()
        {
            // q for quit or y for play again
            while(true)
            {
                ConsoleManger.PlayAgain();
                string input = Console.ReadLine();
                if(input == "q")
                {
                    return false;
                }
                else if(input == "y")
                {
                    return true;
                }
                else
                {
                    ConsoleManger.ClearScreen();
                }
            }
        }
        public static BoardManger GameInitialization()
        {
            ConsoleManger.WelcomeMsg();
            int boardNumOfRows = GetNumberOfRowsOrColumnsFromUser("rows");
            int boardNumOfColumns = GetNumberOfRowsOrColumnsFromUser("columns");
            eGameState opponent = GetOpponent();
            BoardManger boardManger = new BoardManger(boardNumOfRows, boardNumOfColumns, opponent);
            if (opponent == eGameState.Computer)
            {
                boardManger.GameState = eGameState.Player1;
            }
            else
            {
                boardManger.GameState = boardManger.GetRandomPlayerStartTheGame();
            }
            return boardManger;
        }
        public static void Run()
        {
            BoardManger boardManger = GameInitialization();
            int numOfColumns = boardManger.Board.GetLength(1);
            ConsoleManger.ClearScreen();
            ConsoleManger.PrintBoard(boardManger.Board);
            boardManger.GameIsOn = true;
            while (true)
            {
                if(boardManger.GameIsOn == false )
                {
                    bool playAgain = PlayAgain();
                    if(playAgain == false)
                    {
                        break;
                    }
                    else
                    {
                        boardManger.ResetBoardData();
                        boardManger.GameIsOn = true;
                        ConsoleManger.ClearScreen();
                        ConsoleManger.PrintBoard(boardManger.Board);
                    }
                }
                else if(boardManger.GameIsOn == true)
                {
                    int move  = -1;
                    if(boardManger.BoardIsFull() == true)
                    {

                        boardManger.Draw();
                        ConsoleManger.DrawMsg();
                        ConsoleManger.ScoreResults(
                            boardManger.Player1ScoreCount,
                            boardManger.Player2OrComputerScoreCount,
                            boardManger.Opponent
                            );
                        continue;

                    }
                    switch (boardManger.GameState)
                    {
                        case eGameState.Computer:
                            ConsoleManger.PlayerTurnMsg(boardManger.GameState);
                            Delay();
                            move = boardManger.GetRandomValidColumnNumberWithFreeCell();
                            boardManger.FillCellWithValidMoveAndIfWinGameIsOff(move);
                            break;
                        case eGameState.Player1:
                        case eGameState.Player2:
                            bool isValidColumnInput = false;
                            int numberOfColumnsThatAllowed = boardManger.Board.GetLength(1);
                            while (isValidColumnInput != true)
                            {
                                ConsoleManger.PlayerTurnMsg(boardManger.GameState);
                                string userInput = Console.ReadLine();
                                bool isNumber = int.TryParse(userInput, out move);
                                if (isNumber == true)
                                {
                                    isValidColumnInput = boardManger.CheckIfValidMove(move);
                                    if(isValidColumnInput == true)
                                    {
                                        boardManger.FillCellWithValidMoveAndIfWinGameIsOff(move);
                                        ConsoleManger.PrintBoard(boardManger.Board);
                                    }
                                    else
                                    {
                                       ConsoleManger.ClearScreen();
                                       ConsoleManger.PlayerTurnMsg(boardManger.GameState);
                                        ConsoleManger.PrintBoard(boardManger.Board);
                                        ConsoleManger.ChooseYourMoveMsgError(numberOfColumnsThatAllowed);
                                    }

                                }
                                else if( userInput == "q")
                                {
                                    
                                    boardManger.PlayerRetireFromGame(boardManger.GameState);
                                    break;
                                }
                                else
                                {
                                    ConsoleManger.ClearScreen();
                                    ConsoleManger.PrintBoard(boardManger.Board);
                                    ConsoleManger.ChooseYourMoveMsgError(numberOfColumnsThatAllowed);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    if (boardManger.GameIsOn == false)
                    {
                        ConsoleManger.ClearScreen();
                        ConsoleManger.PrintBoard(boardManger.Board);
                        ConsoleManger.WinnerMsg(boardManger.GameState);
                        ConsoleManger.ScoreResults(
                            boardManger.Player1ScoreCount,
                            boardManger.Player2OrComputerScoreCount,
                            boardManger.Opponent
                            );
                    }
                    else
                    {
                        boardManger.ChangeTurn();
                        ConsoleManger.ClearScreen();
                        ConsoleManger.PrintBoard(boardManger.Board);
                    }
                }
            }
        }
        static void Main()
        {
            Run();
        }
    }
}
