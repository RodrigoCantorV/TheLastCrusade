using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageEnemyIndicator : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float lifeTime = 0.6f;
    public float minDist = 2f;
    public float maxDist = 3f;

    

    private Vector3 iniPos;
    private Vector3 targetPos;
    private float timer;
    //public Enemy enemyDamage;
    

    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomDirection();   
    }

    private void GenerateRandomDirection() {
        Quaternion randomRotation = Random.rotation;
        Vector3 randomDirection = randomRotation.eulerAngles;
        float directionX = randomDirection.x;
        float directionY = randomDirection.y;
        float directionZ = randomDirection.z;

        
        // enemyDamage = GetComponent<Enemy>();
        
        // enemyDamage;

        transform.LookAt(2 * transform.position - Camera.main.transform.position, Camera.main.transform.up);

        //float direction = Random.rotation.eulerAngles.z;
        iniPos = transform.position;
        float dist = Random.Range(minDist, maxDist);
        targetPos = iniPos + (Quaternion.Euler(directionX, directionY, directionZ) * new Vector3(dist, dist, dist));
        //transform.localScale = Vector3.zero; 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float fraction = lifeTime / 2f;

        if (timer > lifeTime) Destroy(gameObject);    
        else if(timer > fraction) {
            text.color = Color.Lerp(text.color, Color.clear, (timer - fraction) / (lifeTime - fraction));
        }

        transform.localPosition = Vector3.Lerp(iniPos, targetPos, Mathf.Sin(timer / lifeTime));
        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.Sin(timer / lifeTime));    
    }

    public void SetDamageText(float damage) {
        text.text = damage.ToString();
    }
}