using UnityEngine;

public class Zadanie_2 : MonoBehaviour
{
    public float speed = 3.0f;

    private Vector3 startPosition;
    private float polDystans = 10.0f / 2;     //promień od pozycji początkowej
    private int zwrotPrawo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;     //start od pozycji początkowej
        zwrotPrawo = 1;         //w kierunku w prawo 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * zwrotPrawo * Vector3.right);       //przesunięcie w kierunku w prawo (1) lub w lewo (dla zwrotPrawo == -1)
        
        if (zwrotPrawo * (transform.position - startPosition).x >= polDystans)          //jeżeli pozycja poza promieniem od pozycji początkowej
        {
            transform.position = startPosition + new Vector3(zwrotPrawo * polDystans, 0, 0);       //wyrównanie do długości promienia zgodnie z bieżącym zwrotem
            zwrotPrawo = -1 * zwrotPrawo;           //zmiana kierunku, tzn. zwrotu na przeciwny
        }
    }
}
