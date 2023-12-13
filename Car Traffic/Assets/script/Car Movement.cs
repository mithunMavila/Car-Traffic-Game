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

    public string newTag = "moving";


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
        gameObject.tag = newTag;
        spline.Restart(true);

    }

   
    public void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("car") )
        {
            spline.Pause();
            StartCoroutine(ReverseAnimation());

            gameManager.HealthUpdate(20);


        }
        if (collision.gameObject.CompareTag("human"))
        {
            gameManager.HealthUpdate(20);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("finish"))
        {
            levelManager.CarCount--;
            gameObject.SetActive(false);
        }
    }
    private IEnumerator ReverseAnimation()
    {
        float duration = spline.ElapsedTime;
        float elapsedTime = 0.001f;
       
        while (elapsedTime < duration && spline.ElapsedTime > 0f)
        {
            spline.ElapsedTime -= Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
        gameObject.tag = "car";
    }
}
