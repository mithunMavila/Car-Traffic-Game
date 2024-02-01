using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using DG.Tweening;

public class CarMovement : MonoBehaviour
{
    public SplineContainer mainRoute;
    public SplineContainer reverseRoute;

   private SplineAnimate spline;

    private LevelManager levelManager;
    private GameManager gameManager;

  //  public string newTag = "moving";

    private HelicopterMovement HelicopterMovement;

    private bool reversed;

    private Transform arrow;
    private Transform arrowR;
    public GameObject smoke;
    
    public GameObject Hallow;

    public GameObject coin;
    

    /*public float duration = 1f; // Duration of the shake effect
    public float strength = .02f; // Strength of the shake effect
    public int vibrato = 0; // Number of vibrations in the shake effect
    public float randomness = 0f;*/

    private Vector3 InitialCar;
    public GameObject hitEffect;
    public AudioSource crashingSound;
    public Animator CarShakeAnim;

    private bool mooving;
    

    // Start is called before the first frame update
    void Start()
    {
        mooving = false;
        CarShakeAnim = GetComponent<Animator>();
       
        gameManager=FindFirstObjectByType<GameManager>();
        levelManager = FindObjectOfType<LevelManager>();
        HelicopterMovement = FindFirstObjectByType<HelicopterMovement>();
        arrow = transform.Find("arrow");
        arrowR = transform.Find("arrowR");
        spline = GetComponent<SplineAnimate>();
        arrowR.gameObject.SetActive(false);
       InitialCar = transform.position;

       CarShakeAnim.Play("carShake");
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnMouseDown()
    {
        if (gameManager.reversing==false && gameManager.helicopter==false)
        {
            smoke.SetActive(true);
            mooving = true;
            CarShakeAnim.enabled=false;
          // gameObject.tag = newTag;
            if (!reversed)
            {
                spline.Container = mainRoute;
            }
            
            spline.Restart(true);
          
           
        }
        else if (gameManager.reversing==true && gameManager.helicopter==false)
        {
            //ParticleSystem HallowEffect = Instantiate(Hallow, transform.position, Quaternion.identity);

            // Create a rotation quaternion for a 90-degree rotation around the X-axis
          //  Quaternion rotation = Quaternion.Euler(90f, 0f, 0f);

            // Apply the rotation to the instantiated particle system
            //HallowEffect.transform.rotation = rotation;

           Hallow.SetActive(true);
            CarShakeAnim.enabled = true;
            CarShakeAnim.SetTrigger("Shake"); 
            //transform.DOShakeScale(.12f,0.8f,8,10f).SetEase(Ease.OutBack);
            reversed = true;
            arrow.gameObject.SetActive(false);
            arrowR.gameObject.SetActive(true);
      
            spline.Container = reverseRoute;
            gameManager.reversing = false;
        }
        else if(gameManager.reversing==false && gameManager.helicopter==true)
        {
            gameManager.helicopter= false;
            HelicopterMovement.MoveHelicopter(transform);
        }
        else
        {
            Debug.Log("error in heli");
        }

    }

   
    public void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("car") )
        {

            

            if(mooving)
            {
                Instantiate(hitEffect, transform.position + new Vector3(0, 0, .2f), Quaternion.identity);
                crashingSound.Play();
                spline.Pause();

                float rot = collision.transform.eulerAngles.y;
                // gameObject.transform.DOShakePosition(duration, strength, vibrato, randomness);
                collision.transform.DORotate(new Vector3(0, rot + 20, 0), 0.25f);
                StartCoroutine(returnCar(collision.transform, rot));

                StartCoroutine(ReverseAnimation());
                mooving = false;
                gameManager.HealthUpdate(20);
                smoke.SetActive(false);
            }
            

           


        }
        if (collision.gameObject.CompareTag("human"))
        {
            spline.Pause();
            StartCoroutine(ReverseAnimation());
            gameManager.HealthUpdate(20);
        }
    }
    IEnumerator returnCar(Transform collision,float rot)
    {
        Debug.Log("rotate");
        yield return new WaitForSeconds(.25f);
        collision.transform.DORotate(new Vector3(0, rot , 0), 0.25f);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("finish"))
        {
            levelManager.CarCount--;

            gameObject.SetActive(false);
            coin.SetActive(true);
           
            
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
        // gameObject.tag = "car";
        CarShakeAnim.enabled=true;
    }

   
}
