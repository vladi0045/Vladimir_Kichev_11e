using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class Genre
    {
        [Key]
        public int Genre_ID { get; private set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public IEnumerable<User> Users { get; set; }

        public Genre(string name)
        {
            Name = name;
        }
    }
}
