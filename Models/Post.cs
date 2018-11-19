using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMeAjuda.Models
{
    [Table("posts")]
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Column("post_id")]
        public int Id { get; set; }
        [Column("post_title")]
        public string Title { get; set; }
        [Column("post_content")]
        public string Content { get; set; }
        [Column("post_likes")]
        public int Likes { get; set; }
        [Column("post_creation_date")]
        public DateTime CreationDate { get; set; }
        [Column("post_creator")]
        [ForeignKey("FK_post_creator")]
        public int CreatorId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual User Creator { get; set; }
    }
}
