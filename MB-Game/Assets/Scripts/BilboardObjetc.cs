using UnityEngine;

public class BilboardObjetc : MonoBehaviour
{
    public GameManager manager;

    private void Start()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        transform.LookAt(manager.cameraAtual.transform);
    }
    private void OnTriggerStay(Collider other)
    {
        transform.LookAt(manager.cameraAtual.transform);
    }
    private void OnTriggerExit(Collider other)
    {

    }
}
