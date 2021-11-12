using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Tetris.Logic
{
    [Serializable]
    public class LeaderBoard
    {
        private const string _normalScoreSaveFile = "NormalScores.sav";
        private const string _risingFloorScoreSaveFile = "RisingFloor.sav";

        public const string NormalScoreName = "NormalScores";
        public const string RisingFloorName = "RisingFloorScores";

        public static void SaveAll()
        {
            foreach (var board in Collection.Values)
            {
                board.Save();
            }
        }
        public static void LoadLeaderBoard()
        {
            var loaded = LeaderBoard.Load(_normalScoreSaveFile);
            if (loaded == null)
            {
                loaded = new LeaderBoard();
                loaded.Name = NormalScoreName;
                loaded.SaveFileName = _normalScoreSaveFile;
            }
            loaded.FillInIfNeeded();
            Collection.Add(loaded.Name, loaded);

            loaded = LeaderBoard.Load(_risingFloorScoreSaveFile);
            if (loaded == null)
            {
                loaded = new LeaderBoard();
                loaded.Name = RisingFloorName;
                loaded.SaveFileName = _risingFloorScoreSaveFile;
            }
            loaded.FillInIfNeeded();
            Collection.Add(loaded.Name, loaded);
        }
        public static Dictionary<string, LeaderBoard> Collection = new Dictionary<string, LeaderBoard>();

        public enum Result
        {
            IsInTheBoard,
            HighScore,
            Nothing
        }

        public const int NumberOfRecord = 5;
        public string Name { get; set; }
        public string SaveFileName { get; set; }
        public List<Record> Scores { get; set; }

        public void FillInIfNeeded()
        {
            if (Scores == null)
                Scores = new List<Record>();

            while (Scores.Count < NumberOfRecord)
                Scores.Add(null);
        }

        public Result UpdateBoard(int score)
        {
            FillInIfNeeded();

            bool isHighScore = Scores[0].Score < score;
            bool isInTheLeaderBoard = false;

            DateTime date = DateTime.Today;

            for (int i = 0; i < Scores.Count; i++)
            {
                if (Scores[i] == null)
                {
                    Scores[i] = new Record
                    {
                        Score = score,
                        Date = date
                    };
                    break;
                }
                else if (score > Scores[i].Score)
                {
                    var oldScore = score;
                    var oldDate = date;

                    score = Scores[i].Score;
                    date = Scores[i].Date;

                    Scores[i].Score = oldScore;
                    Scores[i].Date = oldDate;

                    isInTheLeaderBoard = true;
                }
            }

            if (isHighScore || isInTheLeaderBoard)
            {
                Save();
            }

            if (isHighScore)
                return Result.HighScore;
            else if (isInTheLeaderBoard)
                return Result.IsInTheBoard;

            return Result.Nothing;
        }

        private static LeaderBoard Load(string fileName)
        {
            var loadedLeaderBoard = WriteReadBinaryUtils.DeserialLize<LeaderBoard>(fileName);
            if (loadedLeaderBoard != null)
                loadedLeaderBoard.SaveFileName = fileName;

            return loadedLeaderBoard;
        }

        private void Save()
        {
            WriteReadBinaryUtils.Serialize(this, SaveFileName);
        }
    }

    [Serializable]
    public class Record
    {
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
