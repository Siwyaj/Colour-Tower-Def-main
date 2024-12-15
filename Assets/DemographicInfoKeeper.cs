using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemographicInfoKeeper : MonoBehaviour
{
    //LoggedVariables
    public static string participantNumber;
    public static string participantName;
    public static string participantAge;
    public static string participantSex;
    public static string needForEyeCorrection;
    public static string nearFarSight;
    public static string eyeColor;
    public static string countryOfBirth;
    public static string recidingCountry;

    public static void ResetDemographVariables()
    {
        participantNumber = "Number...";
        participantName = "Name...";
        participantAge = "Age...";
        participantSex = "No sex was set";
        needForEyeCorrection = "No eye correction was set...";
        nearFarSight = "No sight type was set...";
        eyeColor = "Eye color...";
        countryOfBirth = "Country of birth...";
        recidingCountry = "Reciding country...";
    }
}
