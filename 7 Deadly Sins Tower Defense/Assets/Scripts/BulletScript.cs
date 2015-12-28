using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    public Transform target;
    public float speed;
    private Vector2 velocity;

    void Start()
    {


    }
	// Update is called once per frame
	void Update () {
        velocity = (target.position - this.transform.position);
        velocity.Normalize();
        velocity = velocity * 10;
        velocity = Vector2.ClampMagnitude(velocity, speed);
        velocity = velocity * Time.deltaTime;
        this.transform.position = new Vector3(((this.transform.position.x + velocity.x)),(this.transform.position.y + velocity.y) , 0 );
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
    }
}
