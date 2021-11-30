using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu, levelMenu, optionsMenu, creditsMenu;

    private void Update()
    {
        if (InputManager.pauseInput && !mainMenu.activeSelf) Return();
    }

    public void Level1() => SceneManager.LoadScene(1);
    public void Level2() => SceneManager.LoadScene(2);
    public void Level3() => SceneManager.LoadScene(3);
    
    public void Play()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }
    
    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    
    public void Credits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }
    
    public void Return()
    {
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void Quit() => Application.Quit();
}
