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

    /**
    * My Animation Curve is an animation curve with a name tag in it.
    * With .Evaluate(t), zone level can be fed into the parameter and received relative value.
    * Which means, zone specific values can be received.
    * 
    * Names are used for the need of creating an array and comparing within foreach loop.
    */
    [SerializeField] private AnimationCurve _increaseRelativeToZoneCurve;

    public string Name { get => name; private set => name = value; }
    public Sprite Sprite { get => _sprite; private set => _sprite = value; }
    public List<int> Amounts { get => _amounts; set => _amounts = value; }
    public Vector2 SpriteSize { get => _spriteSize; private set => _spriteSize = value; }
    public AnimationCurve IncreaseRelativeToZoneCurve { get => _increaseRelativeToZoneCurve; private set => _increaseRelativeToZoneCurve = value; }

    public int GetRandomAmount()
    {
        //Getting Random Amount from the Amounts List.
        int randomIndex = Random.Range(0, Amounts.Count);
        return Amounts[randomIndex];
    }
}