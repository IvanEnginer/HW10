using UnityEngine;

public class Head : MonoBehaviour
{
    public Transform Target;

    private void Update()
    {
        transform.position = Target.position;    
    }
}
