<?php
require_once 'PHPUnit/Framework.php';
require_once dirname(__FILE__).'/../src/EmktCore.php';


class TestEmktCore extends UnitTestCase {

	function testEnviaRequisicaoRequisicaoDeveSerValida() {
		print "Passou aqui";
		$url = "http://testelmm.tecnologia.ws/admin/api/gustavo/contatos/validos?chave=e538ea19267cfdb98f423209419ff77c&pagina=1";
		EmktCore::enviaRequisicao($url);
		print "Passou aqui 2";
		$this->assertTrue(true);
	}
}
?>
