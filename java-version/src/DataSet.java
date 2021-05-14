package quadTree;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.util.ArrayList;
import java.util.List;

public class DataSet {
	public static final List<DataPoint> readDataPoints(String filename) throws DataException {
		ObjectInputStream ois;
		
		try {
			ois = new ObjectInputStream(new FileInputStream(filename));
		} catch (IOException e) {
			throw new DataException("Can't open input stream", e);
		}
		
		int size = 0;
		
		try {
			size = ois.readInt();
		} catch (IOException e) {
			throw new DataException("Couldn't read size from output stream", e);
		}

		ArrayList<DataPoint> dataset = new ArrayList<DataPoint>(size);
		int i = 0;
		
		try {
			for (i = 0; i < size; i++) {
				DataPoint p = (DataPoint)ois.readObject();
				dataset.add(p);
			}
		} catch (IOException e) {
			throw new DataException(String.format("Couldn't output data point at index %d to output stream", i), e);
		} catch (ClassNotFoundException e) {
			throw new DataException(e);
		}
		
		return dataset;
	}
}
