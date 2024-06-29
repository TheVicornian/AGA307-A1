using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("---Target health---")]
    int _hp = 5;
    public int health = 5;
    public int hp
    {
        get => _hp;
        set => _hp = Mathf.Clamp(value, 0, maxHP);
    }
    public int maxHP = 5;

    public TargetSize targetSize;
    float scaleFactor = 1;

    public int moveDistance = 500;
    public float moveSpeed = 0.5f;


    void Start()
    {
        Setup();
    }


    void OnCollisionEnter()
    {
        if (hp > 0)
            hp--;
        else
            Destroy(this.gameObject);
    }
    void Setup()
    {
        switch (targetSize)
        {
            case TargetSize.Small:
                transform.localScale = Vector3.one * scaleFactor;
                break;
            case TargetSize.Medium:
                transform.localScale = Vector3.one * scaleFactor;
                break;
            case TargetSize.Large:
                transform.localScale = Vector3.one * scaleFactor;
                break;
        }
            StartCoroutine(MoveTarget());
        
    }

    IEnumerator MoveTarget()
    {
        {
            for (int i = 0; i < moveDistance * moveSpeed; i++)
            {
                transform.Translate(Vector3.right * Time.deltaTime);

                yield return null;
            }

            transform.Rotate(Vector3.up * 180);

            yield return new WaitForSeconds(3);

            StartCoroutine(MoveTarget());

        }




    }
}
