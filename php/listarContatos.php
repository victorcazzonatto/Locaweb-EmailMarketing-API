<?php
/**
 *  Copyright (c) 2009, Locaweb LTDA.
 * 	Todos os direitor reservados.
 *
 *  Este � um c�digo exemplo de como utilizar a API do Email Marketing.
 *
 * @version 1.0
 * @see http://wiki.locaweb.com.br/pt-br/APIs_do_Email_Marketing
 */

	error_reporting(E_ALL);
	require_once dirname(__FILE__).'/EmailMkt.php';

	// Esses valores podem ser obtidos na p�gina de configura��es do Email Marketing
	$hostName = 'testelmm';
	$login 		= 'gustavo';
	$chaveApi = 'e538ea19267cfdb98f423209419ff77c';
	$emkt 		= new EmailMkt($hostName, $login, $chaveApi);

	print "\ncontatos validos\n";

	try{
		for($pagina=1; $contatos = $emkt->retornaContatosValidos($pagina); $pagina++) {
			foreach($contatos as $contato) {
				//caso necessite de outros campos do contato, utilizar o print_r($contato) para visualizar os campos disponiveis;
				print "email: {$contato->email}|nome: {$contato->nome}|" .
						"datanasc: {$contato->datadenascimento}| estado: {$contato->estado}\n";
			}
		}
	}catch(Exception $e){
		print "Erro ao chamar a API: {$e->getMessage()}\n";
		exit;
	}
?>
