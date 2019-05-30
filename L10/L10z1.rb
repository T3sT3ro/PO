class Kolekcja
    private
    @size
    @begin
    @end
    
    class Node
        public
        @val
        @prev
        @next
        
        def initialize(_val, _prev=nil, _next=nil)
            @val = _val
            @prev = _prev
            @next = _next
        end

        def val() return @val        end
        def next() return @next         end
        def prev() return @prev         end

        def val=(v)             @val = v         end
        def next=(v)             @next = v         end
        def prev=(v)             @prev = v         end
    end
    
    public 

    def find(i)
        n = @begin.next
        i.times {n = n.next}
        return n
    end

    def initialize
        @begin = Node.new(nil)
        @end = Node.new(nil)
        @size = 0
        @begin.next = @end
        @end.prev = @begin
    end

    def length() @size end

    def get(x) 
        if x < 0 or x >= length 
            return nil 
        end
        
        n = find(x)
        return n.val
    end

    def append(v)
        n = Node.new(v, @end.prev, @end)
        @end.prev.next = n
        @end.prev = n
        @size += 1
    end

    def prepend(v)
        n = Node.new(v, @begin, @begin.next)
        @begin.next.prev = n
        @begin.next = n
        @size += 1
    end

    def first(v)
        if length() == 0 then             return nil         end
        return @begin.next.val
    end

    def last(v)
        if length() == 0 then             return nil         end
        return @end.prev.val
    end

    def popFront() 
        if length() == 0  then            return        end

        n = @begin.next
        @begin.next = n.next
        n.next.prev = @begin
    end

    def popBack() 
        if length() == 0 then            return        end

        n = @end.prev
        @end.prev = n.prev
        n.prev.next = @end
    end

    def swap(i, j)
        if i < 0 or j < 0 or i >= length() or j >= length() or i == j then             return
        end

        a = find(i)
        b = find(j)
        t = a.val
        a.val = b.val
        b.val = t
    end

    def to_s
        
        n = @begin.next
        s = ""
        @size.times do
            s += ",#{n.val.to_s}"
            n = n.next
        end
        return "[#{s[1,s.length]}]"
    end
end

class Sortowanie
    def sort1(dq) #bubble sort
        raise "Bad argument\n" unless dq.instance_of?(Kolekcja)
        for i in 0...dq.length - 1
            for j in 0...dq.length - i - 1
              if dq.get(j) > dq.get(j+1) then
                dq.swap(j, j+1)
              end
            end
          end
    end

    def sort2(dq) #insert sort
        raise "Bad argument\n" unless dq.instance_of?(Kolekcja)
        for i in 1...dq.length
            j = i
            while dq.get(j) < dq.get(j-1) and j>0
              dq.swap(j-1, j)
              j = j - 1
            end
          end
    end
end

class SKolekcja < Kolekcja 
    def append(x)
        super
        sort = Sortowanie.new
        sort.sort2(self)
    end

    def prepend(x)
        super
        sort = Sortowanie.new
        sort.sort2(self)
    end
end

class Wyszukaj 
    def szukaj(dq, x)
        raise "Bad argument\n" unless dq.instance_of?(Kolekcja)
        if dq.length == 0 then return nil end
        n = dq.find(0)
        while n != nil && n.val != x
            n = n.next # akcesor Noda więc OK
        end
        return n != nil && n.val == x
    end
end

kolekcja = Kolekcja.new
kolekcja.append(3)
kolekcja.append(8)
kolekcja.append(4)
kolekcja.append(1)
kolekcja.append(7)
kolekcja.append(1)
puts(kolekcja)

sort = Sortowanie.new
time1 = Time.now.to_f
sort.sort1(kolekcja)
time2 = Time.now.to_f
puts ('%.10f' % (time2 - time1))
puts(kolekcja)
w = Wyszukaj.new
puts(w.szukaj(kolekcja, 1))
puts(w.szukaj(kolekcja, 2))
