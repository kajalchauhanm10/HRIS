using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS.Utility
{
    public class ObjHelper
    {
    }

    public class Parameter
    {
        public long Id { get; set; }
        public string ParameterName { get; set; }
        public List<Question> QuestionsList { get; set; }
        public string RatingSystemName { get; set; }
        public Parameter()
        {
            QuestionsList = new List<Question>();
        }
    }

    public class Question
    {
        public long Id { get; set; }
        public string Ques { get; set; }
        public string StyleValue { get; set; }
    }
}