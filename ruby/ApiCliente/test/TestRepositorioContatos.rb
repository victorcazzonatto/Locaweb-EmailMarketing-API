File.join(File.dirname(__FILE__), "..", "lib")
require 'RepositorioContatos'
require 'test/unit'

class TestRepositorioContatos < Test::Unit::TestCase
  
  def test_simple
    login = 'gustavo'
    chave_api = 'e538ea19267cfdb98f423209419ff77c'
    rc = RepositorioContatos.new('', login,  chave_api )
    pagina = 1
    contatos = rc.obterValidos(pagina)
  end
  
end