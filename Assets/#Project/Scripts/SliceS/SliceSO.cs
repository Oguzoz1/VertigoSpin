using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Slice", menuName = "ScriptableObjects/Slice")]
public class SliceSO : ScriptableObject
{
    [Header("===SLICE SETTINGS===")]
    [SerializeField] private new string name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Vector2 _spriteSize;
    [SerializeField] private List<int> _amounts = new List<int>();

    public string Name { get => name; private set => name = value; }
    public Sprite Sprite { get => _sprite; private set => _sprite = value; }
    public List<int> Amounts { get => _amounts; set => _amounts = value; }
    public Vector2 SpriteSize { get => _spriteSize; private set => _spriteSize = value; }

    public int GetRandomAmount()
    {
        //Getting Random Amount from the Amounts List.
        int randomIndex = Random.Range(0, Amounts.Count);
        return Amounts[randomIndex];
    }
}