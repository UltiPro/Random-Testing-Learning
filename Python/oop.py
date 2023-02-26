from oop2 import Nothing

### self może byc inaczej nazwany to tylko konwencja ###

class Position(Nothing):
    # class attributes nie tylko dla obiektu a dla całej klasy
    x = 0
    y = 0

    def __init__(self, mess = "t", z = 0):
        super().__init__(mess) # tutaj parametry dla super czyli konstruktor rodzica
        self.z = z
        self.__z2 = z # __ powodują prywatne pole
        pass

    def get(self):
        return (self.x, self.y)

point = Position()

print(point.get())

Position.x = 1
Position.y = 1

print(point.get())