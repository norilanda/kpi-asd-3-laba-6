using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAlgo
{
    public class GameAlgorithm
    {
        public enum Mode
        {
            Easy,
            Medium,
            Difficult
        }
        Mode _gameMode;

        public GameAlgorithm(int mode)
        {
            _gameMode = (Mode)mode;
        }
    }
}
