using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("INVENTORY SETTINGS")]
    [SerializeField] private Transform _inventorySpace;

    [Header("INVENTORY CONTENT")]
    [SerializeField] private List<GameObject> _objects = new List<GameObject>();

    public List<GameObject> Objects { get => _objects; private set => _objects = value; }

    public void AddObject(GameObject obj)
    {
        Objects.Add(obj);
        obj.transform.SetParent(_inventorySpace);
    }
    public void RemoveObject(GameObject obj)
    {
        Objects.Remove(obj);
    }
    public void CleanInventory()
    {
        foreach(GameObject obj in Objects)
        {
            RemoveObject(obj);
        }
        Objects.Clear();
    }
}