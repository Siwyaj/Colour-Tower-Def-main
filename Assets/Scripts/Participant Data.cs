using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    /*
    string tempParticipantNumber;
    string tempParticipantAge;
    string tempParticipantName;
    string tempParticipantGender;
    string tempParticipantEyeCorrection;
    string tempParticipantNearFarSight;
    string tempParticipantEyeColour;
    string tempParticipantCountryBirth;
    string tempParticipantCurrentResidency;
    */

    [SerializeField] TMP_Text textParticipantNumber;
    [SerializeField] TMP_Text textParticipantName;
    [SerializeField] TMP_Text textParticipantAge;
    [SerializeField] TMP_Text textEyeColour;
    [SerializeField] TMP_Text textCountryBirth;
    [SerializeField] TMP_Text textCurrentResidency;

    //Buttons
    public Button maleButton;
    public Button femaleButton;
    public Button preferNotSayButton;

    public Button eyeCorrectYesButton;
    public Button eyeCorrectNoButton;

    public Button nearSightButton;
    public Button farSightButton;
    public Button bothSightButton;
    public Button neitherSightButton;

    List<string> participantData = new List<string>();
    List<string> tempParticipantData = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveParticipantData()
    {
        participantData.Add(participantNumber);
        participantData.Add(participantAge);
        participantData.Add(participantName);
        participantData.Add(participantGender);
        participantData.Add(participantEyeCorrection);
        participantData.Add(participantNearFarSight);
        participantData.Add(participantEyeColour);
        participantData.Add(participantCountryBirth);
        participantData.Add(participantCurrentResidency);

        tempParticipantData.Clear();
        /*
        textParticipantNumber.text = "";
        textParticipantAge.text = "";
        textParticipantName.text = "";
        textEyeColour.text = "";
        textCountryBirth.text = "";
        textCurrentResidency.text = "";
        */

        foreach (var participant in participantData) 
        {
            Debug.Log(participant);
        }
        foreach (var participant in tempParticipantData)
        {
            Debug.Log(participant);
        }
    }

    public void TempSaveParticipantData()
    {
        participantNumber = textParticipantNumber.text;
        participantAge = textParticipantAge.text;
        participantName = textParticipantName.text;

        participantEyeColour = textEyeColour.text;
        participantCountryBirth = textCountryBirth.text;
        participantCurrentResidency = textCurrentResidency.text;

        tempParticipantData.Add(participantNumber);
        tempParticipantData.Add(participantAge);
        tempParticipantData.Add(participantName);
        tempParticipantData.Add(participantGender);
        tempParticipantData.Add(participantEyeCorrection);
        tempParticipantData.Add(participantNearFarSight);
        tempParticipantData.Add(participantEyeColour);
        tempParticipantData.Add(participantCountryBirth);
        tempParticipantData.Add(participantCurrentResidency);

        foreach (var participant in tempParticipantData)
        {
            Debug.Log(participant);
        }
    }

    public void SetParticipantParticipantGenderMale()
    {
        participantGender = "Male";

        maleButton.interactable = false;
        femaleButton.interactable = true;
        preferNotSayButton.interactable = true;
    }

    public void SetParticipantParticipantGenderFemale()
    {
        participantGender = "Female";

        femaleButton.interactable = false;
        maleButton.interactable = true;
        preferNotSayButton.interactable = true;
    }

    public void SetParticipantParticipantGenderPreferNotToSay()
    {
        participantGender = "Prefer Not to say";

        preferNotSayButton.interactable = false;
        maleButton.interactable = true;
        femaleButton.interactable = true;
    }

    public void SetParticipantParticipantEyeCorrectionYes()
    {
        participantEyeCorrection = "Yes";

        eyeCorrectYesButton.interactable = false;
        eyeCorrectNoButton.interactable = true;
    }

    public void SetParticipantParticipantEyeCorrectionNo()
    {
        participantEyeCorrection = "No";

        eyeCorrectNoButton.interactable = false;
        eyeCorrectYesButton.interactable = true;
    }

    public void SetParticipantParticipantSightNear()
    {
        participantNearFarSight = "Near";

        nearSightButton.interactable = false;
        farSightButton.interactable = true;
        bothSightButton.interactable = true;
        neitherSightButton.interactable = true;
    }

    public void SetParticipantParticipantSightFar()
    {
        participantNearFarSight = "Far";

        farSightButton.interactable = false;
        nearSightButton.interactable = true;
        bothSightButton.interactable = true;
        neitherSightButton.interactable = true;
    }

    public void SetParticipantParticipantSightBoth()
    {
        participantNearFarSight = "Both";

        bothSightButton.interactable = false;
        nearSightButton.interactable = true;
        farSightButton.interactable = true;
        neitherSightButton.interactable = true;
    }

    public void SetParticipantParticipantSightNeither()
    {
        participantNearFarSight = "Neither";

        neitherSightButton.interactable = false;
        nearSightButton.interactable = true;
        farSightButton.interactable = true;
        bothSightButton.interactable = true;
    }
}
