using System;

namespace MillionaireGame.Player.Domain
{
    public class Score
    {
        public int ScoreId { get; set; }

        public int ScoreValue { get; set; }

        public DateTime Date { get; set; }

        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }
    }
}
