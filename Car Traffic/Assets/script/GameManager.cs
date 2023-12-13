using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Health = 100;
    public GameObject LostCanavas;
    public GameObject PauseMenu;

    public HealthBar HealthBar;

   public bool IsPaused;
    // Start is called before the first frame update
    void Start()
    {
        LostCanavas.SetActive(false);
        HealthBar.SetMaxHealth(Health);
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            LostCanavas.SetActive (true);
            Time.timeScale = 0f;
        }
    }

    public void HealthUpdate(int ReducedHealth)
    {
        Health -= ReducedHealth;
        HealthBar.SetHealth(Health);
    }


    public void resume()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        IsPaused = false;
    }
    public void pause()
    {
       
        if (!IsPaused)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            IsPaused = true;
        }
        else
        {
            resume();
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void heli()
    {
        Debug.Log("worked");
    }
}
