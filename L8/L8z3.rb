class Jawna
    def initialize(napis) @napis = napis end
    def zaszyfruj(klucz) Zaszyfrowane.new @napis.chars.map(& ->(c){klucz.fetch(c, c)}).join() end
    def to_s() @napis end
end

class Zaszyfrowane < Jawna
    undef_method :zaszyfruj
    def odszyfruj(klucz) Zaszyfrowane.new @napis.chars.map(& ->(c){klucz.invert.fetch(c,c)}).join() end
end

str = Jawna.new 'asldglwd ndqwyd 121293'
klucz = {'a'=>'7', 'w'=>'#'}
puts str
puts str.zaszyfruj(klucz)
puts str.zaszyfruj(klucz).odszyfruj(klucz).to_s == str.to_s