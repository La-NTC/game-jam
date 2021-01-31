using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
	public Transform objectHolder;
	public float throwForce;
	public bool carryObject;
	public GameObject item;
	public float pickUpDistance;

    // Update is called once per frame
    void Update() {
		if(Input.GetKeyDown(KeyCode.E)) {
			grabObject();
		}

		if (Input.GetMouseButton(1)) {
			leaveObject(false);
		}

		if (Input.GetMouseButton(0)) {
			leaveObject(true);
		}
	}

	void grabObject() {
		RaycastHit hit;
		Ray directionRay = new Ray(transform.position, transform.forward);
		if (Physics.Raycast(directionRay, out hit, pickUpDistance)) {
			if (hit.collider.tag == "PickableObject" && !carryObject) {
				carryObject = true;
				item = hit.collider.gameObject;
				item.transform.SetParent(objectHolder);
				item.gameObject.transform.position = objectHolder.position;
				item.GetComponent<Rigidbody>().isKinematic = true;
				item.GetComponent<Rigidbody>().useGravity = false;
			}
		}
	}

	void leaveObject(bool throwObject) {
		carryObject = false;
		objectHolder.DetachChildren();
		item.GetComponent<Rigidbody>().isKinematic = false;
		item.GetComponent<Rigidbody>().useGravity = true;
		if (throwObject) {
			item.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * throwForce);
		}
	}
}
