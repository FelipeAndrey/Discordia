using UnityEngine;

public class Dad : Interactable
{
    public GameObject Door;

    public override void Interact()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Some()
    {
        Destroy(gameObject);
        Destroy(Door);
    }
}
