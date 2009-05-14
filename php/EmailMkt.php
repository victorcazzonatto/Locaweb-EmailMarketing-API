<?php
/**
 *  Copyright (c) 2009, Locaweb LTDA.
 * 	Todos os direitor reservados.
 *
 *  Está é uma API exemplo que facilita a utilização dos web services do Email Marketing.
 *
 * @version 1.0
 * @see wiki
 */
class EmailMkt {

	private $HOSTNAME_SUFIX='tecnologia.ws';

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
	 * @param string hostName Login usado no Email Marketing.
	 * @param string Login usado no Email Marketing.
	 * @param string Chave gerada para uso dessa API.
	 */
	public function EmailMkt($hostName, $login, $chaveApi) {
		$this->hostName = $hostName;
		$this->login = $login;
		$this->chaveApi = $chaveApi;
	}

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

	/**
	 * Retorna todos os contatos. Se o número de contatos for
	 * superior a xxxx contatos, os contatos são quebrados em páginas
	 * de xxxx elementos.
	 *
	 * @param string pagina Número da página
	 * @return array Contatos ou null se não tiver contatos.
	 */
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
