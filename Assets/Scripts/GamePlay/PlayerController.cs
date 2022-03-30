using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float force = 230f;

    private Rigidbody2D rbody;
    private AudioSource audioSource;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
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
            GameEvents.CallSaveScoreEvent();
            GameEvents.CallGameOverEvent();
            Destroy(gameObject);
        }
    }


}// Class
