﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlissRecruitment.Models
{
    public class QuestionEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string ThumbUrl { get; set; }

        public DateTime Published { get; set; }

        [Required]
        public IList<ChoiceEntity> Choices { get; set; }
    }
}