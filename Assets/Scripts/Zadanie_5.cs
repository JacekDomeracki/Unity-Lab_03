using System.Collections.Generic;
using UnityEngine;

public class Zadanie_5 : MonoBehaviour
{
    // Reference to the prefab. Drag a prefab into this field in the Inspector.
    public GameObject myPrefab;

    // This script will simply instantiate the prefab when the game starts.
    void Start()
    {
        // kostki będą rozmieszczone w węzłach kraty 9 na 9, na płaszczyźnie 10 na 10, punkt centralny (0,0,0)

        List<int> seria_liczb = new List<int>();
        for (int i = 0; i < 81; i++)            // lista 81 różnych wartości dla 81 węzłów
        {
            seria_liczb.Add(i);
        }

        System.Random random = new System.Random();         // systemowy generator liczb losowych
        int index_seli, value_seli;
        float x, y, z;

        for (int i = 0; i < 10; i++)        // losowanie 10 różnych wartości z listy
        {
            index_seli = random.Next(seria_liczb.Count);    // losowanie pozycji na liście, w kolejnych iteracjach bez wcześniej wylosowanych wartości
            value_seli = seria_liczb[index_seli];           // wartość na wylosowanej pozycji -> zidentyfikowany wylosowany węzeł
            seria_liczb.Remove(value_seli);                 // usunięcie z listy tej wylosowanej wartości

            x = value_seli % 9 - 4;                         // dla wylosowanego węzła obliczenie kolumny (współrzędna x) z zakresu od -4 do 4
            y = myPrefab.transform.localScale.y / 2;        // podniesienie podstawy kostki do poziomu płaszczyzny
            z = value_seli / 9 - 4;                         // dla wylosowanego węzła obliczenie wiersza (współrzędna z) z zakresu od -4 do 4

            // Instantiate at position (x, y, z) and zero rotation.
            Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
        }
    }
}
