using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    public GameObject snowObject;
    public GameObject rainObject;

    private ParticleSystem _snowParticles;
    private ParticleSystem _rainParticles;

    // Start is called before the first frame update
    void Start()
    {
        _snowParticles = snowObject.GetComponent<ParticleSystem>();
        _rainParticles = rainObject.GetComponent<ParticleSystem>();
        
        _snowParticles.Stop();
        _rainParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            _snowParticles.Stop();
            _rainParticles.Stop();
        }

        else if (Input.GetKey(KeyCode.K))
        {
            _snowParticles.Play();
            _rainParticles.Stop();
        }

        else if (Input.GetKey(KeyCode.L))
        {
            _snowParticles.Stop();
            _rainParticles.Play();
        }
    }
}
