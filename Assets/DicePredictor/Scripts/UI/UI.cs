using UnityEngine;

public class UI : MonoBehaviour, IRollingSettingsProvider, IDiceFaceModifierSettings
{
    [SerializeField] private RandomDirectionRoller _randomDirectionRoller;
    [SerializeField] private ForwardDirectionRoller _forwardDirectionRoller;
    [SerializeField] private DiceFaceModifier _diceFaceModifier;

    public int DiceAmount => 2;

    public int RequiredFaceIndex { get => _requiredFaceIndex; }

    private int _requiredFaceIndex = 5;

    private IDiceRoller _selectedRoller;

    private void Start()
    {
        _randomDirectionRoller.SettingsProvider = this;
        _diceFaceModifier.Settings = this;

        _selectedRoller = _forwardDirectionRoller;
    }

    public void Roll()
    {
        IDiceRoller diceRoller = _selectedRoller;

        _diceFaceModifier.TargetRoller = diceRoller;
        diceRoller = _diceFaceModifier;

        diceRoller.Roll();
    }
}