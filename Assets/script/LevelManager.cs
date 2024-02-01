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
    [SerializeField] private coinReward coinReward;
    // Start is called before the first frame update
    void Start()
    {
     WinningCanvas.SetActive(false);
        gameover = false;
       // coinReward = GetComponent<coinReward>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CarCount == 0 && !gameover)
        {
            CarCount = -1;
            GameData.currentLevel++;
            gameover = true;
            WinningCanvas.SetActive(true);
            winning.Play();
            // Time.timeScale = 0f;
            Invoke("InvokeCountCoins", 1f);
        }
        
    }
    void InvokeCountCoins()
    {
        // Invoke the CountCoins() method from the coinReward script
        coinReward.CountCoins();
    }
}
