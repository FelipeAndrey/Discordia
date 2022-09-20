public class PuzzleAto1 : Interactable
{
    private GameManager manager;
    public PuzzleTrigger trigger;

    private int puzzleValue;

    public override void Interact()
    {
        if (manager.player.lantern == null)
            return;
        else if (manager.player.lantern.luzAtiva == true)
        {
            RemoveWord();
        }
        else
            return;

    }

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
       
    }

    public void RemoveWord()
    {
        if (gameObject.CompareTag("godWord"))
        {
            puzzleValue += UnityEngine.Random.Range(1, 11);
        }
        else if (gameObject.CompareTag("badWord"))
        {
            puzzleValue -= UnityEngine.Random.Range(1, 6);
        }
        manager.puzzleValueFinal += puzzleValue;
        trigger.puzzleInteract.Add(gameObject);
        gameObject.SetActive(false);

    }
}

