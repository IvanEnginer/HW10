using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject EffectPrefab;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Hit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody && other.attachedRigidbody.GetComponent<TakeDamageOnTrigger>())
        {
            Hit();
        }
    }

    private void Hit()
    {
        Instantiate(EffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
