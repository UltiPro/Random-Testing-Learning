print("Hello world")

# komentarze


def GetString():
    return str(input("Podaj tekst"))


def GetInt():
    local_scope = input("Podaj liczbe")
    return int(local_scope)  # bez obsługi błędów


def GetFloat():
    return float(input("Podaj liczbe"))  # bez obsługi błędów

# print(GetString())

# print(GetInt())

# print(GetFloat())


# są to listy a nie tablice tak w gwoli ścisłości
new_list = [2, 4, "tekst", 1_000_000]

new_list.append(2_000_000)

print(new_list.pop())  # pop zwraca element tak jak w wielu językach xd

# print(newlist[-2]) #indeksy od tyłu

print("-"*20)  # powtarzanie stringów string * string nie zadziała

print(5 / 2)  # dzielenie na float

print(5 // 2)  # dzielenie całkowite

print(5 ** 2)  # 5 do potęgi 2

print(5 % 2)  # modulo ofc

print(0.4 - 0.1)  # wiadomo system zapisu liczb 2 :> -> 0.30...4

"""
elo komentarzyk blokowy 
essa
"""

for i in range(1, 5):  # 1 do 4
    if i == 2:
        continue  # skok jednej iteracji (continue) dalej wykonuje pętle
    print(i)
    # break # blokuje wykonanie się else dla pętli
else:
    print("koniec pentli for")  # zawsze na koniec pętli się wykona

ster = 2

while (ster):
    ster -= 1
    print("True")
    break  # blokuje wykonanie się else dla pętli
else:
    print("koniec pentli while")  # zawsze na koniec pętli się wykona


def fun1():
    """
        Args:
            NONE

        Params:
            NONE
    """
    print("test")
    return None

# fun1()


print("tekst 1 ", "tekst 2", "\ntekst 3")

""" num = int(input("Liczba: "))

if num == 2:
    print(2)
elif num == 3:
    print(3)
else:
    print('nic') """

print("Strings {} be {}".format("can", "insertable"))

print("Strings {1} be {0}".format("insertable", "can"))

print("Strings {var1} be {var2} , number {var3:d}".format(var2="insertable", var1="can", var3 = 69)) # :d :s jak w c
