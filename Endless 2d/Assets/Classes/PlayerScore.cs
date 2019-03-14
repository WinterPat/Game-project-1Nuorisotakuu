namespace Assets.Classes
{
    class PlayerScore
    {
        private int id;
        private int player_id;
        private string player_name;
        private int score;

        public string Player_name { get => player_name; set => player_name = value; }
        public int Score { get => score; set => score = value; }
        public int Id { get => id; set => id = value; }
        public int Player_id { get => player_id; set => player_id = value; }

        public PlayerScore(int id, int player_id, int score, string playerName)
        {
            this.player_name = playerName;
            this.score = score;
            this.player_id = player_id;
            this.id = id;
        }

        public override string ToString()
        {
            return $"{id} {player_id} {player_name} {score}";
        }
    }
}
