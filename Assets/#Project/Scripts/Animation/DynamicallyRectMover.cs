using UnityEngine;
using UnityEngine.UI;

public class DynamicallyRectMover : MonoBehaviour
{
    [Header("SETTINGS")]
    //To be able to set rect, try and error might be needed to set proper start point.
    [SerializeField] private RectTransform rect;
    [SerializeField] private Vector3 _rectStartPoint = new Vector3(325f, -12f, 0f);
    [SerializeField] private Vector3 _rectOffsetModifier = new Vector3(-91f,0,0);
    public void MoveContentHorizontally()
    {
        //Set rect local pos to start position
        rect.transform.localPosition = _rectStartPoint;

        //Increase start pos every time according to level change.
        _rectStartPoint += _rectOffsetModifier;
    }

    public void ReturnToOriginal()
    {
        rect.transform.localPosition = _rectStartPoint;
    }
}