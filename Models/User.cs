using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMeAjuda.Models
{
    [Table("users")]
    public class User
    {
        public User()
        {
            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
        }

        [Column("user_id")]
        public int Id { get; set; }
        [Column("user_name")]
        public string Name { get; set; }
        [Column("user_password")]
        public string Password { get; set; }
        [Column("user_email")]
        public string Email { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
