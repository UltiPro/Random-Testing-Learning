funds = 69.2053

print("Funds: {:f}".format(funds))

print("Funds: {:.1f}".format(funds))

print("Funds: {:10.1f}".format(funds)) # jak nie ma 10 cyfr to puste znaki będą

print("Funds: {:>15.1f}".format(funds))

print("Funds: {:<15.1f}".format(funds))

print("Funds: {:^15.1f}".format(funds))

print("Funds: {:-^15.1f}".format(funds))

print('I\'am Patrick') # wiadomo te same znaki do ciagów

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

print(avrage(5,10,2,3,5))

my_style = "goth" if True else "emo" # jak w C# :>

print(my_style)

my_array = [1, 2, 5, 7 ,10]

if 5 in my_array:
    print(True)

if not 5 in my_array:
    print(True)
else:
    print(False)