using UnityEngine;

public class Bilboard : MonoBehaviour
{
    private Camera Cam;

    public bool useStaticBillboard;
    private bool seekCamera;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Temp), 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (seekCamera)
        {
            if (!useStaticBillboard)
            {
                transform.LookAt(Cam.transform);
            }
            else
            {
                transform.rotation = Cam.transform.rotation;
            }
        }

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }

    private void Temp()
    {

        Cam = Camera.main;
        seekCamera = true;
    }
}
