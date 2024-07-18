using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RollingPhysicSimulator
{
    public List<PhysicRecord> SimulationRecords { get => _simulationRecords; }

    private IReadOnlyCollection<Dice> _dices;

    private List<PhysicRecord> _simulationRecords = new List<PhysicRecord>();

    public void Simulate(IDiceRoller roller)
    {
        ClearRecords();
        StartRolling(roller);
        StartRecord();
    }

    private void ClearRecords()
    {
        _simulationRecords.Clear();
    }

    private void StartRolling(IDiceRoller roller)
    {
        roller.Roll();

        _dices = roller.Dices;
    }

    private void StartRecord()
    {
        Physics.simulationMode = SimulationMode.Script;

        while (!IsAllDicesStopped())
        {
            RecordAllDices();
        }

        RecordLastFrames();

        Physics.simulationMode = SimulationMode.FixedUpdate;
    }

    private void RecordAllDices()
    {
        PhysicRecord physicRecord = new PhysicRecord();

        foreach (var dice in _dices)
        {
            var frame = new PhysicFrame(dice);
            physicRecord.AddFrame(frame);
        }

        _simulationRecords.Add(physicRecord);

        Physics.Simulate(Time.fixedDeltaTime);
    }

    private bool IsAllDicesStopped()
    {
        return _dices.All((i) => i.IsStopped());
    }

    private void RecordLastFrames()
    {
        RecordAllDices();
    }
}