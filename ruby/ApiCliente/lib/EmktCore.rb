require 'net/http'

class EmktCore
  
   def self.envia_requisicao(url)
    resposta = Net::HTTP.get_response(URI.parse(url))
    raise "Não foi possível obter contatos: erro http #{resposta.code}" unless resposta.code=='200'
    resposta.body
  end
  
end