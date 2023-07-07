# import functools
# import functools as fnt
# from functools import reduce
from functools import reduce as re
# from functools import * <- tak nie robimy ale działa

napis1 = "    Tekst     "
napis2 = "patryk"
napis3 = "MAGDA"
napis4 = "Ala ma kota essa"
napis5 = '5'

print(napis2.upper())
print(napis3.lower())

print(napis4.replace("Ala", "Magda"))

tablica_napisu = napis4.split()

print(tablica_napisu)

print(napis1.isdigit())

print(napis5.isdigit())

print(napis1.isalpha())

print(napis5.isalpha())

print("-".join(napis3))  # rozdzielenie po każdym znaku

print(napis4.endswith(" essa"))

print(napis4.endswith("dessa"))

print(napis2.islower())

print(napis3.islower())

print(napis1[5:-3])

print()

### Są typy w pythonie jak w typescipt czy innych językach ###

print("Typy", "-"*20)


def sum(a: int, b: int) -> int:
    return a + b


sum(2, 2)

# map reduce filter

print("Map Filter Reduce", "-"*20)

list1 = [1, 2, 3, 4, 5, 6]

print(list(map(lambda x: x + 1, list1)))

print(list(filter(lambda x: x % 2, list1)))

print(re(lambda x, y: x + y, list1))  # reduce z importu

# list comprehensions

print("List comprehensions", "-"*20)

list2 = [el * 2 for el in list1]

print(list2)

more_complex_list = [('age', 72), ('weight', 80), ('height', 178)]

list3 = {key: value for (key, value) in more_complex_list}

print(list3)  # dictionary

list4 = [el * 2 for el in list1 if el % 3 == 0]

print(list4)

list5 = [el + 1 if el > 3 else el + 2 for el in list1]

print(list5)

# enumerate

values = ["Tak", "Nie", "Nie wiem"]

for values, idx in enumerate(values, 0):
    print(values, idx)

arr1 = [1, 2, 3]
arr2 = [1, 2, 3]

print(arr1 == arr2)
print(arr1 is arr2)
