using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int UserId {get;set;}
        public User User {get;set;}
        public int PostId {get;set;}
        public Post Post {get;set;}
    }
}