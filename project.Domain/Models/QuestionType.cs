using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace project.Domain.Models
{
    public enum QuestionType
    {
        [Description("Feleletválasztós")]
        MultipleChoice,
        [Description("Igaz - hamis")]
        TrueOrFalse,
        [Description("Párosítós")]
        Pairing,
        [Description("Kiegészítős")]
        FillIn,
        [Description("Szám")]
        Number,
        [Description("Számok")]
        Numbers,
        [Description("Szöveg")]
        Text
    }
}
