package br.com.locaweb.emailmarketing.api.contatos;

import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.JSONValue;

import br.com.locaweb.emailmarketing.api.EmktApiException;
import br.com.locaweb.emailmarketing.api.EmktCore;

/**
 * Copyright (c) 2009, Locaweb LTDA. Todos os direitor reservados.
 *
 * Est� � uma API exemplo que facilita a utiliza��o do web services de Contatos.
 *
 * Os m�todos de listagem possuem o par�metro p�gina. Ele informa qual p�gina da
 * pesquisa deve ser retornada. Atualmente o limite de contatos por p�gina � de
 * 25mil contatos por p�gina. Exemplo, caso tenha 40mil contatos em sua base
 * precisar� fazer 2 chamadas passando o par�metro pagina=1 (que devolver� os
 * contatos de 1 a 24999) e em seguida pagina=2 (que devolver� os contatos de
 * 25000 a 40000)
 *
 *
 * @version 0.1
 * @see http://wiki.locaweb.com.br/pt-br/APIs_do_Email_Marketing
 */
public class RepositorioContatos {

	private String hostName;

	private String login;

	private String chave;

	private EmktCore emktCore;

	public RepositorioContatos(String hostName, String login, String chave) {
		this(hostName, login, chave, new EmktCore());
	}

	RepositorioContatos(String hostName, String login, String chave,
			EmktCore emktCore) {
		this.hostName = hostName;
		this.login = login;
		this.chave = chave;
		this.emktCore = emktCore;
	}

	/**
	 * Retorna todos os contatos v�lidos.
	 *
	 * @param pagina
	 *            N�mero da p�gina, as listas de contatos s�o fornecidas
	 *            paginada.
	 *
	 * @return List<Contatos>
	 *
	 * @throws EmktApiException
	 */
	public List<Contatos> obterValidos(int pagina)
			throws EmktApiException {

		return pegaContatos(pagina, "validos");
	}

	/**
	 * Retorna todos os contatos inv�lidos.
	 *
	 * @param pagina
	 *            N�mero da p�gina, as listas de contatos s�o fornecidas
	 *            paginada.
	 *
	 * @return List<Contatos>
	 *
	 * @throws EmktApiException
	 */
	public List<Contatos> obterInvalidos(int pagina)
			throws EmktApiException {

		return pegaContatos(pagina, "invalidos");
	}

	/**
	 * Retorna todos os contatos descadastrados.
	 *
	 * @param pagina
	 *            N�mero da p�gina, as listas de contatos s�o fornecidas
	 *            paginada.
	 *
	 * @return List<Contatos>
	 *
	 * @throws EmktApiException
	 */
	public List<Contatos> obterDescadastrados(int pagina)
			throws EmktApiException {

		return pegaContatos(pagina, "Descadastrados");
	}

	/**
	 * Retorna todos os contatos descadastrados.
	 *
	 * @param pagina
	 *            N�mero da p�gina, as listas de contatos s�o fornecidas
	 *            paginada.
	 *
	 * @return List<Contatos>
	 *
	 * @throws EmktApiException
	 */
	public List<Contatos> obterNaoConfirmados(int pagina)
			throws EmktApiException {

		return pegaContatos(pagina, "nao_confirmados");
	}

	List<Contatos> pegaContatos(int pagina, String status)
			throws EmktApiException {
		if (pagina <= 0) {
			pagina = 1;
		}
		String url = "http://" + this.hostName + ".locaweb.com.br/admin/api/"
				+ this.login + "/contatos/" + status + "?chave_api="
				+ this.chave + "&pagina=" + pagina;
		String resultado = emktCore.enviaRequisicao(url);

		return parseJson(resultado);
	}

	private List<Contatos> parseJson(String dados) {
		List<Contatos> contatos = new LinkedList<Contatos>();
		if (dados == "") {
			return contatos;
		}
		JSONArray array = (JSONArray) JSONValue.parse(dados);
		for (Iterator i = array.iterator(); i.hasNext();) {
			JSONObject jObj = (JSONObject) i.next();
			contatos.add(new Contatos(jObj));
		}

		return contatos;
	}
}
