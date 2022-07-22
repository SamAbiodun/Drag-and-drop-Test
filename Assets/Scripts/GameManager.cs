using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip appear;
    [SerializeField] AudioClip success;

    [SerializeField] private List<GameObject> fruitPrefabs;

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private GameObject first, second, third;

    public GameObject text;

    bool not1, not2, not3;
    // Start is called before the first frame update
    void Start()
    {
        not1= true;
        not2 = true;
        not3 = true;
        text.SetActive(false);
        Invoke("Beginning", 1.5f);
        //var randomSet = fruitPrefabs.OrderBy(s => Random.value).Take(3).ToList();
        /*for (int i = 0; i < randomSet.Count; i++)
        {
            var spawnPlayer = Instantiate(randomSet[i], spawnPoint.position, Quaternion.identity);
        }*/
        //var spawner = Instantiate(randomSet[0], spawnPoint.position, Quaternion.identity);
 
        //StartCoroutine(Spawn(2));
    }

    // Update is called once per frame
    void Update()
    {
        //var randomSet = fruitPrefabs.OrderBy(s => Random.value).Take(3).ToList();
        if (Banana.locked && not1)
        {
            source.PlayOneShot(success);
            StartCoroutine(Spawn2());
            not1 = false;
        }

        if (Grape.locked && not2)
        {
            source.PlayOneShot(success);
            StartCoroutine(Spawn3());
            not2 = false;
        }

        if (Cherry.locked && not3)
        {
            source.PlayOneShot(success);
            not3 = false;
        }
        if (Grape.locked && Cherry.locked && Grape.locked)
        {
            text.SetActive(true);
        }
    }

    void Beginning()
    {
        source.PlayOneShot(appear);
        first.SetActive(true);
    }

    IEnumerator Spawn2()
    {
        yield return new WaitForSeconds(1.5f);
        source.PlayOneShot(appear);
        second.SetActive(true);
    }
    IEnumerator Spawn3()
    {
        yield return new WaitForSeconds(1.5f);
        source.PlayOneShot(appear);
        third.SetActive(true);
    }
    /*public IEnumerator Spawn(float time)
    {
        int x = 0, lastX = 0;
        for (int i = 0; i < fruitPrefabs.Count; i++)
        {
            while (x == lastX)
            {
                x = Random.Range(0, fruitPrefabs.Count);
            }
            lastX = x;

            Instantiate(fruitPrefabs[x], spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }*/
}
