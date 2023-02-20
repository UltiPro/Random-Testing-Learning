print("Hello world")

# komentarze

def GetString():
    return input("Podaj tekst")

def GetInt():
    local_scope = input("Podaj liczbe")
    return int(local_scope) # bez obsługi błędów

def GetFloat():
    return float(input("Podaj liczbe"))  # bez obsługi błędów

# print(GetString())

# print(GetInt())

# print(GetFloat())

newlist = [2, 4, "tekst", 1_000_000] # są to listy a nie tablice tak w gwoli ścisłości

newlist.append(2_000_000)

print(newlist.pop()) # pop zwraca element tak jak w wielu językach xd

