using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private float _minimumX = -12f;
    [SerializeField] private float _moveToX = 24f;
    [SerializeField] private float _speed = 2f;

    private void Update()
    {
        var position = transform.localPosition;
        position.x -= _speed * Time.deltaTime;
        
        if(position.x < _minimumX)
            position.x = _moveToX;

        transform.localPosition = position;
    }
}
