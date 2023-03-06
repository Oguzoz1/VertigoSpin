using UnityEngine;

public class SpinGameManager : MonoBehaviour
{
    private static SpinGameManager _instance;
    public static SpinGameManager Instance
    {
        get { return _instance; }
    }

    [Header("REFERENCES")]
    [SerializeField] private Inventory _inventory;
    [SerializeField] private ZoneInitialiser _zoneInitialiser;
    [SerializeField] private WheelSpinner _wheelSpinner;
    [SerializeField] private RewardClickHandler _rewardClickHandler;
    [SerializeField] private SpinDisplayer _spinDisplayer;
    [SerializeField] private MyButton _leaveButton;
    [SerializeField] private DynamicallyRectMover _dynamicallyRectMover;

    private SliceDisplay _rewardSlice;

    public Inventory Inventory { get => _inventory; private set => _inventory = value; }
    public ZoneInitialiser ZoneInitialiser { get => _zoneInitialiser; private set => _zoneInitialiser = value; }
    public WheelSpinner WheelSpinner { get => _wheelSpinner; private set => _wheelSpinner = value; }
    public RewardClickHandler RewardClickHandler { get => _rewardClickHandler; private set => _rewardClickHandler = value; }
    public SpinDisplayer SpinDisplayer { get => _spinDisplayer; private set => _spinDisplayer = value; }
    public DynamicallyRectMover DynamicallyRectMover { get => _dynamicallyRectMover; private set => _dynamicallyRectMover = value; }

    #region Program Body
    private void Awake()
    {
        if (_instance == null) _instance = this;
        else if (_instance != this) Destroy(gameObject);
    }
    private void Start()
    {
        WheelSpinner.StoppingWheel += InitialiseNextRound;
        _leaveButton.Button.onClick.AddListener(StopGame);
    }
    private void OnDisable()
    {
        WheelSpinner.StoppingWheel -= InitialiseNextRound;
        _leaveButton.Button.onClick.RemoveAllListeners();
    }
    public void InitialiseNextRound()
    {
        //Setting rewardSlice
        if (SpinDisplayer != null)
            _rewardSlice = SpinDisplayer.ClosestSliceToIndýcator();
        if (_rewardSlice.SliceSO.Name != "Bomb")
            _rewardSlice.SetGiven(true);
        else
        {
            Lose();
            return;
        }

        //Set reward within the clickhandler
        RewardClickHandler.SetRewardSlice(_rewardSlice);
        RewardClickHandler.SetRewardImage(_rewardSlice.SliceSO.Sprite);
    }
    public void Lose()
    {
        Debug.Log("LOSE");
        Inventory.CleanInventory();
        Restart();
    }
    public void Restart()
    {
        _dynamicallyRectMover.ReturnToOriginal();
        _zoneInitialiser.SetZone();
        _zoneInitialiser.SetSpritesAndInitialiseZoneTracker();
    }
    public void StopGame()
    {
        //Stop the application
        if (!WheelSpinner.IsSpinning)
            Application.Quit();
    }
    #endregion
}