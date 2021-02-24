using UnityEditor;
using UnityEngine;


public static class Utilits {
	public static Vector2 Vector2(this Vector3 v) {
		return new Vector2(v.x, v.y);
	}
	public static Vector3 Vector3(this Vector2 v) {
		return new Vector3(v.x, v.y, 0);
	}
}