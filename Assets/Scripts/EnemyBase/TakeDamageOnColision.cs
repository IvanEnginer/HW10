using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnColision : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<Bullet>())
            {
                EnemyHealth.TakeDamage(1);
            }
        }

        if(DieOnAnyCollision == true)
        {
            EnemyHealth.TakeDamage(10000);
        }
    }
}
