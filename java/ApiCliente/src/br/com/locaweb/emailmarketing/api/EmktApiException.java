package br.com.locaweb.emailmarketing.api;

public class EmktApiException extends Exception {

	private static final long serialVersionUID = 5731986895294504913L;

	public EmktApiException(String message, Throwable cause) {
		super(message, cause);
	}

	public EmktApiException(String message) {
		super(message);
	}

	public EmktApiException(Throwable cause) {
		super(cause);
	}

}
