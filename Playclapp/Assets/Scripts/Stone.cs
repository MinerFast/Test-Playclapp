using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private GameObject particle;

    private float speed;
    private float distance;

    private Spawner spawner;

    private bool isImmortality = true;

    #region MonoBehaviour
    private Vector3 lastPoint;

    private void Awake()
    {
        StartCoroutine(TimeForImmortality());
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        SetOption();
        lastPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + distance);
    }
    private void FixedUpdate()
    {
        MoveStone();
        if (this.transform.position == lastPoint && !isImmortality)
        {
           StoneEnd();
        }
    }
    #endregion
    void MoveStone()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, lastPoint, speed * Time.deltaTime);
    }
    void SetOption()
    {
        speed = spawner.speedStone;
        distance = spawner.distanceStone;
    }
    void StoneEnd()
    {
        var spawnParticle = Instantiate(particle, this.transform);
        spawnParticle.transform.parent = GameObject.Find("Particles").transform;
        Destroy(this.gameObject);
    }
    IEnumerator TimeForImmortality()
    {
        yield return new WaitForSeconds(0.5f);
        isImmortality = false;
    }

}
