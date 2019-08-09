using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trivial.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public CategoryModel Category { get; set; }
        public string Topic { get; set; }
        public string Level { get; set; }
        public string Text { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}
