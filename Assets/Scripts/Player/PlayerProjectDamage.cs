using UnityEngine;

public class ProjectDamage : MonoBehaviour
{
    [SerializeField] 
    public int damageAmount;
    public bool piercing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyHealth>(out var targetHealth))
        {
            targetHealth.Damage(damageAmount);
            
            if (!piercing)
            {
                Destroy(gameObject); // Destroy the projectile after hitting
            }
        }
    }
}