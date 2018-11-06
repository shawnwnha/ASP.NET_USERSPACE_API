using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        [InverseProperty("Follower")]
        public List<Connection> UsersFollowed { get; set; }
        [InverseProperty("UserFollowed")]
        public List<Connection> Followers { get; set; }
        public User()
        {
            Posts = new List<Post>();
            Comments = new List<Comment>();
            UsersFollowed = new List<Connection>();
            Followers = new List<Connection>();
        }
    }
}