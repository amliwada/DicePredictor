using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiceFaceModifier : MonoBehaviour, IRollingModifier
{
    [SerializeField] private RollingPhysicPlayer _player;

    public IDiceFaceModifierSettings Settings { get => _settings; set => _settings = value; }

    public List<Dice> Dices { get => _targetRoller.Dices; set => _targetRoller.Dices = value; }

    public IDiceRoller TargetRoller { get => _targetRoller; set => _targetRoller = value; }

    private IDiceFaceModifierSettings _settings;

    private IDiceRoller _targetRoller;

    private RollingPhysicSimulator _simulator = new RollingPhysicSimulator();

    public void Roll()
    {
        SimulateRolling();
        SetRollingResults();
        MoveDicesToStartPosition();
        ModifyRollingPhysic();
        StartModifiedPhysic();
    }

    private void SimulateRolling()
    {
        _simulator.Simulate(TargetRoller);
    }

    private void SetRollingResults()
    {
        foreach (var dice in Dices)
        {
            dice.SetResult();
        }
    }

    private void MoveDicesToStartPosition()
    {
        var startRecord = _simulator.SimulationRecords.First();

        foreach (var frame in startRecord.Frames)
        {
            frame.Dice.MoveTo(frame.Position);
            frame.Dice.RotateTo(frame.Rotation);
        }
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