funds = 69.2053

print("Funds: {:f}".format(funds))

print("Funds: {:.1f}".format(funds))

# jak nie ma 10 cyfr to puste znaki będą
print("Funds: {:10.1f}".format(funds))

print("Funds: {:>15.1f}".format(funds))

print("Funds: {:<15.1f}".format(funds))

print("Funds: {:^15.1f}".format(funds))

print("Funds: {:-^15.1f}".format(funds))

print('I\'am Patrick')  # wiadomo te same znaki do ciagów

print(f"Funds: {funds:.2f}")

match funds:
    case 69.2053:
        print(True)
    case 0:
        print(False)
    case _:
        print("ee?")


def avrage(*args):
    return sum(args) / len(args)


print(avrage(5, 10, 2, 3, 5))

my_style = "goth" if True else "emo"  # jak w C# :>

print(my_style)

my_array = [1, 2, 5, 7, 10]

if 5 in my_array:
    print(True)

if not 5 in my_array:
    print(True)
else:
    print(False)

languages = ['Java', 'Python', 'JavaScript']
versions = [14, 3, 6]

res = zip(languages, versions)  # Łączy po indeksach w obiekty typu tuple

# print(list(res))  # list() przeabia typ danych w liste

# for e in list(res): # po tuplach
#    print(e)

# for k, i in dict(res).items(): # po itemach, dict() zamienia na słownik
#    print(k, i)


def donothing():
    pass


def todosmth(a=5):
    return a ** 2


print(todosmth())

print(todosmth(2))

x = 5


def chagneGlobalVar1():
    x = 10


chagneGlobalVar1()

print(x)


def chagneGlobalVar2():
    global x
    x = 10


chagneGlobalVar2()

print(x)

for i in range(1, 10, 2):
    print(i)
