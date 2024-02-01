using System.Collections;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    private Transform carTransform;
    public Vector3 offset = new Vector3(0.0f, 2.0f, 0.0f);
    public Transform destination;
    private Vector3 destinationPosition;
    public float duration = 3.0f;

    public LevelManager levelManager;
    public Transform start;
    private Vector3 startingPosition;
    public Transform pickup;

    public GameManager gameManager;

    void Start()
    {
        startingPosition = start.position;
        destinationPosition = destination.position;
    }

    public void MoveHelicopter(Transform carTransform)
    {
        this.carTransform = carTransform;

        StartCoroutine(MoveHelicopterCoroutine());
    }

    IEnumerator MoveHelicopterCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the percentage of time elapsed
            float t = elapsedTime / duration;

            // Use Lerp to smoothly move from the starting position to the car's position with an offset
            Vector3 targetPosition = carTransform.position + offset;
            transform.position = Vector3.Lerp(startingPosition, targetPosition, t);

            // Optionally, you can also rotate the helicopter to face the car
            // transform.LookAt(carTransform);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // After reaching the car, become the carrier and move to the destination
        BecomeCarrier();
        StartCoroutine(MoveToDestinationCoroutine());
    }

    void BecomeCarrier()
    {
        // Set the helicopter as the parent of the car
        carTransform.parent = transform;
        carTransform.localPosition = pickup.localPosition;
    }

    IEnumerator MoveToDestinationCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the percentage of time elapsed
            float t = elapsedTime / duration;

            // Use Lerp to smoothly move from the current position to the destination position
            transform.position = Vector3.Lerp(carTransform.position, destinationPosition, t);

            // Optionally, you can rotate the helicopter to face the destination
            transform.LookAt(destinationPosition);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // After reaching the destination, deactivate the car, decrement CarCount, and reset the position
        carTransform.gameObject.SetActive(false);
      
        levelManager.CarCount--;
        transform.position = startingPosition;
    }
}
