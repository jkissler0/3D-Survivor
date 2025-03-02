using UnityEngine;
using System.Collections;

public class OrbitController : MonoBehaviour
{
    public GameObject player;
    private float xOrbit = 0;
    private float zOrbit = 0;
    private float offset = 4.5f;
    private float timer = 0;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        // The disc will orbit the player twice and then destroy itself
        // Degrees were converted to radians for this function
        if (timer <= 720)
        {
            xOrbit = Mathf.Sin((timer * Mathf.PI/180));
            zOrbit = Mathf.Cos((timer * Mathf.PI / 180));
            transform.position = player.transform.position + (offset * new Vector3(xOrbit, 0, zOrbit));
        }
        else
        {
            Destroy(gameObject);
        }
        timer += 360 * Time.deltaTime;
    }
}
