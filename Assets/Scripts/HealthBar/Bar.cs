using UnityEngine;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Health Health;

    protected virtual void Start()
    {
        SetValue();
    }

    private void OnEnable()
    {
        Health.ValueChanged += SetValue;
    }
   
    private void OnDisable()
    {
        Health.ValueChanged -= SetValue;
    }

    protected abstract void SetValue();
}
