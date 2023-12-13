using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Health = 100;
    public GameObject LostCanavas;
    // Start is called before the first frame update
    void Start()
    {
        LostCanavas.SetActive(false);
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
}
