<?php
	error_reporting(E_ALL);
	require_once dirname(__FILE__).'/EmailMkt.php';

	// Esses valores podem ser obtidos na página de configurações do Email Marketing.
	// página wiki.
	$hostName = "testelmm";
	$login = 'gustavo';
	$chaveApi = 'e538ea19267cfdb98f423209419ff77c';
	$emkt = new EmailMkt($hostName, $login, $chaveApi);

	print "\ncontatos validos\n";

	try{
		for($pagina=1; $contatos = $emkt->retornaContatosValidos($pagina); $pagina++) {
			foreach($contatos as $contato) {
				//print_r($contato);
				print "email: {$contato->email}|nome: {$contato->nome}|" .
						"datanasc: {$contato->datadenascimento}| estado: {$contato->estado}\n";
			}
		}
	}catch(Exception $e){
		print "Erro ao chamar a API: {$e->getMessage()}\n";
		exit;
	}
?>
