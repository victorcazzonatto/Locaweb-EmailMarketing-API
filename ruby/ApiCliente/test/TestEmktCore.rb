require '../lib/EmktCore'
require 'test/unit'
require 'mocha'

class TestEmktCore < Test::Unit::TestCase
  
  def test_envia_requisicao_nao_deve_lancar_runtimeException_se_codigo_http_igual_a_200
    resposta = stub(:code => '200', :code => '200', :body => 'Resposta')
    URI.expects(:parse).with('').returns('')
    Net::HTTP.expects(:get_response).with('').returns(resposta)
    assert_equal 'Resposta', EmktCore::envia_requisicao('')
  end
  
  def test_envia_requisicao_deve_lancar_runtimeException_se_codigo_http_diferente_de_200
    resposta = stub(:code => '404')
    URI.expects(:parse).with('').returns('')
    Net::HTTP.expects(:get_response).with('').returns(resposta)
    assert_raise(RuntimeError) { EmktCore::envia_requisicao('') }
  end
  
end