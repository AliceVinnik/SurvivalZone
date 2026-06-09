/*AliceVinnik*/

using UnityEngine;

public class TransformRotate : MonoBehaviour
{
    public bool isOn = true;
    [Space]
    public Vector3 dirrection = new Vector3(0f, 1f, 0f);
    public float speed = 50f;

    void Update()
    {
        if (!isOn) return;

        transform.Rotate(dirrection, Time.deltaTime * speed);
    }
}