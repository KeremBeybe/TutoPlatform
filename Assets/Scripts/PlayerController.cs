using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField]
    public float pushForce;
    private float movement;
    [SerializeField]
    private float speed = 5f;
    public Vector3 respawnPoint;
    public GameManager gameManager;
    public AudioSource crashSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, pushForce * Time.fixedDeltaTime);
        rb.velocity = new Vector3(movement * speed, rb.velocity.y, rb.velocity.z);
        FallDetector();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Barier"))
        {
            gameManager.RespawnPlayer();
            crashSound.Play();
        }
    }

    private void FallDetector()
    {
        if(rb.position.y < -1f)
        {
            gameManager.RespawnPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.LevelUp();
        } 
    }
}
