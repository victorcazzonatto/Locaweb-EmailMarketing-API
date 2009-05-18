require 'json'
require File.join(File.dirname(__FILE__), 'EmktCore')

 # Copyright (c) 2009, Locaweb LTDA. Todos os direitor reservados.
 #
 # Está é uma API exemplo que facilita a utilização do web services de Contatos.
 #
 # Os métodos de listagem possuem o parâmetro página. Ele informa qual página da
 # pesquisa deve ser retornada. Atualmente o limite de contatos por página é de
 # 25mil contatos por página. Exemplo, caso tenha 40mil contatos em sua base
 # precisará fazer 2 chamadas passando o parâmetro pagina=1 (que devolverá os
 # contatos de 1 a 24999) e em seguida pagina=2 (que devolverá os contatos de
 # 25000 a 40000)
 # version 0.1
 # see http://wiki.locaweb.com.br/pt-br/APIs_do_Email_Marketing
class RepositorioContatos
  
  def initialize(host_name, login, chave)
    @host_name = host_name
    @login = login
    @chave = chave
  end
  
	def obter_validos(pagina)
    obter_contatos(pagina,  "validos")
  end
  
  def obter_invalidos(pagina)
    obter_contatos(pagina,  "invalidos")
  end
  
  def obter_descadastrados(pagina)
    obter_contatos(pagina,  "descadastrados")
  end
  
  def obter_nao_confirmados(pagina)
    obter_contatos(pagina,  "nao_confirmados")
  end
  
  def obter_contatos(pagina, status)
    pagina = 1 unless pagina > 0
    #url = 	"http://#{@host_name}.locaweb.com.br/admin/api/#{@login}/contatos/#{status}?chave=#{@chave}&pagina=#{pagina}";
		url = "http://testelmm.tecnologia.ws/admin/api/#{@login}/contatos/#{status}?chave=#{@chave}&pagina=#{pagina}"
    resposta = EmktCore::envia_requisicao(url)
    return nil if resposta == "" 
    JSON.parse(resposta)
  end
  
end