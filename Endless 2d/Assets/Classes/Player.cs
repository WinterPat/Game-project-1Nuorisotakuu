namespace Assets.Classes
{
    class Player
    {
        private string name;
        private int id;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public Player(int id, string name)
        {
            this.name = name;
            this.id = id;
        }

        public Player()
        {

        }

    }
}
