namespace hicaphe2.Models
{
    /// <summary>
    /// Singleton pattern
    /// </summary>
    public class HiCaPheDatabase
    {
        public static HiCaPheDatabase Instance;
        public HiCaPheEntities1 database;

        public HiCaPheDatabase()
        {
            if (Instance == null)
                Instance = this;
            else
                return;

            database = new HiCaPheEntities1();
        }
    }
}