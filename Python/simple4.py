### Słowniki ###

print("Słowniki", "-"*20)

dictionary = {
    "jan": "wasilewski",
    "patryk": "wójtowicz",
    "jebac": "pis"
}

print(dictionary["jebac"])

print(dictionary)

print(dict([(1,1),(2,2)]))

for i in dictionary: # iteruje po kluczach
    print(i)

# for i in dictionary.keys(): to samo co wyżej 
#     print(i)

for i in dictionary.values():
    print(i)

for k, v in dictionary.items():
    print(k ,v)

# i wiele innych metod, nie ma co się uczyć na pamke jest dokumentacja elo

### Zbiory ###

# niepowtarzalne wartości posortowane automatycznie, albo nie utrzymujące kolejności (dla obj)

print("Zbiory - Sety", "-"*20)

settick = {"Jan", "Jan", "Patryk", "Pis"}

settick2 = set([1,3,3,5,2])

settick.add("Patryk")

print(settick, settick2)

#operatory zbiorów

zbior1 = {1,2,3,4,5}

zbior2 = {1,3,5,6,7,8,9}

print(zbior1 | zbior2) # suma

print(zbior1 & zbior2) # część wspólna

print(zbior1 ^ zbior2) # część nie wspólna

print(zbior1 - zbior2) # różnica