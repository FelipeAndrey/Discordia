using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpped = 0.125f;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = player.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothSpped);

        transform.position = smoothPos;
    }
}
