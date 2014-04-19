using System;
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
            Game.CurrentDay.Choices.Add(addChoices.Choices);
            return new CommandResult();
        }
    }

    public class AddChoices : GameId
    {
        public Choices Choices { get; set; }

        public AddChoices(Guid id, Choices choices) : base(id)
        {
            Choices = choices;
        }
    }
}
