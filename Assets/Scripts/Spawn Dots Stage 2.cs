using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDotsStage2 : MonoBehaviour
{
    public Transform[] stage2Spots;
    public bool[] availableSpots;
    public List<GameObject> sortingGO = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Stage2SpawnDots()
    {
        if (Click.letThroughGO.Count >= 1)
        {
            GameObject randGO = Click.letThroughGO[Random.Range(0, Click.letThroughGO.Count)];
            for (int i = 0; i < availableSpots.Length; i++)
            {
                if (availableSpots[i] == true)
                {
                    randGO.gameObject.SetActive(true);
                    randGO.transform.position = stage2Spots[i].position;
                    randGO.GetComponent<Sorting>().transformIndex = stage2Spots[i];
                    availableSpots[i] = false;
                    sortingGO.Add(randGO);
                    Click.letThroughGO.Remove(randGO);
                    return;
                }
            }
        }
    }
    
}
