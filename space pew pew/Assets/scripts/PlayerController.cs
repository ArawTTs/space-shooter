using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerController;
    public float speed;

    public GameObject Projectile;
    public GameObject projectilePosition;
    public GameObject Explosion;

    float fireInterval = .5f;
    float nextFire;

    private void Awake()
    {
        if (playerController == null)
        {
            playerController = this;
        }

        else if (playerController != this) 
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        nextFire = fireInterval;
    }

    // Update is called once per frame
    void Update()
    {
        nextFire -= Time.deltaTime;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2 (x, y).normalized;

        Move(direction);

        if (Input.GetKeyDown("space") && nextFire <= 0)
        {
            GameObject projectile = (GameObject)Instantiate (Projectile);
            projectile.transform.position = projectilePosition.transform.position;
            nextFire = fireInterval;
        }
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - .5f;
        min.x = min.x + .5f;

        max.y = max.y - .5f;
        min.y = min.y + .5f;

        Vector2 pos = transform.position;
        pos += direction * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "enemyProjectile")
        {
            PlayerStats.playerStats.playerLife--;
            Debug.Log("Hit");

            Vector2 expos = transform.position;

            GameObject explosion = (GameObject)Instantiate(Explosion);
                explosion.transform.position = expos;
            
        }
    }
}
