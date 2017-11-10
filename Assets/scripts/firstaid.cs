using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstaid : MonoBehaviour {

    // Use this for initialization
    private float health_recover = 20f;
    public ParticleSystem showheart;
    void Start() {

    }
    // Update is called once per frame
    void Update() {

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<tanka>().recover(health_recover);
            Destroy(gameObject, 0.1f);
        }
    }
    void OnDestroy()
    {
        ParticleSystem heart = Instantiate(showheart, transform.position, Quaternion.identity);
        Destroy(heart, 1f);
    }
}
