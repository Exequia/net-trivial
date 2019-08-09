using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trivial.Models
{
    public class GameOptionsModel
    {
        public int QuestionsAmount { get; set; }
        public bool MasterPlayer { get; set; }
        public int SecondsPerQuestion { get; set; }
        public List<List<int>> QuestionsIds { get; set; }
    }
}
