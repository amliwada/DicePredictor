using UnityEngine;

public class PhysicFrame
{
    public Vector3 Position { get => _position; }
    public Quaternion Rotation { get => _rotation; }

    public Dice Dice { get => _dice; }

    private Vector3 _position;
    private Quaternion _rotation;

    private Dice _dice;

    public PhysicFrame(Dice dice)
    {
        _dice = dice;

        _position = dice.transform.position;
        _rotation = dice.transform.rotation;
    }
}