require 'net/http'
require 'json'


class RepositorioContatos
  
  def initialize(host_name, login, chave)
    @host_name = host_name
    @login = login
    @chave = chave
  end
  
  def obtemValidos(pagina)
    pegaContatos(pagina,  "validos")
  end
  
  def obtemContatos(pagina, status)
    #url = 	"http://#{@host_name}.locaweb.com.br/admin/api/#{@login}/contatos?chave_api=#{@chaveApi}&pagina=#{pagina}";
		url = URI.parse("http://testelmm.tecnologia.ws/admin/api/#{@login}/contatos/#{status}?chave=#{@chave}&pagina=#{pagina}")
    resposta = enviaRequisicao(url)
    return nil if resposta == "" 
    resposta = JSON.parse(resposta)
    resposta
  end
  
private

  def enviaRequisicao(url)
    resposta = Net::HTTP.get_response(url)
    raise "Não foi possível obter contatos: erro http #{resposta.code}" unless resposta.code=='200'
    resposta.body
  end
  
end