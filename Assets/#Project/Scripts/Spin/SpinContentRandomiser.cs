using UnityEngine;

public class SpinContentRandomiser : MonoBehaviour
{
    [Header("===RANDOMISER SETTINGS===")]
    [Header("References")]
    [SerializeField] private SliceSO[] _sliceItems;
    [SerializeField] private SliceSO _bomb;
    [SerializeField] private ZoneInitialiser _zoneInitialiser;
    /**
     * My Animation Curve is an animation curve with a name tag in it.
     * With .Evaluate(t), zone level can be fed into the parameter and received relative value.
     * Which means, zone specific values can be received.
     * 
     * Names are used for the need of creating an array and comparing within foreach loop.
     */
    [Header("Curves")]
    [Tooltip("Increase in amount relative to zone level.")]
    [SerializeField] private MyAnimationCurve[] _curves;

    //Set each slice according to randomised values.
    public void SetSlices(SliceDisplay[] slices)
    {
        //Reset slice SO.
        ResetSlices(slices);
        if (_zoneInitialiser.BombExists())
            SetBomb(slices);
        //Set Rest of the Slices
        foreach (SliceDisplay sliceDisplay in slices)
        {
            //Set SO reference in the slices
            if (sliceDisplay.SliceSO == null)
            {
                //Sets max amount relative to zone level.
                SliceSO randomItem = RandomItem();
                AddAmountToAmountList(randomItem);
                //Initialises slices.
                sliceDisplay.SetSliceSO(randomItem);
            }
        }
    }
    private void SetBomb(SliceDisplay[] slices)
    {
        //Plants two bombs within the wheel.
        for (int i = 0; i < 2; i++)
        {
            int randomIndex = Random.Range(0, slices.Length);
            slices[randomIndex].SetSliceSO(_bomb);
        }
    }
    private void ResetSlices(SliceDisplay[] slices)
    {
        foreach (SliceDisplay sliceDisplay in slices)
        {
            sliceDisplay.SliceSO = null;
        }
    }
    private void AddAmountToAmountList(SliceSO slice)
    {
        foreach (MyAnimationCurve curve in _curves)
        {
            if (curve.Name == slice.Name && !slice.Amounts.Contains(_zoneInitialiser.ZoneTracker.CurrentZone()))
            {
                //By feeding the current zone, we are adding another int into max amount could be received from items.
                slice.Amounts.Add((int)curve.Curve.Evaluate(_zoneInitialiser.ZoneTracker.CurrentZone()));
            }
        }
    }
    //return random item from SO list.
    private SliceSO RandomItem()
    {
        int randomIndex = Random.Range(0, _sliceItems.Length);
        return _sliceItems[randomIndex];
    }
    private void OnDisable()
    {
        CleanAmountLists();
    }
    //Cleaning all the set amounts to not to save it accidentally.
    private void CleanAmountLists()
    {
        foreach (SliceSO slice in _sliceItems)
        {
            //Deleting amounts set for randomly picking except the first default value.
            slice.Amounts.RemoveRange(1, slice.Amounts.Count - 1);
        }
    }
}