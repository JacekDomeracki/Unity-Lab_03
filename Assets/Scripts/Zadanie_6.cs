using UnityEngine;

public class Zadanie_6 : MonoBehaviour
{
    // na scenie są 2 obiekty tej klasy, jeden z targetem dla metody SmoothDamp, drugi z targetem dla metody Lerp
    public Transform targetSmoothDamp;
    public Transform targetLerp;
    float smoothTime = 0.3f;
    float xVelocity = 0.0f;
    float speed = 2.0f;

    void Update()
    {
        float newPosition = transform.position.x;       // wartość domyślna

        if (targetSmoothDamp != null && targetLerp == null)     // śledzenie tylko targetu dla metody SmoothDamp
        {
            newPosition = Mathf.SmoothDamp(transform.position.x, targetSmoothDamp.position.x, ref xVelocity, smoothTime);
        }
        if (targetSmoothDamp == null && targetLerp != null)     // śledzenie tylko targetu dla metody Lerp
        {
            newPosition = Mathf.Lerp(transform.position.x, targetLerp.position.x, speed * Time.deltaTime);
        }
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);      // podążanie na osi x za targetem
    }
}
