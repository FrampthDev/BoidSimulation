using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BoidsCubeScript : MonoBehaviour
{

    [SerializeField] private  GameObject BoidPrefab;
    Boid[] Boids= new Boid[10];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        for(int i = 0; i< Boids.Length; i++){
            Boids[i] = new Boid(new Vector3(Random.Range(0f,10f),Random.Range(0f,10f),Random.Range(0f,10f)), new Vector3(Random.Range(0f,0.01f),Random.Range(0f,0.01f),Random.Range(0f,0.01f)));
            //Show(Boids[i]);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i<Boids.Length;i++){
            MoveBoid(ref Boids[i]);
        }
        Debug.Log(Boids[0].GetPosition());
    }

    private void Show(Boid b){
        Instantiate(BoidPrefab,b.GetPosition(),Quaternion.identity);
    }

    private void MoveBoid(ref Boid b){

        b.SetPosition(b.GetPosition()+b.GetVelocity());
        //b.SetPosition(new Vector3(0,0,0));
        
        
    }
    void OnDrawGizmos(){
        foreach(Boid b in Boids){
            Gizmos.DrawSphere(b.GetPosition(),0.5f);
        }
    }
}
