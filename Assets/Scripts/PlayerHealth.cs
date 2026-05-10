using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sr;
    public PlayerInvulnerable playerInvulnerable;

    [Tooltip("Please uncheck it on production")]
    public bool needResetHP = true;

    [Header("ScriptableObjects")]
    public PlayerData playerData;

    [Header("Debug")]
    public VoidEventChannel onDebugDeathEvent;

    [Header("Broadcast event channels")]
    public VoidEventChannel onPlayerDeath;

    // --- NOUVELLES CASES POUR TON UI ---
    [Header("Écrans UI (Glisse tes objets ici)")]
    public GameObject gameOverCanvas; 
    public GameObject hudPommes;      

    private void Awake()
    {
        if (needResetHP || playerData.currentHealth <= 0)
        {
            playerData.currentHealth = playerData.maxHealth;
        }
    }

    private void OnEnable()
    {
        onDebugDeathEvent.OnEventRaised += Die;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Aïe ! Je viens de prendre " + damage + " dégâts !");
        if (playerInvulnerable.isInvulnerable && damage < float.MaxValue) return;

        playerData.currentHealth -= damage;
        if (playerData.currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(playerInvulnerable.Invulnerable());
        }
    }

    private void Die()
    {
        onPlayerDeath?.Raise();
        GetComponent<Rigidbody2D>().simulated = false;
        transform.Rotate(0f, 0f, 45f);
        animator.SetTrigger("Death"); 
    }

    public void OnPlayerDeathAnimationCallback()
    {
        sr.enabled = false;

        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }

        if (hudPommes != null)
        {
            hudPommes.SetActive(false);
        }

        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        onDebugDeathEvent.OnEventRaised -= Die;
    }
}