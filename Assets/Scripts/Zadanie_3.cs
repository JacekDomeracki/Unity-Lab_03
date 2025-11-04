using UnityEngine;

public class Zadanie_3 : MonoBehaviour
{
    public float speed = 3.0f;

    private Vector3 centrPosition;
    private float polDystans = 10.0f / 2;     //promień od pozycji centralnej
    private Vector2Int zwrotXZ;             //współrzędna 'y' Vector2Int będzie odpowiadać współrzędnej 'z' Vector3

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        centrPosition = transform.position + (Vector3.right + Vector3.forward) * polDystans;     //ustalenie pozycji centralnej
        zwrotXZ = new Vector2Int(1, 0);         //start od pozycji początkowej, w kierunku w prawo
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * (zwrotXZ.x * Vector3.right + zwrotXZ.y * Vector3.forward), Space.World);
                //przesunięcie w kierunku w prawo/lewo (1/-1,0) lub do przodu/tyłu (0,1/-1)
        
        if (zwrotXZ.x * (transform.position - centrPosition).x >= polDystans || zwrotXZ.y * (transform.position - centrPosition).z >= polDystans)
                //jeżeli pozycja poza promieniem od pozycji centralnej
        {
            transform.position = centrPosition + new Vector3(zwrotXZ.x + zwrotXZ.y, 0, zwrotXZ.y - zwrotXZ.x) * polDystans;
            //wyrównanie do długości promienia zgodnie z bieżącym zwrotem

            zwrotXZ = new Vector2Int(-1 * zwrotXZ.y, zwrotXZ.x);        //zmiana kierunku, tzn. zwrotu na kolejny lewoskrętnie
            transform.Rotate(0, -90, 0, Space.World);                   //obrót zgodnie z kolejnym zwrotem
        }
    }
}
