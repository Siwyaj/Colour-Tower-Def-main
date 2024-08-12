using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector2 target;
    private Vector2 position;

    [SerializeField] GameObject donut;
    static float speed = 1;
    bool spedUp = false;

    public static int disabledMove = 0;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 randomizePosition = new Vector2(8f, 2.0f);
        target = randomizePosition + new Vector2(Random.Range(0.0f, 0.0f), Random.Range(-1.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Spawncolours.stage2 == false)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);

            position = transform.position;
        }
    }
    
    public void SpeedUp()
    {
        speed = 3;
    }

    public void SpeedDown()
    {
        speed = 1;
    }

    //was moved to "Gate"
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Gate")
        {
            Click.letThroughColours.Add(donut.GetComponent<Click>().id);
            Click.letThroughGO.Add(donut);
            donut.SetActive(false);
            disabledMove++;
        }
    }
    */
}
