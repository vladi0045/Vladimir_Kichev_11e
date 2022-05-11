using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int User_ID { get; private set; }

        [Required, MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        public string LastName { get; set; }

        [Required, Range(10, 80)]
        public int Age { get; set; }

        [Required, MaxLength(20)]
        public string UserName { get; set; }

        [Required, MaxLength(70)]
        public string Password { get; set; }

        [Required, MaxLength(20)]
        public string Email { get; set; }

        public IEnumerable<User> Friends { get; set; }

        public IEnumerable<Game> Games { get; set; }

        private User()
        {

        }

        public User(string firstName, string lastName, int age, string userName, string password, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}
