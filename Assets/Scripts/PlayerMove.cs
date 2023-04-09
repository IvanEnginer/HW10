using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool IsGrounded;

    public float MaxSpeed;

    public Transform ColliderTransform;

    private int _jumpFrameCounter;

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || IsGrounded == false)
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale,new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
        }
        else
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 15f);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded)
            {
                Jump();
            }
        }
    }

    public void Jump()
    {
        Rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
    }

    private void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (IsGrounded == false)
        {
            speedMultiplier = 0.2f;

            if (Rigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiplier = 0;
            }

            if (Rigidbody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplier = 0;
            }
        }

        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);

        if (IsGrounded)
        {
            Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15);
        }

        _jumpFrameCounter += 1;

        if(_jumpFrameCounter == 2)
        {
            Rigidbody.freezeRotation = false;
            Rigidbody.AddRelativeTorque(0f, 0f, 25f, ForceMode.VelocityChange);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        for(int i = 0; i < collision.contactCount; i++)
        {
            float angel = Vector3.Angle(collision.contacts[0].normal, Vector3.up);

            if (angel < 45f)
            {
                IsGrounded = true;
                Rigidbody.freezeRotation= true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }
}
