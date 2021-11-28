package quadTree;

public class DataException extends Exception {
	private static final long serialVersionUID = 1L;

	public DataException(String description, Exception e) {
		super(description, e);
	}

	public DataException(String format) {
		super(format);
	}

	public DataException(Exception e) {
		super(e);
	}

}
