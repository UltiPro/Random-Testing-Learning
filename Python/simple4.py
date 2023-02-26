### Słowniki ###

print("Słowniki", "-"*20)

dictionary = {
    "jan": "wasilewski",
    "patryk": "wójtowicz",
    "jebac": "pis"
}

print(dictionary["jebac"])

print(dictionary)

print(dict([(1, 1), (2, 2)]))

for i in dictionary:  # iteruje po kluczach
    print(i)

# for i in dictionary.keys(): to samo co wyżej
#     print(i)

for i in dictionary.values():
    print(i)

for k, v in dictionary.items():
    print(k, v)

# jeżeli nie istnieje to go doda a jak istnieje to go zwróci
dictionary.setdefault("wasilewski", "jan")

print(dictionary)

dictionary.pop("wasilewski")

print(dictionary)

dictionary.popitem()

print(dictionary)

# i wiele innych metod, nie ma co się uczyć na pamke jest dokumentacja elo

### Zbiory ###

# niepowtarzalne wartości posortowane automatycznie, albo nie utrzymujące kolejności (dla obj)

print("Zbiory - Sety", "-"*20)

settick = {"Jan", "Jan", "Patryk", "Pis"}

settick2 = set([1, 3, 3, 5, 2])

settick.add("Patryk")

print(settick, settick2)

# operatory zbiorów

zbior1 = {1, 2, 3, 4, 5}

zbior2 = {1, 3, 5, 6, 7, 8, 9}

print(zbior1 | zbior2)  # suma

print(zbior1.union(zbior2))

print(zbior1 & zbior2)  # część wspólna

print(zbior1.intersection(zbior2))

print(zbior1 ^ zbior2)  # część nie wspólna

print(zbior1.symmetric_difference(zbior2))

print(zbior1 - zbior2)  # różnica

print(zbior1.difference(zbior2))




# jest jeszcze .update() .extend()




# sety nie posiadają operatora [:] 

### funckja jako parametr , może być też domyślnym parametrem ###

def cosiek():
    print("dupa")


def fun1(fun=cosiek):
    fun()
    pass


fun1(cosiek)
fun1()
