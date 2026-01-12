using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class RammingDamage : MonoBehaviour
{
    [SerializeField] 
    public int damageAmount;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.TryGetComponent<PlayerHealth>(out var targetHealth))
        {
            targetHealth.Damage(damageAmount);
        }
    }
}