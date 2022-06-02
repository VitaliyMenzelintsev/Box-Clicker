using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private GameManager gameManager; 

    private float minSpeed = 10;
    private float maxSpeed = 14;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = 1;

    public ParticleSystem explosionParticle;
    public int pointValue;

    private void Start()
    {
        targetRB = gameObject.GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();       //обращаемся к скрипту Game Manager 
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);                             //сила, подкидывающая предметы
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); //сила, крутящая предметы в полёте

        transform.position = RandomPos();
    }

    private void OnMouseDown() 
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue); //каждый удачный клик прибавляем очки
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other) //уничтожаем обьекты, когда они касаются триггера внизу
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }
}
