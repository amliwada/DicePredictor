using System.Collections.Generic;

public interface IDiceRoller
{
    public List<Dice> Dices { get; }

    public void Roll();
}