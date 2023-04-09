using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private FixedJoint _fixJoint;
    public Rigidbody Rigidbody;

    public Collider Collider;
    public Collider PlayerCollider;

    public RopeGun RopeGun;

    private void Start()
    {
        Physics.IgnoreCollision(Collider, PlayerCollider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_fixJoint == null)
        {
            _fixJoint = gameObject.AddComponent<FixedJoint>();

            if (collision.rigidbody)
            {
                _fixJoint.connectedBody = collision.rigidbody;
            }

            RopeGun.CreateSpring();
        }
    }

    public void StopFix()
    {
        if(_fixJoint)
        {
            Destroy(_fixJoint);
        }
    }
}
