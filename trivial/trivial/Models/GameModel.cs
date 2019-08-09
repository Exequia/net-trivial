using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trivial.Models
{
    public class GameModel
    {
        public EnumGameStage Stage { get; set; } = EnumGameStage.Init;
        public GameOptionsModel Options { get; set; }
        public List<PlayerModel> Players { get; set; } = new List<PlayerModel>();
    }
}
