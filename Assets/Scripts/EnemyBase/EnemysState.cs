using UnityEngine;

public class EnemysState : MonoBehaviour
{
    [SerializeField] private float _distansToEnemyOfSet = 15;
    [SerializeField] private GameObject[] _enemys;

    private Transform _playerTransform;

    private void Update()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;

        for(int i = 0; i < _enemys.Length; i++)
        {
            if (_enemys[i] != null)
            {
                Vector3 toPlayer = _enemys[i].transform.position - _playerTransform.position;

                if (toPlayer.x < _distansToEnemyOfSet)
                {
                    _enemys[i].SetActive(true);
                }
            }
        }
    }
}
