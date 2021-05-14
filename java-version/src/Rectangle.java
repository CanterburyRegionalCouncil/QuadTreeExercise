package quadTree;

public class Rectangle {
	public float x1, x2, y1, y2;
	
	public Rectangle() {
		this(Float.POSITIVE_INFINITY, Float.POSITIVE_INFINITY, Float.NEGATIVE_INFINITY, Float.NEGATIVE_INFINITY);
	};
	
	public Rectangle(float _x1, float _y1, float _x2, float _y2) {
		this.x1 = _x1;
		this.y1 = _y1;
		this.x2 = _x2;
		this.y2 = _y2;
	}
}
