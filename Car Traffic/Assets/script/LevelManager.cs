using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int CarCount;
    public GameObject WinningCanvas;
    // Start is called before the first frame update
    void Start()
    {
     WinningCanvas.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (CarCount == 0)
        {
            WinningCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }
}
