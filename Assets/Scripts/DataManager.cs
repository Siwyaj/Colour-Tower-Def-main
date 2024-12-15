using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static List<List<Vector3>> levelResults = new List<List<Vector3>>() {
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

    public List<Vector3> level1ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level2ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level3ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level4ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level5ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level6ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level7ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level8ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level9ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level10ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level11ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level12ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level13ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level14ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level15ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level16ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level17ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level18ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level19ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level20ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level21ResultsPublic = new List<Vector3>() { };
    public List<Vector3> level22ResultsPublic = new List<Vector3>() { };

    public static int currentLevel;
    public static GameObject LevelGameObject;
    public static Vector3 setBaseColorxyY;
    public static Vector3 baseColorV3;
    public static bool sameColor = false;

    private void FixedUpdate()
    {
        level1ResultsPublic = levelResults[0];
        level2ResultsPublic = levelResults[1];
        level3ResultsPublic = levelResults[2];
        level4ResultsPublic = levelResults[3];
        level5ResultsPublic = levelResults[4];
        level6ResultsPublic = levelResults[5];
        level7ResultsPublic = levelResults[6];
        level8ResultsPublic = levelResults[7];
        level9ResultsPublic = levelResults[8];
        level10ResultsPublic = levelResults[9];
        level11ResultsPublic = levelResults[10];
        level12ResultsPublic = levelResults[11];
        level13ResultsPublic = levelResults[12];
        level14ResultsPublic = levelResults[13];
        level15ResultsPublic = levelResults[14];
        level16ResultsPublic = levelResults[15];
        level17ResultsPublic = levelResults[16];
        level18ResultsPublic = levelResults[17];
        level19ResultsPublic = levelResults[18];
        level20ResultsPublic = levelResults[19];
        level21ResultsPublic = levelResults[20];
        level22ResultsPublic = levelResults[21];

    }
}
