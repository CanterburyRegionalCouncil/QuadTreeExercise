package quadTree;

import java.io.Externalizable;
import java.io.IOException;
import java.io.ObjectInput;
import java.io.ObjectOutput;

public class DataPoint implements Externalizable {
	private static final float EPSILON = 0.000001f;
	public float x, y;
	
	public DataPoint(){};
	
	public DataPoint(float _x, float _y) {
		this.x = _x;
		this.y = _y;
	}

	@Override
	public void readExternal(ObjectInput in) throws IOException,
			ClassNotFoundException {
				x = in.readFloat();
				y = in.readFloat();
	}

	@Override
	public void writeExternal(ObjectOutput out) throws IOException {
		out.writeFloat(x);
		out.writeFloat(y);
	}
	
	@Override
	public boolean equals(Object obj) {
		if (obj instanceof DataPoint) {
			DataPoint that = (DataPoint)obj;
			
			return	Math.abs(this.x - that.x) < EPSILON && 
						Math.abs(this.y - that.y) < EPSILON;
		}
		
		return false;
	}
}
