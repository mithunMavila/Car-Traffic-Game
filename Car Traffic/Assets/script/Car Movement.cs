using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class CarMovement : MonoBehaviour
{
    public SplineContainer mainRoute;
    public SplineContainer reverseRoute;

   private SplineAnimate spline;


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
}
