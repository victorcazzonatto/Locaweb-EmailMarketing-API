<?php
//require_once 'PHPUnit/Framework.php';
require_once dirname(__FILE__).'/../src/RepositorioContatos.php';

class TestRepositorioContatos extends PHPUnit_Framework_TestCase {

	function testObterValidos() {
		$mock = $this->getMockObject('RepositorioContatos',array('obterValidos'));
        $mock->bar();

//		$mock = $this->getMockObject('RepositorioContatos');
//		$mock->__expectAtLeastOnce('obterValidos');
//		$mock->obterValidos();
		//$repositorio = new RepositorioContatos("", "", "");
	}

}
?>