using UnityEngine;

public class Trap : MonoBehaviour
{
    public float damage = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Damage(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Damage(other.gameObject);
        }
    }

    private void Damage(GameObject go)
{
    PlayerHealth playerHealth = go.GetComponent<PlayerHealth>();
    
    if (playerHealth != null)
    {
        playerHealth.TakeDamage(damage);
    }
}
}
