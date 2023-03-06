using UnityEngine;
using UnityEngine.UI;

public class RectScroller : MonoBehaviour
{
    [Header("===SCRIPT REFERENCES AND SETTINGS===")]
    [SerializeField] private RawImage _image;
    [SerializeField] private Vector2 _speed;

    void Update() => Scroll();
    private void Scroll()
    {
        //Moves rect constantly by repeating the image.
        _image.uvRect = new Rect(_image.uvRect.position + _speed * Time.deltaTime, _image.uvRect.size);
    }
}
