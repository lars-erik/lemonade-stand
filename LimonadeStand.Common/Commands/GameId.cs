using System;

namespace LimonadeStand.Common.Commands
{
    public class GameId
    {
        public Guid Id { get; set; }

        public GameId(Guid id)
        {
            Id = id;
        }
    }
}
