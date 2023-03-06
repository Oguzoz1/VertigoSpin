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
    public void DeleteObjects(GameObject obj)
    {
        Destroy(obj);
    }
    public void CleanInventory()
    {
        if (Objects.Count <= 0) return;
        for (int i = 0; i < Objects.Count; i++)
        {
            DeleteObjects(Objects[i]);
        }
        Objects.Clear();
    }
}