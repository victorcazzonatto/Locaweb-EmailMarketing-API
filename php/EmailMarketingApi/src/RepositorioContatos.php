<?php
require_once dirname(__FILE__).'/EmktCore.php';

/**
 *  Copyright (c) 2009, Locaweb LTDA.
 * 	Todos os direitor reservados.
 *
 *  Est� � uma API exemplo que facilita a utiliza��o dos web services do Email Marketing.
 *
 * @version 1.0
 * @see http://wiki.locaweb.com.br/pt-br/APIs_do_Email_Marketing
 */
class RepositorioContatos {

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
 * Os m�todos de listagem possuem o par�metro pagina. Ele informa qual p�gina da pesquisa deve ser retornada.
 * Atualmente o limite de contatos por p�gina � de 25mil contatos por p�gina.
 * Por isso, caso tenha 40mil contatos em sua base por exemplo, precisar� fazer 2 chamadas passando
 * o par�metro pagina=1 (que devolver� os contatos de 1 a 24999) e em seguida pagina=2 (que devolver� os contatos de 25000 a 40000)
 *
 */

	public function obterValidos($pagina='1'){
		return $this->retornaContatosPorStatus($pagina,'validos');
	}

	public function obterInvalidos($pagina='1'){
		return $this->retornaContatosPorStatus($pagina,'invalidos');
	}

	public function obterNaoConfirmados($pagina='1'){
		return $this->retornaContatosPorStatus($pagina,'nao_confirmados');
	}

	public function obterDescadastrados($pagina='1'){
		return $this->retornaContatosPorStatus($pagina,'descadastrados');
	}

	private function retornaContatosPorStatus($pagina='1', $status) {
		$url = "http://{$this->hostName}.{$this->HOSTNAME_SUFIX}/admin" .
				"/api/{$this->login}/contatos/{$status}?chave_api={$this->chaveApi}&pagina={$pagina}";
		$resultado = EmktCore::enviaRequisicao($url);
		if($resultado==null) {
			return null;
		}
		$resultado = json_decode($resultado);

		return $resultado;
	}

}
?>