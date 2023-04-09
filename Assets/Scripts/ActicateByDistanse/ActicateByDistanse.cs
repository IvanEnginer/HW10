using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ActicateByDistanse : MonoBehaviour
{
    public float DistanceToActivate = 20f;

    private bool _isActivate = true;
    private Activator _activator;
    private void Start()
    {
        _activator = FindObjectOfType<Activator>();
        _activator.ObjectsToActivate.Add(this);
    }

    public void CheckDistance(Vector3 playerPosition)
    {
        float distanse = Vector3.Distance(transform.position, playerPosition);

        if(_isActivate)
        {
            if (distanse > DistanceToActivate + 2f)
            {
                Deactivate();
            }
        }
        else
        {
            if (distanse < DistanceToActivate)
            {
                Actovate();
            }
        }

    }

    public void Actovate()
    {
        _isActivate= true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _isActivate= false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _activator.ObjectsToActivate.Remove(this);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, Vector3.forward, DistanceToActivate);
    }
#endif

}
