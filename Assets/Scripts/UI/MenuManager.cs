using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> menuTabs;
    public AudioManager audioManager { get; private set; }
    public void StartGame()
    {
        SceneManager.LoadScene(1); // запускаємо рівень гри
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OpenMenuTab(GameObject tab)
    {
        for(int i = 0; i < menuTabs.Count; i++)
        {
            if (menuTabs[i] == tab)
                menuTabs[i].SetActive(true);
            else
                menuTabs[i].SetActive(false);
        }
    }
    private void Start()
    {
        audioManager = GetComponent<AudioManager>();
    }
}
