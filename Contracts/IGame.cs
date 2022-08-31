namespace GuessANumber.Contracts
{
    public interface IGame
    {
        int Score { get; }
        void Start();
        void Stop();
        void Restart();
        bool SetGameDifficulty();

    }
}
