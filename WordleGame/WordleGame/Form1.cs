namespace WordleGame
{
    public partial class Form1 : Form
    {
        TextBox[,] t = new TextBox[5, 5];
        Label[,] A = new Label[5, 5];
        int currentRow = 0;
        int currentColumn = 0;
        string word = "TABLE";



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)


        {


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    t[i, j] = new TextBox();
                    t[i, j].Width = 50;
                    t[i, j].Height = 50;
                    t[i, j].Location = new Point((j * 60) + 30, (i * 60) + 40);
                    t[i, j].MaxLength = 1;
                    t[i, j].KeyUp += new KeyEventHandler(KeyUpEvent);
                    t[i, j].ForeColor = Color.Black;
                    Controls.Add(t[i, j]);
                }

            }
            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    t[i, j].Enabled = false;
                }
            }
        }
        public void KeyUpEvent(object sender, KeyEventArgs e)
        {
            string c = t[currentRow, currentColumn].Text;
            if (c.Length == 1)
            {
                t[currentRow, currentColumn].Text = c.ToUpper();
            }
            if (currentColumn < 4 && c.Length == 1)
            {
                currentColumn++;
                t[currentRow, currentColumn].Focus();
            }
            else if (currentColumn == 4 && c.Length == 1)
            {
                checkWord();
            }
            if(e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                
                if (currentColumn > 0)
                    currentColumn--;
                t[currentRow, currentColumn].Focus();
                t[currentRow, currentColumn].Text = "";
            }
        }
        public void checkWord()
        {
            string input = "";
            string all = "";
            for (int i = 0; i < 5; i++)
            {
                //   input = t[currentRow, i].Text;
                all = all + t[currentRow, i].Text;
            }
            Status.Text = all;
            for (int i = 0; i < 5; i++)
            {
                if (word[i] == all[i])
                t[currentRow, i].BackColor = Color.Green;
                
                else if (word.Contains(all[i]))   
                t[currentRow, i].BackColor = Color.Yellow;
                   
            }
            if (word.Equals(all))
            {
                Status.Text = "You Win !!";
                Status.BackColor = Color.Green;
                return;
            }
            if (currentRow ==4)
            {
                Status.Text = "You Loose !!";
                Status.BackColor = Color.Red;
                return;
            }
            currentRow++;
            for (int i= 0;i< 5; i++)
            {
                t[currentRow, i].Enabled = true;
            }
            t[currentRow, 0].Focus();
            currentColumn = 0;
            Status.Text = "Next Try :(";
            Status.BackColor = Color.Yellow;
        }
    }
}
