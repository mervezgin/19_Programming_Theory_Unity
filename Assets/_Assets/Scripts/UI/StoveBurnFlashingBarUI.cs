using UnityEngine;
public class StoveBurnFlashingBarUI : MonoBehaviour
{
    private const string IS_FLASHING = "IsFlashing";
    [SerializeField] private StoveCounter stoveCounter;
    private Animator animator;
    float burnShowProgressAmount = 0.5f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
        animator.SetBool(IS_FLASHING, false);
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;
        animator.SetBool(IS_FLASHING, show);
    }
}
