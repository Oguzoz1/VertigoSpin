using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RewardClickHandler : MonoBehaviour, IPointerDownHandler
{
    [Header("REFERENCES")]
    [SerializeField] private Image _rewardImage;

    private SpinGameManager _spinGameManager;
    private Inventory _inventory;
    private WheelSpinner _wheelSpinner;
    private SliceDisplay _rewardSlice;
    private Animator _animator;
    private bool isClicked = false;
    private void Start()
    {
        _spinGameManager = SpinGameManager.Instance;
        _inventory = _spinGameManager.Inventory;
        _wheelSpinner = _spinGameManager.WheelSpinner;
        _animator = GetComponent<Animator>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (this && !isClicked)
        {
            //To Avoid clicking the reward many times to initiate this method.
            isClicked = true;
            //Create copy of the object
            GameObject go = Instantiate(_rewardSlice.gameObject);

            //Adad the copied object into the inventory.
            _inventory.AddObject(go);

            //Raise nextzone event.
            ZoneTracker.HandleContinueNextZone();
            
            //Set animation back to false
            _animator.SetBool("chosen", false);
        }
    }
    #region Setters
    public void SetRewardSlice(SliceDisplay slice)
    {
        _rewardSlice = slice;
    }
    public void SetRewardImage(Sprite sprite)
    {
        _rewardImage.sprite = sprite;
    }
    public void SetIsClickedToFalse()
    {
        //initiated in animation
        isClicked = false;
    }
    #endregion
}
