using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancar : MonoBehaviour
{
    [SerializeField] string shootButton;
    [SerializeField] float maxRanged,posiX,acel;
    private float posiAtual=0;
    private bool canShoot = true,maxRangedDone = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(shootButton))
        {
            canShoot = false;
        }
        Shoot();
    }

    private void Shoot()
    {
        if (!canShoot)
        {
            if (transform.localPosition.y < maxRanged && !maxRangedDone)
            {
                posiAtual += acel;
                posiAtual = Mathf.Clamp(posiAtual, 0, maxRanged);
                transform.localPosition = new Vector3(posiX, posiAtual, 0);
            }
            else
            {
                maxRangedDone = true;
                posiAtual -= acel;
                posiAtual = Mathf.Clamp(posiAtual, 0, maxRanged);
                transform.localPosition = new Vector3(posiX, posiAtual, 0);
                if (transform.localPosition.y == 0) {
                    canShoot = true;
                    maxRangedDone = false;
                }
            }
        }  
    }
}
