using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trivial.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
