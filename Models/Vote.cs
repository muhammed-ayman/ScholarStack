using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class Vote
	{
		[Column("user_id")]
		public int UserID { get; set; }

		[Column("community_post_id")]
		public int CommunityPostID { get; set; }

		[Column("vote_type")]
		public Boolean VoteType { get; set; }
	}
}
