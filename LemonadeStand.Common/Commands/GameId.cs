using System;

namespace LemonadeStand.Common.Commands
{
    public class GameId
    {
        public Guid Id { get; set; }

        public GameId(Guid id)
        {
            Id = id;
        }

        public GameId()
        {
            
        }
    }
}
