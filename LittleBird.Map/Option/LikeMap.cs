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
            HasKey(x => new { x.AppUserID, x.TeewtID });
        }
    }
}
