using UnityEngine;


// invokerepeating
// https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html

public class BubbleSpawnController : MonoBehaviour
{
    public float min = -10;
    public float max = 10;

    public float timeBetweenSpawns = 4f;

    public GameObject spawnerObject;
    public GameObject bubblePrefab;

    private float timer = 0f;

    public void Start()
    {
        this.timeBetweenSpawns = Time.time + timeBetweenSpawns;
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
        GameObject bubble = (GameObject)Instantiate(this.bubblePrefab, this.spawnerObject.transform.position, this.spawnerObject.transform.rotation);
        bubble.transform.parent = this.spawnerObject.transform;

        float randPosition = Random.Range(this.min, this.max);
        bubble.transform.localPosition = new Vector3(randPosition, 0);

        NumberContainer nmContainer = bubble.GetComponent<NumberContainer>();
        int randNumber = Random.Range(0, 65);
        nmContainer.SetNumber(randNumber);
    }
}
