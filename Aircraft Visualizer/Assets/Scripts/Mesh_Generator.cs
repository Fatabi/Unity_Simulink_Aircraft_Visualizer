using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Mesh_Generator : MonoBehaviour
{
    [SerializeField] Gradient terrainGradient;
    [SerializeField] Material mat;
    private Texture2D gradientTexture;
    Mesh mesh;
    Color[] colors;
    Vector3[] vertices;
    int [] triangles;
    public int xSize = 20;
    public int zSize = 20;
    float minTerrainHeight;
    float maxTerrainHeight;
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        // StartCoroutine(CreateShape());
        CreateShape();
    }

    void Update(){
        UpdateMesh();
        GradientToTexture();

        mat.SetTexture("terrainGradient",gradientTexture);
        mat.SetFloat("minTerrainHeight",minTerrainHeight);
        mat.SetFloat("maxTerrainHeight",maxTerrainHeight);
    }
    private void CreateShape()
    {
        vertices = new Vector3[(xSize+1)*(zSize+1)];
        
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x*.1f,z*0.1f)*10f;
                vertices[i]=new Vector3(x,y,z);

                if (y>maxTerrainHeight)
                {
                    maxTerrainHeight = y;
                }
                if (y<minTerrainHeight)
                {
                    minTerrainHeight = y;
                }
                i++;
            }
        }

        triangles = new int[xSize*zSize*6];
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
            
            triangles[tris + 0] = vert + 0;
            triangles[tris + 1] = vert + xSize + 1;
            triangles[tris + 2] = vert + 1;
            triangles[tris + 3] = vert + 1;
            triangles[tris + 4] = vert + xSize + 1;
            triangles[tris + 5] = vert + xSize + 2;    

            vert++;
            tris+=6;
            // yield return new WaitForSeconds(.01f);
            }
            vert++;

 


        }

        // colors = new Color[vertices.Length];

        // for (int i = 0, z = 0; z <= zSize; z++)
        // {
        //     for (int x = 0; x <= xSize; x++)
        //     {
        //         float height =Mathf.InverseLerp(minTerrainHeight,maxTerrainHeight,vertices[i].y);
        //         colors[i]= gradient.Evaluate(height);
        //         i++;
        //     }
        // }
            
    }
    private void GradientToTexture()
    {
        gradientTexture = new Texture2D(1,100);
        Color [] pixelColors = new Color[100];

        for (int i = 0; i < 100; i++)
        {
            pixelColors[i]=terrainGradient.Evaluate((float)i/100);
        }
        gradientTexture.SetPixels(pixelColors);
        gradientTexture.Apply();

    }
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;
        mesh.RecalculateNormals();
    }
    private void OnDrawGizmos(){
        if (vertices==null)
        {
            return;
        }
        for (int i = 0; i < vertices.Length; i++)
        {
            // Gizmos.DrawSphere(vertices[i],0.1f);
        }
    }
}
