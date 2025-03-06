using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SmokeAnimator : MonoBehaviour
{
    const string ParameterGas = "Gas";

    [SerializeField] private Animator _animator;

    public void Gas()
    {
        _animator.SetTrigger(ParameterGas);
    }
}
