using UnityEngine;

public class TradeColor : Interactable
{
    public Material[] colors;
    private int x = 0;
    private Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = colors[x];

    }

    public override void Interact()
    {

        if (FindObjectOfType<Lantern>() == null)
            return;
        else if (FindObjectOfType<Lantern>().luzAtiva == true)
            NextColor();
        else
            return;
    }

    public void NextColor()
    {
        if (x < 2)
        {
            x++;
            rend.sharedMaterial = colors[x];
        }
        else
        {
            x = 0;
            rend.sharedMaterial = colors[x];
        }

    }


}
