package quadTree;

import static org.junit.Assert.assertTrue;

import java.util.Collections;
import java.util.Comparator;
import java.util.List;

import org.junit.Test;

public class QuadTreeTest {
	private static final String DATASET = "dataset.dat";
	private static final String EXPECTED_DATASET = "expected_dataset.dat";

	private Comparator<? super DataPoint> resultComparator = new Comparator<DataPoint>() {
		@Override
		public int compare(DataPoint o1, DataPoint o2) {
			float r1 = (float)Math.sqrt(o1.x * o1.x + o1.y * o1.y);
			float r2 = (float)Math.sqrt(o2.x * o2.x + o2.y * o2.y);

			return Float.compare(r1, r2);
		}
	};

	@Test
	public void testIntersect() throws Exception {
		List<DataPoint> dataset = DataSet.readDataPoints(DATASET);
		Rectangle rect = new Rectangle(-0.1f, -0.1f, 0.1f, 0.1f);

		List<DataPoint> expectedResult = DataSet.readDataPoints(EXPECTED_DATASET);
		List<DataPoint> actualResult = getIntersectedSetUsingQuadTree(dataset, rect);

		Collections.sort(actualResult, resultComparator);

		assertTrue(identical(actualResult, expectedResult));
	}

	private List<DataPoint> getIntersectedSetUsingQuadTree(List<DataPoint> dataset, Rectangle rect) {

		throw new UnsupportedOperationException("Not Yet Implemented");
	}

	private boolean identical(List<DataPoint> testSet1, List<DataPoint> testSet2) {
		if(testSet1.size() != testSet2.size()) {
            return false;
        }

		for (int i = 0; i < testSet1.size(); i++) {
			if (!testSet1.get(i).equals(testSet2.get(i))) {
				return false;
			}
		}

		return true;
	}
}
