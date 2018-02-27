using UnityEngine;
using System.Collections; 
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Linq;
using System.Text;
public class TerrainRaiser : MonoBehaviour {

    bool shouldDraw = false;
    public UnityEngine.Terrain myTerrain;
    TerrainData tData;
    int xResolution;
    int zResolution;
    float[,] heights;
    public float speed = 0.01f;
    string speedString;
     

    void OnGUI() {
        if (GUI.Button(new Rect(Screen.width / 200, Screen.height / 200, 50, 50),"" )) {
            shouldDraw = true;
        }
        if (GUI.Button(new Rect(Screen.width / 200, Screen.height / 200 + 55, 50, 50),"")) {
            shouldDraw = false;
        }
        speedString = GUI.TextField(new Rect(Screen.width / 200, Screen.height / 200 + 110, 60, 20), speedString, 4);
    }

    // Use this for initialization
    void Start() {
        speedString = speed.ToString();
        tData = myTerrain.terrainData;
        xResolution = tData.heightmapWidth;
        zResolution = tData.heightmapHeight;
        
        for (int x = 0; x < (int) (xResolution / 4); x++ ) {
            for (int y = 0; y < (int) (zResolution / 4); y++) {
                float[,,] modHeights = new float[1, 1, 1];
                modHeights[0, 0, 0] = 255f;
                myTerrain.terrainData.SetAlphamaps(x, y, modHeights);
            }
        }
        heights = tData.GetHeights(0, 0, xResolution, zResolution);
    }

    // Update is called once per frame
    void Update() {
        speed = Convert.ToSingle(speedString);
        if (shouldDraw == true && Input.GetMouseButton(0) && Input.GetKey(KeyCode.RightControl)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                raiseTerrain(hit.point);

            }
        }
        if (shouldDraw == true && Input.GetMouseButton(1) && Input.GetKey(KeyCode.RightControl)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                lowerTerrain(hit.point);
            }
        }
    }

    private void raiseTerrain(Vector3 point) {
        int mouseX = (int)((point.x / tData.size.x) * xResolution);
        int mouseZ = (int)((point.z / tData.size.z) * zResolution);
        float[,] modHeights = new float[1, 1];
        float y = heights[mouseX, mouseZ];
        y += (speed / 10) * Time.deltaTime;
        if (y > tData.size.y)
            y = tData.size.y;
        modHeights[0, 0] = y;
        heights[mouseX, mouseZ] = y;
        tData.SetHeights(mouseX, mouseZ, modHeights);

    }
    private void lowerTerrain(Vector3 point) {
        int mouseX = (int)((point.x / tData.size.x) * xResolution);
        int mouseZ = (int)((point.z / tData.size.z) * zResolution);
        float[,] modHeights = new float[1, 1];
        float y = heights[mouseX, mouseZ];
        y -= (speed / 10) * Time.deltaTime;
        if (y < 0.0f)
            y = 0.0f;
        modHeights[0, 0] = y;
        heights[mouseX, mouseZ] = y;
        tData.SetHeights(mouseX, mouseZ, modHeights);
    }

}