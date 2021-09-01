using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Ex05.ConnectFourWinApp
{
    public class FormGameSettings : Form
    {
        private Label label2;
        private TextBox m_TextBoxPlayer1Name;
        private TextBox m_TextBoxPlayer2Name;
        private CheckBox m_CheckBoxPlayer2;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown m_UpDownNumberOfRows;
        private NumericUpDown m_UpDownNumberOfCols;
        private Button m_ButtonStart;
        private Label label1;
        public FormGameSettings()
        {
            InitializeComponent();
        }
        public string Player1Name
        {
            get { return m_TextBoxPlayer1Name.Text; }
            set { m_TextBoxPlayer1Name.Text = value; }
        }
        public string Player2Name
        {
            get { return m_TextBoxPlayer2Name.Text; }
            set { m_TextBoxPlayer2Name.Text = value; }
        }
        public int NumberOfRows
        {
            get { return decimal.ToInt32(m_UpDownNumberOfRows.Value); }
        }
        public int NumberOfCols
        {
            get { return decimal.ToInt32(m_UpDownNumberOfCols.Value); }
        }
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_TextBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.m_TextBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.m_CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_UpDownNumberOfRows = new System.Windows.Forms.NumericUpDown();
            this.m_UpDownNumberOfCols = new System.Windows.Forms.NumericUpDown();
            this.m_ButtonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_UpDownNumberOfRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_UpDownNumberOfCols)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Players:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player 1:";
            // 
            // m_TextBoxPlayer1Name
            // 
            this.m_TextBoxPlayer1Name.Location = new System.Drawing.Point(134, 39);
            this.m_TextBoxPlayer1Name.Name = "m_TextBoxPlayer1Name";
            this.m_TextBoxPlayer1Name.Size = new System.Drawing.Size(100, 23);
            this.m_TextBoxPlayer1Name.TabIndex = 3;
            // 
            // m_TextBoxPlayer2Name
            // 
            this.m_TextBoxPlayer2Name.Enabled = false;
            this.m_TextBoxPlayer2Name.Location = new System.Drawing.Point(134, 71);
            this.m_TextBoxPlayer2Name.Name = "m_TextBoxPlayer2Name";
            this.m_TextBoxPlayer2Name.Size = new System.Drawing.Size(100, 23);
            this.m_TextBoxPlayer2Name.TabIndex = 4;
            this.m_TextBoxPlayer2Name.Text = "[Computer]";
            // 
            // m_CheckBoxPlayer2
            // 
            this.m_CheckBoxPlayer2.AutoSize = true;
            this.m_CheckBoxPlayer2.Location = new System.Drawing.Point(33, 73);
            this.m_CheckBoxPlayer2.Name = "m_CheckBoxPlayer2";
            this.m_CheckBoxPlayer2.Size = new System.Drawing.Size(83, 21);
            this.m_CheckBoxPlayer2.TabIndex = 5;
            this.m_CheckBoxPlayer2.Text = "Player 2:";
            this.m_CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.m_CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Board Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rows:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cols:";
            // 
            // m_UpDownNumberOfRows
            // 
            this.m_UpDownNumberOfRows.Location = new System.Drawing.Point(76, 151);
            this.m_UpDownNumberOfRows.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_UpDownNumberOfRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_UpDownNumberOfRows.Name = "m_UpDownNumberOfRows";
            this.m_UpDownNumberOfRows.Size = new System.Drawing.Size(40, 23);
            this.m_UpDownNumberOfRows.TabIndex = 9;
            this.m_UpDownNumberOfRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // m_UpDownNumberOfCols
            // 
            this.m_UpDownNumberOfCols.Location = new System.Drawing.Point(193, 151);
            this.m_UpDownNumberOfCols.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_UpDownNumberOfCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_UpDownNumberOfCols.Name = "m_UpDownNumberOfCols";
            this.m_UpDownNumberOfCols.Size = new System.Drawing.Size(40, 23);
            this.m_UpDownNumberOfCols.TabIndex = 10;
            this.m_UpDownNumberOfCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // m_ButtonStart
            // 
            this.m_ButtonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ButtonStart.Location = new System.Drawing.Point(15, 194);
            this.m_ButtonStart.Name = "m_ButtonStart";
            this.m_ButtonStart.Size = new System.Drawing.Size(243, 33);
            this.m_ButtonStart.TabIndex = 11;
            this.m_ButtonStart.Text = "Start!";
            this.m_ButtonStart.UseVisualStyleBackColor = true;
            this.m_ButtonStart.Click += new System.EventHandler(this.m_ButtonStart_Click);
            // 
            // FormGameSettings
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.m_ButtonStart);
            this.Controls.Add(this.m_UpDownNumberOfCols);
            this.Controls.Add(this.m_UpDownNumberOfRows);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_CheckBoxPlayer2);
            this.Controls.Add(this.m_TextBoxPlayer2Name);
            this.Controls.Add(this.m_TextBoxPlayer1Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormGameSettings";
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.FormGameSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_UpDownNumberOfRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_UpDownNumberOfCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void FormGameSettings_Load(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            switch (m_CheckBoxPlayer2.Checked)
            {
                case true:
                    m_TextBoxPlayer2Name.Text = string.Empty;
                    break;
                case false:
                    m_TextBoxPlayer2Name.Text = "[Computer]";
                    break;
                default:
                    break;
            }
            m_TextBoxPlayer2Name.Enabled = m_CheckBoxPlayer2.Checked;
        }
        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
