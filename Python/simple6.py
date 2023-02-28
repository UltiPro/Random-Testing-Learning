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
