using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    private int score;
    [SerializeField]
    private Sprite[] spritesPipa;
    [SerializeField]
    private Button pipa;
    private int numeroSprite;
    private int probabilidadPalo;
    [SerializeField]
    private float limiteEjeXSpawnIzq;
    [SerializeField]
    private float limiteEjeXSpawnDer;
    [SerializeField]
    private float alturaYSpawn;
    [SerializeField]
    private GameObject[] pipaPrefab;
    private int pipaPrefabSprite;

    void Awake()
    {
        score = PlayerPrefs.GetInt("Score");
        if(score.Equals(null))
        {
            score = 0;
        }
        numeroSprite = Random.Range(0, 7);
        probabilidadPalo = Random.Range(0, 4095);
        if(probabilidadPalo == 0)
        {
            numeroSprite = 8;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        pipa.image.sprite = spritesPipa[numeroSprite];
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void cascarPipa()
    {
        if (numeroSprite != 8)
        {
            score++;
        }
        else
        {
            score = score + 100;
        }
        numeroSprite = Random.Range(0, 7);
        probabilidadPalo = Random.Range(0, 4095);
        if (probabilidadPalo == 0)
        {
            numeroSprite = 8;
        }
        pipa.image.sprite = spritesPipa[numeroSprite];
        Vector2 posicion = new Vector2(Random.Range(limiteEjeXSpawnIzq, limiteEjeXSpawnDer), alturaYSpawn);
        pipaPrefabSprite = Random.Range(0, 0);
        Instantiate(pipaPrefab[pipaPrefabSprite],posicion,Quaternion.identity);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Score", score);
    }
}
