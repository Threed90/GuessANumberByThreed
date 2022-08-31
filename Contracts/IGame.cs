using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
