# w - write
# r - read
# a - append (zachowuje stan pliku dopisuje na końcu)
# r+ , w+ , a+ - write and read itp
# wb/rb - zapis binarny/odczyt binarny
# x - jak plik istnieje error

file1 = open('files/new.txt', mode="r")

print(file1.read())

file1.close()

file2 = open('files/new.txt', mode="r")

line = file2.readline()

while line:
    print("t", line)
    line = file2.readline()

print(file2.readline())

file2.close()

file3 = open('files/new.txt', mode="r")

print(file3.readlines())

file3.close()

try:
    file4 = open('files/nima.txt', mode="r")
except IOError:
    print("Nie ma takiego pliku")

with open('files/write.txt', mode="w") as file:
    file.write("a")
    pass

try:
    with open("files/fname.txt", "x") as fout:
        print("nie ma")
except FileExistsError:
        print("jest")