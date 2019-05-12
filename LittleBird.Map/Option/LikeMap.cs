using LittleBird.Core.Map;
using LittleBird.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBird.Map.Option
{
    public class LikeMap : CoreMap<Like>
    {
        public LikeMap()

        {
            ToTable("dbo.Likes");

            HasRequired(x => x.Tweet)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.TweetID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.AppUser)
               .WithMany(x => x.Likes)
               .HasForeignKey(x => x.AppUserID)
               .WillCascadeOnDelete(false);
            
        }
    }
}
