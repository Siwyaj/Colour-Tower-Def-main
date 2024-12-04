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

    public GameObject homeButton;
    public GameObject showPauseScreen;

    GameObject SC;

    //Ref colour stuff
    [SerializeField] GameObject bannerColour;
    [SerializeField] GameObject bannerColour2;
    [SerializeField] GameObject castleColour;
    [SerializeField] GameObject castleColour2;
    [SerializeField] GameObject guardsColour;
    [SerializeField] GameObject guardsColour2;
    [SerializeField] GameObject stageRefColour;
    [SerializeField] GameObject colourSquare;
    //[SerializeField] GameObject colourSquare2;

    [SerializeField] GameObject participantDataPanel;
    [SerializeField] GameObject areYouSurePanel;

    public static bool gamePaused = false;

    Color stageColor;
    int level;

    List<Vector3> allColourCords = new List<Vector3>();
    List<Vector3> halfAllColours = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        SC = GameObject.Find("Manager");

        showRemainingPanel = Spawncolours.showRemainingPanel;
        showScoreScreen = scoreScreen;
        levelSelectScreen = levelScreen;
        /*
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
        */
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

    public void HomeButton()
    {
        Time.timeScale = 0f;
        showPauseScreen.SetActive(true);
        homeButton.SetActive(false);

        gamePaused = true;
    }

    public void HideHomeButton()
    {
        homeButton.SetActive(false);
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1f;
        showPauseScreen.SetActive(false);
        homeButton.SetActive(true);

        gamePaused = false;
    }

    public void QuitGameButton()
    {
        Time.timeScale = 1f;
        showPauseScreen.SetActive(false);
        showRemainingPanel.SetActive(false);

        gamePaused = false;

        string path = Application.persistentDataPath + "/Tower Defense Data log Juiced.csv";
        File.AppendAllText(path, "\n");
        File.AppendAllText(path, "Quit game before done");

        //Spawncolours.CIE1931xyCoordinates.Clear; this don't work?
        //Spawncolours.maxSpawn = 0;
        //done button stuff
        SC.GetComponent<Spawncolours>().QuitGame();
        //Rn don't work, spawns 16 after you quit and launch level?

        levelSelectScreen.SetActive(true);
    }

    public void ShowParticipantPanel()
    {
        participantDataPanel.SetActive(true);
    }

    public void CancelParticipant()
    {
        participantDataPanel.SetActive(false);
        Debug.Log("Cancel");
        //add stuff that reset the inputfields
    }

    public void AreYouSureParticipantPanel()
    {
        areYouSurePanel.SetActive(true);
    }

    public void AreYouSureParticipantCancel()
    {
        areYouSurePanel.SetActive(false);
        Debug.Log("Cancel 2");
    }

    public void AreYouSureParticipantSave()
    {
        areYouSurePanel.SetActive(false);
        participantDataPanel.SetActive(false);
        Debug.Log("yes saved");
        //Stuff is saved over in participant script in a list
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        levelSelectScreen.SetActive(true);
    }

    public void BackToStartFromLevel()
    {
        startScreen.SetActive(true);
        levelSelectScreen.SetActive(false);
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
    /*
    public void NewLevel1()
    {
        level = 1;
        Vector3 currentBasexyY = new Vector3(0.2296f, 0.2897f, 0.2815f);
        Spawncolours.baseColourCord = currentBasexyY;
        LevelStuff(currentBasexyY);
    }*/

    public void LevelStuff()//Vector3 basexyY
    {
        Debug.Log("levelstuff ran");
        Vector3 basexyY = DataManager.baseColorV3;
        Move.speed = 1;

        allColourCords.Clear();
        halfAllColours.Clear();

        showRemainingPanel.SetActive(true);
        homeButton.SetActive(true);

        score = Random.Range(75, 95);
        scoreText.text = score.ToString() + "%";

        levelSelectScreen.SetActive(false);
        Spawncolours.timeStart = true;

        Spawncolours.selectedLevel = level;
        Spawncolours.stage1 = true;

        stageColor = blackBox.GetComponent<ConvertToP3>().convertBasesRGBToP3(basexyY);
        ColorData.baseColorP3 = stageColor;
        Debug.Log("base color in DataManager.setBaseColorxyY: " + DataManager.setBaseColorxyY);
        Debug.Log("base color in Levelstuff: " + stageColor + " with xyY " + basexyY);
        bannerColour.GetComponent<SpriteRenderer>().color = stageColor;
        bannerColour2.GetComponent<SpriteRenderer>().color = stageColor;
        castleColour.GetComponent<SpriteRenderer>().color = stageColor;
        castleColour2.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour.GetComponent<SpriteRenderer>().color = stageColor;
        guardsColour2.GetComponent<SpriteRenderer>().color = stageColor;
        stageRefColour.GetComponent<SpriteRenderer>().color = stageColor;
        colourSquare.GetComponent<SpriteRenderer>().color = stageColor;

        
        Spawncolours.CIE1931xyCoordinates = blackBox.GetComponent<CalculatexyYCoordinates>().CreateCoordinates(basexyY);
        Debug.Log("spawned colors"+Spawncolours.CIE1931xyCoordinates.Count);
        Spawncolours.maxSpawn = Spawncolours.CIE1931xyCoordinates.Count;
    }

}
