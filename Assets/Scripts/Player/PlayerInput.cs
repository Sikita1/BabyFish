using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;

    void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            _mover.TryMoveUp();

        if (Input.GetKeyDown(KeyCode.S))
            _mover.TryMoveDown();
    }
}
