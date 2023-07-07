from oop2 import Nothing
import copy

### self może byc inaczej nazwany to tylko konwencja ###


class Position(Nothing):
    # class attributes nie tylko dla obiektu a dla całej klasy
    x = 0
    y = 0

    def __init__(self, mess="t", z=0):
        super().__init__(mess)  # tutaj parametry dla super czyli konstruktor rodzica
        self.z = z
        self.__z2 = z  # __ powodują prywatne pole
        pass

    def get(self):
        return (self.x, self.y)


point = Position()

print(point.get())

Position.x = 1
Position.y = 1

print(point.get())

arr1 = [1, 2, 3, 4]
arr2 = [1, 2, 3, 4, 5, 6]

arr3 = copy.copy(arr1)
arr4 = copy.deepcopy(arr2)
arr5 = arr2[1:-2]

print(arr3 is arr1)
print(arr4 is arr2)
print(arr5 is arr2)

p1 = Position()
p2 = Position()

p3 = copy.copy(p1)
p4 = copy.deepcopy(p2)

print(p3 is p1)
print(p4 is p2)
