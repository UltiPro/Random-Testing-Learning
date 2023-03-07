import queue
from collections import deque


class DivideByZeroException(Exception):
    message = "źle lol"


try:
    x = 5
    y = 0
    if (y == 0):
        raise DivideByZeroException("tekst")
    if (x == 5):
        raise Exception()
except DivideByZeroException as e:
    print("Nie dzielimy przez zero. "+e.message)
except Exception:
    print("coś")
finally:
    print("Koniec try'a - finally")
# except:  # nie robimy tego nie wszystko warto obsługiwać
#    print("dla wszystkich innych")


### stringi nie mogą być edytowane poprzez index ###

string = "dupa"

# string[2] = 'c' ### ERROR

q = queue.Queue()

q.put("tak")

q.put("nie")

q.put("tak 2")

print(q.get())

q2 = deque(["Tak", "Nie", "Osiem"])

print(q2.pop())

f1 = frozenset(["Tak","Tak","Nie"])

print(f1)

### string

stringek = "     Dupa    jakaś    "

print(stringek.strip())

print(stringek.find("Dupa"))

del(stringek) # usuwa całkowicie zmienną (obiekt)

### print(stringek)

print(all([True,True,False,True]))

print(all([True,True,True,True]))

print(any([True,True,False,True]))

print(any([False,False,False,False]))