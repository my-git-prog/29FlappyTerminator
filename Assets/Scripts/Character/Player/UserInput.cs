using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const KeyCode KeyAttack = KeyCode.RightControl;
    private const KeyCode KeyPause = KeyCode.Escape;
    private const string AxisGas = "Jump";

    public event Action GasButtonPressed;
    public event Action AttackButtonPressed;
    public event Action PauseButtonPressed;

    private void Update()
    {
        if (Input.GetAxisRaw(AxisGas) > 0f)
        {
            GasButtonPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyAttack))
        {
            AttackButtonPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyPause))
        {
            PauseButtonPressed?.Invoke();
        }
    }
}
