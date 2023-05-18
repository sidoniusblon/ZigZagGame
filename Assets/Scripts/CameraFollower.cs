using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] GameObject target;
    Vector3 distance;
    Camera cam;
    public Color[] colors;
    float time;
    [SerializeField] float timeSpeed;
     Color firstColor, SecondColor;
    void Start()
    {
       distance= this.transform.position - target.transform.position;
        cam = GetComponent<Camera>();
        firstColor = colors[Random.Range(0, colors.Length)];
        SecondColor = colors[Random.Range(0, colors.Length)];

    }

    
    private void LateUpdate()
    { if (PlayerController.isdead) return;
        transform.position = target.transform.position + distance;
        cam.backgroundColor = Color.Lerp(firstColor, SecondColor,time);
        time += Time.deltaTime * timeSpeed;
        if (time >= 1)
        {
            time = 0;
            firstColor = SecondColor;
            SecondColor = colors[Random.Range(0, colors.Length)];
        }
    }
}
