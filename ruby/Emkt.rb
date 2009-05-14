require 'net/http'
require 'json'


class Emkt
  
  def initialize(host_name, login, chaveApi)
    @host_name = host_name
    @login = login
    @chaveApi = chaveApi
  end
  
  def retornaContatos(pagina='1')
    #url = 	"http://#{@host_name}.locaweb.com.br/admin/api/#{@login}/contatos?chave_api=#{@chaveApi}&pagina=#{pagina}";
		url = URI.parse("http://testelmm.tecnologia.ws/admin/api/#{@login}/contatos?chave_api=#{@chaveApi}&pagina=#{pagina}")
    resposta = enviaRequisicao(url)
    return nil if resposta.nil?
    resposta = JSON.parse(resposta)
    resposta['contatos']
  end
  
private

  def enviaRequisicao(url)
    resposta = Net::HTTP.get_response(url)
    #Net::HTTPNotFound
    resposta.code == '404'  ? nil : resposta.body
  end
  
end