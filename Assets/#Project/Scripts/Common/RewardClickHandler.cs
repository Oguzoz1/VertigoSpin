using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class RewardClickHandler : MonoBehaviour, IPointerDownHandler
{
    [Header("REFERENCES")]
    [SerializeField] private Image _rewardImage;

    private SpinGameManager _spinGameManager;
    private Inventory _inventory;
    private ZoneInitialiser _zoneInitialiser;
    private SliceDisplay _rewardSlice;
    private Animator _animator;
    private bool isClicked = false;
    private void Start()
    {
        _spinGameManager = SpinGameManager.Instance;
        _inventory = _spinGameManager.Inventory;
        _zoneInitialiser = _spinGameManager.ZoneInitialiser;
        _animator = GetComponent<Animator>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (this && !isClicked)
        {
            //To Avoid clicking the reward many times to initiate this method.
            isClicked = true;
            //Set animation back to false
            _animator.SetBool("chosen", false);

            if (_rewardSlice.SliceSO.Name != "Bomb")
            {
                Debug.Log("IS NOT A BOMB");

                //Create copy of the object
                GameObject go = Instantiate(_rewardSlice.gameObject);

                //Size Correction
                Image goImage = go.GetComponentInChildren<Image>();
                TextMeshProUGUI text = go.GetComponentInChildren<TextMeshProUGUI>();

                goImage.SetNativeSize();
                goImage.rectTransform.sizeDelta = goImage.rectTransform.sizeDelta * 0.2f;
                go.transform.localRotation = Quaternion.Euler(Vector3.zero);
                text.transform.transform.localScale = text.transform.transform.localScale * 4f;
                //Adad the copied object into the inventory.
                _inventory.AddObject(go);

                //Set Next Zone
                _zoneInitialiser.ZoneTracker.SetNextZone();

                //Raise nextzone event.
                ZoneTracker.HandleContinueNextZone();

            }
            else _spinGameManager.Lose();
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
