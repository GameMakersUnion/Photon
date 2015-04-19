using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Emitter : MonoBehaviour
{
    LineRenderer line;
    List<Vector3> list = new List<Vector3>();
    Vector3 initialLightDir;
	RaycastHit2D hit;
	RaycastHit2D[] hits;
	bool isReflection = false;

    // Use this for initialization
    void Start()
    {
        line = GetComponent<LineRenderer>();
        initialLightDir = new Vector3(1, 1);
		list.Add (transform.position);
		SetPoint (transform.position, initialLightDir);
	}

    // Update is called once per frame
    void Update()
    {
		SetLine ();
    }

    //is called recursively to draw the beam of light
    void SetPoint(Vector3 origin, Vector3 direction)
    {
		if (isReflection) {
			hits = Physics2D.RaycastAll (origin, direction);
			if (hits.Length > 1) {
				switch (hits[1].collider.tag) {
				case "Solid":
					list.Add (hits[1].point);
					break;
				case "Reflect":
					list.Add (hits[1].point);
					isReflection = true;
					Vector3 reflection = Reflect (hits[1], direction);
					SetPoint (hits[1].point, reflection);
					break;
				case "Refract":
					list.Add (hits[1].point);
					//Vector3 refraction = Refract (hit, direction);
					SetPoint (hits[1].point, new Vector3 (0, 1, 0));
					break;
				default:
					Debug.Log ("default");
					break;
				}
				isReflection = false;
			} else {
				list.Add (direction * 20);
			}
		} else {
			hit = Physics2D.Raycast (origin, direction);
			if (hit.collider != null) {
				switch (hit.collider.tag) {
				case "Solid":
					list.Add (hit.point);
					break;
				case "Reflect":
					list.Add (hit.point);
					isReflection = true;
					Vector3 reflection = Reflect (hit, direction);
					SetPoint (hit.point, reflection);
					break;
				case "Refract":
					list.Add (hit.point);
					//Vector3 refraction = Refract (hit, direction);
					SetPoint (hit.point, new Vector3 (0, 1, 0));
					break;
				default:
					Debug.Log ("default");
					break;
				}
			} else {
				list.Add (direction * 20);
			}
		}
	}
	
	Vector3 Reflect(RaycastHit2D hit, Vector3 direction) {
        Vector2 normal = hit.normal;
        Vector2 incidentVect = direction.normalized;
        Vector2 reflectedVect = incidentVect - 2 * (Vector2.Dot(incidentVect, normal)) * normal;
		return reflectedVect;
    }

    Vector3 Refract(RaycastHit2D hit, Vector3 direction) {
		return direction + new Vector3(1,2,3);
    }

    void SetLine() {
        line.SetVertexCount(list.Count);
        line.SetPosition(0, transform.position);
        for (int i = 1; i < list.Count; i++)
        {
            line.SetPosition(i, list[i]);
        }
    }

}
