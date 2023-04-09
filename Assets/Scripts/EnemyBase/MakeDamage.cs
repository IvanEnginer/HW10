using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    public int DamageValue = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody && collision.rigidbody.GetComponent<PlayerHealth>() is PlayerHealth playerHealth)
        {
            playerHealth.TakeDamage(DamageValue);
        }
    }
}
