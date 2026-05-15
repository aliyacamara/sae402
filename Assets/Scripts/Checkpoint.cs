using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public BoxCollider2D bc2d;
    
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerSpawn playerSpawn = collision.GetComponent<PlayerSpawn>();
            if (playerSpawn != null)
            {
                playerSpawn.currentSpawnPosition = transform.position;
                
                bc2d.enabled = false;

                if (anim != null)
                {
                    anim.SetTrigger("Activate");
                }
            }
        }
    }
}

