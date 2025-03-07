using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class dataWriter : MonoBehaviour
{


    string tempDataPath = Application.dataPath + "/TDTemp.csv";
    string DataPath = Application.dataPath + "/TDData.csv";
    // Start is called before the first frame update
    void Start()
    {
        
        File.Create(tempDataPath).Close();
        
        if (!File.Exists(DataPath))
        {
            {
                File.WriteAllText(DataPath, "part_nr;" +
                "participant_name;" +
                "date_and_time;" +
                "time_on_screen;" +
                "time_since_last_pop;" +
                "xyY(x);" +
                "xyY(y);" +
                "xyY(Y);" +
                "P3_R;" +
                "P3_G;" +
                "P3_B;" +
                "base_P3_x;" +
                "base_P3_y;" +
                "base_P3_Y;" +
                "base_P3_R;" +
                "base_P3_G;" +
                "base_P3_B;" +
                "differentiated?;" +
                "distance_to_base_xyY;" +
                "distamce_to_base_P3;" +
                "lvl_nr;stage_nr;" +
                "part_age;" +
                "part_sex;" +
                "part_eye_correct;" +
                "part_nearfar;" +
                "part_eye_color;" +
                "part_birth;" +
                "part_reciding;" +
                "place_on_screen(x);" +
                "place_on_screen(y)");
            }
        }
    }

}
