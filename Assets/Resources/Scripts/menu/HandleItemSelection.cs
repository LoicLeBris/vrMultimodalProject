using UnityEngine;
using UnityEngine.UI;

using UnityEngine;
using System.Collections.Generic;

public class ItemSelection : MonoBehaviour
{
    public Dictionary<int, GameObject> itemsDictionary = new Dictionary<int, GameObject>();
    private int selectedItemIndex = -1;

    public void SelectItem(int index)
    {
        selectedItemIndex = index;
        Debug.Log("Selected item: " + selectedItemIndex);
        InstantiateNewObject(selectedItemIndex);
    }

    public void InstantiateNewObject(int index)
{
    if (itemsDictionary.ContainsKey(index))
    {
        // Remove Rigidbody component from the existing object
        Destroy(itemsDictionary[index].GetComponent<Rigidbody>());
    }
    else
    {
        GameObject cube = new GameObject("MyNewItem");
        cube.AddComponent<BoxCollider>();
        BoxCollider boxCollider = cube.GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            boxCollider.size = new Vector3(2f, 2f, 2f);
        }
        MeshFilter meshFilter = cube.AddComponent<MeshFilter>();
        meshFilter.mesh = GetCubeMesh();
        MeshRenderer meshRenderer = cube.AddComponent<MeshRenderer>();
        meshRenderer.material = GetCubeMaterial();
        cube.layer = LayerMask.NameToLayer("Grabbable");
        Rigidbody cubeRigidbody = cube.AddComponent<Rigidbody>(); 
        cubeRigidbody.mass = 1f; 
        
        cube.transform.position = new Vector3(5f, 0.5f, 2f);

        itemsDictionary.Add(index, cube);
    }
}


    private Mesh GetCubeMesh()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f)
        };

        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3,
            1, 5, 6,
            1, 6, 2,
            4, 0, 3,
            4, 3, 7,
            5, 4, 7,
            5, 7, 6,
            4, 5, 1,
            4, 1, 0,
            3, 2, 6,
            3, 6, 7
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        return mesh;
    }

    private Material GetCubeMaterial()
    {
        Material material = new Material(Shader.Find("Standard"));
        material.color = Color.red; 
        return material;
    }

}
