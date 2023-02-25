arr1 = [1, 2, 3]

arr2 = [1, 2, 3]

arr3 = arr1

print(arr1 == arr2, arr1 == arr3)  # true true

print(arr1 is arr2, arr1 is arr3)  # false true

print(arr1 == arr2 and arr1 == arr3)  # true

print(arr1 is arr2 or arr1 is arr3)  # true

_ = 5  # podłoga to poprawna zmienna xD

print(_)

### Tuple ###

print("Tuple", "-"*20)

# tuple są nie mutowalne czyli nie można edytować ich zawartości

tuple1 = 1, 2, 3

tuple2 = (1, 2, 3)

print(tuple1[2], tuple2[2])

print(tuple1, tuple2)

# tuple[2] = 4 TAK NIE MOŻNA, BRAK MOŻLIWOŚCI EDYCJI

# tupla z jednym elementem

tuple3 = (1,)

print(tuple3)

# zamiana na tuple

print(tuple(arr1))

# wyciąganie do zmiennych

a, b, c = tuple(arr1)

print(a, b, c)

# i wiele innych metod, nie ma co się uczyć na pamke jest dokumentacja elo

### Listy ###

print("Listy", "-"*20)

lists = [1, 2, 3]

lists2 = list(tuple1)

print(lists[2], lists2[2])

lists[2] = 4
lists.append(3)

print(lists[-1], lists)  # -1 od tyłu etc. -1 -2 -3

# sortowanie

lists.sort()

print(lists)

lists.reverse()

a, b, c, d = lists

print(a, b, c, d)

new_list = lists[1:3]

print(new_list)

new_list2 = lists[:]

# wiadomo bo python sprawdza zawartość nie czy to ten sam obj
print(new_list2 == lists)

print(new_list2 is lists)  # nie jest to ten sam obj :>

# i wiele innych metod, nie ma co się uczyć na pamke jest dokumentacja elo
