package br.com.locaweb.emailmarketing.api;

import static org.easymock.EasyMock.expect;
import static org.easymock.classextension.EasyMock.createMock;
import static org.easymock.classextension.EasyMock.replay;
import static org.easymock.classextension.EasyMock.verify;
import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

import java.io.IOException;
import java.util.List;

import org.apache.commons.httpclient.HttpClient;
import org.apache.commons.httpclient.HttpException;
import org.apache.commons.httpclient.methods.GetMethod;
import org.junit.Before;
import org.junit.Test;

import br.com.locaweb.emailmarketing.api.contatos.Contatos;
import br.com.locaweb.emailmarketing.api.contatos.RepositorioContatos;


public class EmktCoreTest {

	private HttpClient clienteHttpMock;

	private GetMethod metodoMock;

	@Before
	public void iniciar() {
		clienteHttpMock = createMock(HttpClient.class);
		metodoMock = createMock(GetMethod.class);
	}

	@Test
	public void enviaRequisicaoValorDeRetornoIgual200() throws Exception {
		expect(clienteHttpMock.executeMethod(metodoMock)).andReturn(200);
		expect(metodoMock.getResponseBody()).andReturn("".getBytes());
		metodoMock.releaseConnection();
		replay(clienteHttpMock);
		replay(metodoMock);
		EmktCore emktCore = new EmktCore();
		assertEquals("", emktCore.enviaRequisicao(clienteHttpMock, metodoMock));
	}

	@Test(expected=EmktApiException.class)
	public void enviaRequisicaoValorDeRetornoDiferenteDe200() throws Exception {
		expect(clienteHttpMock.executeMethod(metodoMock)).andReturn(404);
		expect(metodoMock.getResponseBody()).andReturn("".getBytes());
		metodoMock.releaseConnection();
		replay(clienteHttpMock);
		replay(metodoMock);
		EmktCore emktCore = new EmktCore();
		emktCore.enviaRequisicao(clienteHttpMock, metodoMock);
	}

	@Test(expected=EmktApiException.class)
	public void enviaRequisicaoHttpExceptionLancada() throws Exception {
		expect(clienteHttpMock.executeMethod(metodoMock)).andStubThrow(new HttpException());
		metodoMock.releaseConnection();
		replay(clienteHttpMock);
		replay(metodoMock);
		EmktCore emktCore = new EmktCore();
		emktCore.enviaRequisicao(clienteHttpMock, metodoMock);
	}

	@Test(expected=EmktApiException.class)
	public void enviaRequisicaoIOExceptionLancada() throws Exception {
		expect(clienteHttpMock.executeMethod(metodoMock)).andStubThrow(new IOException());
		metodoMock.releaseConnection();
		replay(clienteHttpMock);
		replay(metodoMock);
		EmktCore emktCore = new EmktCore();
		emktCore.enviaRequisicao(clienteHttpMock, metodoMock);
	}

}
