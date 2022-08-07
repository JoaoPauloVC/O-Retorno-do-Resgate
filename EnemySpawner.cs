using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    public GameObject Wargal; // Wargal Monster
    [SerializeField]
    public GameObject Kalkara;// Kalkara Monster

    public Transform[] spawnPoints;
    public float spawnTime;
    public int secondsToIncreaseSpawnWargal;
    public int secondsToSpawnKalkara;
    public float spawnRate;

    private void FixedUpdate()
    {
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);

        if (Time.timeSinceLevelLoad == 0)
            InvokeRepeating("SpawnNewWargal", 1f, spawnTime); //Keeps Spawning Wargals

        if(Time.time%secondsToIncreaseSpawnWargal == 0 && Time.timeSinceLevelLoad > 0) //Decreases Time to Spawn new Wargals
        {
            CancelInvoke();
            spawnTime = spawnTime/spawnRate;
            InvokeRepeating("SpawnNewWargal", 1f, spawnTime);
        }

        if(Time.time%secondsToSpawnKalkara == 0 && Time.timeSinceLevelLoad > 0) //Spawn a Kalkara
            Instantiate(Kalkara, spawnPoints[randSpawnPoint].position, transform.rotation);
    }

    public void SpawnNewWargal()
    {
        int randSpawnPoint = Random.Range(0, spawnPoints.Length); //Pick Random spawnPoint

        Instantiate(Wargal, spawnPoints[randSpawnPoint].position, transform.rotation); // Create Wargal Monster in Random spawnPoint
    }
}
