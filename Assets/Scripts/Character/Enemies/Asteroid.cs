using UnityEngine;

public class Asteroid : Enemy
{
    [SerializeField] private AsteroidView _view;

    public void Initialize(Vector3 position, float rotationSpeed)
    {
        base.Initialize(position);
        _view.Initialize(rotationSpeed);
    }
}
