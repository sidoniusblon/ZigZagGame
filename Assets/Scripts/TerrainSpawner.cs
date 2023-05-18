using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    [SerializeField] GameObject lastTerrain;
    
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            SpawnTerrain();
        }
    }
    private void Update()
    {
        
    }


    public void SpawnTerrain()
    {
        Vector3 direction;
        if (Random.Range(0, 2) == 0)
            direction = Vector3.left;
        else direction = Vector3.forward;


        if (Random.Range(0, 10)==1)
        {
            lastTerrain.transform.GetChild(0).gameObject.SetActive(true);
        }
        else lastTerrain.transform.GetChild(0).gameObject.SetActive(false);
        lastTerrain = Instantiate(lastTerrain, lastTerrain.transform.position + direction, lastTerrain.transform.rotation);
        
        
    }
    public void DestroyTerrain(GameObject collision)
    {
        StartCoroutine(wait(collision));
        
    }
    IEnumerator wait(GameObject go)
    {
       
        yield return new WaitForSeconds(0.5f);
        go.AddComponent<Rigidbody>();
    }

}
