using UnityEngine;
using UnityEngine.SceneManagement;

public class GoodEnding : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public GameObject Loading;
    private bool collided = false;

    private void Update()
    {
        /*if (collided)
        {
            dialogueTrigger.p_Dmanager.CanNext = true;
            if (dialogueTrigger.p_Dmanager.sentences.Count == 0 && Input.GetKeyDown(KeyCode.Space))
            {
                callGoodEndingScene();
            }
        }*/
    }

    public void callGoodEndingScene()
    {
        Loading.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("GoodEnd");
    }

    private void OnTriggerEnter(Collider other)
    {
        collided = true;
    }
}
