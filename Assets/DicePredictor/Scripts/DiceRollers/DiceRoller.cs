using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour, IDiceRoller
{
    [SerializeField] private List<Transform> _rollPositions;

    [SerializeField] private List<Dice> _dices;

    public List<Dice> Dices { get => _dices; }

    public void Roll()
    {
        MoveDicesToRollPositions();
        SetRandomDicesTransform();
        ShowDices();
    }

    private void MoveDicesToRollPositions()
    {
        var diceCount = Mathf.Min(Dices.Count, _rollPositions.Count);

        for (int i = 0; i < diceCount; i++)
        {
            Dices[i].MoveTo(_rollPositions[i].position);
        }
    }

    private void SetRandomDicesTransform()
    {
        foreach (var dice in Dices)
        {
            SetRandomTransform(dice);
        }
    }

    private void SetRandomTransform(Dice dice)
    {
        RotateDice(dice);
        SetDiceVelocity(dice);
        SetDiceTorque(dice);
    }

    private void RotateDice(Dice dice)
    {
        float x = Random.Range(-180, 180);
        float y = Random.Range(-180, 180);
        float z = Random.Range(-180, 180);
        dice.RotateTo(x, y, z);
    }

    private void SetDiceVelocity(Dice dice)
    {
        float x = Random.Range(-2, 2);
        float y = Random.Range(10, 15);
        float z = Random.Range(15, 20);
        dice.SetVelocity(x, y, z);
    }

    private void SetDiceTorque(Dice dice)
    {
        dice.AddTorque(50, 50, 50);
    }

    private void ShowDices()
    {
        foreach (var dice in Dices)
        {
            dice.Show();
        }
    }
}