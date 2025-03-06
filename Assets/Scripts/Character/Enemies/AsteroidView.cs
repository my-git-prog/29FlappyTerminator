using UnityEngine;

public class AsteroidView : MonoBehaviour
{
    private float _rotationSpeed = 0f;

    public void Initialize(float rotationSpeed)
    {
        _rotationSpeed = rotationSpeed;
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
    }
}
