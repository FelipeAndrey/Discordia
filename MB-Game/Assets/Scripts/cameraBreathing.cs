using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBreathing : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera camera;
    public float min = -1f;
    public float max = 1f;
    [Range(0f, 1f)]
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
