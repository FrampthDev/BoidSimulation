using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BoidsCubeScript : MonoBehaviour
{

    [SerializeField] private  GameObject BoidPrefab;
    [SerializeField] private Vector3 ActionCube;
    

    [SerializeField] private int nBoids, BoidsVelocity;
    private Boid[] Boids;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Boids = new Boid[nBoids];
        for(int i = 0; i< Boids.Length; i++){
            Boids[i] = new Boid(new Vector3(Random.Range(0f,10f),Random.Range(0f,10f),Random.Range(0f,10f)), 
            (Vector3.Normalize(new Vector3(Random.Range(0f,0.1f),Random.Range(0f,0.1f),Random.Range(0f,0.1f)))));
            //Show(Boids[i]);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i<Boids.Length;i++){
            MoveBoid(ref Boids[i]);
        }
        //Debug.Log(Boids[0].GetPosition());
    }

    private void Show(Boid b){
        Instantiate(BoidPrefab,b.GetPosition(),Quaternion.identity);
    }

    private void MoveBoid(ref Boid b){


        if ((b.GetPosition().x<-ActionCube.x/2 -transform.position.x || b.GetPosition().x>ActionCube.x/2 -transform.position.x) ||
            (b.GetPosition().y<-ActionCube.y/2 -transform.position.y || b.GetPosition().y>ActionCube.y/2 -transform.position.y) ||
            (b.GetPosition().z<-ActionCube.z/2 -transform.position.z || b.GetPosition().z>ActionCube.z/2 -transform.position.z)){
                b.SetPosition(-b.GetPosition()+new Vector3(0.1f,0.1f,0.1f));
            }
        else {
            b.SetPosition(b.GetPosition()+b.GetVelocity()*Time.deltaTime*BoidsVelocity);
        }
    
    }
    void OnDrawGizmos(){
        
        Gizmos.DrawWireCube(transform.position, ActionCube);
        foreach(Boid b in Boids){
            Gizmos.DrawSphere(b.GetPosition(),0.5f);
        }
    }
}
