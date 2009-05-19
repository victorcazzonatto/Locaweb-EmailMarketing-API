<?php
class EmktCore {

	static function enviaRequisicao($url) {
		$curl = curl_init();
		curl_setopt($curl, CURLOPT_URL, $url);
		curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
		$resultado_http = curl_exec($curl);
		$http_code = curl_getinfo($curl, CURLINFO_HTTP_CODE);
		curl_close($curl);

		if ($http_code != '200') {
			throw new Exception("Erro inesperado: statusCode:$http_code, mensagem:$resultado_http");
		}

		return $resultado_http;
	}
}
?>
