using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlissRecruitment.Models
{
    public class ChoiceEntity
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }

        [JsonIgnore]
        public int QuestionEntityId { get; set; }

        [Required]
        public string Choice { get; set; }

        public int Votes { get; set; }
    }
}