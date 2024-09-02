using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private PlayerController player;
    private float volume = 1.0f;
    private float footstepTimer;
    private float footstepTimerMax = 0.1f;
    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }
    private void Update()
    {
        footstepTimer -= Time.deltaTime;
        if (footstepTimer < 0f)
        {
            footstepTimer = footstepTimerMax;
            if (player.IsWalking())
            {
                SoundManager.Instance.PlayFootstepsSound(player.transform.position, volume);
            }
        }
    }
}
