using UnityEngine;
using System.Collections;
using System.Linq; // used for Sum of array

public class AssignSplatMap : MonoBehaviour
{
    TerrainData terrainData;

    // Splat map is data used to represent which texture is shown.
    // The map is a 3D array: [coordinate x, coordinate y, texture index]
    // The first two parts of the array represent the coordinate, and the last part
    // represents the texture at that coordinate. The texture is represented as a float:
    // a percentage from 0 to 1, which 0 being hidden and 1 being fully opaque.

    float[] PixelSplatWeights(int x, int y)
    {
        // Normalise x/y coordinates to percentages of the alphamap size.
        // The percentage is represented as 0-1, instead of 0-100.
        float x_01 = (float)x / terrainData.alphamapWidth;
        float y_01 = (float)y / terrainData.alphamapHeight;

        // Get the height of this coordinate on the terrain.
        // `GetHeight` expects a coordinate in the heightmap.
        float height = terrainData.GetHeight(
            Mathf.RoundToInt(y_01 * terrainData.heightmapHeight),
            Mathf.RoundToInt(x_01 * terrainData.heightmapWidth)
        );

        // Setup an array to record the mix of texture weights at this point
        // alphamapLayer are textures tied to the Terrain. Edit these in
        // Terrain -> Paint Textures (paintbrush icon) -> Textures
        float[] splatWeights = new float[terrainData.alphamapLayers];
        // Get the maximum height that the terrain can be.
        float maxHeight = terrainData.size.y;

        for (int i = 0; i < splatWeights.Length; i++)
        {
            float bottomOfSection = maxHeight * i / splatWeights.Length;
            float topOfSection = maxHeight * (i + 1) / splatWeights.Length;

            if (bottomOfSection <= height && height <= topOfSection)
            {
                splatWeights[i] = 1;
            }
        }

        // Sum of all textures weights must add to 1, so calculate normalization factor from sum of weights
        float weightsSum = splatWeights.Sum();
        // Loop through each terrain texture
        for (int i = 0; i < terrainData.alphamapLayers; i++)
        {

            // Normalize so that sum of all texture weights = 1
            splatWeights[i] /= weightsSum;
        }

        return splatWeights;
    }

    void Start()
    {
        // Get the attached terrain component
        Terrain terrain = GetComponent<Terrain>();

        // Get a reference to the terrain data
        terrainData = terrain.terrainData;

        // Splatmap data is stored internally as a 3d array of floats, so declare a new empty array ready for your custom splatmap data:
        float[,,] splatmapData = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];

        for (int y = 0; y < terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < terrainData.alphamapWidth; x++)
            {
                var splatWeights = PixelSplatWeights(x, y);

                // Loop through each terrain texture
                for (int i = 0; i < terrainData.alphamapLayers; i++)
                {
                    // Assign this point to the splatmap array
                    splatmapData[x, y, i] = splatWeights[i];
                }
            }
        }

        // Finally assign the new splatmap to the terrainData:
        terrainData.SetAlphamaps(0, 0, splatmapData);
    }
}