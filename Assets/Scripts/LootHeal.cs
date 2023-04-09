using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    public int HealthVAlue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>() is PlayerHealth playerHealth)
        {
            if(playerHealth.Health < playerHealth.MaxHealth)
            {
                other.attachedRigidbody.GetComponent<PlayerHealth>().AddHealth(HealthVAlue);

                Destroy(gameObject);
            }
        }
    }
}
