using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] float VelMax = 1f;
    [SerializeField] float acel = 1f;
    [SerializeField] float desac = 1f;
    [SerializeField] float angularVel = 1f;
    private float xAxis;
    private float yAxis;
    private float VelAtual;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xAxis = Input.GetAxis("Vertical");
        yAxis = Input.GetAxis("Horizontal");

        if (xAxis != 0)
        {
            VelAtual += (xAxis * acel);
            ClampVelocity(VelAtual);
        }
        else
        {
            Stoped();
            ClampVelocity(VelAtual);
        }
        if (yAxis != 0)
        {
            Rotate(transform, yAxis * angularVel);
        }
    }
    private void ClampVelocity(float vel)
    {
        float x = Mathf.Clamp(vel, -VelMax, VelMax);
        rb.velocity = transform.up * x;
        VelAtual = x;
    }
    private void Stoped()
    {
        if (VelAtual != 0)
        {
            if (VelAtual > 0)
            {
                VelAtual -= desac;
                VelAtual = Mathf.Clamp(VelAtual, 0, VelMax);
            }
            else if (VelAtual < 0)
            {
                VelAtual += desac;
                VelAtual = Mathf.Clamp(VelAtual, -VelMax, 0);
            }
        }
    }
    private void Rotate(Transform t, float angulo)
    {
        t.Rotate(0, 0, -angulo);
    }
}
