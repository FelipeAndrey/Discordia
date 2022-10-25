using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public GameObject door;

    public void OnTriggerEnter(Collider other)
    {
        door.SetActive(true);
    }
}
