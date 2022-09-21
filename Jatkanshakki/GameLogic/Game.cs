using Jatkanshakki.DataSaving;

namespace Jatkanshakki.GameLogic
{


    public class Game
    {
        Ui _ui;


        private static List<Point> bluelist = new List<Point>();
        public List<Point> blueList
        {
            get { return bluelist; }
        }

        private static List<Point> RedList = new List<Point>();
        public List<Point> redList

        {
            get { return RedList; }
        }

        private List<Point> checkIfUserWonList = new List<Point>();


        public Game(Ui ui)
        {
            _ui = ui;
        }

        public Game()
        {

        }


        public void SendUserClickedSpotsToCheckWinMethod(Point checkUserClickedSpot)
        {

            if (redList.Count == blueList.Count)
            {
                checkIfUserWonList = bluelist;
            }
            else
            {
                checkIfUserWonList = RedList;
            }
            //Turha kuluttaa resursseja tarkistukseen jos voitto ei ole vielä mahdollista
            if (checkIfUserWonList.Count > 4)
            {
                CheckWinner(checkUserClickedSpot);
                CheckIfGameboardIsFull();
            }

        }

        private void CheckIfGameboardIsFull()
        {
            int i = 0;
            var buttons = _ui.GetButtons();
            foreach (Button item in buttons.OfType<Button>())
            {
                if (item.BackColor == Color.White)
                {
                    i++;
                }
            }
            if (i == 0)
            {
                ResetGameIfGameIsDraw();
            }
        }

        private void ResetGameIfGameIsDraw()
        {
            var newForm = new Form() { Size = new Size(0, 0) };
            Task.Delay(TimeSpan.FromSeconds(3))
                .ContinueWith((t) => newForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());

            MessageBox.Show(newForm, "Tasapeli", "Jatkanshakki");

            Application.Restart();
            Environment.Exit(0);
        }



        private void CheckWinner(Point userClickedSpot)
        {

            int x = userClickedSpot.X;
            int y = userClickedSpot.Y;
            Point checkUserClickedSpot = new Point(userClickedSpot.X, userClickedSpot.Y);
            int yY = 0;
            int xX = 0;

            int checkDirectionsAmount = 5; //tarkistettavia suuntia on yhteensä 4
            int wonLineMinimiunLenght = 5;
            //Katsotaan kaikki suunnat. Suuntia on yhteensä 4.
            for (int i = 1; i < checkDirectionsAmount; i++)
            {

                int countUserClickedSpotsLenght = 0;
                checkUserClickedSpot = userClickedSpot;

                ResetCheckValues(i, ref xX, ref yY);

                ResetXAndY(x, y, userClickedSpot);

                FirstCheck(x, y, xX, yY, ref countUserClickedSpotsLenght, checkUserClickedSpot);

                checkUserClickedSpot = userClickedSpot;
                ResetXAndY(x, y, userClickedSpot);

                ResetCheckValues(i, ref xX, ref yY);

                SecondCheck(x, y, xX, yY, ref countUserClickedSpotsLenght, checkUserClickedSpot);

                if (countUserClickedSpotsLenght > wonLineMinimiunLenght)
                {

                    TaskAfterWon(countUserClickedSpotsLenght);
                    return;

                }

            }

        }


        private void ResetCheckValues(int i, ref int xX, ref int yY)
        {
            if (i == 1) { xX = 0; yY = 1; } //Ylös alas
            else if (i == 2) { xX = 1; yY = 0; } //Oikealle vasemmalle
            else if (i == 3) { xX = 1; yY = 1; }
            else if (i == 4) { xX = 1; yY = -1; }
        }

        private void ResetXAndY(int x, int y, Point userClickedSpot)
        {
            y = userClickedSpot.Y;
            x = userClickedSpot.X;
        }

       
        //FristCheck ja SecondCheck avulla tarkistetaan monenko putki käyttäjällä on. Aluksi tarkistetaan vasemmalle siihen asti
        //Mihin käyttäjä on laittanut nappuloita. Tämän jälkeen tarkistetaan oikealle ja jos pisteet ovat yli 5 ilmoitetaan käyttäjälle että hän voitti.
        private void FirstCheck(int x, int y, int Xx, int Yy, ref int countUserClickedSpotsLength, Point checkUserClickedSpot)
        {
            while (checkIfUserWonList.Contains(checkUserClickedSpot))
            {
                x -= Xx;
                y -= Yy;
                checkUserClickedSpot = new Point(x, y);
                countUserClickedSpotsLength++; //todo pakko olla parempi nimi
            }

        }


        //
        private void SecondCheck(int x, int y, int xX, int yY, ref int countUserClickedSpotsLenght, Point checkUserClickedSpot)
        {
            while (checkIfUserWonList.Contains(checkUserClickedSpot))
            {
                x += xX;
                y += yY;
                checkUserClickedSpot = new Point(x, y);
                countUserClickedSpotsLenght++;
            }

        }


        private void TaskAfterWon(int CountUserClickedSpotsLenght)
        {
            var w = new Form() { Size = new Size(0, 0) };
            Task.Delay(TimeSpan.FromSeconds(3))
                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());
            MessageBox.Show(w, "Voitit! Voittosuorasi oli " + (CountUserClickedSpotsLenght - 1) + " pitkä!");
            SaveDataJson saveDataJson = new SaveDataJson();
            if (!File.Exists("Data.json"))
            {
                saveDataJson.ResetPlayersDataFromJsonFile();
            }
            saveDataJson.ReadPlayerScoresToJsonFile();
            WhatUserWantDoAfterWon();
        }



        private void WhatUserWantDoAfterWon()
        {
            var TimedMessage = new Form() { Size = new Size(0, 0) };
            Task.Delay(TimeSpan.FromSeconds(5))
                .ContinueWith((t) => TimedMessage.Close(), TaskScheduler.FromCurrentSynchronizationContext());
            DialogResult dialogResult = MessageBox.Show(TimedMessage, "Haluatko jatkaa peliä? Jos et paina mitään jatkat peliä automaattisesti!", "Jatkansakki", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {

                Application.Restart();
                Environment.Exit(0);

            }
        }

    }
}
