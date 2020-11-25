using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace project.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public string ID { get; set; }
    }
}
