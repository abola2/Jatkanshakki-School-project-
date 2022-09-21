using Jatkanshakki.GameLogic;
using Jatkanshakki.DataSaving;


namespace Jatkanshakki
{
    public partial class Ui : Form
    {
        public Ui()
        {
            InitializeComponent();

        }

        private void StartScreen(object sender, EventArgs e)
        {
            this.BackgroundImage = new Bitmap(Properties.Resources.Tic_tac_toe_svg);
            this.ClientSize = new Size(1200, 900);

            for (int i = 0; i < 4; i++)
            {
                int nWidth = Width / 3;
                int nHeight = Height / 4;
                Button buttonStart = new Button();
                buttonStart.FlatStyle = FlatStyle.Flat;
                buttonStart.Font = new Font("Cooper Black", 32);
                buttonStart.BackColor = Color.FloralWhite;

                buttonStart.Size = new Size(nWidth, nHeight / 2);
                this.Controls.Add(buttonStart);
                buttonStart.Click += StartGame;
                if (i == 0)
                {

                    buttonStart.Location = new Point(nWidth, nHeight - 30);
                    buttonStart.Text = "Lyhyt";
                }
                else if (i == 1)
                {
                    buttonStart.Location = new Point(nWidth, nHeight + 100);
                    buttonStart.Text = "Normaali";
                }
                else if (i == 2)
                {
                    buttonStart.Location = new Point(nWidth, nHeight + 230);
                    buttonStart.Text = "Pitkä";
                }
                else if (i == 3)
                {
                    buttonStart.Location = new Point(nWidth, nHeight + 360);
                    buttonStart.Text = "Sulje";
                }

            }

        }


        private void StartGame(object sender, EventArgs e)
        {

            Button? button = sender as Button;
            int boardSize = 31;
            if (button.Text == "Sulje")
            {
                CloseGame(e, e);
            }


            else if (button.Text == "Lyhyt") boardSize = 5;
            else if (button.Text == "Normaali") boardSize = 21;
            else if (button.Text == "Pitkä") boardSize = 41;
            if (button.Text != "Sulje")
            {


                {
                    foreach (Control item in this.Controls.OfType<Button>().ToList())
                    {
                        Controls.Remove(item);
                    }
                }

                BoardCreateUserSelectedSize(boardSize);

            }

        }


        private void CloseGame(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Haluatko sulkea pelin?", "Jatkansakki", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }

        public void StartOver(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Haluatko varmasti palata pelivalikkoon?", "Jatkansakki", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Restart();
                Environment.Exit(0);
            }

        }


        Gamebutton[,] _buttons = new Gamebutton[100, 100];


        private void BoardCreateUserSelectedSize(int boardSize)
        {
            this.ClientSize = new Size(1200, 900);
            int nX = Width / boardSize;
            int nY = boardSize;
            int nWidth = Width / boardSize;
            int nHeight = Height / boardSize;
            //Some code
            UserTurn ut = new(this);
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    _buttons[x, y] = new Gamebutton();
                    _buttons[x, y].FlatStyle = FlatStyle.Flat;
                    _buttons[x, y].Location = new Point(nX, nY);
                    _buttons[x, y].BackColor = Color.White;
                    _buttons[x, y].Size = new Size(nWidth, nHeight);
                    _buttons[x, y].Location = new Point(x * nWidth, y * nHeight);
                    _buttons[x, y].X = x;
                    _buttons[x, y].Y = y;
                    _buttons[x, y].Click += ut.Tic_Tac_Toe_Button_click;
                    Controls.Add(_buttons[x, y]);
                }

            }
            CenterToScreen();
        }

        public Button[,] GetButtons()
        {
            return _buttons;

        }


        private void ResetPlayersScores(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Haluatko varmasti nollata pisteet? TÄTÄ EI VOI PERUA!", "Jatkansakki", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SaveDataJson saveDataJson = new SaveDataJson();
                saveDataJson.ResetPlayersDataFromJsonFile();
                ScoresResetedMessage();

            }
        }


        private void ScoresResetedMessage()
        {
            var w = new Form() { Size = new Size(0, 0) };
            Task.Delay(TimeSpan.FromSeconds(3))
            .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());
            MessageBox.Show(w, "Nollasit pisteet!", "Jatkanshakki");
        }

        private void ScoreUpdate(object sender, EventArgs e)
        {
            SaveDataJson savedDataJson = new SaveDataJson();

            savedDataJson.ScoreJson(sender, e);
        }


        private async void ScoreClickToolStripMenuNow_MouseHover(object sender, EventArgs e)
        {


            if (!File.Exists("Data.json"))
            {
                SaveDataJson saveDataJson = new SaveDataJson();
                await saveDataJson.ResetPlayersDataFromJsonFile();
            }
            ScoreUpdate(sender, e);
        }
    }

}




