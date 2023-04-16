using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private int _totalSussecfulObject = 0;
    private int _totalObjectCount;
    public GameObject gas;
    public List<GameObject> puzzlePieces;
    public List<Transform> puzzleDots;
    public List<GameObject> places;
    public List<GameObject> selectPlaces;
    public List<GameObject> placed;
    public List<Transform> placeDots;
    public List<GameObject> selectedObject;
  
    public void Create()
    {
        
        int y = Random.Range(1, 4);

        _totalObjectCount = y;

        for (int i=0; i<y; i++)
        {
            int z;

            if (y == 1)
            {
                z = Random.Range(0, 6);
            }
            else if (y == 2)
            {
                z = Random.Range(0, 5);
            }
            else
            {
                z = Random.Range(0, 4);
            }

            selectedObject.Add(places[z]);
            selectPlaces.Add(placed[z]);
            puzzlePieces[z].SetActive(true);
            places[z].SetActive(true);
            puzzlePieces[z].transform.position = puzzleDots[i].position;

            places.RemoveAt(z);
            placed.RemoveAt(z);
            puzzlePieces.RemoveAt(z);

            int x = Random.Range(0, placeDots.Count);

            if (selectedObject[i].name == "Dikdörtgen  Eksik Parça Zemini")
            {
                placeDots[x].position = new Vector2(placeDots[x].transform.position.x, -4.22f);
            }
            else if (selectedObject[i].name == "Kare  Eksik Parça Zemini" || selectedObject[i].name == "Üçgen Eksik Parça Zemini")
            {
                placeDots[x].position = new Vector2(placeDots[x].transform.position.x, placeDots[x].transform.position.y);
            }
            else
            {
                placeDots[x].position = new Vector2(placeDots[x].transform.position.x, -4.55f);
            }

            selectedObject[i].transform.position = placeDots[x].position;
            selectPlaces[i].transform.position = placeDots[x].position;
            placeDots.RemoveAt(x);

        }
    }
    private void Start()
    {
        Create();
    }
    public void PieceCount()
    {
        _totalSussecfulObject++;
        if (_totalSussecfulObject == _totalObjectCount)
        {
            Debug.Log("NEXT LEVEL");
            gas.SetActive(true);
        }
    }
}
