using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
    public int GunIndex;
    public int NumberOfBullet = 30;

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody.GetComponent<PlayerArmory>())
        {
            other.attachedRigidbody.GetComponent<PlayerArmory>().AddBullets(GunIndex, NumberOfBullet);
            Destroy(gameObject);
        }
    }
}
