using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform Aim;
    public Camera PlayerCamera;
    public Transform PlayerRotation;

    private void LateUpdate()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(-Vector3.forward,Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        Aim.position = point;

        Vector3 toAim = Aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        float angel = Vector3.Angle(toAim, Vector3.right);

        RotatePlayer(angel);
    }

    private void RotatePlayer(float angel)
    {
        if (angel > 90f)
        {

            PlayerRotation.transform.rotation = Quaternion.Lerp(PlayerRotation.transform.rotation, Quaternion.Euler(0, 45f, 0), 10f * Time.deltaTime);
        }
        else
        {
            PlayerRotation.transform.rotation = Quaternion.Lerp(PlayerRotation.transform.rotation, Quaternion.Euler(0, -45f, 0), 10f * Time.deltaTime);
        }
    }
}
