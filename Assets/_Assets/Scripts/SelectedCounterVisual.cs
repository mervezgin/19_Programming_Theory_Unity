using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;
    void Start()
    {
        PlayerController.Instance.OnSelectedCounterChanged += PlayerController_OnSelectedCounterChanged;
    }
    void PlayerController_OnSelectedCounterChanged(object sender, PlayerController.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == baseCounter) { Show(); }
        else { Hide(); }
    }
    void Show()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray) { visualGameObject.SetActive(true); }
    }
    void Hide()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray) { visualGameObject.SetActive(false); }
    }
}
