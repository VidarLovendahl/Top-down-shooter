using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Image healthBar;
    [SerializeField] private float maxHealth = 5f;

    private void Start()
    {
        if (player == null)
            player = FindAnyObjectByType<Player>();
        RefreshHealthBar();
    }

    public void RefreshHealthBar()
    {
        if (player == null || healthBar == null)
            return;

        healthBar.fillAmount = Mathf.Clamp01(player.health / maxHealth);            
    }
}
