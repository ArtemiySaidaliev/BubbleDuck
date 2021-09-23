using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorScript : MonoBehaviour
{

    public GameObject platformPrefab;
    public GameObject platformPrefabUltra;
    public GameObject platformPrefabMinus;
    public Camera camera;

    public float numberOfPlatforms = 10f;
    public float numberOfPlatformsUltra = 1f;
    public float numberOfPlatformsMinus= 1f;
    public float minY = .2f;
    public float maxY = 1.5f;

    void Start()
    {
        Vector2 spawnPosition = new Vector2();

        Vector3 bottomLeftWorld = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 topRightWorld = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
       for(int i = 0; i< numberOfPlatforms; i++)
       {
           spawnPosition.y += Random.Range(minY, maxY);
           spawnPosition.x = Random.Range(bottomLeftWorld.x, topRightWorld.x);
           Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
       } 
       for(int i = 0; i< numberOfPlatformsUltra; i++)
       {
           spawnPosition.y += Random.Range(minY, maxY);
           spawnPosition.x = Random.Range(bottomLeftWorld.x, topRightWorld.x);
           Instantiate(platformPrefabUltra, spawnPosition, Quaternion.identity);
       } 
        for(int i = 0; i< numberOfPlatformsMinus; i++)
       {
           spawnPosition.y += Random.Range(minY, maxY);
           spawnPosition.x = Random.Range(bottomLeftWorld.x, topRightWorld.x);
           Instantiate(platformPrefabMinus, spawnPosition, Quaternion.identity);
       } 
    }
}
