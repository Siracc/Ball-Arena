using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _playerRb;
    GameObject _focalPoint;
    [SerializeField] GameObject _powerupIndicator;
    [SerializeField] float _speed = 5.0f;
    [SerializeField] bool _hasPowerup = false;
    float _powerUpStrength = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");

    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _playerRb.AddForce(_focalPoint.transform.forward * forwardInput * _speed);
        _powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            _hasPowerup = true;
            _powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(8);
        _hasPowerup = false;
        _powerupIndicator.gameObject.SetActive(false);
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && _hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            

            enemyRigidbody.AddForce(awayFromPlayer * _powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with : " + collision.gameObject.name + " with powerup set to " + _hasPowerup);
        }
    }




}   
