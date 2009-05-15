package br.com.locaweb.emailmarketing.api.contatos;

import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.JSONValue;

import br.com.locaweb.emailmarketing.api.EmktApiException;
import br.com.locaweb.emailmarketing.api.EmktCore;

public class RepositorioContatos {

	private String hostName;

	private String login;

	private String chave;

	private EmktCore emktCore;

	public RepositorioContatos(String hostName, String login, String chave) {
		this(hostName, login, chave, new EmktCore());
	}

	protected RepositorioContatos(String hostName, String login, String chave, EmktCore emktCore) {
		this.hostName = hostName;
		this.login = login;
		this.chave = chave;
		this.emktCore = emktCore;
	}

	public List<Contatos> pegaContatosValidos(int pagina) throws EmktApiException {

		return pegaContatos(pagina, "validos");
	}

	protected List<Contatos> pegaContatos(int pagina, String status) throws EmktApiException {
		if (pagina <= 0) {
			pagina = 1;
		}


//		 String url = "http://" + this.hostName + ".locaweb.com.br/admin/api/"
//		 + this.login +	 "/contatos/" + status + "?chave_api=" + this.chave + "&pagina=" + pagina;

		String url = "http://testelmm.tecnologia.ws/admin/api/" + this.login
				+ "/contatos/" + status + "?chave=" + this.chave
				+ "&pagina=" + String.valueOf(pagina);



		String resultado = emktCore.enviaRequisicao(url);

		return parseJson(resultado);
	}

	private List<Contatos> parseJson(String dados) {
		List<Contatos> contatos = new LinkedList<Contatos>();
		if(dados== "") {
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
