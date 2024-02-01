using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameData GameData;
    public int CarCount;
    public GameObject WinningCanvas;
    public bool gameover;

    public ParticleSystem winning;
    // Start is called before the first frame update
    void Start()
    {
     WinningCanvas.SetActive(false);
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CarCount == 0 && !gameover)
        {
            
            GameData.currentLevel++;
            gameover = true;
            WinningCanvas.SetActive(true);
            winning.Play();
           // Time.timeScale = 0f;
        }
        
    }
}
