using UnityEngine;

public class UI : MonoBehaviour, IDiceFaceModifierSettings
{
    [SerializeField] private DiceRoller _diceRoller;
    [SerializeField] private DiceFaceModifier _diceFaceModifier;

    public int DiceAmount => 2;

    public int RequiredFaceIndex { get => _requiredFaceIndex; }

    private int _requiredFaceIndex = 5;

    private void Start()
    {
        _diceFaceModifier.Settings = this;
    }

    public void Roll()
    {
        IDiceRoller diceRoller = _diceRoller;

        _diceFaceModifier.TargetRoller = diceRoller;
        diceRoller = _diceFaceModifier;

        diceRoller.Roll();
    }
}