using System.Collections.Generic;
using UnityEngine;

public class RandomDirectionRoller : MonoBehaviour, IDiceRoller
{
    [SerializeField] private Dice _dicePrefab;
    
    public List<Dice> Dices { get => _spawnedDicesList; set => _spawnedDicesList = value; }

    public IRollingSettingsProvider SettingsProvider { get => _settingsProvider; set => _settingsProvider = value; }

    private IRollingSettingsProvider _settingsProvider;

    private List<Dice> _allInstantiatedDices = new List<Dice>();
    private List<Dice> _spawnedDicesList = new List<Dice>();

    public void Roll()
    {
        SpawnDices();
        MoveToSpawnPositions();
        ShowSpawnedDices();
    }

    private void SpawnDices()
    {
        if (_allInstantiatedDices.Count > SettingsProvider.DiceAmount)
        {
            _spawnedDicesList = _spawnedDicesList.GetRange(0, SettingsProvider.DiceAmount);

            return;
        }

        for (int i = _allInstantiatedDices.Count; i < SettingsProvider.DiceAmount; i++)
        {
            InstantiateDice();
        }

        _spawnedDicesList = _allInstantiatedDices;
    }

    private void InstantiateDice()
    {
        var newDice = Instantiate(_dicePrefab, transform);
        _allInstantiatedDices.Add(newDice);
    }

    private void MoveToSpawnPositions()
    {
        foreach (var dice in Dices)
        {
            SetRandomPosition(dice);
        }
    }

    private void SetRandomPosition(Dice dice)
    {
        MoveDice(dice);
        RotateDice(dice);
        SetDiceVelocity(dice);
        SetDiceTorque(dice);
    }

    private void MoveDice(Dice dice)
    {
        var spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-5, 5);
        dice.MoveTo(spawnPosition);
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
        float x = 0;
        float y = 10;
        float z = 15;
        dice.SetVelocity(x, y, z);
    }

    private void SetDiceTorque(Dice dice)
    {
        float x = 35;
        float y = 35;
        float z = 35;
        dice.SetTorque(x, y, z);
    }

    private void ShowSpawnedDices()
    {
        for (int i = 0; i < _spawnedDicesList.Count; i++)
        {
            _spawnedDicesList[i].Show();
        }

        for (int i = _spawnedDicesList.Count; i < _allInstantiatedDices.Count; i++)
        {
            _allInstantiatedDices[i].Hide();
        }
    }
}