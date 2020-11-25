using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float smoothTimeX, smoothTimeY;
    public Vector2 velocity;

    public GameObject player;
    public Vector2 minPosition, maxPosition;
    public bool bound = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
        this.transform.position = new Vector3(posX, posY, this.transform.position.z);
        if (bound)
        {
            this.transform.position = new Vector3(
                Mathf.Clamp(this.transform.position.x, minPosition.x, maxPosition.x),
                Mathf.Clamp(this.transform.position.y, minPosition.y, maxPosition.y),
                Mathf.Clamp(this.transform.position.z, transform.position.z, transform.position.z)
             );
        }
    }
}
