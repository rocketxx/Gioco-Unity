using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class Enemy : MonoBehaviour, IKillable<float>
{
    [SerializeField] protected float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField] protected Transform[] checkPoints;
    [SerializeField] protected Transform target;
    [SerializeField] int coins;
    [SerializeField] float maxHealth;
    [SerializeField] Image lifeBar;
    int targetIndex;
    [SerializeField] protected float strength;
    private float health;
    protected Animator anim;
    /*
    protected virtual void Init()
    {
        Debug.Log("init di enemy");
    }
    */
    protected void Awake()
    {
        anim = GetComponent<Animator>();
        TakeCheckPoints();
    }

    protected virtual void Start()
    {
        
        //StartCoroutine(RotateToTarget());
        
        //Init();
    }

    protected virtual void Update()
    {
        lifeBar.transform.LookAt(Camera.main.transform.position);
    }

    protected virtual void Reset()
    {
        health = maxHealth;
        lifeBar.fillAmount = 1;
    }

    protected virtual void OnEnable()
    {
        Reset();
    }

    public void Hit(float damage)
    {
        anim.SetBool("Hit", true);
        
        
        health -= damage;
        float fill = health / maxHealth;
        lifeBar.fillAmount = fill;
        lifeBar.color = Color.Lerp(Color.red, Color.yellow, 1 - fill);
        if (health <= 0)
        {
            Kill();
        }

    }

    public void  Kill()
    {
        SoundManager.instance.PlayEnemyDestroy();
        CoinManager.instance.AddCoins(coins);
        gameObject.SetActive(false);
    }

    public void ResetHit()
    {
        anim.SetBool("Hit", false);
    }

    public void Spawn(Transform spawnPoint)
    {
        transform.Spawn(spawnPoint);
    }

    public void Spawn(Transform spawnPoint, float yOffset)
    {
        transform.Spawn(spawnPoint);
        transform.Translate(Vector3.up * yOffset);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            if (other.tag == "End")
            {
                gameObject.SetActive(false);
                PlayerManager.instance.TakeDamage(strength);
            }
            /*
            else
            {
                targetIndex++;
                target = checkPoints[targetIndex];
            }
            */
        }
    }

    public void TakeCheckPoints()
    {
        GameObject aux = GameObject.Find("CheckPoints");
        checkPoints = new Transform[aux.transform.childCount];
        for(int i=0; i<checkPoints.Length;i++)
        {
            checkPoints[i] = aux.transform.GetChild(i);
        }
        target = checkPoints[0];
        targetIndex = 0;
    }

    IEnumerator RotateToTarget()
    {
        /*
        Vector3 direction;
        Quaternion lookRotation;
        direction = target.position - transform.position;
        lookRotation = Quaternion.LookRotation(direction);
        float t = 0;
        while(t<1)
        {
            t += Time.deltaTime / rotationSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, t);
            //Mathf.Lerp()
            yield return 0;
        }
        */
        
        Vector3 direction;
        Quaternion lookRotation;
        while(true)
        {
            direction = target.position - transform.position;
            lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            yield return 0;
        }
        
    }
}
