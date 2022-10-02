using UnityEngine;

public class Bilboard : MonoBehaviour
{
    private Camera Cam;

    public bool useStaticBillboard;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!useStaticBillboard)
        {
            transform.LookAt(Cam.transform);
        }
        else
        {
            transform.rotation = Cam.transform.rotation;
        }


        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
