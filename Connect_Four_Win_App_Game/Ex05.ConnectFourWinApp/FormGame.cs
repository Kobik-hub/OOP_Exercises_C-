using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace ConnectFourWinApp
{
    class FormGame: Form
    {
        private readonly FormGameSettings r_FormGameSetting = new FormGameSettings();
        private Button[,] m_ButtonsCells;
        private List<Button> m_ButtonsPlayerOptions;
        private Label m_LabelPlayer1NameAndScore;
        private Label m_LabelPlayer2OrComputerNameAndScore;
        private BoardManger m_BoardManger;
        public FormGame()
        {
            InitializeComponent();
            this.r_FormGameSetting.FormClosed += new FormClosedEventHandler(button_CloseForm_Click);
            r_FormGameSetting.ShowDialog();
        }
        private void button_CloseForm_Click(object sender, FormClosedEventArgs e)
        {
            if(r_FormGameSetting.DialogResult == DialogResult.OK)
            {
                GameInitialization();
            }
            else
            {
                Application.Exit();
            }
        }
        private void InitializeComponent()
        {
            this.m_LabelPlayer1NameAndScore = new System.Windows.Forms.Label();
            this.m_LabelPlayer2OrComputerNameAndScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_LabelPlayer1NameAndScore
            // 
            this.m_LabelPlayer1NameAndScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_LabelPlayer1NameAndScore.AutoSize = true;
            this.m_LabelPlayer1NameAndScore.Location = new System.Drawing.Point(51, 239);
            this.m_LabelPlayer1NameAndScore.Name = "m_LabelPlayer1NameAndScore";
            this.m_LabelPlayer1NameAndScore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_LabelPlayer1NameAndScore.Size = new System.Drawing.Size(0, 13);
            this.m_LabelPlayer1NameAndScore.TabIndex = 0;
            // 
            // m_LabelPlayer2OrComputerNameAndScore
            // 
            this.m_LabelPlayer2OrComputerNameAndScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_LabelPlayer2OrComputerNameAndScore.AutoSize = true;
            this.m_LabelPlayer2OrComputerNameAndScore.Location = new System.Drawing.Point(183, 239);
            this.m_LabelPlayer2OrComputerNameAndScore.Name = "m_LabelPlayer2OrComputerNameAndScore";
            this.m_LabelPlayer2OrComputerNameAndScore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_LabelPlayer2OrComputerNameAndScore.Size = new System.Drawing.Size(0, 13);
            this.m_LabelPlayer2OrComputerNameAndScore.TabIndex = 1;
            // 
            // FormGame
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.m_LabelPlayer2OrComputerNameAndScore);
            this.Controls.Add(this.m_LabelPlayer1NameAndScore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        public void GameInitialization()
        {
            createOptionButtonsRow();
            createGameCells();
            boardMangerSetup();
            setPlayersName();
            setLabelsNameAndScore();
        }
        private void setPlayersName()
        {
            r_FormGameSetting.Player1Name = r_FormGameSetting.Player1Name.Length == 0 ? "Player 1" : r_FormGameSetting.Player1Name;
            string player2NameOrComputer;
            if (r_FormGameSetting.Player2Name == "[Computer]")
            {
                player2NameOrComputer = "Computer";
            }
            else if (r_FormGameSetting.Player2Name.Length == 0)
            {
                player2NameOrComputer = "Player 2";
            }
            else
            {
                player2NameOrComputer = r_FormGameSetting.Player2Name;
            }
            r_FormGameSetting.Player2Name = player2NameOrComputer;
        }
        private void setLabelsNameAndScore()
        {
            int player1Score = m_BoardManger.Player1ScoreCount;
            int player2OrComputerScore = m_BoardManger.Player2OrComputerScoreCount;
            m_LabelPlayer1NameAndScore.Text = string.Format("{0}: {1}", r_FormGameSetting.Player1Name, player1Score);
            m_LabelPlayer2OrComputerNameAndScore.Text = string.Format("{0}: {1}", r_FormGameSetting.Player2Name, player2OrComputerScore);
        }
        private void boardMangerSetup()
        {
            int numberOfRows = r_FormGameSetting.NumberOfRows;
            int numberOfCol = r_FormGameSetting.NumberOfCols;
            eGameState opponent = r_FormGameSetting.Player2Name == "[Computer]" ? eGameState.Computer : eGameState.Player2;
            m_BoardManger = new BoardManger(numberOfRows, numberOfCol, opponent);
            if (opponent == eGameState.Computer)
            {
                m_BoardManger.GameState = eGameState.Player1;
            }
            else
            {
                m_BoardManger.GameState = m_BoardManger.GetRandomPlayerStartTheGame();
            }
            m_BoardManger.GameIsOn = true;
            m_BoardManger.PlayerWon += BoardManger_OnPlayerWon; 
            m_BoardManger.Tie += BoardManger_OnTie;
        }
        private void BoardManger_OnTie(object i_Sender, EventArgs i_E)
        {

            setLabelsNameAndScore();
            DialogResult dialogResultPlayAgain = showMessageBoxTie();
            if (dialogResultPlayAgain == DialogResult.Yes)
            {
                m_BoardManger.ResetBoardData();
                resetGameCells();
                m_BoardManger.GameIsOn = true;
                makeAllOptionsColEnabled();
            }
            else
            {
                this.Close();
            }
        }
        private void BoardManger_OnPlayerWon(object i_Sender, EventArgs i_E)
        {
            setLabelsNameAndScore();
            DialogResult dialogResultPlayAgain= showMessageBoxAWin();
            if(dialogResultPlayAgain == DialogResult.Yes)
            {
                m_BoardManger.ResetBoardData();
                resetGameCells();
                m_BoardManger.GameIsOn = true;
                makeAllOptionsColEnabled();
            }
            else
            {
                this.Close();
            }
        }
        private void resetGameCells()
        {
            foreach(Button btn in m_ButtonsCells)
            {
                btn.Text = string.Empty;
            }
        }
        private DialogResult showMessageBoxAWin()
        {
            eGameState eWinner = m_BoardManger.GameState;
            string winnerName;
            if(eWinner == eGameState.Player1)
            {
                winnerName = r_FormGameSetting.Player1Name;
            }
            else
            {
                winnerName = r_FormGameSetting.Player2Name;
            }
            string msg = string.Format("{0} Won!!{1}Another Round?", winnerName, Environment.NewLine);
            string caption = "A win";
            return MessageBox.Show(msg, caption, MessageBoxButtons.YesNo);
        }
        private DialogResult showMessageBoxTie()
        {
          
            string msg = string.Format("Tie!{0}Another Round?",Environment.NewLine);
            string caption = "A Tie";
            return MessageBox.Show(msg, caption, MessageBoxButtons.YesNo);
        }
        private void createGameCells()
        {
            int numberOfRows = this.r_FormGameSetting.NumberOfRows;
            int numberOfCols = this.r_FormGameSetting.NumberOfCols;
            m_ButtonsCells = new Button[numberOfRows, numberOfCols];
            int startYPosition = this.m_ButtonsPlayerOptions.LastOrDefault().Bottom + 10;
            for(int i=0; i< numberOfRows; i++)
            {
                int LastBtnRightPostion = 10;
                for (int j=0; j < numberOfCols; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(50, 50);
                    if(j == 0)
                    {
                        btn.Left = 10;
                        LastBtnRightPostion = btn.Right;
                    }
                    else
                    {
                        btn.Left = LastBtnRightPostion + 10 ;
                        LastBtnRightPostion = btn.Right;
                    }
                    btn.Top = startYPosition * (i+1) + 10 * i;
                    btn.Text = string.Empty;
                    m_ButtonsCells[i, j] = btn;
                    this.Controls.Add(btn);
                }
            }
        }
        private void createOptionButtonsRow()
        {
            int formWidth = (this.r_FormGameSetting.NumberOfCols) * 65;
            int formHight = (this.r_FormGameSetting.NumberOfRows +1 ) * 65 + 30;
            this.Size = new System.Drawing.Size(formWidth, formHight);
            m_ButtonsPlayerOptions = new List<Button>();
            for (int i = 0; i < r_FormGameSetting.NumberOfCols; i++)
            {
                Button btn = new Button();
                btn.Text = (i + 1).ToString();
                btn.Size = new Size(50, 30);
                if (m_ButtonsPlayerOptions.Count == 0)
                {
                    btn.Left = 10;
                }
                else
                {
                    int LastBtnRightPostion = m_ButtonsPlayerOptions.LastOrDefault().Right;
                    btn.Left = LastBtnRightPostion + 10;
                }
                btn.Top = 10;
                btn.Click += btnRowMoveOption_Clicked; 
                m_ButtonsPlayerOptions.Add(btn);
            }
            foreach (Button btn in m_ButtonsPlayerOptions)
            {
                this.Controls.Add(btn);
            }
        }
        private void btnRowMoveOption_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int colNumberChoice = int.Parse(btn.Text);
            fillCellInFormGame(colNumberChoice);
            m_BoardManger.FillCellWithValidMoveAndIfWinGameIsOff(colNumberChoice);
            if (m_BoardManger.BoardIsEmpty == true)
            {
                setLabelsNameAndScore();
            }
            else
            {
                m_BoardManger.ChangeTurn(); 
                if(m_BoardManger.GameState == eGameState.Computer)
                {
                    int move = m_BoardManger.GetRandomValidColumnNumberWithFreeCell();
                    fillCellInFormGame(move);
                    m_BoardManger.FillCellWithValidMoveAndIfWinGameIsOff(move);
                    if (m_BoardManger.BoardIsEmpty == true)
                    {
                        setLabelsNameAndScore();
                    }
                    else
                    {
                        m_BoardManger.ChangeTurn();
                    }
                }
            }
        }
        private void fillCellInFormGame(int i_ColNumberChoice)
        {
            eGameState eTurn = m_BoardManger.GameState;
            int numberOfRows = r_FormGameSetting.NumberOfRows;
            for (int i= numberOfRows - 1; i >= 0; i--)
            {
                if(m_ButtonsCells[i,i_ColNumberChoice-1].Text == string.Empty)
                {
                    string moveSign = (eTurn == eGameState.Player1) ? "X" : "0";
                    m_ButtonsCells[i, i_ColNumberChoice-1].Text = moveSign;
                    break;
                }
            }
            if(m_ButtonsCells[0, i_ColNumberChoice-1].Text != string.Empty)
            {
                m_ButtonsPlayerOptions[i_ColNumberChoice-1].Enabled = false;
            }
        }
        private void makeAllOptionsColEnabled()
        {
            foreach(Button btn in m_ButtonsPlayerOptions)
            {
                btn.Enabled = true;
            }
        }
    }
}
