using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Effect : MonoBehaviour
{
    private readonly int ParameterStart = Animator.StringToHash(nameof(Start));

    [SerializeField] private float _lifeTime = 1.0f;

    private Animator _animator;
    private WaitForSeconds _delay;
    private Coroutine _coroutine;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _delay = new WaitForSeconds(_lifeTime);
    }

    public void Show(Vector3 position)
    {
        if(_coroutine != null )
            StopCoroutine( _coroutine );

        gameObject.SetActive(true);
        transform.position = position;
        _animator.SetTrigger(ParameterStart);
        _coroutine = StartCoroutine(DelayedDeactivate());
    }

    private IEnumerator DelayedDeactivate()
    {
        yield return _delay;

        gameObject.SetActive(false);
    }
}
