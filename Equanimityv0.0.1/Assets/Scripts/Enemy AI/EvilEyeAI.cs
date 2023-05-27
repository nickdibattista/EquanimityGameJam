using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEyeAI : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lookSpeed;
    [SerializeField]
    private float fieldOfMove;
    [SerializeField]
    private float spotRange;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < spotRange)
        {
            if (Mathf.Abs((angle + 360) % 360 - (transform.rotation.eulerAngles.z + 360) % 360) < fieldOfMove / 2)
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(Vector3.forward * angle), lookSpeed * Time.deltaTime);
        }
    }
}
