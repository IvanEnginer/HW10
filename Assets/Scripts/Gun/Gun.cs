using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Spawn;
    public float BulletSpeed = 10f;
    public float SpawnPeriod = 0.2f;

    public AudioSource ShotSound;
    public GameObject Flash;

    public ParticleSystem ShotEffect;

    private float _timer;

    private void Start()
    {
        Flash.SetActive(false);
    }

    private void Update()
    {
        _timer += Time.unscaledDeltaTime;

        if (Input.GetMouseButton(0)) 
        { 
            if (_timer > SpawnPeriod)     
            {
                _timer = 0;

                Shot();
            }
        }
    }

    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;
        ShotSound.Play();
        Flash.SetActive(true);

        Invoke(nameof(HideFlash), 0.12f);
        ShotEffect.Play();
    }

    public void HideFlash()
    {
        Flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int numberOfBullets)
    {

    }
}
