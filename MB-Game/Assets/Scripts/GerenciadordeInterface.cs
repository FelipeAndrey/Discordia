using UnityEngine;
using UnityEngine.SceneManagement;


public class GerenciadordeInterface : MonoBehaviour
{
    public GameObject menus;
    public GameObject loading;
    public void NewGameBtN(string newGameLevel)
    {
        menus.SetActive(false);
        loading.SetActive(true);
        SceneManager.LoadScene(newGameLevel);
    }
    public void CreditsBTN(string CreditsLVL)
    {
        SceneManager.LoadScene(CreditsLVL);
    }
    public void OptionsBTN(string OptionsLVL)
    {
        SceneManager.LoadScene(OptionsLVL);
    }
    public void BackBTN(string Return)
    {
        SceneManager.LoadScene(Return);
    }
    public void ExitGameBtn()
    {
        Application.Quit();
    }
}