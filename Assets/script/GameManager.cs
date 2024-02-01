using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public int Health = 100;
    public GameObject LostCanavas;
    public GameObject PauseMenu;

    public HealthBar HealthBar;

   public bool IsPaused;
    public bool reversing = false;
    public bool helicopter=false;

    public static GameManager instance;

    public Text Hcount;
    public Text Rcount;

    public int heliCount = 1;
    public int ReveCount = 1;

   // private AudioSource carHorn;
   //public AudioClip carHornSound;

    // Start is called before the first frame update
    void Start()
    {
       // carHorn = GetComponent<AudioSource>();
        //carHornSound = GetComponent<AudioClip>();   
        //carHorn.Play();
        LostCanavas.SetActive(false);
        HealthBar.SetMaxHealth(Health);
        PauseMenu.SetActive(false);
        instance = this;  
        
        Hcount.text = heliCount.ToString();
        Rcount.text = ReveCount.ToString();    
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
       
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void Next()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1f;
    }

    public void heli()
    {
        if(heliCount>0)
        {
            reversing = false;
            helicopter = true;
            heliCount--;
            Hcount.text = heliCount.ToString();
        }
        
    }
    public void ReverseButtonClick()
    {
        if(ReveCount > 0)
        {
            helicopter = false;
            reversing = true;
            ReveCount--;
            Rcount.text = ReveCount.ToString();
        }
       

    }
}
