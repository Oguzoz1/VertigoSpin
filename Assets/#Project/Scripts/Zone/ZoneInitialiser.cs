using UnityEngine;
using TMPro;
using System.Collections.Generic;
//Initialises zones and invokes spin initialisation.
public class ZoneInitialiser : MonoBehaviour
{
    [Header("===REFERENCES===")]
    [SerializeField] private ZoneTracker _zoneTracker;
    [SerializeField] private Transform _scrollViewContent;
    [SerializeField] private SpinSO[] _spinSO;

    [Header("===SETTINGS===")]
    [SerializeField] private int _zoneAmount = 30;

    [Header("===PREFABS===")]
    [SerializeField] private GameObject _normalZone;
    [SerializeField] private GameObject _safeZone;
    [SerializeField] private GameObject _superZone;

    public ZoneTracker ZoneTracker { get => _zoneTracker; private set => _zoneTracker = value; }

    private SpinDisplayer _spinDisplayer;
    private void Start()
    {
        _spinDisplayer = SpinGameManager.Instance.SpinDisplayer;

        ZoneTracker.ContinueNextZone += SetSpritesAndInitialiseSpin;
        SetZone();
        SetSpritesAndInitialiseSpin();
    }
    private void OnDisable()
    {
        Debug.Log("UNSUBBED TO EVENTS");
        ZoneTracker.ContinueNextZone -= SetSpritesAndInitialiseSpin;
    }
    #region Setters
    public void SetZone()
    {
        //Spawning entire zone into content.
        //Since we check remainders, i starts from 1.
        for (int i = 1; i <= _zoneAmount; i++)
        {
            //Return true or false if its dividable to 5 or 30.
            bool isSafeZone = i % 5 == 0 && i % 30 != 0;
            bool isSuperZone = i % 30 == 0;

            //Spawn according to the bools.
            if (!isSafeZone && !isSuperZone) SpawnZone(_normalZone,i);
            else if (isSuperZone) SpawnZone(_superZone, i);
            else SpawnZone(_safeZone, i);
        }
        ZoneTracker.SetTracker();
    }
    public void ResetInitialiser()
    {
        ZoneTracker.SetTracker();
        SetSpritesAndInitialiseSpin();
    }
    private void SetZoneText(TextMeshProUGUI text, int level)
    {
        text.text = level.ToString();
    }

    //Generates Spin Content and Sets Spin Sprite. Using this to randomise the spin relative to zone level.
    public void SetSpritesAndInitialiseSpin()
    {
        //Checking spinSO and getting correct SO
        if (IsSafeZone() && !IsSuperZone()) _spinDisplayer.Spin = GetSpin("Silver");
        else if (IsSuperZone()) _spinDisplayer.Spin = GetSpin("Gold");
        else _spinDisplayer.Spin = GetSpin("Bronze");

        //Initialising Spin from ZoneInitialiser to avoid timing confusion/null reference/false level zone.
        _spinDisplayer.InitialiseSpin(_spinDisplayer.Spin);
    }
    #endregion
    #region Methods
    private void SpawnZone(GameObject zone, int level)
    {
        //Spawn object and set content its parent.
        GameObject go = Instantiate(zone, _scrollViewContent);
        SetZoneText(go.GetComponentInChildren<TextMeshProUGUI>(), level);
        ZoneTracker.Zones.Add(go);
    }
    private SpinSO GetSpin(string name)
    {
        SpinSO spin = null;

        //Compare spin name to input to find the right one.
        foreach (SpinSO sp in _spinSO)
            if (sp.Name == name) spin = sp;
        return spin;
    }
    public bool BombExists()
    {
        if (IsSafeZone() && !IsSuperZone()) return false;
        else if (IsSuperZone()) return false;
        else return true;
    }
    private bool IsSafeZone()
    {
        //if the current zone dividable by 5 but not 30
        return ZoneTracker.CurrentZone() % 5 == 0 && ZoneTracker.CurrentZone() % 30 != 0;
    }
    private bool IsSuperZone()
    {
        //if the current zone is dividable by 30.
        return ZoneTracker.CurrentZone() % 30 == 0; ;
    }
    #endregion
}