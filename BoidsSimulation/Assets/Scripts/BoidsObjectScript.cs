using Unity.Mathematics;
using UnityEngine;

public class Boid 
{

    
    private Vector3 position;
    private Vector3 velocity;
    private Vector3 acceleration;

    public Boid(Vector3 _position, Vector3 _velocity){
        position = _position;
        velocity = _velocity;
    }
    
    public Vector3 GetPosition(){
        return position;
    }
    public void SetPosition(Vector3 newPosition){
        this.position = newPosition;
    }
    public Vector3 GetVelocity(){
        return velocity;
    }
    
}

