using UnityEngine;

public class Zadanie_4 : MonoBehaviour
{
    public float speed = 5.0f;

    private float halfPlane = 20.0f / 2;      // pół boku płaszczyzny, kwadrat, środek w punkcie (0,0,0)
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        // pobranie wartości zmiany pozycji w danej osi
        // wartości są z zakresu [-1, 1]
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");

        // tworzymy wektor prędkości
        Vector3 velocity = speed * Time.deltaTime * new Vector3(mH, 0, mV).normalized;

        // przesunięcie Rigidbody z uwzględnieniem sił fizycznych
        Vector3 newPosition = transform.position + velocity;

        // ograniczenie pozycji w obrębie płaszczyzny
        newPosition.x = Mathf.Clamp(newPosition.x, -halfPlane, halfPlane);
        newPosition.z = Mathf.Clamp(newPosition.z, -halfPlane, halfPlane);

        // wykonujemy przesunięcie Rigidbody
        rb.MovePosition(newPosition);        
    }
}
