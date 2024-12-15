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

    public TMP_InputField participantNumberField;//number
    public TMP_InputField participantNameField;//name
    public TMP_InputField participantAgeField;//age
    public TMP_InputField participantEyeColorField;//EyeColor
    public TMP_InputField participantCOfBirthField;//Country of birth
    public TMP_InputField participantRecidingCField;//Reciding Contry

    public TMP_Text textParticipantNumber;
    [SerializeField] TMP_Text textParticipantName;
    [SerializeField] TMP_Text textParticipantAge;
    [SerializeField] TMP_Text textEyeColour;
    [SerializeField] TMP_Text textCountryBirth;
    [SerializeField] TMP_Text textCurrentResidency;


    static string particpantSexTemp = "No sex was set...";
    static string needForEyeCorrectionTemp = "No eye correction was set...";
    static string nearFarSightTemp = "No sight type was set...";

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
        participantNumber = participantNumberField.text;
        participantAge = participantAgeField.text;
        participantName = participantNameField.text;
        participantEyeColour = participantEyeColorField.text;
        participantCountryBirth = participantCOfBirthField.text;
        participantCurrentResidency = participantRecidingCField.text;
        participantEyeCorrection = needForEyeCorrectionTemp;
        participantGender = particpantSexTemp;
        participantNearFarSight = nearFarSightTemp;

        //reset level results
        DataManager.levelResults = new List<List<Vector3>>() {
        new List<Vector3>(), //level1
        new List<Vector3>(), //level2
        new List<Vector3>(), //level3
        new List<Vector3>(), //level4
        new List<Vector3>(), //level5
        new List<Vector3>(), //level6
        new List<Vector3>(), //level7
        new List<Vector3>(), //level8
        new List<Vector3>(), //level9
        new List<Vector3>(), //level10
        new List<Vector3>(), //level11
        new List<Vector3>(), //level12
        new List<Vector3>(), //level13
        new List<Vector3>(), //level14
        new List<Vector3>(), //level15
        new List<Vector3>(), //level16
        new List<Vector3>(), //level17
        new List<Vector3>(), //level18
        new List<Vector3>(), //level19
        new List<Vector3>(), //level20
        new List<Vector3>(), //level21
        new List<Vector3>(), //level22
        };
    }

    public void ResetDemographVariables()
    {
        participantNumberField.text = "Number...";
        participantNameField.text = "Name...";
        participantAgeField.text = "Age...";
        participantEyeColorField.text = "Eye color...";
        participantCOfBirthField.text = "Country of birth...";
        participantRecidingCField.text = "Reciding country...";

        maleButton.interactable = true;
        femaleButton.interactable = true;
        preferNotSayButton.interactable = true;
        eyeCorrectYesButton.interactable = true;
        eyeCorrectNoButton.interactable = true;
        nearSightButton.interactable = true;
        farSightButton.interactable = true;
        bothSightButton.interactable = true;
        neitherSightButton.interactable = true;


    }
    public void Cancel()
    {
        //Sets the participant data based on saved in static
        participantNumberField.text = participantNumber;
        participantAgeField.text = participantAge;
        participantNameField.text = participantName;
        participantEyeColorField.text = participantEyeColour;
        participantCOfBirthField.text = participantCountryBirth;
        participantRecidingCField.text = participantCurrentResidency;

        maleButton.interactable = true;
        femaleButton.interactable = true;
        preferNotSayButton.interactable = true;
        eyeCorrectYesButton.interactable = true;
        eyeCorrectNoButton.interactable = true;
        nearSightButton.interactable = true;
        farSightButton.interactable = true;
        bothSightButton.interactable = true;
        neitherSightButton.interactable = true;

        if(participantGender == "Male")
        {
            maleButton.interactable = false;
        }
        else if (participantGender == "Female")
        {
            femaleButton.interactable = false;
        }
        else if (participantGender == "Prefer Not to say")
        {
            preferNotSayButton.interactable = false;
        }

        if(participantEyeCorrection == "Yes")
        {
            eyeCorrectYesButton.interactable = false;
        }
        else if (participantEyeCorrection == "No")
        {
            eyeCorrectNoButton.interactable = false;
        }
        switch (participantNearFarSight)
        {
            case "Near":
                nearSightButton.interactable = false;
                break;
            case "Far":
                farSightButton.interactable = false;
                break;
            case "Both":
                bothSightButton.interactable = false;
                break;
            case "Neither":
                neitherSightButton.interactable = false;
                break;
        }

    }

    public void SetParticipantParticipantGenderMale()
    {
        particpantSexTemp = "Male";

        maleButton.interactable = false;
        femaleButton.interactable = true;
        preferNotSayButton.interactable = true;
    }

    public void SetParticipantParticipantGenderFemale()
    {
        particpantSexTemp = "Female";

        femaleButton.interactable = false;
        maleButton.interactable = true;
        preferNotSayButton.interactable = true;
    }

    public void SetParticipantParticipantGenderPreferNotToSay()
    {
        particpantSexTemp = "Prefer Not to say";

        preferNotSayButton.interactable = false;
        maleButton.interactable = true;
        femaleButton.interactable = true;
    }

    public void SetParticipantParticipantEyeCorrectionYes()
    {
        needForEyeCorrectionTemp = "Yes";

        eyeCorrectYesButton.interactable = false;
        eyeCorrectNoButton.interactable = true;
    }

    public void SetParticipantParticipantEyeCorrectionNo()
    {
        needForEyeCorrectionTemp = "No";

        eyeCorrectNoButton.interactable = false;
        eyeCorrectYesButton.interactable = true;
    }

    public void SetParticipantParticipantSightNear()
    {
        nearFarSightTemp = "Near";

        nearSightButton.interactable = false;
        farSightButton.interactable = true;
        bothSightButton.interactable = true;
        neitherSightButton.interactable = true;
    }

    public void SetParticipantParticipantSightFar()
    {
        nearFarSightTemp = "Far";

        farSightButton.interactable = false;
        nearSightButton.interactable = true;
        bothSightButton.interactable = true;
        neitherSightButton.interactable = true;
    }

    public void SetParticipantParticipantSightBoth()
    {
        nearFarSightTemp = "Both";

        bothSightButton.interactable = false;
        nearSightButton.interactable = true;
        farSightButton.interactable = true;
        neitherSightButton.interactable = true;
    }

    public void SetParticipantParticipantSightNeither()
    {
        nearFarSightTemp = "Neither";

        neitherSightButton.interactable = false;
        nearSightButton.interactable = true;
        farSightButton.interactable = true;
        bothSightButton.interactable = true;
    }
}
