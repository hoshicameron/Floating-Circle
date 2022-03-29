using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _force = 230f;

    private Rigidbody2D _rbody;


    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
        {
            Flap();
        }
    }

    private void Flap()
    {
        _rbody.AddForce(Vector2.up*_force);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Todo Show GameOver UI
            SceneManager.LoadScene(0);
        }
    }
}// Class
