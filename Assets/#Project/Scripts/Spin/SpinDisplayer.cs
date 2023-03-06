using UnityEngine;
using UnityEngine.UI;

//Sets sprites and references for the spin.
public class SpinDisplayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpinSO _spin;
    [SerializeField] private SpinContentRandomiser _contentRandomiser;

    [Header("UI References")]
    [SerializeField] private Image _spinImage;
    [SerializeField] private Image _spinIndicatorImage;

    public SpinSO Spin { get => _spin; set => _spin = value; }
    public SpinContentRandomiser ContentRandomiser { get => _contentRandomiser; private set => _contentRandomiser = value; }

    //Initialises Spin to have new values right before spin.
    public void InitialiseSpin(SpinSO spin)
    {
        SetSpinReferencesandSlices(spin);
        SetSpinSprites(spin);
    }
    private void SetSpinReferencesandSlices(SpinSO spin)
    {
        Spin = spin;
        Spin.SetSliceReferences(this);
        ContentRandomiser.SetSlices(Spin.Slices);
    }
    private void SetSpinSprites(SpinSO spin)
    {
        _spinImage.sprite = spin.SpinSprite;
        _spinIndicatorImage.sprite = spin.SpinIndicatorSprite;
    }
    public SliceDisplay ClosestSliceToIndýcator()
    {
        //Iterates through slices to find the closest one.
        SliceDisplay closest = null;
        float distance = Mathf.Infinity;
        foreach(SliceDisplay slice in Spin.Slices)
        {
            float sqrDist = (_spinIndicatorImage.gameObject.transform.position - slice.transform.position).sqrMagnitude;
            if (sqrDist <= distance)
            {
                distance = sqrDist;
                closest = slice;
            }
        }
        //Initiates Reward Animation.
        closest.RewardNotifierAnimator.SetBool("chosen", true);
        return closest;
    }
}