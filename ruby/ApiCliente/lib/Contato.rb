class Contato  
  
  def initialize(hash_atributos)
    @hash_atributos = hash_atributos
  end
  
  def method_missing(metodo)
    @hash_atributos[metodo.to_s]
  end
  
end