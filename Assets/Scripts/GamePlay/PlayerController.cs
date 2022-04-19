using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float force = 230f;
    [SerializeField] private GameObject explosionPrefab = null;

    private Rigidbody2D rbody;
    private AudioSource audioSource;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        rbody.gravityScale = 0;
        rbody.velocity=Vector2.zero;
    }

    private bool canMove = false;

    private void OnEnable()
    {
        GameEvents.GameStartEvent+=OnGameStart;
        GameEvents.GameOverEvent+=OnGameOver;
    }

    private void OnDisable()
    {
        GameEvents.GameStartEvent-=OnGameStart;
        GameEvents.GameOverEvent-=OnGameOver;
    }

    private void OnGameOver()
    {
        canMove = false;
    }

    private void OnGameStart()
    {
        canMove = true;
        rbody.gravityScale = 1;
    }

    void Update()
    {
        if(!canMove)    return;

        if (Input.GetKeyDown(KeyCode.Space) ||
                        (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Flap();
            if (AudioManager.Instance.IsSoundFxMuted() == false)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
    }

    private void Flap()
    {
        rbody.AddForce(Vector2.up*force);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            StartDeathSequence();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            StartDeathSequence();
        }
    }

    private void StartDeathSequence()
    {
        GameEvents.CallGameOverEvent();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}// Class
