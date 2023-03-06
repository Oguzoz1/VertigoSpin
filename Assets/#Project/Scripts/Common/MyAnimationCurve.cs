using UnityEngine;

[System.Serializable]
public class MyAnimationCurve
{
    [SerializeField] private string name;
    [SerializeField] private AnimationCurve curve;
    public string Name { get => name; private set => name = value; }
    public AnimationCurve Curve { get => curve; private set => curve = value; }
}
