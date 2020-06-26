﻿using System.ComponentModel.DataAnnotations;

namespace CatCards.Models
{
    public class CatCard
    {
        public int CatCardId { get; set; }
        [Required]
        public string CatFact { get; set; }
        [Required]
        [Url]
        public string ImgUrl { get; set; }
        [Required]
        public string Caption { get; set; }
    }
}
