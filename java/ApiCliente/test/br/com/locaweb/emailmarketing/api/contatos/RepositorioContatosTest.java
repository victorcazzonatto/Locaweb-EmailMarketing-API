package br.com.locaweb.emailmarketing.api.contatos;

import static org.easymock.EasyMock.expect;
import static org.easymock.classextension.EasyMock.createMock;
import static org.easymock.classextension.EasyMock.replay;
import static org.easymock.classextension.EasyMock.verify;
import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

import java.util.List;

import org.junit.Before;
import org.junit.Test;

import br.com.locaweb.emailmarketing.api.EmktCore;

public class RepositorioContatosTest {

	private EmktCore emktCoreMock;

	private String urlExpected;

	private RepositorioContatos rc;

	@Before
	public void iniciar() {
		emktCoreMock = createMock(EmktCore.class);
		rc = new RepositorioContatos("test", "gustavo",
				"e538ea19267cfdb98f423209419ff77c", emktCoreMock);
		urlExpected = "http://test.locaweb.com.br/admin/api/gustavo/contatos/validos?chave_api=e538ea19267cfdb98f423209419ff77c&pagina=1";
	}

	@Test
	public void retornaContatosValidosVerificaSeAUrlEhValida() throws Exception {
		expect(emktCoreMock.enviaRequisicao(urlExpected)).andReturn("");
		replay(emktCoreMock);
		rc.pegaContatos(1, "validos");
		verify(emktCoreMock);
	}

	@Test
	public void retornaContatosValidosDeveRetornarUmContatoValido() throws Exception {
		String respostaMock = "[{\"email\":\"xconta4@testecarganl.tecnologia.ws\",\"nome\":\"nomeTeste\"}]";
		expect(emktCoreMock.enviaRequisicao(urlExpected)).andReturn(respostaMock);
		replay(emktCoreMock);
		List<Contatos> contatos =rc.pegaContatos(1, "validos");
		assertEquals(1, contatos.size());
		assertEquals("xconta4@testecarganl.tecnologia.ws", contatos.get(0).pegaEmail());
		assertEquals("nomeTeste", contatos.get(0).pegaAtributo("nome"));
		verify(emktCoreMock);
	}

	@Test
	public void retornaContatosValidosNumeroDaPaginaMenorOuIgualAZero() throws Exception {
		expect(emktCoreMock.enviaRequisicao(urlExpected)).andReturn("");
		expect(emktCoreMock.enviaRequisicao(urlExpected)).andReturn("");
		replay(emktCoreMock);
		rc.pegaContatos(0, "validos");
		rc.pegaContatos(-1, "validos");
		verify(emktCoreMock);
	}

	@Test
	public void retornaContatosValidosRecebeDadosEmBranco() throws Exception {
		expect(emktCoreMock.enviaRequisicao(urlExpected)).andReturn("");
		replay(emktCoreMock);
		List<Contatos> contatos =rc.pegaContatos(1, "validos");
		assertTrue(contatos.isEmpty());
		verify(emktCoreMock);
	}

	@Test(expected=NullPointerException.class)
	public void retornaContatosValidosRecebeDadosNulo() throws Exception {
		expect(emktCoreMock.enviaRequisicao(urlExpected)).andReturn(null);
		replay(emktCoreMock);
		List<Contatos> contatos =rc.pegaContatos(1, "validos");
		assertTrue(contatos.isEmpty());
		verify(emktCoreMock);
	}

	@Test(expected=Error.class)
	public void retornaContatosValidosErroAoFazerOParse() throws Exception {
		expect(emktCoreMock.enviaRequisicao(urlExpected)).andReturn("String inválida.");
		replay(emktCoreMock);
		rc.pegaContatos(1, "validos");
		verify(emktCoreMock);
	}

}
