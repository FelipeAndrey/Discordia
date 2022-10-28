using UnityEngine;

public class Lantern : MonoBehaviour
{
    public GameManager manager;
    public Light luz;
    public float intencidade = 1;
    public bool luzAtiva;

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.E))
        {
            luzAtiva = !luzAtiva;
            luz.gameObject.SetActive(luzAtiva);
        }
    }

}
