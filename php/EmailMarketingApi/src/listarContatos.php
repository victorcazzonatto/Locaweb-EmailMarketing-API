<?php
	error_reporting(E_ALL);
	require_once dirname(__FILE__).'/RepositorioContatos.php';

	// Esses valores podem ser obtidos na página de configurações do Email Marketing
	$hostName = '';
	$login 	  = 'gustavo';
	$chaveApi = 'e538ea19267cfdb98f423209419ff77c';
	$repositorio = new RepositorioContatos($hostName, $login, $chaveApi);

	print "\ncontatos validos\n";
	for($pagina=1; $contatos = $repositorio->obterValidos($pagina); $pagina++) {
		foreach($contatos as $contato) {
			//caso necessite de outros campos do contato, utilizar o print_r($contato) para visualizar os campos disponiveis;
			print "email: {$contato->email}|nome: {$contato->nome}|" .
					"datanasc: {$contato->datadenascimento}| estado: {$contato->estado}\n";
		}
	}
?>