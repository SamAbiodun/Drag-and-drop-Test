using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip appear;
    [SerializeField] AudioClip success;

    [SerializeField] Transform spawnLocation;

    public GameObject gameOver;

    PuzzlePiece Master;

    PuzzlePiece puzzlePiece;

    public GameObject spawnPiece1, spawnPiece2, spawnPiece3;

    bool not2, not3;

    [SerializeField] private List<GameObject> piecePrefabList;

    private void Start()
    {
        gameOver.SetActive(false);
        //not1 = true;
        not2 = true;
        not3 = true;
        Appear();
        Spawn();
        Invoke("Spawn1", 1.7f);
        //spawnPiece1.SetActive(true);

        //spawnPiece3.SetActive(true);
    }

    private void Update()
    {
        if (spawnPiece1.GetComponent<PuzzlePiece>().placed && not2)
        {
            StartCoroutine(Spawn2());
            not2 = false;
        }

        if (spawnPiece2.GetComponent<PuzzlePiece>().placed && not3)
        {
            StartCoroutine(Spawn3());
            not3 = false;
        }

        if (spawnPiece1.GetComponent<PuzzlePiece>().placed && spawnPiece2.GetComponent<PuzzlePiece>().placed && spawnPiece3.GetComponent<PuzzlePiece>().placed)
        {
            gameOver.SetActive(true);
        }
    }

    void Spawn1()
    {
        source.PlayOneShot(appear);
        spawnPiece1.SetActive(true);
    }

    IEnumerator Spawn2()
    {
        yield return new WaitForSeconds(0.8f);
        spawnPiece2.SetActive(true);
        source.PlayOneShot(appear);
    }
    IEnumerator Spawn3()
    {
        yield return new WaitForSeconds(0.8f);
        spawnPiece3.SetActive(true);
        source.PlayOneShot(appear);
    }

    void Sounds()
    {
        source.PlayOneShot(appear);
    }

    void Spawn()
    {
        var randomSet = piecePrefabList.OrderBy(s => Random.value).Take(3).ToList();
        spawnPiece1 = Instantiate(randomSet[0], spawnLocation.position, Quaternion.identity);
        spawnPiece2 = Instantiate(randomSet[1], spawnLocation.position, Quaternion.identity);
        spawnPiece3 = Instantiate(randomSet[2], spawnLocation.position, Quaternion.identity);
        spawnPiece1.SetActive(false);
        spawnPiece2.SetActive(false);
        spawnPiece3.SetActive(false);
    }

    void Appear()
    {
        Invoke("Sounds", 0.083f);
        Invoke("Sounds", 0.6f);
        Invoke("Sounds", 1.1f);
    }
}
