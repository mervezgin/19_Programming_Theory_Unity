using System;
using UnityEngine;
public class StoveBurnWarningUI : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;
    float burnShowProgressAmount = 0.5f;
    private void Start()
    {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
        Hide();
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;
        if (show) { Show(); }
        else { Hide(); }
    }
    private void Show() { gameObject.SetActive(true); }
    private void Hide() { gameObject.SetActive(false); }
}
