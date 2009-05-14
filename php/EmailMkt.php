<?php
/**
 *  Copyright (c) 2009, Locaweb LTDA.
 * 	Todos os direitor reservados.
 *
 *  Está é uma API exemplo que facilita a utilização dos web services do Email Marketing.
 *
 * @version 1.0
 * @see http://wiki.locaweb.com.br/pt-br/APIs_do_Email_Marketing
 */
class EmailMkt {

	private $HOSTNAME_SUFIX='locaweb.com.br';

	/**
	 * Nome do servidor.
	 */
  private $hostName;

	/**
	 * Login usado no Email Marketing.
	 */
	private $login;

	/**
	 * Chave gerada para uso dessa API.
	 */
	private $chaveApi;

	/**
	 * @param string hostName usado no Email Marketing.
	 * @param string Login usado no Email Marketing.
	 * @param string Chave gerada para uso dessa API.
	 */
	public function EmailMkt($hostName, $login, $chaveApi) {
		$this->hostName = $hostName;
		$this->login = $login;
		$this->chaveApi = $chaveApi;
	}

/************************** Inicio metodos de Listagem de Contatos **************************************************
 * Os métodos de listagem possuem o parâmetro pagina. Ele informa qual página da pesquisa deve ser retornada.
 * Atualmente o limite de contatos por página é de 25mil contatos por página.
 * Por isso, caso tenha 40mil contatos em sua base por exemplo, precisará fazer 2 chamadas passando
 * o parâmetro pagina=1 (que devolverá os contatos de 1 a 24999) e em seguida pagina=2 (que devolverá os contatos de 25000 a 40000)
 *
 */

	public function retornaContatosValidos($pagina='1'){
		return $this->retornaContatosPorStatus($pagina,'validos');
	}

	public function retornaContatosInvalidos($pagina='1'){
		return $this->retornaContatosPorStatus($pagina,'invalidos');
	}

	public function retornaContatosNaoConfirmados($pagina='1'){
		return $this->retornaContatosPorStatus($pagina,'nao_confirmados');
	}

	public function retornaContatosDescadastrados($pagina='1'){
		return $this->retornaContatosPorStatus($pagina,'descadastrados');
	}



	private function retornaContatosPorStatus($pagina='1', $status) {

		$url = "http://{$this->hostName}.{$this->HOSTNAME_SUFIX}/admin" .
				"/api/{$this->login}/contatos/{$status}?chave_api={$this->chaveApi}&pagina={$pagina}";

		$resultado = $this->enviaRequisicao($url);
		if($resultado==null) {
			return null;
		}
		$resultado = json_decode($resultado);

		return $resultado;
	}

/************************** Fim do metodos de Listagem de Contatos **************************************************/

	private function enviaRequisicao($url) {
		$curl = curl_init();
		curl_setopt($curl, CURLOPT_URL, $url);
		curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
		$resultado_http = curl_exec($curl);
		$http_code = curl_getinfo($curl, CURLINFO_HTTP_CODE);
		curl_close($curl);

		if($http_code == '200'){
			return $resultado_http;
		}
		elseif ($http_code == '404') {
			return null;
		}
		elseif ($http_code == '500') {
			throw new Exception("Erro interno no servidor: $resultado_http");
		}
		elseif ($http_code == '401') {
			throw new Exception("Nao autorizado");
		}
		elseif ($http_code == '400') {
			throw new Exception("Parametros invalidos");
		}
		else{
			throw new Exception("Erro inesperado: statusCode:$http_code, mensagem:$resultado_http");
			return null;
		}
	}
}

?>
