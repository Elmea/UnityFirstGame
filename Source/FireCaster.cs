using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FireCaster : MonoBehaviour
{
    [SerializeField] float activeTime;
    [SerializeField] float inactiveTime;

    [SerializeField] ParticleSystem particle;

    private bool isActive = false;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && isActive && !PlayerInfo.godMod)
        {
            PlayerCollision player = other.GetComponent<PlayerCollision>();

            player.GotHited();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            if (isActive)
            {
                particle.Stop();
                timer = inactiveTime;
                isActive = false;
            }
            else
            {
                timer = activeTime;
                particle.Play();
                isActive = true;
            }
        }
    }
}