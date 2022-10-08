using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEnding : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public GameObject Loading;
    private bool collided = false;

    private void Update()
    {
        if (collided)
        {
            dialogueTrigger.manager.canNext = true;
            if (dialogueTrigger.manager.sentences.Count == 0 && Input.GetKeyDown(KeyCode.Space))
            {
                callGoodEndingScene();
            }
        }
    }

    public void callGoodEndingScene()
    {
        Loading.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("BadEnd");
    }

    private void OnTriggerEnter(Collider other)
    {
        collided = true;
    }
}
