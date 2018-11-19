using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMeAjuda.Models
{
    [Table("comments")]
    public class Comment
    {
        [Column("comment_id")]
        public int Id { get; set; }
        [Column("comment_content")]
        public string Content { get; set; }
        [Column("comment_likes")]
        public int Likes { get; set; }
        [Column("comment_creation_date")]
        public DateTime CreationDate { get; set; }
        [Column("comment_post")]
        [ForeignKey("FK_comment_post")]
        public int PostId { get; set; }
        [Column("comment_creator")]
        [ForeignKey("FK_comment_creator")]
        public int CreatorId { get; set; }

        public virtual Post Post { get; set; }
        public virtual User Creator { get; set; }
    }
}
