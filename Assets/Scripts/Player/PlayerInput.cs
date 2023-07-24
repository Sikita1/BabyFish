using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        MovePlayerDisplayControl.SwipeEvent += OnSwipe;
    }

    private void OnDisable()
    {
        MovePlayerDisplayControl.SwipeEvent -= OnSwipe;
    }

    private void OnSwipe(bool vectorUp)
    {
        if (vectorUp)
            _mover.TryMoveUp();
        else if (vectorUp == false)
            _mover.TryMoveDown();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            _mover.TryMoveUp();

        if (Input.GetKeyDown(KeyCode.S))
            _mover.TryMoveDown();
    }
}
