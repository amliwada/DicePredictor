using System.Collections;
using UnityEngine;

public class RollingPhysicPlayer : MonoBehaviour
{
    private Coroutine _player = null;

    private RollingPhysicSimulator _simulator;

    public void Play(RollingPhysicSimulator simulator)
    {
        _simulator = simulator;

        StopCurrentPlayer();
        StartPlayingCoroutine();
    }

    private void StopCurrentPlayer()
    {
        if (_player is null)
        {
            return;
        }

        StopCoroutine(_player);

        _player = null;
    }

    private void StartPlayingCoroutine()
    {
        if (_player is null)
        {
            _player = StartCoroutine(PlayingCoroutine());
        }
    }

    private IEnumerator PlayingCoroutine()
    {
        foreach (var record in _simulator.SimulationRecords)
        {
            foreach (var frame in record.Frames)
            {
                frame.Dice.MoveTo(frame.Position);
                frame.Dice.RotateTo(frame.Rotation);
            }

            yield return new WaitForFixedUpdate();
        }

        StopCurrentPlayer();
    }
}