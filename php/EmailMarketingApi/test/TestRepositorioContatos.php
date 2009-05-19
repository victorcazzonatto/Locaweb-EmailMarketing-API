<?php
require_once 'PHPUnit/Framework.php';
require_once dirname(__FILE__) . '/../src/RepositorioContatos.php';
error_reporting(E_ALL);

class TestRepositorioContatos extends PHPUnit_Framework_TestCase {

	private $emktCoreMock;

	private $repositorio;

	private $urlEsperada;

	public function setUp() {
		$this->emktCoreMock = $this->getMock("EmktCore");
		$this->repositorio = new RepositorioContatos("test", "gustavo", "e538ea19267cfdb98f423209419ff77c");
		$this->urlEsperada = "http://test.locaweb.com.br/admin/api/gustavo/contatos/validos?chave_api=e538ea19267cfdb98f423209419ff77c&pagina=1";
	}

	function testObterValidosUrlValida() {

		$this->emktCoreMock->expects($this->once())->method('enviaRequisicao')->with($this->urlEsperada);
		$this->repositorio->setEmktCore($this->emktCoreMock);
		$this->repositorio->obterValidos(1);
	}

	function testObterValidosDeveRetornarNull() {
		$this->emktCoreMock->expects($this->once())->method('enviaRequisicao')->with($this->urlEsperada);
		$this->repositorio->setEmktCore($this->emktCoreMock);
		$this->assertNull($this->repositorio->obterValidos(1));
	}

	function testObterValidosDeveRetornarUmContatoValido() {
		$respostaMock = '[{"email":"xconta4@testecarganl.tecnologia.ws","nome":"nomeTeste"}]';
		$this->emktCoreMock->expects($this->once())->method('enviaRequisicao')->with($this->urlEsperada)->will($this->returnValue($respostaMock));
		$this->repositorio->setEmktCore($this->emktCoreMock);
		$contatos = $this->repositorio->obterValidos(1);
		$this->assertEquals(1, count($contatos));
		$this->assertEquals('xconta4@testecarganl.tecnologia.ws', $contatos[0]->email);
		$this->assertEquals('nomeTeste', $contatos[0]->nome);
	}

	function testObterValidosDeveLancarUmaExcecaoComErroDeParseNoJson() {
		$respostaMock = '[{"a":"b}]';
		$this->emktCoreMock->expects($this->once())->method('enviaRequisicao')->with($this->urlEsperada)->will($this->returnValue($respostaMock));
		$this->repositorio->setEmktCore($this->emktCoreMock);
		try {
			$contatos = $this->repositorio->obterValidos(1);
			$this->assertFail();
		} catch (Exception $e){
			$this->assertTrue(true);
		}
	}

}
?>