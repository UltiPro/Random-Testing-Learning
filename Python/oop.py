### self może byc inaczej nazwany to tylko konwencja ###

class Position:
    # class attributes nie tylko dla obiektu a dla całej klasy
    x = 0
    y = 0

    def __init__(self, z = 0):
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