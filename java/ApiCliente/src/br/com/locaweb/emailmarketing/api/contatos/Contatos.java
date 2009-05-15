package br.com.locaweb.emailmarketing.api.contatos;

import org.json.simple.JSONObject;


public class Contatos {

	private JSONObject jsonObj;

	public Contatos(JSONObject jsonObj) {
		this.jsonObj = jsonObj;
	}

	public String pegaEmail() {

		return pegaAtributo("email");
	}

	public String pegaAtributo(String nomeAtribuito) {

		return (String) jsonObj.get(nomeAtribuito);
	}

}
