namespace Jatkanshakki.GameLogic;
using Jatkanshakki.DataSaving;

public class UserTurn
    {
        Ui _ui;

        public UserTurn(Ui ui)
        {
            _ui = ui;
        }


        public void Tic_Tac_Toe_Button_click(object sender, EventArgs e)
        {

            Gamebutton? button = sender as Gamebutton;

            Game game = new(_ui);

            Point userClickedSpot = new Point(button.X, button.Y);


            if (!game.blueList.Contains(userClickedSpot) && !game.redList.Contains(userClickedSpot))
            {
                if (game.redList.Count > game.blueList.Count)
                {
                    button.BackColor = Color.CadetBlue;
                    game.blueList.Add(userClickedSpot);
                }
                else if (game.redList.Count == game.blueList.Count)
                {
                    button.BackColor = Color.Coral;
                    game.redList.Add(userClickedSpot);
                }
                PlayPopSound();
                game.SendUserClickedSpotsToCheckWinMethod(userClickedSpot);

            }
            button.FlatAppearance.MouseOverBackColor = Color.Transparent;

        }

        private void PlayPopSound()
        {
            Stream str = Properties.Resources.pop_sound1;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            //pop sound https://mixkit.co/free-sound-effects/pop/
            snd.Play();

        }

    }





