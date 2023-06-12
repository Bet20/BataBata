using System;

[Serializable]
public class LevelAsset {
	public int ID;
	public float x;
	public float z;
	public float rotation;

	public LevelAsset(int ID, float x, float z, float rotation)
	{
		this.ID = ID;
		this.x = x;
		this.z = z;
		this.rotation = rotation;
	}
}