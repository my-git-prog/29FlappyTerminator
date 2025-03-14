using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SmokeAnimator : MonoBehaviour
{
    private readonly int ParameterGas = Animator.StringToHash(nameof(Gas));

    [SerializeField] private Animator _animator;

    public void Gas()
    {
        _animator.SetTrigger(ParameterGas);
    }
}
