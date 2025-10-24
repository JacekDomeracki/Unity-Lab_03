using UnityEngine;

public class Zadanie_2 : MonoBehaviour
{
    public float speed = 4.0f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingForward = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(10f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = movingForward ? targetPosition : startPosition;
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            movingForward = !movingForward;
        }
    }
}
