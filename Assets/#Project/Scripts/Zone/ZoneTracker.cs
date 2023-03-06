using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTracker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _currentZone;
    [SerializeField] private DynamicallyRectMover _dynamicRectMover;

    private List<GameObject> _zones = new List<GameObject>();
    public List<GameObject> Zones { get => _zones; set => _zones = value; }

    public delegate void OnNextZone();
    public static event OnNextZone ContinueNextZone;
    //Setting tracker by filling references
    private void Start()
    {
        _dynamicRectMover = SpinGameManager.Instance.DynamicallyRectMover;
    }
    public static void HandleContinueNextZone()
    {
        ContinueNextZone?.Invoke();
    }
    public void SetTracker()
    {
        //Setting Current Zone to default.
        _currentZone = Zones[0];
    }
    public void SetNextZone()
    {
        //Change zone visually
        _dynamicRectMover.MoveContentHorizontally();

        //Setting next zone reference
        if (Zones[CurrentZone()] != null)
        _currentZone = Zones[CurrentZone()];
    }
    public int CurrentZone()
    {
        //Returns the current level.
        return Zones.IndexOf(_currentZone) + 1 ;
    }
}