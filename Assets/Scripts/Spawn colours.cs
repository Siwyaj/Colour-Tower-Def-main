using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Spawncolours : MonoBehaviour
{
    [SerializeField] GameObject doneButton;
    public static float elapsedTime;
    public static bool timeStart = false;

    public AudioSource win;

    //Spawning stuff
    [SerializeField] GameObject colourCircle;
    [SerializeField] GameObject borderDonut;
    [SerializeField] GameObject blackBox;
    public Vector2 randomizePosition;
    public Color colorConverted;
    private int p;

    private int spawned;
    public static bool stage1 = false;
    public static List<Vector3> CIE1931xyCoordinates = new List<Vector3>() { new Vector3(0f,0f, 0f)};
    public List<Vector3> checkList;
    public static int maxSpawn = 99;
    public static Vector3 baseColourCord = new Vector3();

    public static GameObject showRemainingPanel;
    public GameObject remainingPanel;
    public TextMeshProUGUI remainingSpawns;

    //Stage 2 stuff
    public static bool stage2 = false;
    public Transform[] stage2Spots;
    public bool[] availableSpots;
    private List<GameObject> sortingGO = new List<GameObject>();
    //GameObject SDStage2;

    List<Vector3> stage2Cords = new List<Vector3>();
    bool runBool = false;

    private float stage2Start;

    //Level value
    public static int selectedLevel;

    // Start is called before the first frame update
    void Start()
    {
        //SDStage2 = GameObject.Find("Manager");
        showRemainingPanel = remainingPanel;
        elapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        remainingSpawns.text = "Remaining: " + checkList.Count.ToString();

        if (timeStart)
        {
            elapsedTime += Time.deltaTime;
        }

        checkList = CIE1931xyCoordinates;
        if (stage1)
        {
            if (spawned - (Move.disabledMove + Click.disabledClick) < 7 && CIE1931xyCoordinates.Count != 0)
            {
                SpawnDots();
                spawned++;
            }
        }
        //totalDisabled = Move.disabledMove + Click.disabledClick;
        if (Move.disabledMove + Click.disabledClick == maxSpawn)
        {
            stage1 = false;
            stage2 = true;
            stage2Start = elapsedTime;
            doneButton.SetActive(true);

            GameObject.Find("Main Camera").transform.position = new Vector3(0, -20, -10);
        }

        if (stage2 && !runBool)
        {
            showRemainingPanel.SetActive(false);

            Move.disabledMove = 0;
            Click.disabledClick = 0;
            
            Stage2SpawnDots();

            runBool = true;
        }
    }

    public void SpawnDots()
    {
        //var randomXY = Random.Range(0, (CIE1931xyCoordinates.Length - 1));
        Vector3 currentDot = CIE1931xyCoordinates[Random.Range(0, CIE1931xyCoordinates.Count)];
        CIE1931xyCoordinates.Remove(currentDot);
        colorConverted = blackBox.GetComponent<ConvertToP3>().Convert(currentDot);

        randomizePosition = new Vector2(Random.Range(-13f, -11f), Random.Range(-1f, -5f));

        GameObject circle = Instantiate(colourCircle, new Vector2(randomizePosition[0], randomizePosition[1]), Quaternion.identity);
        GameObject donut = Instantiate(borderDonut, new Vector2(randomizePosition[0], randomizePosition[1]), Quaternion.identity);

        //colourCircle.GetComponent<SpriteRenderer>().sortingOrder = +p;
        //borderDonut.GetComponent<SpriteRenderer>().sortingOrder = +p + 1;

        circle.GetComponent<SpriteRenderer>().color = colorConverted;

        circle.transform.SetParent(donut.transform);

        donut.GetComponent<Click>().id = currentDot;
        donut.GetComponent<data>().xyYCoordinate = currentDot;
        donut.GetComponent<data>().P3Color = colorConverted;
        donut.GetComponent<data>().xyYDistanceToBasexyY = blackBox.GetComponent<CalculateDistances>().CalculatexyYDistance(baseColourCord, currentDot);
        donut.GetComponent<data>().P3ColorDistanceToBase = blackBox.GetComponent<CalculateDistances>().CalculateP3Distance(blackBox.GetComponent<ConvertToP3>().Convert(baseColourCord), colorConverted);

        Click.allColours.Add(currentDot);
        Click.spawnedGO.Add(donut);
    }

    
    public void Stage2SpawnDots()
    {
        stage2Cords = blackBox.GetComponent<CalculateStage2coordinates>().Stage2Coordinates(Click.allColours, Click.letThroughColours, baseColourCord);

        for (int p = 0; p < stage2Cords.Count; p++)
        {
            Vector3 currentStage2Cord = stage2Cords[0];
            Color colourStage2Knight = blackBox.GetComponent<ConvertToP3>().Convert(currentStage2Cord);

            GameObject circle = Instantiate(colourCircle, new Vector2(-1000, -1000), Quaternion.identity);
            GameObject donut = Instantiate(borderDonut, new Vector2(-1000, -1000), Quaternion.identity);

            circle.GetComponent<SpriteRenderer>().color = colourStage2Knight;

            circle.transform.SetParent(donut.transform);

            GameObject randGO = donut;

            for (int i = 0; i < availableSpots.Length; i++)
            {
                if (availableSpots[i] == true)
                {
                    randGO.transform.position = stage2Spots[i].position;
                    randGO.GetComponent<Sorting>().transformIndex = stage2Spots[i];
                    availableSpots[i] = false;
                    sortingGO.Add(randGO);
                    stage2Cords.Remove(stage2Cords[0]);
                    break;
                }
            }
        }
    }

    public void ClearSortingGO()
    {
        foreach (var dot in sortingGO)
        {
            Destroy(dot);
        }
        for (int i = 0; i < availableSpots.Length; i++)
        {
            if (availableSpots[i] == false)
            {
                availableSpots[i] = true;
            }
        }
    }

    public void DoneSorting()
    {
        win.Play();

        stage2 = false;
        runBool = false;
        spawned = 0;
        timeStart = false;
        elapsedTime = 0;

        doneButton.SetActive(false);
        UI.showScoreScreen.SetActive(true);
        GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, -10);

        ClearSortingGO();
        ClearSpawnedGO();

        CreateText();
        Click.chosenColours.Clear();
        Click.letThroughColours.Clear();
        //Click.allColours.Clear();
        Click.sortedColours.Clear();
        Click.letThroughGO.Clear();
    }

    void CreateText()
    {
        string path = Application.persistentDataPath + "/Tower Defense Data log Juiced.csv";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Level Stage x y Time PositionX PositionY");
        }

        if (File.Exists(path))
        {
            File.AppendAllText(path, "\n");

            string level = selectedLevel.ToString();

            foreach (var y in Click.chosenColours)
            {
                string chosenData = level + " " + "1" + " " + y.Value[0] + " " + y.Value[1] + " " + y.Key;
                File.AppendAllText(path, chosenData);
                File.AppendAllText(path, "\n");
            }
            /*
            File.AppendAllText(path, "\n");
            File.AppendAllText(path, "Stage 2 start:" + stage2Start +"\n");
            File.AppendAllText(path, "Sorted: \n");
            */
            foreach (var x in Click.sortedColours)
            {
                string sortedData = level + " " + "2" + " " + x.Value[0] + " " + x.Value[1] + " " + x.Key;
                File.AppendAllText(path, sortedData);
                File.AppendAllText(path, "\n");
            }

            //File.AppendAllText(path, "Let through: \n");

            foreach (var x in Click.letThroughColours)
            {
                string letThroughData = level + " " + "3" + " " + x[0] + " " + x[1];
                File.AppendAllText(path, letThroughData);
                File.AppendAllText(path, "\n");
            }

        }
    }

    public void ClearSpawnedGO()
    {
        foreach (var go in Click.letThroughGO)
        {
            Destroy(go);
        }

        foreach (var dot in Click.spawnedGO)
        {
            Destroy(dot);
        }
    }

    public void QuitGame()
    {
        stage1 = false;
        stage2 = false;
        runBool = false;
        spawned = 0;
        timeStart = false;
        elapsedTime = 0;

        Move.disabledMove = 0;
        Click.disabledClick = 0;

        doneButton.SetActive(false);
        GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, -10);

        ClearSpawnedGO();
        
        ClearSortingGO();

        CreateText();
        Click.chosenColours.Clear();
        Click.letThroughColours.Clear();
        Click.sortedColours.Clear();
        Click.letThroughGO.Clear();
    }
}