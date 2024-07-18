using System.Collections.Generic;
using UnityEngine;

public class DiceFaceModifier : MonoBehaviour, IRollingModifier
{
    [SerializeField] private RollingPhysicPlayer _player;

    public IDiceFaceModifierSettings Settings { get => _settings; set => _settings = value; }

    public List<Dice> Dices { get => _targetRoller.Dices; }

    public IDiceRoller TargetRoller { get => _targetRoller; set => _targetRoller = value; }

    private IDiceFaceModifierSettings _settings;

    private IDiceRoller _targetRoller;

    private RollingPhysicSimulator _simulator = new RollingPhysicSimulator();

    public void Roll()
    {
        SimulateRolling();
        ModifyRollingPhysic();
        StartModifiedPhysic();
    }

    private void SimulateRolling()
    {
        _simulator.Simulate(TargetRoller);
    }

    private void ModifyRollingPhysic()
    {
        foreach (var dice in Dices)
        {
            dice.RotateToFace(Settings.RequiredFaceIndex);
        }
    }

    private void StartModifiedPhysic()
    {
        _player.Play(_simulator);
    }
}