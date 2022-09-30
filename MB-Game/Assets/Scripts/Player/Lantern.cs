using UnityEngine;

public class Lantern : MonoBehaviour
{
    public GameManager manager;
    public Light luz;
    public float intencidade = 1;
    public bool luzAtiva;
    public float distanceToInteract = 10;
    private float valueRangeMax = 50;
    private float valueIntencMax = 1000;
    private float valueIntencMin = 50;


    private void Start()
    {
        GetComponentInChildren<Light>();

        luz.range = valueRangeMax;
        luz.intensity = valueIntencMax;
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.E))
        {
            luzAtiva = !luzAtiva;
            luz.gameObject.SetActive(luzAtiva);
        }
        if (luzAtiva)
        {
            if (Physics.Raycast(manager.cameraAtual.transform.position, manager.cameraAtual.transform.forward, out hitInfo, distanceToInteract, LayerMask.GetMask("Ground", "Scenary")))
            {
                //luz.intensity = math.lerp(valueIntencMin, valueIntencMax, 5 * Time.deltaTime);
                luz.intensity = valueIntencMin;
            }
            else
            {
                //luz.intensity = math.lerp(valueIntencMax, valueIntencMin, 5 * Time.deltaTime);
                luz.intensity = valueIntencMax;
            }

        }
    }

}
