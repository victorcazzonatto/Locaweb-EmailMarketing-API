package br.com.locaweb.emailmarketing.api;

import java.io.IOException;

import org.apache.commons.httpclient.HttpClient;
import org.apache.commons.httpclient.HttpException;
import org.apache.commons.httpclient.HttpStatus;
import org.apache.commons.httpclient.methods.GetMethod;

public class EmktCore {

	public String enviaRequisicao(String url) throws EmktApiException {

		return enviaRequisicao(new HttpClient(), new GetMethod(url));
	}

	String enviaRequisicao(HttpClient clienteHttp, GetMethod metodo)
			throws EmktApiException {
		try {
			int statusCode = clienteHttp.executeMethod(metodo);
			byte[] corpoResposta = metodo.getResponseBody();
			String resposta = new String(corpoResposta);
			if (statusCode != HttpStatus.SC_OK) {
				throw new EmktApiException("Código HTTP: " + statusCode + " "
						+ resposta);
			}

			return resposta;
		} catch (HttpException e) {
			throw new EmktApiException("Erro no protocolo", e);
		} catch (IOException e) {
			throw new EmktApiException("Problemas com a rede", e);
		} finally {
			metodo.releaseConnection();
		}
	}
}
