using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Models
{
    public class Connection
    {
        [Key]
        public int ConnectionId { get; set; }
        [ForeignKey("UserFollowed")]
        public int UserFollowedId { get; set; }
        public User UserFollowed { get; set; }
        [ForeignKey("Follower")]
        public int FollowerId { get; set; }
        public User Follower { get; set; }
    }
}