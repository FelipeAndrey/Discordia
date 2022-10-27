using UnityEngine;

public class LanternRaycast : MonoBehaviour
{
    public GameManager manager;
    public Lantern Mesh;
    public float distanceToInteract = 10;
    private float valueRangeMax = 50;
    private float valueIntencMax = 300;
    private float valueIntencMin = 50;

    // Start is called before the first frame update
    void Start()
    {
        Mesh.luz.range = valueRangeMax;
        Mesh.luz.intensity = valueIntencMax;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hitInfo;

        if (Mesh.luzAtiva)
        {
            if (Physics.Raycast(manager.cameraAtual.transform.position, manager.cameraAtual.transform.forward, out hitInfo, distanceToInteract, LayerMask.GetMask("Ground")))
            {
                //luz.intensity = math.lerp(valueIntencMin, valueIntencMax, 5 * Time.deltaTime);
                Mesh.luz.intensity = valueIntencMin;
            }
            else
            {
                //luz.intensity = math.lerp(valueIntencMax, valueIntencMin, 1 * Time.deltaTime);
                Mesh.luz.intensity = valueIntencMax;
            }

        }
    }
}
