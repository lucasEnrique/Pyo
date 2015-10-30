using UnityEngine;
using System.Collections;

public class TouchDrag : MonoBehaviour 
{
	public Transform scanPos;
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 curScreenPoint;
	private Vector3 curPosition;
	public char lockXY = 'n';

	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(scanPos.position);

		if(lockXY == 'y')
		{
			offset = scanPos.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z ));
		}
		if(lockXY == 'x')
		{
			offset = scanPos.position - Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z ));
		}
		if(lockXY == 'n')
		{
			offset = scanPos.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z ));
		}
	}
	void OnMouseDrag()
	{
		if(lockXY == 'y')
		{
			curScreenPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);
		}
       	if(lockXY == 'x')
       	{
			curScreenPoint = new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z);
       	}
       if(lockXY == 'n')
   		{
			curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		}
		
		curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}
}
