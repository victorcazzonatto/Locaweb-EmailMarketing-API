require 'Emkt'

login = 'gustavo'
chave_api = 'e538ea19267cfdb98f423209419ff77c'
emkt = Emkt.new('', login,  chave_api );
pagina = 1
while(contatos = emkt.retornaContatos(pagina))
  contatos.each{ |contato|
    puts contato['email']
    puts contato['nome']
  }
  pagina+= pagina  
end