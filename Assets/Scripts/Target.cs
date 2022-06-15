using UnityEngine;

public class Target : MonoBehaviour
{


    private Rigidbody _targetRB;
    private GameManager _gameManager; 

    private float _minSpeed = 10;
    private float _maxSpeed = 14;
    private float _maxTorque = 10;
    private float _xRange = 4;
    private float _ySpawnPos = 1;

    public ParticleSystem ExplosionParticle;
    public int PointValue;

    private void Start()
    {
        _targetRB = gameObject.GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();       //обращаемся к скрипту Game Manager 
        _targetRB.AddForce(RandomForce(), ForceMode.Impulse);                             //сила, подкидывающая предметы
        _targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); //сила, крутящая предметы в полёте

        transform.position = RandomPos();
    }

    private void OnMouseDown() 
    {
        if (_gameManager.IsGameActive)
        {
            Destroy(gameObject);
            _gameManager.UpdateScore(PointValue); //каждый удачный клик прибавляем очки
            Instantiate(ExplosionParticle, transform.position, ExplosionParticle.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider _other) //уничтожаем обьекты, когда они касаются триггера внизу
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos, 0);
    }
}
