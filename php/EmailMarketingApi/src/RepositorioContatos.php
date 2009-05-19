<?php
require_once dirname(__FILE__).'/EmktCore.php';

/**
 *  Copyright (c) 2009, Locaweb LTDA.
 * 	Todos os direitor reservados.
 *
 *  Estс щ uma API exemplo que facilita a utilizaчуo dos web services do Email Marketing.
 *
 * @version 0.1
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
	private $chave;

	private $emktCore;

	private $hostNameSufix;

	/**
	 * @param string hostName usado no Email Marketing.
	 * @param string Login usado no Email Marketing.
	 * @param string Chave gerada para uso dessa API.
	 */
	public function RepositorioContatos($hostName, $login, $chave, $hostNameSufix='tecnologia.ws') {
		$this->hostName = $hostName;
		$this->login = $login;
		$this->chave = $chave;
		$this->hostNameSufix = $hostNameSufix;
		$this->emktCore = new EmktCore();
	}


/************************** Inicio metodos de Listagem de Contatos **************************************************
 * Os mщtodos de listagem possuem o parтmetro pagina. Ele informa qual pсgina da pesquisa deve ser retornada.
 * Atualmente o limite de contatos por pсgina щ de 25mil contatos por pсgina.
 * Por isso, caso tenha 40mil contatos em sua base por exemplo, precisarс fazer 2 chamadas passando
 * o parтmetro pagina=1 (que devolverс os contatos de 1 a 24999) e em seguida pagina=2 (que devolverс os contatos de 25000 a 40000)
 *
 */

	public function obterValidos($pagina='1'){
		return $this->obterPorStatus($pagina,'validos');
	}

	public function obterInvalidos($pagina='1'){
		return $this->obterPorStatus($pagina,'invalidos');
	}

	public function obterNaoConfirmados($pagina='1'){
		return $this->obterPorStatus($pagina,'nao_confirmados');
	}

	public function obterDescadastrados($pagina='1'){
		return $this->obterPorStatus($pagina,'descadastrados');
	}

	private function obterPorStatus($pagina='1', $status) {
		$url = "http://{$this->hostName}.{$this->hostNameSufix}/admin" .
				"/api/{$this->login}/contatos/{$status}?chave={$this->chave}&pagina={$pagina}";

		$resultado = $this->emktCore->enviaRequisicao($url);
		if($resultado==null) {
			return null;
		}
		$resultado = json_decode($resultado);
		if($resultado===null) {
			throw new Exception('Erro ao transformar em JSON.');
		}

		return $resultado;
	}

	public function setEmktCore($emktCore) {
		$this->emktCore = $emktCore;
	}
}
?>