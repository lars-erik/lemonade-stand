using System;
using System.Collections.Generic;
using LemonadeStand.Common.Persistence;

namespace LemonadeStand.Common.Commands
{
    public class AddChoicesCommand : GameCommandBase
    {
        public AddChoicesCommand(IRepository<Game> repository)
            : base(repository)
        {
        }

        public CommandResult Execute(AddChoices addChoices)
        {
            Initialize(addChoices);
            foreach(var choice in addChoices.Choices)
                Game.CurrentDay.Choices.Add(choice);
            return new CommandResult();
        }
    }

    public class AddChoices : GameId
    {
        public List<Choices> Choices { get; set; }

        public AddChoices(Guid id, List<Choices> choices) : base(id)
        {
            Choices = choices;
        }

        public AddChoices()
        {
        }
    }
}
