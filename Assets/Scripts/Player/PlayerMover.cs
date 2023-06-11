using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private int _maxHeight;
    [SerializeField] private int _minHeight;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private Player _player;

    private Vector3 _targetPosition;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private float _step = 5f;
    private bool _isMove;

    private void Start()
    {
        _targetPosition = transform.position;

        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);

        _isMove = true;
    }

    private void Update()
    {
        Vector3 _direction = _targetPosition - transform.position;

        if (transform.position != _targetPosition)
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

        Rotate(_direction);
    }
    public void StopPlayer() => _isMove = false;

    public void TryMoveUp()
    {
        if (_targetPosition.y < _maxHeight && _isMove == true)
            SetNextPosition(_stepSize);
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHeight && _isMove == true)
            SetNextPosition(-_stepSize);
    }

    private void Rotate(Vector2 direction)
    {
        if (direction.y == 0)
        {
            SmoothRotation(Quaternion.identity);
            _player.SpeedNormal();
        }
        else if (direction.y > 0)
        {
            SmoothRotation(_maxRotation);
            _player.SpeedUp();
        }
        else
        {
            SmoothRotation(_minRotation);
            _player.SpeedUp();
        }
    }

    private void SmoothRotation(Quaternion target)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, target, _step * Time.deltaTime);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
    }
}
