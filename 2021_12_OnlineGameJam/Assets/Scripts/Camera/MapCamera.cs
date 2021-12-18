using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]

public class MapCamera : MonoBehaviour
{
	public Camera camera;
	public Transform target;
	public float y = 28.8f;


	float _smooth = 0.125f;

	float _camOffset = 5f;
	float _landY = -15f;
	float _lvGap = 60f;

	[SerializeField] float[] _lv1CamMm;
	[SerializeField] float[] _lv2CamMm;
	[SerializeField] float[] _lv3CamMm;
	[SerializeField] float[] _lv4CamMm;

	float _gap = 60f;

	private void Update()
	{
		LimitCamera();
	}

	void LimitCamera()
	{
		float ty = target.position.y;
		Vector3 desPos = new Vector3(0, target.transform.position.y + _camOffset, -10f);
		Vector3 smooth = Vector3.Lerp(transform.position, desPos, _smooth);


		if (ty < _landY + _lvGap) {
			camera.transform.position = new Vector3(0, Mathf.Clamp(smooth.y, _lv1CamMm[0], _lv1CamMm[1]), -10);
		}
		else if (_landY + _lvGap <= ty && ty < _landY + _lvGap * 2) {
			camera.transform.position = new Vector3(0, Mathf.Clamp(smooth.y, _lv2CamMm[0], _lv2CamMm[1]), -10);
		}
		else if (_landY + _lvGap * 2<= ty && ty < _landY + _lvGap * 3) {
			camera.transform.position = new Vector3(0, Mathf.Clamp(smooth.y, _lv3CamMm[0], _lv3CamMm[1]), -10);
		}
		else if (_landY + _lvGap * 3 <= ty && ty < 175f) {
			camera.transform.position = new Vector3(0, Mathf.Clamp(smooth.y, _lv4CamMm[0], _lv4CamMm[1]), -10);
		}
	}
}
