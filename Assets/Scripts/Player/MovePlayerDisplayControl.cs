using UnityEngine;

public class MovePlayerDisplayControl : MonoBehaviour
{
    public delegate void OnSwipeInput(bool vectorUp);
    public static event OnSwipeInput SwipeEvent;

    private Vector2 _tapPosition;
    private Vector2 _swipeDelta;

    private float _deadZone = 0;

    private bool _isSwiping;
    //private bool _isMobile;

    //private void Start()
    //{
    //    _isMobile = Application.isMobilePlatform;
    //}

    private void Update()
    {
        //if (_isMobile == false)
        //{
            if (Input.GetMouseButtonDown(0))
            {
                _isSwiping = true;
                _tapPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                ResetSwipe();
            }
        //}
        //else if(_isMobile)
        //{
        //    if (Input.touchCount > 0)
        //    {
        //        if (Input.GetTouch(0).phase == TouchPhase.Began)
        //        {
        //            _isSwiping = true;
        //            _tapPosition = Input.GetTouch(0).position;
        //        }
        //        else if (Input.GetTouch(0).phase == TouchPhase.Canceled ||
        //                 Input.GetTouch(0).phase == TouchPhase.Ended)
        //        {
        //            ResetSwipe();
        //        }
        //    }
        //}

        CheckSwipe();
    }

    private void CheckSwipe()
    {
        _swipeDelta = Vector2.zero;

        if (_isSwiping == true)
        {
            if (/*!_isMobile && */Input.GetMouseButton(0))
                _swipeDelta = (Vector2)Input.mousePosition - _tapPosition;
            else if (Input.touchCount > 0)
                _swipeDelta = Input.GetTouch(0).position - _tapPosition;
        }

        if (_swipeDelta.magnitude > _deadZone)
        {
            if (SwipeEvent != null)
                SwipeEvent?.Invoke(_swipeDelta.y > 0 ? true : false);

                ResetSwipe();
        }
    }

    private void ResetSwipe()
    {
        _isSwiping = false;
        _tapPosition = Vector2.zero;
        _swipeDelta = Vector2.zero;
    }
}
