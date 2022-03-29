using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public Queue<GameObject> obstaclePool=new Queue<GameObject>();

    [SerializeField] private int poolSize=50;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float smooth = 5f;

    [SerializeField] private  Vector2 widthRange=new Vector2(3f,3f);
    [SerializeField] private Vector2 heightRange=new Vector2(2.3f,4.3f);

    [SerializeField] private Transform obstacleContainer;
    [SerializeField] private GameObject obstaclePrefab;

    private Vector3 startPosition;
    private GameObject top, bottom;

    private float topHeight, topWidth;
    private float bottomHeight, bottomWidth;

    private float topInterval
    {
        get => (topWidth - smooth / speed) / speed;
    }

    private float bottomInterval
    {
        get => (bottomWidth - smooth / speed) / speed;
    }

    private Vector3 topScale
    {
        get=>new Vector3(topWidth,topHeight,1f);
    }

    private Vector3 bottomScale
    {
        get => new Vector3(bottomWidth, bottomHeight, 1f);
    }
    void Awake()
    {
        startPosition=new Vector3(15f,0f,0f);
        FillPool();
    }

    private void Start()
    {
        StartCoroutine(TopRandomGenerator());
        StartCoroutine(BottomRandomGenerator());
    }

    private void FillPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefab, startPosition, Quaternion.identity, obstacleContainer);
            obstacle.SetActive(false);

            obstaclePool.Enqueue(obstacle);
        }
    }

    private void UpdateSpeed()
    {
        ObstacleMover.Speed = speed;
    }

    private GameObject GetObstacleFromPool()
    {
        GameObject clone = obstaclePool.Dequeue();
        clone.transform.position = startPosition;
        UpdateSpeed();
        obstaclePool.Enqueue(clone);
        return clone;
    }

    private void UpdateTopTransform()
    {
        top.transform.localScale = topScale;
        top.transform.position=new Vector3(top.transform.position.x,5f-top.transform.localScale.y*0.5f,0f);
    }

    private void UpdateBottomTransform()
    {
        bottom.transform.localScale = bottomScale;
        bottom.transform.position=new Vector3(bottom.transform.position.x,-5+bottom.transform.localScale.y*0.5f,0f);
    }

    private IEnumerator TopRandomGenerator()
    {
        topWidth = widthRange.x;

        while (true)
        {
            top = GetObstacleFromPool();
            topHeight = Random.Range(heightRange.x, heightRange.y);
            UpdateTopTransform();
            yield return new WaitForSeconds(topInterval);
            top.SetActive(true);
        }
    }

    private IEnumerator BottomRandomGenerator()
    {
        bottomWidth = widthRange.x;

        while (true)
        {
            bottom = GetObstacleFromPool();
            bottomHeight = Random.Range(heightRange.x, heightRange.y);
            UpdateBottomTransform();
            yield return new WaitForSeconds(bottomInterval);
            bottom.SetActive(true);
        }
    }

}// Class
