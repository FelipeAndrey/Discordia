using UnityEngine;

public class LocalTrigger : MonoBehaviour
{
    public BargainManager bargainManager;
    public GameObject bargainTarget;
    private bool collided;
    public int ID { get; set; }
    private void Update()
    {
        if (collided)
        {
            foreach (Bargain target in bargainManager.Bargain)
            {
                if (target.bargainID == ID)
                {
                    bargainManager.Type = target.type.ToString();
                    bargainManager.Local(bargainTarget);
                    if (!this.GetComponent<DialogueTrigger>().manager.onDialogue)
                    {
                        return;
                    }
                    else
                    {
                        this.gameObject.SetActive(false);
                    }
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        collided = true;
    }
}
