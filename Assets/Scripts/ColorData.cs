using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ColorData : MonoBehaviour
{
    public static int levelNumber;
    bool? selected;
    int stagenr;
    public static float timeSinceLastPress;
    public Vector3 xyYCoordinate;
    public Color P3Color;
    public float xyYDistanceToBasexyY;
    public float P3ColorDistanceToBase;
    float timeAlive;
    public static Color baseColorP3;
    public static Vector3 baseVectorP3;

    string path = Application.dataPath + "/TDTemp.csv";

    public void Selected()
    {
        selected = true;
        LogDataForPoint();
        timeSinceLastPress = 0;
        selected = null;
    }
    public void NotSelected()
    {
        selected = false;
        LogDataForPoint();
        selected = null;
    }

    private void FixedUpdate()
    {
        timeAlive += Time.deltaTime;
        timeSinceLastPress += Time.deltaTime;
    }
    
    public void LogDataForPoint()
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }

        stagenr = 999;//for errors
        if (Spawncolours.stage1)
        {
            stagenr = 1;
        }
        else
        {
            stagenr = 2;
        }

        string dataToBewritten = "\n" + ParticipantData.participantNumber + ";" +
            ParticipantData.participantName + ";" +
            System.DateTime.Now + ";" + timeAlive + ";" +
            timeSinceLastPress + ";" +
            xyYCoordinate[0] + ";" +
            xyYCoordinate[1] + ";" +
            xyYCoordinate[2] + ";" +
            P3Color[0] + ";" +
            P3Color[1] + ";" +
            P3Color[2] + ";" +
            Spawncolours.baseColourCord[0] + ";" +
            Spawncolours.baseColourCord[1] + ";" +
            Spawncolours.baseColourCord[2] + ";" +
            baseColorP3[0] + ";" +
            baseColorP3[1] + ";" +
            baseColorP3[2] + ";" +
            selected + ";" +
            xyYDistanceToBasexyY + ";" +
            P3ColorDistanceToBase + ";" +
            DataManager.currentLevel + ";" + //fix self
            stagenr + ";" +
            ParticipantData.participantAge + ";" +
            ParticipantData.participantGender + ";" +
            ParticipantData.participantEyeCorrection + ";" +
            ParticipantData.participantNearFarSight + ";" +
            ParticipantData.participantEyeColour + ";" +
            ParticipantData.participantCountryBirth + ";" +
            ParticipantData.participantCurrentResidency + ";" +
            transform.position.x + ";" +
            transform.position.y;

        
        
        
        //Debug.Log("logged: " + dataToBewritten);
        File.AppendAllText(path, dataToBewritten, new UTF8Encoding(false));
    }

}
