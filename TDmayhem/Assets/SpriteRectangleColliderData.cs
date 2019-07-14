using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRectangleColliderData : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Collider2D GetRectBoxCollider {
        get {
            return gameObject.GetComponent<BoxCollider2D>();
        }
    }

    public Bounds GetRectBoxColliderBounds {
        get {
            return GetRectBoxCollider.bounds;
        }
    }

    public float rightSpriteBoundSize {
        get {
            float BoundsSize;
            Bounds _spriteBounds = gameObject.GetComponent<SpriteRenderer>().bounds;
            return BoundsSize = _spriteBounds.max.x - _spriteBounds.center.x;
        }
    }


    /* public Bounds GetRectColliderBounds(Collider2D _UnitRectbox) {
            Bounds _bounds;
            return _bounds = _UnitRectbox.GetComponent<BoxCollider2D>().bounds;
        } */

    void Start()
    {
        
    }
}
