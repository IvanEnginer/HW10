using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float Speed;
    public Transform Spawn;
    public Gun[] Guns;

    public ChargeIcon ChargeIcon;

    public float MaxCharge = 3f;
    private float _currentCharge;
    private bool _isCharged;

    private void Update()
    {
        if(_isCharged )
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                foreach ( var item in Guns )
                {
                    if(item.gameObject.activeSelf)
                    {
                        PlayerRigidbody.AddForce(-Spawn.forward * Speed, ForceMode.VelocityChange);
                        item.Shot();

                        _isCharged = false;
                        _currentCharge = 0f;
                        ChargeIcon.StartCharge();

                        break;
                    }
                }
            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            ChargeIcon.SetChargeValue(_currentCharge, MaxCharge);

            if (_currentCharge>= MaxCharge)
            {
                _isCharged= true;
                ChargeIcon.StopCharge();
            }
        }

    }
}
