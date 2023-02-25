class DivideByZeroException(Exception):
    pass

try:
    x = 5
    y = 0
    if(y == 0) raise: DivideByZeroException
except DivideByZeroException:
    print("Nie dzielimy przez zero")
except Exception:
    print("coś")
finally:
    print("Koniec try'a")