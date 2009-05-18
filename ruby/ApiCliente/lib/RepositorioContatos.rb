require 'json'

class RepositorioContatos
  
  def initialize(host_name, login, chave)
    @host_name = host_name
    @login = login
    @chave = chave
  end
  
  def obter_validos(pagina)
    obter_contatos(pagina,  "validos")
  end
  
  def obter_contatos(pagina, status)
    pagina = 1 unless pagina > 0
    url = 	"http://#{@host_name}.locaweb.com.br/admin/api/#{@login}/contatos/#{status}?chave=#{@chave}&pagina=#{pagina}";
		#url = "http://testelmm.tecnologia.ws/admin/api/#{@login}/contatos/#{status}?chave=#{@chave}&pagina=#{pagina}"
    resposta = EmktCore::envia_requisicao(url)
    return nil if resposta == "" 
    JSON.parse(resposta)
  end
  
end