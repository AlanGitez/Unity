using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonoBehaviour
{
    public float patrolSpeed;
    public float waitingTime;
    public List<float> randomXRange;
    public List<float> randomYRange;

    private GameObject wayPoint;
    private Vector3 dir;

    private StatesMachine stateMachine;
    private VisionController visionController;
    private PersecutionState persecutionState;
    private GameObject player;
    private Rigidbody2D rb;
    
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<StatesMachine>();
        visionController = GetComponent<VisionController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
         TargetUpdate();
       
        StartCoroutine(PatrolUpdate());
    }

    void FixedUpdate()
    {   
        TargetUpdate();
        if(visionController.PlayerDetection()){
            stateMachine.StatusUpdate(stateMachine.persecutionState);
            
            return;
        }        
    }


    // GENERA UN TARGET ALEATORIAMENTE EN CUALQUIER PARTE DEL MAPA.
    // TENER EN CUENTA LAS 2 LISTAS QUE CONTIENEN POSICIONES ALEATORIAS.
    private void TargetUpdate(){
        float randomPosX = Random.Range(randomXRange[0], randomXRange[1]);
        float randomPosY = Random.Range(randomYRange[0], randomYRange[1]);
        if(wayPoint == null && gameObject != null){
            wayPoint = new GameObject("Target");
            wayPoint.transform.position = new Vector2(randomPosX, randomPosY);
        }    
    }


    private IEnumerator PatrolUpdate(){
        
        //float distance = Vector2.Distance(transform.position, target.transform.position);
        while(Vector2.Distance(transform.position, wayPoint.transform.position) >= 0.05f){
           
            MoveToTarget();

            yield return null;
        } 
        rb.velocity = Vector2.zero;
        Destroy(wayPoint.gameObject); // CLAVE PARAR QUE SE MUEVA

        yield return new WaitForSeconds(waitingTime);
        TargetUpdate();
        StartCoroutine(PatrolUpdate());


    }

    // A CONSIDERACION DE QUE ES EL MECANISMO DE MOVIMIENTO QUE MEJOR ME FUNCIONO
    public void MoveToTarget(){
        dir = (wayPoint.transform.position - transform.position);
        float movX = dir.normalized.x * patrolSpeed * Time.fixedDeltaTime;
        float movY = dir.normalized.y * patrolSpeed * Time.fixedDeltaTime;
        rb.velocity = new Vector2(movX, movY);

        Vector3 lookAt = wayPoint.transform.position - transform.position;

        float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg;
        rb.SetRotation(angle+90f);      
    }

    // A CHEQUEAR, PERO LO USO PARA QUE, AL PONER SETACTIVE=FALSE LUEGO DE "ISDIE", SE RESETEE EL TARGET Y EL MOVIMIENTO
    private void OnEnable() {
        TargetUpdate();
       
        StartCoroutine(PatrolUpdate());
        
    }

    // PARA VERLO EN EL MAPA AL TARGET 
    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        if(wayPoint != null){
        Gizmos.DrawWireSphere(wayPoint.transform.position, 2f);
        }
    }

    // NO FUNCIONO, LA IDEA ERA QUE CON ESTO, EL ENEMY TE SIGA SOLO CON DISPARARLE 
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Bullet"){
            stateMachine.StatusUpdate(stateMachine.persecutionState);
        }
    }
    
}
