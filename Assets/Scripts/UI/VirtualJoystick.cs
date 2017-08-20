using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler {
	private Image bgImg;
	private Image JoystickImg;
	private Vector3 InputVector;

	public virtual void OnPointerDown(PointerEventData ped){
		OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped){
		InputVector = Vector3.zero;
		JoystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	public virtual void OnDrag(PointerEventData ped){
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform, 
			ped.position, ped.pressEventCamera, out pos)) {
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

			InputVector = new Vector3 (pos.x * 3 +1, 0, pos.y * 3 - 1);
			InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;

			// Move joystick image
			JoystickImg.rectTransform.anchoredPosition = 
				new Vector3(InputVector.x * bgImg.rectTransform.sizeDelta.x/2 , InputVector.z * bgImg.rectTransform.sizeDelta.y/2);
		}

	}

	public float Horizonal(){
		if(InputVector.x != 0)
			return InputVector.x;
		else
			return Input.GetAxis("Horizontal");
	}
	public float Vertical(){
		if(InputVector.z != 0)
			return InputVector.z;
		else
			return Input.GetAxis("Vertical");
	}

	// Use this for initialization
	void Start () {
		bgImg = GetComponent<Image> ();
		JoystickImg = transform.GetChild (0).GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
