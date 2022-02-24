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
        [Description("Feleletválasztós - több helyes megoldás")]
        MultipleChoiceMultipleAnswer,
        [Description("Igaz - hamis")]
        TrueOrFalse,
        [Description("Párosítós")]
        Pairing,
        [Description("Kiegészítős")]
        FillIn,
        [Description("Szám")]
        Number,
        [Description("Sorrendbe helyezés")]
        Order,
        [Description("Szöveg")]
        Text,
        [Description("Programozási feladat")]
        ProgrammingQuestion
    }
}
