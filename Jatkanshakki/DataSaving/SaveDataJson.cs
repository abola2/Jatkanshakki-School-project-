using System.Text.Json;
using Jatkanshakki.GameLogic;

namespace Jatkanshakki.DataSaving
{
    public class SaveDataJson
    {

        Ui _ui;

        public SaveDataJson(Ui ui)
        {
            _ui = ui;
        }

        public SaveDataJson()
        {
           
        }

        public class TicTacToeRedAndBlueScores
        {
            public int red { get; set; }
            public int blue { get; set; }
        }


        public void ScoreJson(object sender, EventArgs e)
        {
            ToolStripMenuItem? tool = sender as ToolStripMenuItem;
            string fileName = "Data.json";
            string jsonString = File.ReadAllText(fileName);
            TicTacToeRedAndBlueScores score = JsonSerializer.Deserialize<TicTacToeRedAndBlueScores>(jsonString)!;
            if (tool.Text != "Pisteet")
            {
                if (tool.Text.Contains("Punainen")) tool.Text = "Punainen: " + score.red;
                if (tool.Text.Contains("Sininen")) tool.Text = "Sininen: " + score.blue;
            }
        }




        private void UpdateBlueScoreInJsonFile(int blue)
        {
           
            string json = File.ReadAllText("Data.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            jsonObj["blue"] = blue + 1;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("Data.json", output);
        }


        private void UpdateRedScoreInJsonFile(int red)
        {

            string json = File.ReadAllText("Data.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            jsonObj["red"] = red + 1;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("Data.json", output);
        }


        public async Task ResetPlayersDataFromJsonFile()
        {

            var playersdata = new TicTacToeRedAndBlueScores
            {
                red = 0,
                blue = 0

            };
            string fileName = "Data.json";
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, playersdata);
            await createStream.DisposeAsync();
        }



        public void ReadPlayerScoresToJsonFile()
        {
            string fileName = "Data.json";
            string jsonString = File.ReadAllText(fileName);
            TicTacToeRedAndBlueScores score = JsonSerializer.Deserialize<TicTacToeRedAndBlueScores>(jsonString)!;

            
            Game game = new Game();
            if (game.redList.Count == game.blueList.Count)
            {
                UpdateBlueScoreInJsonFile(score.blue);
            }

            else
            {
                UpdateRedScoreInJsonFile(score.red);
            }

        }




    }
}
