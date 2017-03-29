using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : ScrollingManager {

    private ChunckSelection chunckSelection;
    public Vector3 scrollVelocity;

	// Use this for initialization
	void Awake () {
        chunckSelection = scrollingObjectPrefab.GetComponent<ChunckSelection>();
        chunckSelection.SelectChunk();
	}

    protected override Vector3 GetScrollDirection()
    {
        return scrollVelocity.normalized;
    }

    protected Vector3 GetInitialGenerationPosition()
    {
        Vector3 objectPosition = Camera.main.ViewportToWorldPoint(
            new Vector3(viewportOffset.x, 0f));
        objectPosition.z = 0f;
        return objectPosition;
    }

    protected override Transform GenerateObject(Vector3 localPosition)
    {
        Transform levelChunk = chunckSelection.GenerateChunk();
        levelChunk.parent = transform;
        levelChunk.localPosition = localPosition - new Vector3(0.5f * scrollingObjectPrefab.size.x, 0f, 0f);
        levelChunk.GetComponent<NestedPrefab>().GeneratePrefabs();
        chunckSelection.SelectChunk();
        return levelChunk;
    }
}
