using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RandomSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;
    //public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    public int count, countControl;
    public float offset;
    public int speed;
    int randEnemy;
    float randX, previousX;

    public void LevelDiff(int countF,float spawnF,int speedF)
    {
        this.count = countF;
        this.spawnMostWait = spawnF;
        this.speed = speedF;
    }
    void Start()
    {
        spawnLeastWait = spawnMostWait;
        countControl = 0;
       
        StartCoroutine(waitSpawner());
        offset = 40f;
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                LevelDiff(10, 3, 5);
                break;
            case "Level2":
                LevelDiff(100,3, 6);
                break;
            case "Level3":
                LevelDiff(300, 3, 6);
                break;

        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<TouchController>().forwardForce = speed;
    }
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        previousX = randX;
    }

    // Update is called once per frame
   
    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop)
        {
            if(countControl == count)
            {
                stop = true;
            } 
            randX = Random.Range(-1, 2);
            //previousX = randX;
            randEnemy = Random.Range(0, 3);
            if(previousX!= randX)
            {
                countControl += 1;
                Vector3 spawnPosition = new Vector3((0 + randX), -2.22f, transform.position.z + offset);
                Instantiate(enemies[randEnemy], spawnPosition, gameObject.transform.rotation);
                Debug.Log(enemies[randEnemy].name.ToString() + randX);
            }
            
            yield return new WaitForSeconds(spawnWait);
        }
        
    }
   
}
