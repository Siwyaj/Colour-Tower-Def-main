using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class ScoreHandler : MonoBehaviour
{
    public GameObject maxDistancePoint;
    public Material triangleMaterial;
    private CanvasRenderer gamutFieldCanvasRendere;

    float maxxyYValues = 0.014f;

    //FakeValues for test
    
    float maxSpaceValues;



   
    private void Awake()
    {
        // Get the CanvasRenderer component attached to the GameObject
        gamutFieldCanvasRendere = gameObject.GetComponent<CanvasRenderer>();

        if (gamutFieldCanvasRendere == null)
        {
            Debug.LogError("CanvasRenderer component missing on this GameObject.");
        }
    }




    public void SetUserGamut(List<Vector3> stage2Endpoints, Vector3 baseCoord)
    {
        Debug.Log("endpoint count in score handler:" + stage2Endpoints.Count);
        // Get the CanvasRenderer component attached to the GameObject
        gamutFieldCanvasRendere = gameObject.GetComponent<CanvasRenderer>();

        foreach(Vector3 endpoint in stage2Endpoints)
        {
            Debug.Log("endpoints contains(*100): " + endpoint*100);
        }
        Debug.Log("BaseVector(*100): " + baseCoord);

        if (gamutFieldCanvasRendere == null)
        {
            Debug.LogError("CanvasRenderer component missing on this GameObject.");
        }

        maxSpaceValues = Vector2.Distance(transform.localPosition, maxDistancePoint.transform.localPosition);
        float ratio = maxSpaceValues / maxxyYValues;//To be multiplied with list to get ui positions for vectors
        Mesh gamutMest = new Mesh();

        Vector3[] verticies = new Vector3[9];
        Vector2[] uv = new Vector2[9];
        int[] triangles = new int[3*8];


        //Points
        verticies[0] = Vector3.zero;
        verticies[1] = (stage2Endpoints[0] - baseCoord) * ratio;
        verticies[2] = (stage2Endpoints[1] - baseCoord) * ratio;
        verticies[3] = (stage2Endpoints[2] - baseCoord) * ratio;
        verticies[4] = (stage2Endpoints[3] - baseCoord) * ratio;
        verticies[5] = (stage2Endpoints[4] - baseCoord) * ratio;
        verticies[6] = (stage2Endpoints[5] - baseCoord) * ratio;
        verticies[7] = (stage2Endpoints[6] - baseCoord) * ratio;
        verticies[8] = (stage2Endpoints[7] - baseCoord) * ratio;

        Debug.Log("Vertex 0:" + verticies[0]);
        Debug.Log("Vertex 1:" + verticies[1]);
        Debug.Log("Vertex 2:" + verticies[2]);
        Debug.Log("Vertex 3:" + verticies[3]);
        Debug.Log("Vertex 4:" + verticies[4]);
        Debug.Log("Vertex 5:" + verticies[5]);
        Debug.Log("Vertex 6:" + verticies[6]);
        Debug.Log("Vertex 7:" + verticies[7]);
        Debug.Log("Vertex 8:" + verticies[8]);


        //Triangles
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;


        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        triangles[6] = 0;
        triangles[7] = 3;
        triangles[8] = 4;

        triangles[9] = 0;
        triangles[10] = 4;
        triangles[11] = 5;

        triangles[12] = 0;
        triangles[13] = 5;
        triangles[14] = 6;

        triangles[15] = 0;
        triangles[16] = 6;
        triangles[17] = 7;

        triangles[18] = 0;
        triangles[19] = 7;
        triangles[20] = 8;
        
        triangles[21] = 0;
        triangles[22] = 8;
        triangles[23] = 1;
        
        gamutMest.vertices = verticies;
        gamutMest.uv = uv;
        gamutMest.triangles = triangles;

        gamutFieldCanvasRendere.SetMesh(gamutMest);

        triangleMaterial.SetColor("_Color", new Color(ColorData.baseColorP3.r, ColorData.baseColorP3.g, ColorData.baseColorP3.b, 0.7f)); // 0.5f for 50% transparency

        gamutFieldCanvasRendere.SetMaterial(triangleMaterial, null);
    }

}
