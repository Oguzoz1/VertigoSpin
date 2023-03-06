using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpinner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MyButton _spinButton;

    [Header("Maximum Values")]
    [Range(500f, 900f)]
    [SerializeField] private float _maxSpeed = 900;
    [Range(50f, 200f)]
    [SerializeField] private float _maxDecreasingSpeed = 200f;
    [Range(30f, 150f)]
    [SerializeField] private float _maxDecreasingSpeedModifier = 150f;

    [Header("Values")]
    [SerializeField] private float _spinSpeed = 500f;
    [SerializeField] private float _decreasingSpeed = 10f;
    [SerializeField] private float _decreasingSpeedModifier = 5f;
    [SerializeField] private bool _isSpinning = false;

    public bool IsSpinning { get => _isSpinning; private set => _isSpinning = value; }

    public delegate void OnStopWheel();
    public static event OnStopWheel StoppingWheel;


    private void Awake()
    {
        StoppingWheel += StopSpinning;
        _spinButton.Button.onClick.AddListener(StartSpinning);
    }
    private void OnDisable()
    {
        StoppingWheel -= StopSpinning;
    }
    private void Update() => Spin();

    //Main Method to execute spinning.
    public void StartSpinning()
    {
        //call this with an event which spins the wheel
        if (IsSpinning) return;
        IsSpinning = true;
        ResetSpin();
        SetDefaultValues();
        SetSpinValues();
    }
    #region Setting Values
    public void SetIsSpinningBool(bool _bool)
    {
        IsSpinning = _bool;
    }
    private void SetSpinValues()
    {
        _spinSpeed = RandomSpinSpeed();
        _decreasingSpeed = RandomDecreesingSpeed();
        _decreasingSpeedModifier = RandomDecreasingSpeedModifier();
    }
    private void SetDefaultValues()
    {
        _spinSpeed = 500f;
        _decreasingSpeed = 50f;
        _decreasingSpeedModifier = 30f;
    }
    #endregion
    #region Randomisers
    private float RandomSpinSpeed()
    {
        //Helps to randomise to increase chance factor.
        return Random.Range(_spinSpeed, _maxSpeed);
    }
    private float RandomDecreesingSpeed()
    {
        //Helps to randomise to increase chance factor.
        return Random.Range(_decreasingSpeed, _maxDecreasingSpeed);
    }
    private float RandomDecreasingSpeedModifier()
    {
        //Helps to randomise to increase chance factor.
        return Random.Range(_decreasingSpeedModifier, _maxDecreasingSpeedModifier);
    }
    #endregion
    #region Spin Logic
    private void Spin()
    {
        //If its true, start spinnnig the wheel and gradually decrease the speed.
        if (IsSpinning)
        {
            float spinAmount = -_spinSpeed * Time.deltaTime;
            transform.Rotate(0f, 0f, spinAmount);
            GraduallyDecreaseSpeed();
        }
    }
    private void GraduallyDecreaseSpeed()
    {
        //if spin speed higher than 0, keep decreasing the speed;
        if (_spinSpeed > 0)
        {
            _decreasingSpeed += Time.deltaTime * _decreasingSpeedModifier;
            _spinSpeed -= _decreasingSpeed * Time.deltaTime;
        }
        else StoppingWheel?.Invoke();
    }
    private void StopSpinning()
    {
        //Set spin speed 0 and spin bool to false.
        _spinSpeed = 0;
        IsSpinning = false;
    }
    private void ResetSpin()
    {
        //Resets spin orientation.
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    #endregion
}