package br.com.locaweb.emailmarketing.api.exemplos;

import java.util.List;

import br.com.locaweb.emailmarketing.api.contatos.Contatos;
import br.com.locaweb.emailmarketing.api.contatos.RepositorioContatos;

public class ListarContatos {

	public static void main(String[] args) throws Exception {
		String hostName = "";
		String login = "gustavo";
		String chaveApi = "e538ea19267cfdb98f423209419ff77c";
		RepositorioContatos rc = new RepositorioContatos(hostName, login, chaveApi);

		int i = 1;
		List<Contatos> resultado = rc.pegaContatosValidos(i++);
		while(!resultado.isEmpty()) {
			for (Contatos contato : resultado) {
				System.out.println("Email: " + contato.pegaEmail());
				System.out.println("Nome: " + contato.pegaAtributo("nome"));
			}
			resultado = rc.pegaContatosValidos(i++);
		}
	}
}
