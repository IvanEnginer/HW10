using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public int Segments = 10;

    public void Draw(Vector3 a, Vector3 b,  float lenght)
    {
        LineRenderer.enabled = true;

        float interpolant = Vector3.Distance(a, b) / lenght;

        float offset = Mathf.Lerp(lenght / 2f, 0f, interpolant);

        Vector3 ADown = a + Vector3.down * offset;
        Vector3 BDown = b + Vector3.down * offset;

        LineRenderer.positionCount = Segments + 1;

        for (int i = 0; i < Segments+1; i++)
        {
            LineRenderer.SetPosition(i, Bezier.GetPoint(a, ADown, BDown, b, (float)i / Segments));
        }
    }

    public void Hide()
    {
        LineRenderer.enabled= false;
    }
}
