using UnityEngine;

public class EnemyHardMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    private Player _target;

    public void Initialize(Player target)
    {
        _target = target;
    }

    private void Update()
    {
        var position = transform.position;
        
        position.y = Mathf.MoveTowards(position.y, _target.transform.position.y, _moveSpeed * Time.deltaTime);
        transform.position = position;
    }
}
