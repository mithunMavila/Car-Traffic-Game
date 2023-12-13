using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class CarMovement : MonoBehaviour
{
    public SplineContainer mainRoute;
    public SplineContainer reverseRoute;

   private SplineAnimate spline;

    public LevelManager levelManager;
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        mainRoute = GetComponent<SplineContainer>();
        spline = GetComponent<SplineAnimate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        spline.Restart(true);
    }

   
    public void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("car") )
        {
            gameManager.Health -= 10;
        }
        if (collision.gameObject.CompareTag("human"))
        {
            gameManager.Health -= 20;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("finish"))
        {
            levelManager.CarCount--;
        }
    }
}
