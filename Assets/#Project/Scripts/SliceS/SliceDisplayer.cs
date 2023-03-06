using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliceDisplayer : MonoBehaviour
{
    [Header("===SLICE REFERENCES===")]
    [SerializeField] private SliceSO _sliceSO;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Animator _rewardNotifierAnimator;


    private bool _given = false;
    private int _sliceAmount;
    public int SliceAmount { get => _sliceAmount; private set => _sliceAmount = value; }
    public SliceSO SliceSO { get => _sliceSO; set => _sliceSO = value; }
    public bool Given { get => _given; private set => _given = value; }
    public Animator RewardNotifierAnimator { get => _rewardNotifierAnimator; private set => _rewardNotifierAnimator = value; }

    public void SetSliceSO(SliceSO slice)
    {
        //Feeds reference.
        SliceSO = slice;

        //Sets values relative SliceSO.
        SliceAmount = SliceSO.GetRandomAmount();
        gameObject.name = SliceSO.name;
        _image.sprite = SliceSO.Sprite;
        _image.sprite.rect.Set(SliceSO.SpriteSize.x, SliceSO.SpriteSize.y, SliceSO.SpriteSize.x, SliceSO.SpriteSize.y);
        //Setting reward indicating bool 'Given' to default 
        Given = false;

        //Setting SliceSO text
        if (SliceAmount != 0)
            _text.text = $"x{SliceAmount}";
        else _text.text = "";
    }
    public void SetGiven(bool _bool)
    {
        Given = _bool;
    }
}
