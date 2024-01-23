using UnityEngine;
using UnityEngine.UI;

using UnityEngine;
using System.Collections.Generic;

public class ItemSelection : MonoBehaviour
{
    public Dictionary<int, GameObject> itemsDictionary = new Dictionary<int, GameObject>();
    private int selectedItemIndex = -1;
    public GameObject prefabToSpawn; 

    public void SelectItem(int index)
    {

        switch (index)
        {
            case 0:
                prefabToSpawn = Resources.Load("CombatKnifes/knife3a") as GameObject;
                InstantiateNewObject(index, prefabToSpawn);
                break;
            default:
                InstantiateNewSquare(index);
                break;
        }
    }

    public void InstantiateNewObject(int index, GameObject prefabToSpawn)
    {
        if (itemsDictionary.ContainsKey(index))
        {
            Destroy(itemsDictionary[index]);
            itemsDictionary.Remove(index);
        }
        else
        {
            GameObject newObject = Instantiate(prefabToSpawn, new Vector3(5f, 0.5f, 2f), Quaternion.identity);

            newObject.name = "MyNewItem";
            newObject.layer = LayerMask.NameToLayer("Grabbable");

            Rigidbody objectRigidbody = newObject.GetComponent<Rigidbody>();
            if (objectRigidbody == null)
            {
                objectRigidbody = newObject.AddComponent<Rigidbody>();
                objectRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                objectRigidbody.mass = 1f;
            }

            newObject.AddComponent<MouseDrag>();

            itemsDictionary.Add(index, newObject);
        }
    }

public void InstantiateNewSquare(int index)
{
    if (itemsDictionary.ContainsKey(index))
    {
        Destroy(itemsDictionary[index]);
        itemsDictionary.Remove(index);
    }
    else
    {
        GameObject cube = new GameObject("MyNewItem");
        cube.AddComponent<BoxCollider>();
        BoxCollider boxCollider = cube.GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(1.1f, 1.1f, 1.1f);
        MeshFilter meshFilter = cube.AddComponent<MeshFilter>();
        meshFilter.mesh = GetCubeMesh();
        MeshRenderer meshRenderer = cube.AddComponent<MeshRenderer>();
        meshRenderer.material = GetCubeMaterial();
        cube.layer = LayerMask.NameToLayer("Grabbable");
        Rigidbody cubeRigidbody = cube.AddComponent<Rigidbody>(); 
        cubeRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        cubeRigidbody.mass = 1f; 

        cube.AddComponent<MouseDrag>();
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
