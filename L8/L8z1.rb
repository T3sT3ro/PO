class Fixnum
    def czynniki
        t = [1]
        for i in 2..self
            if self%i == 0
                t << i
            end
        end
        return t
    end

    def ack(m)
        if self == 0 
            return m+1
        elsif m == 0
            return (self-1).ack(1)
        else
            return (self-1).ack(self.ack(m-1))
        end
    end

    def doskonala
        return self == self.czynniki.sum - self
    end

    def slownie
        t = ['zero', 'jeden', 'dwa', 'trzy', 'cztery', 'pięć', 'sześć', 'siedem', 'osiem', 'dziewięć', 'dziesięć']
        return self.to_s.chars.map(&:to_i).map(& ->(x){t[x]}).join(" ")
    end


end

puts 24.czynniki.inspect
puts 24.slownie
puts 12338.slownie
puts 28.doskonala
puts 23.doskonala
puts 3.ack(4)
puts 2.ack(1)

k = {'a' => 'z'}
puts k['a']
puts k.has_key? 'a'
puts k.has_key? 'b'