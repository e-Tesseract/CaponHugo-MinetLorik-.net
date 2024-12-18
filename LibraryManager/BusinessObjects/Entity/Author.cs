﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Entity
{
    [Table("author")]
    public class Author: IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Author()
        {
        }

        public Author(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
