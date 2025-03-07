using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] float speed;
    public GameObject donutTarget;

    public GameObject audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
    }

    private void OnDestroy()
    {
        audioManager.GetComponent<Audiomanager>().PlayAudio();
    }

    // Update is called once per frame
    void Update()
    {
        if (donutTarget == null)
        {
            Destroy(arrow);
            Destroy(this);
            Destroy(transform);
        }
        if (donutTarget != null) 
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, donutTarget.transform.position, step);
            
            if (transform.position == donutTarget.transform.position)
            {
                Destroy(donutTarget);
                Destroy(arrow);
                Click.chosenColours.Add((Spawncolours.elapsedTime, donutTarget.transform.position), donutTarget.GetComponent<ColorData>().xyYCoordinate);
                Click.disabledClick++;
            }
        }
    }
}
