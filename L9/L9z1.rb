class Funkcja < Proc
    private

    @@steps = 100000
    def sgn(x) x <=> 0.0 end

    public
    
    def value(x) call(x) end

    # Durand-Kerner
    def zerowe(a, b, e) 
        x = []
        while(a + e <=b)
            if sgn(value(a)) != sgn(value(a+e)) then x << (a+e/2.0) end
            a += e
        end
        return x
    end

    def pole(a, b)
        delta = Float(b-a)/@@steps
        area = 0
        @@steps.times do
            area += delta * value(a+delta/2.0) # middle of range
            a += delta
        end
        return area
    end
        
    def poch(x) (value(x+1.0e-10)-value(x))/1.0e-10 end

    def draw(a, b)
        xy_for_gnuplot = "#X\t#Y\n"
        delta = Float(b-a)/@@steps
        @@steps.times {|i| xy_for_gnuplot << "#{a + i*delta}\t#{value(a+ i*delta)}\n"}
        return xy_for_gnuplot
    end
end

f = Funkcja.new {|x| Math.sin(x)}
puts "value #{f.value(Math::PI)}"
puts "roots #{f.zerowe(-2*Math::PI, 2*Math::PI, 1.0e-5)}"
puts "area #{f.pole(0, Math::PI)}"
puts "deriv #{f.poch(0.8)}" # 69 hehe
puts f.draw(-1, 1)