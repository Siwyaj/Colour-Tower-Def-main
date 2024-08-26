using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParticipantData : MonoBehaviour
{
    public static string participantNumber;
    public static string participantAge;
    public static string participantName;
    public static string participantGender;
    public static string participantEyeCorrection;
    public static string participantNearFarSight;
    public static string participantEyeColour;
    public static string participantCountryBirth;
    public static string participantCurrentResidency;

    [SerializeField] TMP_Text textParticipantNumber;
    [SerializeField] TMP_Text textParticipantName;
    [SerializeField] TMP_Text textParticipantAge;
    [SerializeField] TMP_Text textEyeColour;
    [SerializeField] TMP_Text textCurrentResidency;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SetParticipantNumber();
        //Debug.Log(participantNumber);
    }

    public void SetParticipantNumber()
    {
        participantNumber = textParticipantNumber.text;
    }

    public void SetParticipantAge()
    {
        //participantAge =
    }

    public void SetParticipantParticipantName()
    {
        //participantName = 
    }

    public void SetParticipantParticipantGenderMale()
    {
        //participantGender = "Male";
    }

    public void SetParticipantParticipantGenderFemale()
    {
        //participantGender = "Female";
    }

    public void SetParticipantParticipantGenderPreferNotToSay()
    {
        //participantGender = "Prefer Not to say";
    }

    public void SetParticipantParticipantEyeCorrectionYes()
    {
        participantEyeCorrection = "Yes";
    }

    public void SetParticipantParticipantEyeCorrectionNo()
    {
        participantEyeCorrection = "No";
    }

    public void SetParticipantParticipantSightNear()
    {
        participantNearFarSight = "Near";
    }

    public void SetParticipantParticipantSightFar()
    {
        participantNearFarSight = "Far";
    }

    public void SetParticipantParticipantSightBoth()
    {
        participantNearFarSight = "Both";
    }

    public void SetParticipantParticipantSightNeither()
    {
        participantNearFarSight = "Neither";
    }

    public void SetParticipantParticipantEyeColour()
    {
        //participantEyeColour = 
    }

    public void SetParticipantCountryBirth()
    {
        //participantCountryBirth = 
    }

    public void SetParticipantCurrentResidency()
    {
        //participantCurrentResidency = 
    }
}
