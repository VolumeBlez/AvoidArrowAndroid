namespace Main.Assets._Project.CodeBase.Runtime.Core.Player
{
    public class PlayerModel
    {
        public int Score;
        public int Health;

        public PlayerModel(int startMaxHealth)
        {
            Health = startMaxHealth;
            Score = 0;
        }
    }
}
