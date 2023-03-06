using UnityEngine;
using UnityEngine.UI;

public class MyButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    public Button Button { get => _button; private set => _button = value; }

    private void OnValidate()
    {
        if (Button == null) Button = GetComponent<Button>();
    }
}
