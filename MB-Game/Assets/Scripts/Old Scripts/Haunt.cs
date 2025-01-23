using UnityEngine;

public class Haunt : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public GameObject GoodEnding;
    public GameObject mark;

    void Update()
    {
        /*if (dialogueTrigger.collided)
        {
            dialogueTrigger.p_Dmanager.CanNext = true;
            if (dialogueTrigger.p_Dmanager.sentences.Count == 0 && Input.GetKeyDown(KeyCode.Space))
            {
                GoodEnding.SetActive(true);
                //dialogueTrigger.manager.canNext = false;
                this.gameObject.GetComponent<DialogueTrigger>().enabled = false;
                mark.SetActive(true);
            }
        }*/
    }
}
