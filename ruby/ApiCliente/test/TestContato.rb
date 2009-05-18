require '../lib/Contato'
require 'test/unit'

class TestContato < Test::Unit::TestCase
  
  def test_contatos
    hash_atributos = {'a' => 'b',  'c' => 'd'}
    c = Contato.new(hash_atributos)
    assert_equal 'b', c.a
    assert_equal 'd', c.c
  end
    
end