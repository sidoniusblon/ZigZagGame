using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Vector3 direction = Vector3.left;
    [SerializeField]
    private float speed;
    [SerializeField]
    TerrainSpawner spawner;
    float score;
    bool bestScorewin;
    public TextMeshProUGUI tmp;
    public static bool isdead=true;
    public GameObject bestScoreText;
    int bestScore;
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        if (UiManagerSC.isRestarted) isdead = false;
    }
    void Update()
    {
        if (isdead) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            if (direction.x == 0) direction = Vector3.left;
            else direction = Vector3.forward;
        }

        transform.Translate(direction * speed * Time.deltaTime);
        tmp.text = ((int)score).ToString();
        if (this.transform.position.y <= 0.2f)
        {
            UiManagerSC.Instance.restartPanel.SetActive(true);
            isdead = true;
            if (score > bestScore)
            {
                PlayerPrefs.SetInt("BestScore", (int)score);
            }
            UiManagerSC.Instance.bestScoreShow();
        }
        Debug.Log(score);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Terrain"))
        {
            spawner.SpawnTerrain();
            spawner.DestroyTerrain(collision.gameObject);
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) { score += 5; if (score % 30 == 0) speed += 0.3f; if (score > bestScore && bestScorewin == false) { bestScoreText.SetActive(true); bestScorewin = true; } }
        other.gameObject.SetActive(false);
    }
}
