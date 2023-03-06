using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spin", menuName = "ScriptableObjects/Spin")]

public class SpinSO : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private Sprite _spinSprite;
    [SerializeField] private Sprite _spinIndicatorSprite;
    [SerializeField] private SliceDisplay[] _slices;

    public SliceDisplay[] Slices { get => _slices; private set => _slices = value; }
    public Sprite SpinSprite { get => _spinSprite; private set => _spinSprite = value; }
    public Sprite SpinIndicatorSprite { get => _spinIndicatorSprite; private set => _spinIndicatorSprite = value; }
    public string Name { get => name; set => name = value; }

    public void SetSliceReferences(SpinDisplayer initialiser)
    {
        Slices = initialiser.GetComponentsInChildren<SliceDisplay>();
    }
}
