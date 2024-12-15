using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevelWithColor : MonoBehaviour
{
    public int buttonLevel;
    //public GameObject pointPrefab;
    GameObject blackBox;
    public GameObject circleColor;
    Color levelP3Color;
    public Vector3 baseVector;

    List<Vector3> xyYBaseColors = new List<Vector3>()
    {
        new Vector3(210f/255f, 121f/255f, 117f/255f), //Level1
        new Vector3(216f/255f, 179f/255f, 90f/255f), //Level2
        new Vector3(127f/255f, 175f/255f, 120f/255f), //Level3
        new Vector3(66f/255f, 157f/255f, 179f/255f), //Level4
        new Vector3(116f/255f, 147f/255f, 194f/255f), //Level5
        new Vector3(190f/255f, 121f/255f, 154f/255f), //Level6
        new Vector3(249f/255f, 242f/255f, 238f/255f), //Level7
        new Vector3(161f/255f, 157f/255f, 154f/255f), //Level8
        new Vector3(43f/255f, 41f/255f, 43f/255f), //Level9
        new Vector3(192f/255f, 75f/255f, 145f/255f), //Level10
        new Vector3(245f/255f, 205f/255f, 0f/255f), //Level11
        new Vector3(186f/255f, 26f/255f, 51f/255f), //Level12
        new Vector3(57f/255f, 146f/255f, 64f/255f), //Level13
        new Vector3(25f/255f, 55f/255f, 135f/255f), //Level14
        new Vector3(222f/255f, 118f/255f, 32f/255f), //Level15
        new Vector3(195f/255f, 79f/255f, 95f/255f), //Level16
        new Vector3(83f/255f, 58f/255f, 106f/255f), //Level17
        new Vector3(98f/255f, 187f/255f, 166f/255f), //Level18
        new Vector3(126f/255f, 125f/255f, 174f/255f), //Level19
        new Vector3(82f/255f, 106f/255f, 60f/255f), //Level20
        new Vector3(197f/255f, 145f/255f, 125f/255f), //Level21
        new Vector3(112f/255f, 76f/255f, 60f/255f), //Level22
    };
    public List<Vector3> levelScore = new List<Vector3>();
    void Start()
    {
        baseVector = xyYBaseColors[buttonLevel - 1];
        blackBox = GameObject.FindGameObjectsWithTag("ColourMathBlackBox")[0];
        levelP3Color = blackBox.GetComponent<ConvertToP3>().convertBasesRGBToP3(baseVector);
        circleColor.GetComponent<RawImage>().color = levelP3Color;
    }

    public void setThisLevelInDataManager()
    {
        Debug.Log("DataManager data set");
        ColorData.baseColorP3 = levelP3Color;
        ColorData.levelNumber = buttonLevel;
        CalculatexyYCoordinates blackboxComponent = blackBox.GetComponent<CalculatexyYCoordinates>();
        Vector3 xyYBaseFromButton = baseVector;

        Spawncolours.CIE1931xyCoordinates = blackboxComponent.CreateCoordinates(xyYBaseFromButton);
        Spawncolours.baseColourCord = Spawncolours.CIE1931xyCoordinates[0];
        DataManager.setBaseColorxyY = Spawncolours.CIE1931xyCoordinates[0];
        DataManager.baseColorV3 = xyYBaseColors[buttonLevel - 1];
        DataManager.currentLevel = buttonLevel-1;

    }
}
