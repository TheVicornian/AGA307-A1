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



    public TargetDifficulty targetDifficulty;



    public TargetColour targetColour;

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
        if (Input.GetKeyDown(KeyCode.R))
        targetSize = (TargetSize) Random.Range(0,3);

        switch (targetSize)
        {
            case TargetSize.Small:
                transform.localScale = Vector3.one * 0.5f;
                moveSpeed = 2;
                GetComponent<Renderer>().material.color = Color.red;
                
                break;
            case TargetSize.Medium:
                transform.localScale = Vector3.one * 1f;
                moveSpeed = 1;
                GetComponent<Renderer>().material.color = Color.yellow ;

                break;
            case TargetSize.Large:
                transform.localScale = Vector3.one * 2f; ;
                moveSpeed = 0.1f;
                GetComponent<Renderer>().material.color = Color.green;

                break;
        }

        transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);

        StartCoroutine(MoveTarget());
        StartCoroutine(TeleportTarget());

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


    IEnumerator TeleportTarget()
    {
        yield return new WaitForSeconds (3);

        transform.Translate(UnityEngine.Random.Range(-2, 8), UnityEngine.Random.Range(-2,8), UnityEngine.Random.Range(-2, 8));
      
        StartCoroutine(TeleportTarget());
    }
}
