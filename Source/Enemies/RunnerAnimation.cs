using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Runner))]
public class RunnerAnimation : MonoBehaviour
{
    Animator controller;
    Runner runner;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Animator>();
        runner = GetComponent<Runner>();
    }

    private void Update()
    {
        controller.SetBool("isRunning", runner.isCharging);
    }
}
