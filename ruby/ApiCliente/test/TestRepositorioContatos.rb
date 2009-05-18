require '../lib/RepositorioContatos'
require '../lib/EmktCore'
require 'test/unit'
require 'mocha'

class TestRepositorioContatos < Test::Unit::TestCase
  
  def setup
      @repositorio = RepositorioContatos.new('emktHost', 'gustavo', 'e538ea19267cfdb98f423209419ff77c')
      @url = 'http://emktHost.locaweb.com.br/admin/api/gustavo/contatos/teste?chave=e538ea19267cfdb98f423209419ff77c&pagina=1'
  end
        
  def test_obter_contatos_url_deve_ser_valida
    EmktCore.expects(:envia_requisicao).with(@url).returns("")
    @repositorio.obter_contatos(1, 'teste')
  end
  
  def test_obter_contatos_url_deve_ser_valida_se_numero_de_pagina_for_negativo_ou_0
    EmktCore.expects(:envia_requisicao).with(@url).returns("")
    @repositorio.obter_contatos(-1, 'teste')
    EmktCore.expects(:envia_requisicao).with(@url).returns("")
    @repositorio.obter_contatos(0, 'teste')
  end
  
  def test_obter_contatos_espera_um_retorno_em_branco_do_ws
    EmktCore.expects(:envia_requisicao).with(@url).returns("")
    assert_nil @repositorio.obter_contatos(1, 'teste')
  end
  
  def test_obter_contatos_deve_retornar_um_objeto_contato_valido
    resultado_ws = '[{"email":"xconta4@testecarganl.tecnologia.ws","nome":"nome1","htmlemail":"1"}]'
    EmktCore.expects(:envia_requisicao).with(@url).returns(resultado_ws)
    contatos =  @repositorio.obter_contatos(1, 'teste')
    assert_equal 1, contatos.size
    assert_equal 'xconta4@testecarganl.tecnologia.ws', contatos[0].email
    assert_equal 'nome1', contatos[0].nome
    assert_equal '1',contatos[0].htmlemail
  end
  
  def test_obter_contatos_Json_parserError_esperada
    resultado_ws = 'Parse invalido'
    EmktCore.expects(:envia_requisicao).with(@url).returns(resultado_ws)
    assert_raise(JSON::ParserError) {@repositorio.obter_contatos(1, 'teste')}
  end
  
  def test_obter_contatos_lanca_uma_expetion_de_rede_ou_http
    EmktCore.expects(:envia_requisicao).with(@url).raises(Exception)
    assert_raise(Exception) {@repositorio.obter_contatos(1, 'teste')}
  end
    
end