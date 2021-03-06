﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperheroCreator.Models
{
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        public string superheroName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string primaryAbility { get; set; }
        public string secondaryAbility { get; set; }
        public string catchPhrase { get; set; }
    }
}