<?php
class EmktCore {

	function enviaRequisicao($url) {
		$curl = curl_init();
		curl_setopt($curl, CURLOPT_URL, $url);
		curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
		$resultado_http = curl_exec($curl);
		$http_code = curl_getinfo($curl, CURLINFO_HTTP_CODE);
		curl_close($curl);

		$this->validaCodigoHttp($http_code);

		return $resultado_http;
	}

	function validaCodigoHttp($http_code) {
		if(empty($http_code)) {
			throw new Exception("Erro inesperado, falta algum parametro na url ou algum problema na rede.");
		}

		if ($http_code != '200') {
			throw new Exception("Erro inesperado: statusCode:$http_code, mensagem:$resultado_http");
		}
	}
}
?>
