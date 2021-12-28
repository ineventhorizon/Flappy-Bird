using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeFactory : MonoBehaviour
{
    
    [SerializeField] public float spawnTime = 8f;
    [SerializeField] public float defaultSpeed = 0.1f;
    private float currentTime = 0;
    private Vector2 previousPipePosition;
    private int count = 0;

    private static PipeFactory instance;
    public static PipeFactory Instance => instance ?? (instance = FindObjectOfType<PipeFactory>());
    [SerializeField] private Pipe pipe;
    [SerializeField] private Transform pipeParent;

    private void Awake()
    {
        instance = instance ??= this;
    }
    private void Start()
    {
        SpawnObject(transform.position);
    }

    private void Update()
    {
        TimedSpawn();
    }

    public void SpawnObject(Vector2 position)
    {
        Pipe spawnedPipe = Instantiate(pipe, pipeParent);
        
        if(count % 10 == 0 && count != 0)
        {
            defaultSpeed += 0.1f;
        }
        spawnedPipe.pipeSpeed = defaultSpeed;
        spawnedPipe.transform.position = (Vector3)position;
        previousPipePosition = position;
    }

    private void TimedSpawn()
    {
        if (currentTime < spawnTime)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            SpawnObject(RandomPosition());
            currentTime = 0;
            count++;
        }
    }

    private Vector2 RandomPosition()
    {
        Vector2 randomPos = transform.position;
        randomPos.y = Random.Range(pipeParent.position.y - 0.4f, pipeParent.position.y + 0.4f);
        //Debug.Log(randomPos);
        return randomPos;
    }
}
