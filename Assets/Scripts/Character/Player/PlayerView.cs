using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private SmokeAnimator _smokeAnimator;
    [SerializeField] private UserInput _userInput;

    private void OnEnable()
    {
        _userInput.GasButtonPressed += _smokeAnimator.Gas;
    }

    private void OnDisable()
    {
        _userInput.GasButtonPressed -= _smokeAnimator.Gas;
    }
}
