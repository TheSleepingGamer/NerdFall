using System.Collections.Generic;
using UnityEngine;


// invokerepeating
// https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html

public class BubbleSpawnController : MonoBehaviour
{
   // public int min = -1;
   // public int max = 1;

    public float timeBetweenSpawns = 4f;

    public GameObject spawnerObject;
    public GameObject bubblePrefab;

    private float timer = 0f;
    private List<float> spawnPositions;

    public void Start()
    {
        this.timeBetweenSpawns = Time.time + timeBetweenSpawns;

        this.spawnPositions = new List<float>()
        {
            -6,
            -2,
            2,
            6
        };
    }

    public void Update()
    {
        // TODO: replace with InvokeRepeat()
        timer += Time.deltaTime;
        if (timer >= timeBetweenSpawns)
        {
            this.SpawnNewBubble();
            timer = 0f;
        }
    }

    private void SpawnNewBubble()
    {
        for (int i = 0; i < this.spawnPositions.Count; i++)
        {
            GameObject bubble = (GameObject)Instantiate(this.bubblePrefab, this.spawnerObject.transform.position, this.spawnerObject.transform.rotation);
            bubble.transform.parent = this.spawnerObject.transform;
            bubble.transform.localPosition = new Vector3(this.spawnPositions[i], 0);
            NumberContainer nmContainer = bubble.GetComponent<NumberContainer>();
            int randNumber = Random.Range(0, 65);
            nmContainer.SetNumber(randNumber);
        }
    }
}
