using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrayExtensions
{
    public static T GetRandom<T>(this T[] array)
    {
        int index = Random.Range(0, array.Length);
        Debug.Log(index);
        return array[index];
    }
}

public class ChunckSelection : MonoBehaviour
{
    [Header("Prefab Reference")]
    public NestedPrefab[] chunks;

    public NestedPrefab lastSelectedChunck;
    public ScrollingObject currentScrollObject;

    public void SelectChunk()
    {
        if (currentScrollObject == null)
        {
            currentScrollObject = GetComponent<ScrollingObject>();
        }
        lastSelectedChunck = chunks.GetRandom();
        currentScrollObject.size =
            lastSelectedChunck.GetComponent<ScrollingObject>().size;
        
    }

    public Transform GenerateChunk()
    {
        return Instantiate(lastSelectedChunck.transform) as Transform;
    }
}