using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject blackBox;
    public GameObject tutorialScreen;
    public GameObject tutorialScreen2;

    public GameObject levelScreen;
    public static GameObject levelSelectScreen;

    public int score;
    public static GameObject showScoreScreen;
    public GameObject scoreScreen;
    public TextMeshProUGUI scoreText;

    public GameObject showRemainingPanel;

    //Ref colour stuff
    [SerializeField] GameObject bannerColour;
    [SerializeField] GameObject bannerColour2;
    //[SerializeField] GameObject castleColour;
    [SerializeField] GameObject guardsColour;
    [SerializeField] GameObject guardsColour2;
    [SerializeField] GameObject stageRefColour;

    Color stageColor;

    List<Vector2> allColourCords = new List<Vector2>();
    List<Vector2> halfAllColours = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        showRemainingPanel = Spawncolours.showRemainingPanel;
        showScoreScreen = scoreScreen;
        levelSelectScreen = levelScreen;

        string path = Application.persistentDataPath + "/Tower Defense Data log Juiced.csv";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Level Stage x y Time PositionX PositionY");
        }

        if (File.Exists(path))
        {
            File.AppendAllText(path, "\n");
            File.AppendAllText(path, "new participant");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreScreen()
    {
        showScoreScreen.SetActive(false);
        levelSelectScreen.SetActive(true);
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        levelSelectScreen.SetActive(true);
    }

    public void TutorialScreen()
    {
        startScreen.SetActive(false);
        tutorialScreen.SetActive(true);
    }

    public void NextTutorialScreen()
    {
        startScreen.SetActive(false);
        tutorialScreen.SetActive(false);
        tutorialScreen2.SetActive(true);
    }

    public void BackToStart()
    {
        startScreen.SetActive(true);
        tutorialScreen.SetActive(false);
        tutorialScreen2.SetActive(false);
    }

    public void Level1()
    {
        showRemainingPanel.SetActive(true);

        score = Random.Range(75, 95);
        scoreText.text = score.ToString() + "%";

        levelSelectScreen.SetActive(false);
        Spawncolours.timeStart = true;

        Spawncolours.selectedLevel = 1;
        Spawncolours.stage1 = true;

        stageColor = blackBox.GetComponent<ConvertToP3>().Convert(new Vector2(0.2f, 0.14f));
        bannerColour.GetComponent<SpriteRenderer>().color = stageColor;
        bannerColour2.GetComponent<SpriteRenderer>().color = stageColor;
        //castleColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour2.GetComponent<SpriteRenderer>().color = stageColor;
        stageRefColour.GetComponent<SpriteRenderer>().color = stageColor;
        Spawncolours.CIE1931xyCoordinates = blackBox.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(new Vector2(0.2f, 0.14f), 0.005f);
        Spawncolours.maxSpawn = Spawncolours.CIE1931xyCoordinates.Count;
    }

    public void Level2()
    {
        allColourCords.Clear();
        halfAllColours.Clear();

        showRemainingPanel.SetActive(true);

        score = Random.Range(75, 95);
        scoreText.text = score.ToString() + "%";

        levelSelectScreen.SetActive(false);
        Spawncolours.timeStart = true;

        Spawncolours.selectedLevel = 2;
        Spawncolours.stage1 = true;
        
        stageColor = blackBox.GetComponent<ConvertToP3>().Convert(new Vector2(0.55f, 0.4f));
        bannerColour.GetComponent<SpriteRenderer>().color = stageColor;
        bannerColour2.GetComponent<SpriteRenderer>().color = stageColor;
        //castleColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour2.GetComponent<SpriteRenderer>().color = stageColor;
        stageRefColour.GetComponent<SpriteRenderer>().color = stageColor;

        allColourCords = blackBox.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(new Vector2(0.55f, 0.4f), 0.0015f);
        for (int i = 0; i < 36; i++)
        {
            halfAllColours.Add(allColourCords[i]);
            allColourCords.Remove(allColourCords[i]);
            Debug.Log(i);
        }
        Spawncolours.CIE1931xyCoordinates = halfAllColours;
        Spawncolours.maxSpawn = Spawncolours.CIE1931xyCoordinates.Count;
    }

    public void Level2second()
    {
        allColourCords.Clear();
        halfAllColours.Clear();

        showRemainingPanel.SetActive(true);

        score = Random.Range(75, 95);
        scoreText.text = score.ToString() + "%";

        levelSelectScreen.SetActive(false);
        Spawncolours.timeStart = true;

        Spawncolours.selectedLevel = 2;
        Spawncolours.stage1 = true;

        stageColor = blackBox.GetComponent<ConvertToP3>().Convert(new Vector2(0.55f, 0.4f));
        bannerColour.GetComponent<SpriteRenderer>().color = stageColor;
        bannerColour2.GetComponent<SpriteRenderer>().color = stageColor;
        //castleColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour2.GetComponent<SpriteRenderer>().color = stageColor;
        stageRefColour.GetComponent<SpriteRenderer>().color = stageColor;

        allColourCords = blackBox.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(new Vector2(0.55f, 0.4f), 0.0015f);
        for (int i = 0; i < 36; i++)
        {
            halfAllColours.Add(allColourCords[i]);
            allColourCords.Remove(allColourCords[i]);
            Debug.Log(i);
        }
        Spawncolours.CIE1931xyCoordinates = allColourCords;
        Spawncolours.maxSpawn = Spawncolours.CIE1931xyCoordinates.Count;
    }

    public void Level3()
    {
        showRemainingPanel.SetActive(true);

        score = Random.Range(75, 95);
        scoreText.text = score.ToString() + "%";

        levelSelectScreen.SetActive(false);
        Spawncolours.timeStart = true;

        Spawncolours.selectedLevel = 3;
        Spawncolours.stage1 = true;
        
        stageColor = blackBox.GetComponent<ConvertToP3>().Convert(new Vector2(0.3f, 0.6f));
        bannerColour.GetComponent<SpriteRenderer>().color = stageColor;
        bannerColour2.GetComponent<SpriteRenderer>().color = stageColor;
        //castleColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour2.GetComponent<SpriteRenderer>().color = stageColor;
        stageRefColour.GetComponent<SpriteRenderer>().color = stageColor;
        Spawncolours.CIE1931xyCoordinates = blackBox.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(new Vector2(0.3f, 0.6f), 0.02f);
        Spawncolours.maxSpawn = Spawncolours.CIE1931xyCoordinates.Count;
    }

    public void Level4()
    {
        showRemainingPanel.SetActive(true);

        score = Random.Range(75, 95);
        scoreText.text = score.ToString() + "%";

        levelSelectScreen.SetActive(false);
        Spawncolours.timeStart = true;

        Spawncolours.selectedLevel = 4;
        Spawncolours.stage1 = true;

        stageColor = blackBox.GetComponent<ConvertToP3>().Convert(new Vector2(0.2f, 0.14f));
        bannerColour.GetComponent<SpriteRenderer>().color = stageColor;
        bannerColour2.GetComponent<SpriteRenderer>().color = stageColor;
        //castleColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour2.GetComponent<SpriteRenderer>().color = stageColor;
        stageRefColour.GetComponent<SpriteRenderer>().color = stageColor;
        Spawncolours.CIE1931xyCoordinates = blackBox.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(new Vector2(0.2f, 0.14f), 0.005f);
        Spawncolours.maxSpawn = Spawncolours.CIE1931xyCoordinates.Count;
    }

    public void Level5()
    {
        allColourCords.Clear();
        halfAllColours.Clear();

        showRemainingPanel.SetActive(true);

        score = Random.Range(75, 95);
        scoreText.text = score.ToString() + "%";

        levelSelectScreen.SetActive(false);
        Spawncolours.timeStart = true;

        Spawncolours.selectedLevel = 5;
        Spawncolours.stage1 = true;

        stageColor = blackBox.GetComponent<ConvertToP3>().Convert(new Vector2(0.55f, 0.4f));
        bannerColour.GetComponent<SpriteRenderer>().color = stageColor;
        bannerColour2.GetComponent<SpriteRenderer>().color = stageColor;
        //castleColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour2.GetComponent<SpriteRenderer>().color = stageColor;
        stageRefColour.GetComponent<SpriteRenderer>().color = stageColor;

        allColourCords = blackBox.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(new Vector2(0.55f, 0.4f), 0.0015f);
        for (int i = 0; i < 36; i++)
        {
            halfAllColours.Add(allColourCords[i]);
            allColourCords.Remove(allColourCords[i]);
            Debug.Log(i);
        }
        Spawncolours.CIE1931xyCoordinates = halfAllColours;
        Spawncolours.maxSpawn = Spawncolours.CIE1931xyCoordinates.Count;
    }

    public void Level5second()
    {
        allColourCords.Clear();
        halfAllColours.Clear();

        showRemainingPanel.SetActive(true);

        score = Random.Range(75, 95);
        scoreText.text = score.ToString() + "%";

        levelSelectScreen.SetActive(false);
        Spawncolours.timeStart = true;

        Spawncolours.selectedLevel = 5;
        Spawncolours.stage1 = true;

        stageColor = blackBox.GetComponent<ConvertToP3>().Convert(new Vector2(0.55f, 0.4f));
        bannerColour.GetComponent<SpriteRenderer>().color = stageColor;
        bannerColour2.GetComponent<SpriteRenderer>().color = stageColor;
        //castleColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour2.GetComponent<SpriteRenderer>().color = stageColor;
        stageRefColour.GetComponent<SpriteRenderer>().color = stageColor;

        allColourCords = blackBox.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(new Vector2(0.55f, 0.4f), 0.0015f);
        for (int i = 0; i < 36; i++)
        {
            halfAllColours.Add(allColourCords[i]);
            allColourCords.Remove(allColourCords[i]);
            Debug.Log(i);
        }
        Spawncolours.CIE1931xyCoordinates = allColourCords;
        Spawncolours.maxSpawn = Spawncolours.CIE1931xyCoordinates.Count;
    }

    public void Level6()
    {
        showRemainingPanel.SetActive(true);

        score = Random.Range(75, 95);
        scoreText.text = score.ToString() + "%";

        levelSelectScreen.SetActive(false);
        Spawncolours.timeStart = true;

        Spawncolours.selectedLevel = 6;
        Spawncolours.stage1 = true;

        stageColor = blackBox.GetComponent<ConvertToP3>().Convert(new Vector2(0.3f, 0.6f));
        bannerColour.GetComponent<SpriteRenderer>().color = stageColor;
        bannerColour2.GetComponent<SpriteRenderer>().color = stageColor;
        //castleColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour2.GetComponent<SpriteRenderer>().color = stageColor;
        stageRefColour.GetComponent<SpriteRenderer>().color = stageColor;
        Spawncolours.CIE1931xyCoordinates = blackBox.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(new Vector2(0.3f, 0.6f), 0.02f);
        Spawncolours.maxSpawn = Spawncolours.CIE1931xyCoordinates.Count;
    }

    public void Level7()
    {
        showRemainingPanel.SetActive(true);

        score = Random.Range(75, 95);
        scoreText.text = score.ToString() + "%";

        levelSelectScreen.SetActive(false);
        Spawncolours.timeStart = true;

        Spawncolours.selectedLevel = 7;
        Spawncolours.stage1 = true;

        stageColor = blackBox.GetComponent<ConvertToP3>().Convert(new Vector2(0.2f, 0.14f));
        bannerColour.GetComponent<SpriteRenderer>().color = stageColor;
        bannerColour2.GetComponent<SpriteRenderer>().color = stageColor;
        //castleColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour2.GetComponent<SpriteRenderer>().color = stageColor;
        stageRefColour.GetComponent<SpriteRenderer>().color = stageColor;
        Spawncolours.CIE1931xyCoordinates = blackBox.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(new Vector2(0.2f, 0.14f), 0.005f);
        Spawncolours.maxSpawn = Spawncolours.CIE1931xyCoordinates.Count;
    }

    public void Level8()
    {
        allColourCords.Clear();
        halfAllColours.Clear();

        showRemainingPanel.SetActive(true);

        score = Random.Range(75, 95);
        scoreText.text = score.ToString() + "%";

        levelSelectScreen.SetActive(false);
        Spawncolours.timeStart = true;

        Spawncolours.selectedLevel = 8;
        Spawncolours.stage1 = true;

        stageColor = blackBox.GetComponent<ConvertToP3>().Convert(new Vector2(0.55f, 0.4f));
        bannerColour.GetComponent<SpriteRenderer>().color = stageColor;
        bannerColour2.GetComponent<SpriteRenderer>().color = stageColor;
        //castleColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour2.GetComponent<SpriteRenderer>().color = stageColor;
        stageRefColour.GetComponent<SpriteRenderer>().color = stageColor;

        allColourCords = blackBox.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(new Vector2(0.55f, 0.4f), 0.0015f);
        for (int i = 0; i < 36; i++)
        {
            halfAllColours.Add(allColourCords[i]);
            allColourCords.Remove(allColourCords[i]);
            Debug.Log(i);
        }
        Spawncolours.CIE1931xyCoordinates = halfAllColours;
        Spawncolours.maxSpawn = Spawncolours.CIE1931xyCoordinates.Count;
    }

    public void Level8second()
    {
        allColourCords.Clear();
        halfAllColours.Clear();

        showRemainingPanel.SetActive(true);

        score = Random.Range(75, 95);
        scoreText.text = score.ToString() + "%";

        levelSelectScreen.SetActive(false);
        Spawncolours.timeStart = true;

        Spawncolours.selectedLevel = 8;
        Spawncolours.stage1 = true;

        stageColor = blackBox.GetComponent<ConvertToP3>().Convert(new Vector2(0.55f, 0.4f));
        bannerColour.GetComponent<SpriteRenderer>().color = stageColor;
        bannerColour2.GetComponent<SpriteRenderer>().color = stageColor;
        //castleColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour2.GetComponent<SpriteRenderer>().color = stageColor;
        stageRefColour.GetComponent<SpriteRenderer>().color = stageColor;

        allColourCords = blackBox.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(new Vector2(0.55f, 0.4f), 0.0015f);
        for (int i = 0; i < 36; i++)
        {
            halfAllColours.Add(allColourCords[i]);
            allColourCords.Remove(allColourCords[i]);
            Debug.Log(i);
        }
        Spawncolours.CIE1931xyCoordinates = allColourCords;
        Spawncolours.maxSpawn = Spawncolours.CIE1931xyCoordinates.Count;
    }

    public void Level9()
    {
        showRemainingPanel.SetActive(true);

        score = Random.Range(75, 95);
        scoreText.text = score.ToString() + "%";

        levelSelectScreen.SetActive(false);
        Spawncolours.timeStart = true;

        Spawncolours.selectedLevel = 9;
        Spawncolours.stage1 = true;

        stageColor = blackBox.GetComponent<ConvertToP3>().Convert(new Vector2(0.3f, 0.6f));
        bannerColour.GetComponent<SpriteRenderer>().color = stageColor;
        bannerColour2.GetComponent<SpriteRenderer>().color = stageColor;
        //castleColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour2.GetComponent<SpriteRenderer>().color = stageColor;
        stageRefColour.GetComponent<SpriteRenderer>().color = stageColor;
        Spawncolours.CIE1931xyCoordinates = blackBox.GetComponent<CalculateCIE1931xyCoordinates>().CreateCoordinates(new Vector2(0.3f, 0.6f), 0.02f);
        Spawncolours.maxSpawn = Spawncolours.CIE1931xyCoordinates.Count;
    }
}
